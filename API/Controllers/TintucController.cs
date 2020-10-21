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
    public class TintucController : ControllerBase
    {
        private readonly ItintucBusiness _IBusiness;
        public TintucController(ItintucBusiness _IBusine)
        {
            _IBusiness = _IBusine;
        }

        [Route("get_tin_tuc")]
        [HttpGet]
        public List<TintucModel> GET_ALL_TIN_TUC()
        {
            return _IBusiness.Get_ALL_Tintuc();
        }
        [Route("Get_tintuc_new")]
        [HttpGet]
        public List<TintucModel> Get_tintuc()
        {
            return _IBusiness.Get_tintuc_new();
        }
        [Route("get_chitiettintuc_by_id/{id}")]
        [HttpGet]
        public TintucModel get_chitiettintuc_by_id(int id)
        {
            return _IBusiness.get_chitiettintuc_by_id(id);
        }
    }
}
