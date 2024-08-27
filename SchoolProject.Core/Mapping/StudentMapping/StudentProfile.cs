using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.StudentMapping
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile() 
        {
            GetStudentListMapping();
            GetStudentByIdMapping();
            AddStudentMapping();
        }
    }
}
