using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.Plugins.Email.Settings
{
    public class EmailSettings
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string EncryptedEmailAddress { get; set; }
        public string EncryptedPassword { get; set; }
        public bool EnableSSL { get; set; }
        public string DefaultCCEmails { get; set; }
        public string DefaultEmails { get; set; }
        public string DefaultSubject { get; set; }
    }
}
