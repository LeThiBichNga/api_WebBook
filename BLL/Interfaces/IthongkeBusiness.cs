using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL.Interfaces
{
   public interface IthongkeBusiness
    {
        List<SanphamModel> Get_Saphet_Sanpham();
        List<SanphamModel> Get_Het_Sanpham();
        List<SanphamModel> Get_tonkho_Sanpham();
    }
}
