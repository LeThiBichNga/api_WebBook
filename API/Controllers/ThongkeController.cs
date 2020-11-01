using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongkeController : ControllerBase
    {
        private readonly IthongkeBusiness _IBusiness;
        public ThongkeController(IthongkeBusiness _IBusine)
        {
            _IBusiness = _IBusine;
        }

     
        [Route("Get_Het_Sanpham")]
        [HttpGet]
        public List<SanphamModel> Get_Het_Sanpham()
        {
            return _IBusiness.Get_Het_Sanpham();
        }
        [Route("Get_tonkho_Sanpham")]
        [HttpGet]
        public List<SanphamModel> Get_tonkho_Sanpham()
        {
            return _IBusiness.Get_tonkho_Sanpham();
        }

        [Route("Get_Saphet_Sanpham")]
        [HttpGet]
        public List<SanphamModel> Get_Saphet_Sanpham()
        {
            return _IBusiness.Get_Saphet_Sanpham();
        }
    }
}
