﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public enum CommandToServer : byte
    {
        Authentification,
        SendMessage,
        SendMessageGroup,
        DeleteGroup,
        AllUsers,
        CreateGroup,
        Exit
    }
}
