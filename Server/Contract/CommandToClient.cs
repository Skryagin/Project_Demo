using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
        public enum CommandToClient : byte
        {
            Message,
            UsersOnline,
            MessageGroup
        }
}
