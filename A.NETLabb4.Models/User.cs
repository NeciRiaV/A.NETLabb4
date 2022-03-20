using System;
using System.ComponentModel.DataAnnotations;

namespace A.NETLabb4.Models
{
    public class User
    {
#nullable enable
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
#nullable disable
    }
}
