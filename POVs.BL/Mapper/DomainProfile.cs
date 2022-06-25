using AutoMapper;
using POVs.BL.Models;
using POVs.BL.ModelView;
using POVs.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POVs.BL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            // from entity to vm (Retreive)
            CreateMap<Department, DepartmentVM>();
            CreateMap<Employee, EmployeeVM>();
            // from vm to entity (create, update and delete)
            CreateMap<DepartmentVM, Department>();
            CreateMap<EmployeeVM, Employee>();
        }
    }
}
