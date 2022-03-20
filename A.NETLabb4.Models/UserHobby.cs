using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace A.NETLabb4.Models
{
    public class UserHobby
    {
        [Key]
        public int UserHobbyID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int HobbyID { get; set; }
        public string? WebsiteLink { get; set; }
        public User User { get; set; }
        public Hobby Hobby { get; set; }
    }
}
