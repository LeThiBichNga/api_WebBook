using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
    public class sanphamBusiness : IsanphamBusiness
    {
        private readonly IsanphamRespo _Respo;
        public sanphamBusiness(IsanphamRespo respo)
        {
            _Respo = respo;
        }
        public List<SanphamModel> Get_ALL_Sanpham()
        {
            return _Respo.Get_ALL_Sanpham();
        }

       

        public SanphamModel Get_Sanpham_By_ID(int id)
        {
            return _Respo.Get_Sanpham_By_ID(id);
        }

        public List<SanphamModel> Get_Sanpham_lq(int id)
        {
            return _Respo.Get_Sanpham_lq(id);
        }

        public List<SanphamModel> Get_Sanpham_New()
        {
            return _Respo.Get_Sanpham_New();
        }

        public List<SanphamModel> get_san_pham(int pageIndex, int pageSize, out long total, int id_loai)
        {
            return _Respo.get_san_pham(pageIndex, pageSize, out total, id_loai);
        }

        public List<SanphamModel> get_san_pham_by_iddm(int id)
        {
            return _Respo.get_san_pham_by_iddm(id);
        }

        public List<SanphamModel> get_san_pham_search(int pageIndex, int pageSize, out long total, string search)
        {
            return _Respo.get_san_pham_search(pageIndex, pageSize, out total, search);
        }
    }
}
