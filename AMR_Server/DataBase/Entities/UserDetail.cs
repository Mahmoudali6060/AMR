using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Entities
{
    public partial class UserDetail
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string PinCode { get; set; }
    }

}
