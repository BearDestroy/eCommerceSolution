using AutoMapper;
using Core.DTO;
using eCommerce.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Helpers
{
    public  class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterAddRequest, KhachHang>();
            //.ForMember(kh => kh.HoTen, option => option.MapFrom(RegisterVM => RegisterVM.HoTen)) 
            // Nếu có thuộc tính khách nhau thì convert
            //.ReverseMap(); Cấu hình 2 chiều
        }
    }
}
