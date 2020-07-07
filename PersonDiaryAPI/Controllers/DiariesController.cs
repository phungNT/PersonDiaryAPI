using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonDiaryAPI.Data;
using PersonDiaryAPI.Dtos;
using PersonDiaryAPI.Models;

namespace PersonDiaryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiariesController : ControllerBase
    {
        private readonly PersonDiaryAPIContext _context;
        private readonly IDiaryRepo _repository;
        private readonly IMapper _mapper;

        public DiariesController(PersonDiaryAPIContext context, IDiaryRepo repository, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Diaries
        [HttpGet]
        public ActionResult<IEnumerable<DiaryReadDto>> GetAllDiarys()
        {
            IEnumerable<Diary> diary = _repository.GetAllDiary();
            if (diary != null)
            {
                return Ok(_mapper.Map<IEnumerable<DiaryReadDto>>(diary));
            }
            return NotFound();
        }

        // GET: api/Diaries/5
        [HttpGet("{id}", Name = "GetDiaryById")]
        public ActionResult<DiaryReadDto> GetDiaryById(int id)
        {

            Diary diary = _repository.GetDiaryById(id);
            if (diary != null)
            {
                return Ok(_mapper.Map<DiaryReadDto>(diary));
            }

            return NotFound();
        }

        // PUT: api/Diaries/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public ActionResult UpdateDiary(int id, DiaryUpdateDto diaryUpdateDto)
        {
             var diaryModelFromRepo = _repository.GetDiaryById(id);
             if(diaryModelFromRepo == null)
                {
                    return NotFound();
                }
            _mapper.Map(diaryUpdateDto, diaryModelFromRepo);
            _repository.UpdateDiary(diaryModelFromRepo);
            _context.SaveChanges();
            return NoContent();
        }

        // POST: api/Diaries
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<DiaryReadDto> CreateDiary(DiaryCreateDto diaryCreateDto)
        {
            var diary = _mapper.Map<Diary>(diaryCreateDto);
            _repository.CreateDiary(diary);
            _repository.SaveChange();
            var diaryReadDto = _mapper.Map<DiaryReadDto>(diary);
            return CreatedAtRoute(nameof(GetDiaryById), new { Id = diaryReadDto.diaryId }, diaryReadDto);


        }

        // DELETE: api/Diaries/5
        [HttpDelete("{id}")]
        public ActionResult<Diary> DeleteDiary(int id)
        {
            var diaryModelFromRepo = _repository.GetDiaryById(id);
            if (diaryModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map<Diary>(diaryModelFromRepo);
            _repository.DeleteDiary(diaryModelFromRepo);
            _context.SaveChanges();
            return NoContent();
        }

        private bool DiaryExists(int id)
        {
            return _context.Diarys.Any(e => e.diaryId == id);
        }
    }
}
