using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL.Interfaces
{
    public interface IsanphamRespo
    {
        List<SanphamModole> Get_ALL_Sanpham();
        SanphamModole Get_Sanpham_By_ID(int id);
        List<SanphamModole> Get_Sanpham_New();
        List<SanphamModole> Get_Sanpham_lq(int id);
        List<SanphamModole> get_san_pham_by_iddm(int id);
        List<SanphamModole> get_san_pham(int pageIndex, int pageSize, out long total, int id_loai);
        List<SanphamModole> get_san_pham_search(int pageIndex, int pageSize, out long total, string search);
    }
}
