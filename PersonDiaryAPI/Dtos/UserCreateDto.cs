using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonDiaryAPI.Dtos
{
    public class UserCreateDto
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
    }
}
