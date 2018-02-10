using System;
using System.IO;
using System.Globalization;
using System.Net.Mail;
using System.Net.Http;
using System.Text;

namespace Common
{
    public static class General
    {
        public static bool MaintenanceMode;

        public static bool MaintenanceSwitch()
        {
            if (MaintenanceMode)
                MaintenanceMode = false;
            else MaintenanceMode = true;

            return MaintenanceMode;
        }

        public static DateTime DTNow()
        {
            return DateTime.UtcNow;
        }

        //Attempts to Parse ISODateTime, Then Javascript DateTime, Then General string.
        public static Tuple<bool, DateTime> ParseDateTime(string dtstr)
        {
            if (!DateTime.TryParseExact(dtstr, "yyyy-mm-dd'T'HH:MM:ss",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
            {
                if (dtstr.Length > 22)
                {
                    if (!DateTime.TryParseExact(dtstr.Substring(0, 24), "ddd MMM d yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    {
                        if (!DateTime.TryParse(dtstr, out dt))
                            return new Tuple<bool, DateTime>(false, DateTime.MinValue);

                    }
                }
                else if (!DateTime.TryParse(dtstr, out dt))
                    return new Tuple<bool, DateTime>(false, DateTime.MinValue);
            }

            return new Tuple<bool, DateTime>(true, dt);
        }

        public static string GetIP()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ipAddress))
                return context.Request.ServerVariables["REMOTE_ADDR"];
            else
            {
                string[] addresses = ipAddress.Split(',');
                ipAddress = null;
                return addresses[0];
            }
        }

        public static string RandomString()
        {
            return Path.GetRandomFileName().Replace(".", Settings.Empty);
        }

        static void LogWrite(string logMessage, TextWriter w)
        {
            w.WriteLine("---");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} : ");
            w.Write($"{logMessage}");
        }

        public static void ErrorLog(object sender, EventArgs e)
        {
            string FLoc = DTNow().ToShortDateString().Replace('/', '-') + ".txt";
            string LogDir = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Logs/");

            using (StreamWriter w = File.AppendText(Path.Combine(LogDir, FLoc)))
            { LogWrite(e.ToString(), w); }
        }

        public static MailMessage NewMessage(string email, string mailnamedesc, string product, string subject)
        {
            if (string.IsNullOrEmpty(email))
                email = Settings.CompanyEmail;

            if (string.IsNullOrEmpty(mailnamedesc))
                mailnamedesc = Settings.MailNameDesc;

            if (string.IsNullOrEmpty(product))
                product = Settings.ProductName;

            if (string.IsNullOrEmpty(subject))
                subject = "Notification";

            return new MailMessage
            {
                From = new MailAddress(email, mailnamedesc, Encoding.UTF8),
                Subject = $"{product} {subject}",
                SubjectEncoding = Encoding.UTF8,
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = true,
                Priority = MailPriority.High
            };
        }

        public static SmtpClient MailConfiguration(string username, string password, string smtp)
        {
            if (string.IsNullOrEmpty(username))
                username = Settings.MailUsername;

            if (string.IsNullOrEmpty(password))
                password = Settings.MailPassword;

            if (string.IsNullOrEmpty(smtp))
                smtp = Settings.SMTP;

            SmtpClient sc = new SmtpClient
            {
                Credentials = new System.Net.NetworkCredential(username, password),
                Host = smtp,
                Port = 587,
                EnableSsl = true
            };

            return sc;
        }

        /*
        public static StringContent AsJson(this object o) =>
            new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json");

        public static async System.Threading.Tasks.Task<HttpResponseMessage> PostJson(object dataclass, string Url)
        {
            using (var client = new HttpClient())
                return await client.PostAsync(Url, dataclass.AsJson());
        }
        

        public static async System.Threading.Tasks.Task<HttpResponseMessage> PostJson(object dataclass, string Url)
        {
            using (var client = new HttpClient())
                return await client.PostAsJsonAsync(Url, dataclass);
        }
        */
    }
}