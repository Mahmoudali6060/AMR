
using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Account.Services
{
    public interface IAccountService
    {
        User Authenticate(User user);
        //SecurityToken GenerateToken(UserDto user);
    }
}
