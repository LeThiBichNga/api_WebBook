using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanphamController : ControllerBase
    {
        private readonly IsanphamBusiness _IBusiness;
        private string _path;
        public SanphamController(IsanphamBusiness _IBusine, IConfiguration configuration)
        {
            _IBusiness = _IBusine;
            _path = configuration["AppSettings:PATH"];
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

            //if (string.IsNullOrEmpty(_IBusiness.Get_Sanpham_By_ID(id).ToString()))
            //{
            //    return null;
            //}
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
        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [Route("create_san_pham")]
        [HttpPost]
        public bool create_san_pham(SanphamModel sp)
        {
            if (sp.anh != null)
            {
                var arrData = sp.anh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/sanpham/{arrData[0]}";
                    sp.anh = arrData[0];
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            sp.ngaynhap = DateTime.Now;
            return _IBusiness.create_san_pham(sp);
        }
        [Route("update_san_pham/{id}")]
        [HttpPut]
        public bool update_san_pham(int id,SanphamModel sp)
        {
            if (sp.anh != null)
            {
                var arrData = sp.anh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/sanpham/{arrData[0]}";
                    sp.anh = arrData[0];
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            else
            {
                sp.anh = _IBusiness.Get_Sanpham_By_ID(id).anh;
            }
            return _IBusiness.update_san_pham(id,sp);
        }
        [Route("delete_san_pham/{id}")]
        [HttpDelete]
        public bool delete_san_pham(int id)
        {
            return _IBusiness.delete_san_pham(id);
        }
    }
}
