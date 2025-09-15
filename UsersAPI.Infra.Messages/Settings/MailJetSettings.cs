using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAPI.Infra.Messages.Settings
{
    public class MailJetSettings
    {
        public string? ApiKey { get; set; }
        public string? SecretKey { get; set; }
        public string? Sender { get; set; }
    }
}
