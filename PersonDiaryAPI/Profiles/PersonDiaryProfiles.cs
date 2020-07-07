using AutoMapper;
using PersonDiaryAPI.Data;
using PersonDiaryAPI.Dtos;
using PersonDiaryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonDiaryAPI.Profiles
{
    public class PersonDiaryProfiles:Profile
    {
        public PersonDiaryProfiles()
        {
            CreateMap<Diary, DiaryReadDto>();
            CreateMap<DiaryCreateDto, Diary>();
            CreateMap<DiaryUpdateDto, Diary>();
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
        }
        
    }
}
