using SchoolProject.Core.Features.Departments.Queries.Response;
using SchoolProject.Data.Entities;


namespace SchoolProject.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile
    {
        public void GetSingleDepartmentMapping()
        {
            CreateMap<Department, GetSingleDepartmentResponse>()
                .ForMember(dis => dis.Id, src => src.MapFrom(n => n.DID))
                .ForMember(dis => dis.DName, src => src.MapFrom(src => src.GetLocalized(src.DNameAr, src.DNameEn)))
                .ForMember(dis => dis.MangerName, src => src.MapFrom(src => src.Instructor.GetLocalized(src.Instructor.NameAR, src.Instructor.NameEr)))
                //.ForMember(dis => dis.StudentList, src => src.MapFrom(n => n.Students))
                .ForMember(dis => dis.SubjectList, src => src.MapFrom(n => n.DepartmentSubjects))
                .ForMember(dis => dis.InstructorList, src => src.MapFrom(n => n.Instructors));


            CreateMap<DepartmentSubject, SubjectResponse>()
                .ForMember(dis => dis.Id, src => src.MapFrom(src => src.SubID))
                .ForMember(dis => dis.Name, src => src.MapFrom(src => src.Subjects.GetLocalized(src.Subjects.SubjectNameAR, src.Subjects.SubjectNameEn)));
            //CreateMap<Student, StudentResponse>()
            //    .ForMember(dis => dis.Id, src => src.MapFrom(src => src.StudID))
            //    .ForMember(dis => dis.Name, src => src.MapFrom(src => src.GetLocalized(src.NameAr, src.NameEn)));
            CreateMap<Instructor, InstructorResponse>()
                .ForMember(dis => dis.Id, src => src.MapFrom(src => src.InsId))
                .ForMember(dis => dis.Name, src => src.MapFrom(src => src.GetLocalized(src.NameAR, src.NameEr)));


        }
    }
}
