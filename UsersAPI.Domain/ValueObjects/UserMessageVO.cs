using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace UsersAPI.Domain.ValueObjects
{
    public class UserMessageVO
    {
        public Guid Id { get; set; }
        public DateTime SendeAt { get; set; }
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
