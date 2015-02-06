using Prague.Messaging.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague.Messaging
{
    public class NotFoundSubjectTemplateFileException : Exception
    {
        private string _templateName = "";
        public NotFoundSubjectTemplateFileException(string templateName)
        {
            _templateName = templateName;
        }
        public override string Message
        {
            get
            {
                return string.Format("Subject for template {0} not found in the templates folder", _templateName);
            }
        }
    }

    public class TemplateManager
    {
        public static Dictionary<string, Template> LoadTemplates()
        {
            List<string> templateNames = Directory.GetFiles(Configuration.TemplatesFolder, "*.body.cshtml").Select(x => Path.GetFileName(x).Replace(".body.cshtml", "")).ToList(); //assumes bodies as templates
            Dictionary<string, Template> templates = new Dictionary<string, Template>();
            foreach (var templateName in templateNames)
            {
                Template template = new Template();
                template.Subject = GetSubjectTemplate(templateName);
                template.Body = GetBodyTemplate(templateName);
                templates.Add(templateName, template);
            }
            return templates;
        }

        private static string GetSubjectTemplate(string templateName)
        {
            string subjectFileName = Path.Combine(Configuration.TemplatesFolder, templateName + ".subject.cshtml");
            if (File.Exists(subjectFileName))
            {
                using (TextReader reader = File.OpenText(subjectFileName))
                {
                    return reader.ReadToEnd();
                }
            }
            else
            {
                throw new NotFoundSubjectTemplateFileException(templateName);
            }
        }

        private static string GetBodyTemplate(string templateName)
        {
            using (TextReader reader = File.OpenText(Path.Combine(Configuration.TemplatesFolder, templateName + ".body.cshtml")))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
