using AutoMapper;
using FacialRecognitionEmployeeAttendanceSystem_UI.Models;
using FacialRecognitionEmployeeAttendanceSystem_UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Mappers
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Departments, DepartmentViewModel>().
                ForMember(dpv => dpv.shiftName, dp => dp.MapFrom(u => u.shifts.shiftName));

            CreateMap<Users, UserViewModel>().
                ForMember(usv => usv.departmentName, us => us.MapFrom(u => u.departments.departmentName)).
                ForMember(usv => usv.roleName, us => us.MapFrom(u => u.roles.roleName)).
                ForMember(usv => usv.shiftName, us => us.MapFrom(u => u.shifts.shiftName));

            CreateMap<Attendances, AttendancesViewModel>().
                ForMember(atv => atv.userName, at => at.MapFrom(u => u.users.fullName));

            CreateMap<Payslips, PayslipViewModel>().
                ForMember(psv => psv.userName, ps => ps.MapFrom(u => u.users.fullName));

        }
    }
}
