using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL.Interfaces
{
    public interface ItintucBusiness
    {
        List<TintucModel> Get_ALL_Tintuc();
       TintucModel Get_Tintuc_By_ID();
        List<TintucModel> Get_tintuc_new();
        TintucModel get_chitiettintuc_by_id(int id);
    }
}
