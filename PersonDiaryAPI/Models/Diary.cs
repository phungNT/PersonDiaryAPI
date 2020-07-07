using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonDiaryAPI.Models
{
    public class Diary
    {
        [Key]
        public int diaryId { get; set; }
        public string title { get; set; }
        [Required]
        public string content { get; set; }
        public string status { get; set; }
        public DateTime dateTime { get; set; }
        public String description { get; set; }
        public virtual int userId { get; set; }
        public virtual User user { get; set; }
    }
}
