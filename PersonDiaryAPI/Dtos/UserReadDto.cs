using PersonDiaryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonDiaryAPI.Dtos
{
    public class UserReadDto
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        public virtual IEnumerable<DiaryReadDto> diarys { get; set; }
    }
}
