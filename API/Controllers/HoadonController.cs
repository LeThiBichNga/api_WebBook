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
    public class HoadonController : ControllerBase
    {
        private readonly IhoadonBusiness _IBusiness;
        public HoadonController(IhoadonBusiness _IBusine)
        {
            _IBusiness = _IBusine;
        }
        [Route("get_hoa_don")]
        [HttpGet]
        public List<DonhangModel> GET_ALL_HOA_DON()
        {
            return _IBusiness.Get_ALL_Hoadon();
        }
        [Route("Dat_Hang")]
        [HttpPost]
        public bool Dat_Hang([FromBody]dathangModel dt)
        {
            dt.maid = Guid.NewGuid().ToString(); 
            foreach(chitietdonhangModel ct in dt.listjson_chitiet)
            {
                ct.madh = dt.maid;
                ct.manctdh = Guid.NewGuid().ToString();
            }
            return _IBusiness.Dat_Hang(dt.maid, dt.ten_kh, dt.noi_giao, dt.sdt, dt.thanh_tien, dt.listjson_chitiet);
        }
        [Route("get_tien")]
        [HttpGet]
        public int Get_tien()
        {
            return _IBusiness.Get_tien(DateTime.Now.Month, DateTime.Now.Year);
        }
    }
}
