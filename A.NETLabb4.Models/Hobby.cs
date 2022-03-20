using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace A.NETLabb4.Models
{
    public class Hobby
    {
        [Key]
        public int HobbyID { get; set; }
        [Required]
        public string HobbyName { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<UserHobby> UserHobbies { get; set; }


       
    }
}
