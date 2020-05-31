using DataBase.Entities;
using Microsoft.IdentityModel.Tokens;
using Shared.Security;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Account.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;

        public AccountService(AppDbContext context)
        {
            _context = context;
        }

        public User Authenticate(User loggedUser)
        {
            User user = null;
            //if (systemConfiguration.AuthenticationMode == (int)AuthenticateMode.ActiveDirctory && !External)
            //{
            user = AuthenticateAD(loggedUser.UserName, loggedUser.Password);
            //}
            // return null if user not found
            //if (user == null)
            //return new Error(ErrorMsg.UnAuthorized.ToDescriptionString());
            // authentication successful so generate jwt token
            var TokenHandler = new JwtSecurityTokenHandler();
            var Token = GenerateToken(user);
            user.Token = TokenHandler.WriteToken(Token);

            // remove password before returning
            user.Password = null;
            return user;
        }
        #region helpers
        private User AuthenticateAD(string userName, string password)
        {
            using (var context = new PrincipalContext(ContextType.Domain, "197.50.225.151", userName, password))
            {
                if (context.ValidateCredentials(userName, password))
                {

                    UserPrincipal userPrincile = new UserPrincipal(context);
                    PrincipalSearcher searcher = new PrincipalSearcher(userPrincile);
                    UserPrincipal foundUser = searcher.FindAll().Where(x => x.SamAccountName.Equals(userName)).FirstOrDefault() as UserPrincipal;
                    if (foundUser != null)
                    {
                        var user = _context.Users.Where(x => x.Id == foundUser.Guid)
                            .Select(x => new User
                            {
                                Id = x.Id,
                                UserName = x.UserName,
                            })
                            .FirstOrDefault();
                        if (user == null)
                        {
                            return GetUserAD(foundUser, password);
                        }
                        else
                            return user;
                    }
                }
            }

            return null;
        }
        private User GetUserAD(UserPrincipal foundUser, string _password)
        {
            if (foundUser != null)
            {
                var user = new User
                {
                    Id = foundUser.Guid.Value,
                    UserName = foundUser.SamAccountName,
                    Password = GetPassword(_password)
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            else
            {
                return null;
            }
        }

        internal string GetPassword(string Password)
        {
            return TripleDES.Encrypt(Password, true);
        }

        public SecurityToken GenerateToken(User user)
        {
            var TokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes("F648Ic/rdhJghjkDYxgY9vj/ENI=");
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    // 'user' is the model for the authenticated user
                    // also note that you can include many claims here
                    // but keep in mind that if the token causes the
                    // request headers to be too large, some servers
                    // such as IIS may reject the request.
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
            };
            return TokenHandler.CreateToken(TokenDescriptor);
        }
        #endregion
    }
}
