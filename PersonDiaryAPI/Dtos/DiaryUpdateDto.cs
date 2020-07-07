using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonDiaryAPI.Dtos
{
    public class DiaryUpdateDto
    {
        public string title { get; set; }
        public string content { get; set; }
        public string status { get; set; }
        public DateTime dateTime { get; set; }
        public String description { get; set; }
        public virtual int userId { get; set; }
    }
}
