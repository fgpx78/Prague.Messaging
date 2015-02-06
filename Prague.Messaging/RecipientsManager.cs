using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague.Messaging
{
    public class RecipientsManager
    {
        public static List<ExpandoObject> LoadRecipients()
        {
            var recipients = Prague.Utils.Import.Excel.GetSpreadsheetDataToExpando("Recipients", Configuration.RecipientListFile);
            return recipients;
        }
    }
}
