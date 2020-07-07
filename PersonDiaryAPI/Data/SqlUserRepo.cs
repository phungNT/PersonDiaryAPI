using Microsoft.EntityFrameworkCore;
using PersonDiaryAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PersonDiaryAPI.Data
{
    public class SqlUserRepo : IUserRepo
    {
        private PersonDiaryAPIContext _context;

        public SqlUserRepo(PersonDiaryAPIContext context)
        {
            _context = context;
        }
        public void CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            User user = _context.Users.Include(u => u.diarys).FirstOrDefault(u => u.userId == id);

            List<Diary> diaries = user.diarys.ToList();
            for(int i =0; i< diaries.Count; i++)
            {
                if (diaries.ElementAt(i).status.Trim().Equals("disable"))
                {
                    diaries.RemoveAt(i);
                    i--;
                }
            }
  
            user.diarys = diaries.AsEnumerable();
            return user;

                
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
