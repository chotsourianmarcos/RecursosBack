﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IUserSecurityLogic
    {
        string GenerateAuthorizationToken(string userName, string userPasswordEncrypted);
        //void RefreshUserToken(string userName, string newEncryptedToken);
        //string ReturnUserToken(string userName, string userPasswordEncrypted);
        bool ValidateUserToken(string userName, string token);
    }
}
