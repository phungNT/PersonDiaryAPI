using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonDiaryAPI.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string gender { get; set; }
        public virtual IEnumerable<Diary> diarys { get; set; }
    }
}
