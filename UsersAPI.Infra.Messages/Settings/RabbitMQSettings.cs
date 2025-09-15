using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace UsersAPI.Infra.Messages.Settings
{
    public class RabbitMQSettings
    {
        public string? Url { get; set; }
        public string? Queue { get; set; }
    }
}
