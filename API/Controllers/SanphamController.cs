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
    public class SanphamController : ControllerBase
    {
        private readonly IsanphamBusiness _IBusiness;
        public SanphamController(IsanphamBusiness _IBusine)
        {
            _IBusiness = _IBusine;
        }
        [Route("get_san_pham")]
        [HttpGet]
        public List<SanphamModel> GET_ALL_SAN_PHAM()
        {
            return _IBusiness.Get_ALL_Sanpham();
        }
        [Route("Get_Sanpham_new")]
        [HttpGet]
        public List<SanphamModel> Get_Sanpham()
        {
            return _IBusiness.Get_Sanpham_New();
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public SanphamModel Get_Sanpham_By_ID(int id)
        {
            return _IBusiness.Get_Sanpham_By_ID(id);
        }
        [Route("Get_Sanpham_lq/{id}")]
        [HttpGet]
        public List<SanphamModel> Get_Sanpham_lq(int id)
        {
            return _IBusiness.Get_Sanpham_lq(id);
        }
        [Route("get_san_pham_by_iddm/{id}")]
        [HttpGet]
        public List<SanphamModel> get_san_pham_by_iddm(int id)
        {
            return _IBusiness.get_san_pham_by_iddm(id);
        }
        [Route("get_sp_idloai")]
        [HttpPost]
        public ResponseModel get_sp_idloai([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            var page = int.Parse(formData["page"].ToString());
            var pageSize = int.Parse(formData["pageSize"].ToString());
            int item_group_id = 0;
            if (formData.Keys.Contains("item_group_id") && !string.IsNullOrEmpty(Convert.ToString(formData["item_group_id"]))) {
                item_group_id = int.Parse(formData["item_group_id"].ToString());
                long total = 0;
                var data = _IBusiness.get_san_pham(page, pageSize, out total, item_group_id);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            return response;
        }
        [Route("get_san_pham_search")]
        [HttpPost]
        public ResponseModel get_san_pham_search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            var page = int.Parse(formData["page"].ToString());
            var pageSize = int.Parse(formData["pageSize"].ToString());
            string search = "";
            if (formData.Keys.Contains("search") && !string.IsNullOrEmpty(Convert.ToString(formData["search"])))
            {
                search = formData["search"].ToString();
                long total = 0;
                var data = _IBusiness.get_san_pham_search(page, pageSize, out total, search);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            return response;
        }
    }
}
