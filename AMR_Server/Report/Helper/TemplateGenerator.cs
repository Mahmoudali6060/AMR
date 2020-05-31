using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Helper
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString()
        {
            string reportTitle = "Title";
            List<string> header = new List<string>()
            {
                "Username","Address"
            };

            var user1 = new UserDetail()
            {
                UserName = "A"
            };
            var user2 = new UserDetail()
            {
                UserName = "B"
            };

            List<UserDetail> userDetails = new List<UserDetail>();
            userDetails.Add(user1);
            userDetails.Add(user2);

            var sb = new StringBuilder();
            sb.Append(@"
             <html>
                <head></head>
                <body>
                    <div class='header'><h1>");
            sb.AppendFormat("{0}", reportTitle);
            sb.Append(@"</h1></div>
                    <table align='center'
                        <tr>
                            <td>Username</td>
                        </tr>");

            foreach (var user in userDetails)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                  </tr>", user.UserName);

            }

            sb.Append(@"
                     </table>
                  </body>
                </html>
            ");


            return sb.ToString();
        }
    }
}
