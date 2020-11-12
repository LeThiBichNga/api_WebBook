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
    public class TintucController : ControllerBase
    {
        private readonly ItintucBusiness _IBusiness;
        private string _path;

        public TintucController(ItintucBusiness _IBusine, IConfiguration configuration)
        {
            _IBusiness = _IBusine;
            _path = configuration["AppSettings:PATH"];
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
        [Route("create_tin_tuc")]
        [HttpPost]
        public bool create_tin_tuc(TintucModel tt)
        {
            if (tt.hinhanh != null)
            {
                var arrData = tt.hinhanh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/tintuc/{arrData[0]}";
                    tt.hinhanh = arrData[0];
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
           tt.ngaydang = DateTime.Now;
            return _IBusiness.create_tin_tuc(tt);
        }
        [Route("update_tin_tuc/{id}")]
        [HttpPut]
        public bool update_tin_tuc(int id, TintucModel tt)
        {
            if (tt.hinhanh != null)
            {
                var arrData = tt.hinhanh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/tintuc/{arrData[0]}";
                    tt.hinhanh = arrData[0];
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            else
            {
                tt.hinhanh = _IBusiness.get_chitiettintuc_by_id (id).hinhanh;
            }
            return _IBusiness.update_tin_tuc(id, tt);
        }
        [Route("delete_tin_tuc/{id}")]
        [HttpDelete]
        public bool delete_tin_tuc(int id)
        {
            return _IBusiness.delete_tin_tuc(id);
        }
    }
}
