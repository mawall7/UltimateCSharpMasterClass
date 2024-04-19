﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.UserCommunication
{
    public interface IUserCommunication
    {
        int ReadInteger(string prompt);
        void ShowMessage(string message);
    }
}
