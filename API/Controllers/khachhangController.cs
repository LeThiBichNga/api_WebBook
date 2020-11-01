using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class khachhangController : ControllerBase
    {
        private readonly IkhachhangBusiness _IBusiness;
        public khachhangController(IkhachhangBusiness _IBusine)
        {
            _IBusiness = _IBusine;
        }
        [Route("get_khach_hang")]
        [HttpGet]
        public List<KhachhangModel> GET_ALL_KHACH_HANG()
        {
            return _IBusiness.Get_ALL_Khachhang();
        }
        [Route("Check_login")]
        [HttpGet]
        public KhachhangModel Check_login(string email, string pass)
        {
            return _IBusiness.Check_login(email, pass);
        }
    }
}
