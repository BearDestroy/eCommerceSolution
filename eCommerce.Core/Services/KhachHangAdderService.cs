using AutoMapper;
using Core.DTO;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RespositoryConstract;
using eCommerce.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Services
{
    public class KhachHangAdderService : IKhachHangAdder
    {
        private readonly IKhachHangRespository _khachHangRespository;
        private readonly IMapper _mapper;
        public KhachHangAdderService(IMapper mapper, IKhachHangRespository khachHangRespository)
        {
            _mapper = mapper;
            _khachHangRespository = khachHangRespository;
        }
        public KhachHang AddKhachHang(RegisterAddRequest registerAddRequest)
        {
            if (registerAddRequest == null)
            {
                throw new ArgumentNullException(nameof(RegisterAddRequest));
            }
            var khachHangLocal = _mapper.Map<KhachHang>(registerAddRequest);
            khachHangLocal.RandomKey = RandomKey.GenerateRamdomKey();
            khachHangLocal.MatKhau = registerAddRequest.MatKhau.ToMd5Hash(khachHangLocal.RandomKey);
            khachHangLocal.HieuLuc = true;//sẽ xử lý khi dùng Mail để active
            khachHangLocal.VaiTro = 0;


            return _khachHangRespository.AddKhachHang(khachHangLocal);

        }
    }
}
