using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Prague.Utils.Import
{
    public class Excel
    {
        public static List<ExpandoObject> GetSpreadsheetDataToExpando(string workSheet, string filePath)
        {
            List<ExpandoObject> data = new List<ExpandoObject>();

            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filePath, false))
            {
                // Get the worksheet we are working with
                IEnumerable<Sheet> sheets = spreadsheetDocument.WorkbookPart.Workbook.Descendants<Sheet>().Where(s => s.Name == workSheet);
                WorksheetPart worksheetPart = (WorksheetPart)spreadsheetDocument.WorkbookPart.GetPartById(sheets.First().Id);
                Worksheet worksheet = worksheetPart.Worksheet;
                SharedStringTablePart sstPart = spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
                SharedStringTable ssTable = sstPart.SharedStringTable;
                // Get the CellFormats for cells without defined data types
                WorkbookStylesPart workbookStylesPart = spreadsheetDocument.WorkbookPart.GetPartsOfType<WorkbookStylesPart>().First();
                CellFormats cellFormats = (CellFormats)workbookStylesPart.Stylesheet.CellFormats;

                ExtractRowsData(data, worksheet, ssTable, cellFormats);
            }

            return data;
        }


        /// <summary>
        /// Get the data using the first row as columns and the rest of the rows as data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="worksheet"></param>
        /// <param name="ssTable"></param>
        /// <param name="cellFormats"></param>
        private static void ExtractRowsData(List<ExpandoObject> data, Worksheet worksheet, SharedStringTable ssTable, CellFormats cellFormats)
        {
            var columnHeaders = worksheet.Descendants<Row>().First().Descendants<Cell>().Select(c => Convert.ToString(ProcessCellValue(c, ssTable, cellFormats))).ToArray();
            var columnHeadersCellReference = worksheet.Descendants<Row>().First().Descendants<Cell>().Select(c => c.CellReference.InnerText.Replace("1", string.Empty)).ToArray();
            var spreadsheetData = from row in worksheet.Descendants<Row>()
                                  where row.RowIndex > 1
                                  select row;

            foreach (var dataRow in spreadsheetData)
            {
                dynamic row = new ExpandoObject();
                Cell[] rowCells = dataRow.Descendants<Cell>().ToArray();
                for (int i = 0; i < columnHeaders.Length; i++)
                {
                    // Find and add the correct cell to the row object
                    Cell cell = dataRow.Descendants<Cell>().Where(c => c.CellReference == columnHeadersCellReference[i] + dataRow.RowIndex).FirstOrDefault();
                    ((IDictionary<String, Object>)row).Add(new KeyValuePair<String, Object>(columnHeaders[i], ProcessCellValue(cell, ssTable, cellFormats)));
                }
                data.Add(row);
            }
        }

        /// <summary>
        /// Process the valus of a cell and return a .NET value
        /// </summary>
        static Func<Cell, SharedStringTable, CellFormats, Object> ProcessCellValue = (c, ssTable, cellFormats) =>
        {
            if (c == null) return String.Empty; //force an empty value if the cell is null

            // If there is no data type, this must be a string that has been formatted as a number
            if (c.DataType == null)
            {
                if (c.StyleIndex == null) 
                    return c.CellValue.Text;
                
                CellFormat cf = cellFormats.Descendants<CellFormat>().ElementAt<CellFormat>(Convert.ToInt32(c.StyleIndex.Value));
                if (cf.NumberFormatId >= 0 && cf.NumberFormatId <= 13) // This is a number
                    return Convert.ToDecimal(c.CellValue.Text);
                else if (cf.NumberFormatId >= 14 && cf.NumberFormatId <= 22) // This is a date
                    return DateTime.FromOADate(Convert.ToDouble(c.CellValue.Text));
                else
                    return c.CellValue.Text;
            }

            switch (c.DataType.Value)
            {
                case CellValues.SharedString:
                    return ssTable.ChildElements[Convert.ToInt32(c.CellValue.Text)].InnerText;
                case CellValues.Boolean:
                    return c.CellValue.Text == "1" ? true : false;
                case CellValues.Date:
                    return DateTime.FromOADate(Convert.ToDouble(c.CellValue.Text));
                case CellValues.Number:
                    return Convert.ToDecimal(c.CellValue.Text);
                default:
                    if (c.CellValue != null)
                        return c.CellValue.Text;
                    return string.Empty;
            }
        };

    }
}
