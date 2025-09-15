using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Domain.ValueObjects;

namespace UsersAPI.Domain.Interfaces.Messages
{
    public interface IUserMessageProducer
    {
        void Send(UserMessageVO userMessage);
    }
}
