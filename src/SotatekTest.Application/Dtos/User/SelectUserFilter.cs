using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotatekTest.Application.Dtos.User
{
    public class SelectUserFilter
    {
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? SortBy { get; set; }
    }
}
