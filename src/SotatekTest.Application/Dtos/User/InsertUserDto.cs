using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotatekTest.Application.Dtos.User
{
    public class InsertUserDto
    {
        public string FullName { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="Age must be greater than or equal to 1")]
        public int? Age { get; set; }
        [EmailAddress(ErrorMessage = "The field must be a valid email address")]
        public string Email { get; set; }
        public string? Phone { get; set; }
    }
}
