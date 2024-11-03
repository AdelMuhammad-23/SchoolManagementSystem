using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Abstracts.Functions;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Servies.Abstructs;


namespace SchoolProject.Servies.Implementation
{
    public class InstructorServies : IInstructorServies
    {
        #region Fileds
        private readonly ApplicationDbContext _dbContext;
        public readonly IInstructorRepository _instructorRepository;
        private readonly IInstructorFunctionsRepository _instructorFunctionsRepository;
        private readonly IFileServies _fileServies;
        private readonly IHttpContextAccessor _contextAccessor;
        #endregion
        #region Constructors
        public InstructorServies(ApplicationDbContext dbContext,
                                 IInstructorFunctionsRepository instructorFunctionsRepository,
                                 IInstructorRepository instructorRepository,
                                 IFileServies fileServies,
                                 IHttpContextAccessor contextAccessor)
        {
            _dbContext = dbContext;
            _instructorFunctionsRepository = instructorFunctionsRepository;
            _instructorRepository = instructorRepository;
            _fileServies = fileServies;
            _contextAccessor = contextAccessor;
        }


        #endregion

        #region Handle Functions
        public async Task<List<Instructor>> GetAllInstructors()
        {
            var instructorList = await _dbContext.Instructor.ToListAsync();
            return instructorList;
        }
        public async Task<decimal> GetSalarySummationOfInstructor()
        {
            decimal result = 0;
            result = _instructorFunctionsRepository.GetSalarySummationOfInstructor("select dbo.GetSalarySummation()");
            return result;
        }
        public async Task<string> DeleteInstructor(Instructor instructor)
        {
            var trancat = _dbContext.Database.BeginTransaction();
            try
            {
                await _instructorRepository.DeleteAsync(instructor);
                await trancat.CommitAsync();
                return "Deleted Successfully";
            }
            catch (Exception ex)
            {
                await trancat.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<Instructor> GetInstructorById(int id)
        {
            return await _instructorRepository.GetByIdAsync(id);
        }

        public async Task<string> AddInstructor(Instructor instructor, IFormFile instructorImage)
        {
            var context = _contextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            var imageUrl = await _fileServies.UploadImage("Instructors", instructorImage);

            switch (imageUrl)
            {
                case "this extension is not allowed":
                    return "this extension is not allowed";
                case "this image is too big":
                    return "this image is too big";
                case "FailedToUploadImage":
                    return "FailedToUploadImage";
            }
            instructor.Image = baseUrl + imageUrl;
            var addInstructor = await _instructorRepository.AddAsync(instructor);
            return "Success";
        }

        public async Task<bool> IsNameArExist(string nameAr)
        {
            //Check if the name is Exist Or not
            var student = _instructorRepository.GetTableNoTracking().Where(x => x.NameAR.Equals(nameAr)).FirstOrDefault();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
        {
            //Check if the name is Exist Or not
            var student = await _instructorRepository.GetTableNoTracking().Where(x => x.NameAR.Equals(nameAr) & x.InsId != id).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameEnExist(string nameEn)
        {
            //Check if the name is Exist Or not
            var student = await _instructorRepository.GetTableNoTracking().Where(x => x.NameEr.Equals(nameEn)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
        {
            //Check if the name is Exist Or not
            var student = await _instructorRepository.GetTableNoTracking().Where(x => x.NameEr.Equals(nameEn) & x.InsId != id).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<string> UpdateInstructor(Instructor instructor, IFormFile instructorImage)
        {

            if (instructorImage != null)
            {
                var context = _contextAccessor.HttpContext.Request;
                var baseUrl = context.Scheme + "://" + context.Host;
                var imageUrl = await _fileServies.UploadImage("Instructors", instructorImage);
                await _fileServies.UploadImage("Instructors", instructorImage);
                switch (imageUrl)
                {
                    case "this extension is not allowed":
                        return "this extension is not allowed";
                    case "this image is too big":
                        return "this image is too big";
                    case "FailedToUploadImage":
                        return "FailedToUploadImage";
                }
                instructor.Image = baseUrl + imageUrl;

            }

            await _instructorRepository.UpdateAsync(instructor);
            return "Success";
        }
        #endregion
    }
}
