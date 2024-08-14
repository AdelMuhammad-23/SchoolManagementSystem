using AutoMapper;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.StudentMapping
{
    public partial class StudentProfile : Profile
    {
        public void AddStudentMapping()
        {
            CreateMap<AddStudentCommand, Student>()
                .ForMember(dest => dest.DID, src => src.MapFrom(dep => dep.DepartmentId));

        }
    }
}
