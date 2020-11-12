using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL.Interfaces
{
    public interface IsanphamBusiness
    {
        List<SanphamModel> Get_ALL_Sanpham();
        SanphamModel Get_Sanpham_By_ID(int id);
        List<SanphamModel> Get_Sanpham_New();
        List<SanphamModel> Get_Sanpham_lq(int id);
        List<SanphamModel> get_san_pham_by_iddm(int id);
        List<SanphamModel> get_san_pham(int pageIndex, int pageSize, out long total, int id_loai);
        List<SanphamModel> get_san_pham_search(int pageIndex, int pageSize, out long total, string search);
        bool create_san_pham(SanphamModel sp);
        bool update_san_pham(int id, SanphamModel sp);
        bool delete_san_pham(int id);
    }
}
