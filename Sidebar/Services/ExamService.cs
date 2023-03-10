using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using Sidebar.Data;
using Sidebar.Dtos;
using Sidebar.Models;

namespace Sidebar.Services
{
    public class ExamService : ControllerBase, IExamService
    {
        private WebAppDbContext _db;
        private UnitOfWork _unit;
        private readonly IMapper _mapper;
        private MyDTO _myDTO;
        public ExamService(WebAppDbContext db, UnitOfWork unit, IMapper mapper)
        {
            _db = db;
            _unit = unit;
            _mapper = mapper;
            _myDTO = new MyDTO();
        }
        public async Task<MyDTO> Get(int id)
        {
            if (id == null || _db.Exams == null || await _unit.Exam.GetAsync(id) == null)
            {
                _myDTO.View = "Index";
                _myDTO.Message = "The requested exam could not be found. Please try again later.";
            }
            else
            {
                _myDTO.View = "Details";
                Exam exam = await _unit.Exam.GetAsync(id);
                _myDTO.ExamDto = _mapper.Map<ExamDto>(exam);
            }
            return _myDTO;
        }
        public async Task<IEnumerable<ExamDto>?> GetAll()
        {
            var exams = await _unit.Exam.GetAllAsync();
            _myDTO.ExamDtos = _mapper.Map<List<ExamDto>>(exams);
            return _myDTO.ExamDtos;
        }

        public async Task<MyDTO> GetForUpdate(int id)
        {
            _myDTO.View = "Edit";
            if (id == null || _db.Exams == null)
            {
                _myDTO.View = "Index";
                _myDTO.Message = "The requested exam could not be found. Please try again later.";
                return _myDTO;
            }
            Exam exam = await _unit.Exam.GetAsync(id);
            _myDTO.ExamDto = _mapper.Map<ExamDto>(exam);
            if (_myDTO.ExamDto == null)
            {
                _myDTO.View = "Index";
                _myDTO.Message = "The requested exam could not be found. Please try again later.";
            }
            return _myDTO;
        }

        public async Task<MyDTO> AddOrUpdate(int id, [Bind("Id,AssessmentTestCode,ExaminationDate,ScoreReportDate," +
            "CandidateScore,PercentageScore,AssessmentResultLabel,CandidateId,Candidate,TitleOfCertificate,Certificate")] ExamDto examDto)
        {
            Candidate candidate = await _unit.Candidate.GetAsync(examDto.CandidateId);
            Certificate certificate = await _unit.Certificate.GetAsyncByTilteOfCert(examDto.TitleOfCertificate);
            examDto.Candidate = candidate;
            examDto.Certificate = certificate;
            //if(await _unit.Exam.GetAsync(examDto.Id) == null)
            //{
                
            //}
            Exam exam = _mapper.Map<Exam>(examDto);

            EntityState state = _unit.Exam.AddOrUpdate(exam);
            if (id != exam.Id)
            {
                if (state == EntityState.Added)
                {
                    _myDTO.View = "Create";
                }
                if (state == EntityState.Modified)
                {
                    _myDTO.View = "Edit";
                }
                _myDTO.Message = "The exam Id was compromised. The request could not be completed due to security reasons. Please try again later.";
                _myDTO.ExamDto = examDto;
                return _myDTO;
            }
            if (ModelState.IsValid)
            { 
                if(state == EntityState.Added)
                {
                    _myDTO.Message = "The requested exam has been added successfully.";
                    exam.AssessmentTestCode = RandomizerFactory.GetRandomizer(new FieldOptionsIBAN()).Generate();
                }
                if (state == EntityState.Modified)
                {
                    _myDTO.Message = "The requested exam has been updated successfully.";
                }
                if (state == EntityState.Modified && !await _unit.Exam.Exists(exam.Id))
                {
                    _myDTO.Message = "The requested exam could not be found. Please try again later.";
                }                
                await _unit.SaveAsync();
                _myDTO.View = "Index";
                IEnumerable<Exam> exams = await _unit.Exam.GetAllAsync();
                _myDTO.ExamDtos = _mapper.Map<List<ExamDto>>(exams);
                return _myDTO;
            }
            else
            {
                if (state == EntityState.Added)
                {
                    _myDTO.View = "Create";
                }
                if (state == EntityState.Modified)
                {
                    _myDTO.View = "Edit";
                }
                _myDTO.Message = "Invalid entries. Please try again later.";
                _myDTO.ExamDto = examDto;
            }
            return _myDTO;
        }

        public async Task<MyDTO> GetForDelete(int id)
        {
            _myDTO.View = "Delete";
            if (id == null || _db.Exams == null)
            {
                _myDTO.View = "Index";
                _myDTO.Message = "The requested exam could not be found. Please try again later.";
                IEnumerable<Exam> exams = await _unit.Exam.GetAllAsync();
                _myDTO.ExamDtos = _mapper.Map<List<ExamDto>>(exams);
                return _myDTO;
            }
            Exam exam = await _unit.Exam.GetAsync(id);
            _myDTO.ExamDto = _mapper.Map<ExamDto>(exam);
            if (_myDTO.ExamDto == null)
            {
                _myDTO.View = "Index";
                _myDTO.Message = "The requested exam could not be found. Please try again later.";
                IEnumerable<Exam> exams = await _unit.Exam.GetAllAsync();
                _myDTO.ExamDtos = _mapper.Map<List<ExamDto>>(exams);
            }
            return _myDTO;
        }

        public async Task<MyDTO> Delete(int id)
        {
            _myDTO.View = "Index";
            _myDTO.Message = "The requested exam has been deleted successfully.";
            if (!await _unit.Exam.Exists(id))
            {
                _myDTO.Message = "The requested exam could not be found. Please try again later.";
                return _myDTO;
            }
            Exam exam = await _unit.Exam.GetAsync(id);
            _unit.Exam.Delete(exam);
            await _unit.SaveAsync();
            IEnumerable<Exam> exams = await _unit.Exam.GetAllAsync();
            _myDTO.ExamDtos = _mapper.Map<List<ExamDto>>(exams);
            return _myDTO;
        }
    }
}
