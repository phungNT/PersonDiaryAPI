using PersonDiaryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonDiaryAPI.Data
{
    public interface IDiaryRepo
    {
        bool SaveChange();
        IEnumerable<Diary> GetAllDiary();
        Diary GetDiaryById(int id);
        void CreateDiary(Diary diary);
        void UpdateDiary(Diary diary);
        void DeleteDiary(Diary diary);
    }
}
