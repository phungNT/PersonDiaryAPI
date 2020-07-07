using Microsoft.EntityFrameworkCore;
using PersonDiaryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonDiaryAPI.Data
{
    public class SqlDiaryRepo : IDiaryRepo
    {
        private PersonDiaryAPIContext _context;

        public SqlDiaryRepo(PersonDiaryAPIContext context)
        {
            _context = context;
        }
        public void CreateDiary(Diary diary)
        {
            if (diary == null)
            {
                throw new ArgumentNullException(nameof(diary));
            }
            _context.Diarys.Add(diary);
        }

        public void DeleteDiary(Diary diary)
        {
            Diary selectDiary= (from d in _context.Diarys where d.diaryId == diary.diaryId select d).First();
            selectDiary.status = "disable";
        }

        public IEnumerable<Diary> GetAllDiary()
        {
            var query = from d in _context.Diarys where d.status == "enable" select d;
            IEnumerable<Diary> diary = query.ToList();
            return diary;
        }

        public Diary GetDiaryById(int id)
        {
            var query = from d in _context.Diarys where d.status == "enable" select d;
            Diary diary = query.FirstOrDefault(t => t.diaryId == id);
            return diary;
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateDiary(Diary diary)
        {
            
        }
    }
}
