using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL.Interfaces
{
   public interface ItintucRespo
    {
        List<TintucModel> Get_ALL_Tintuc();
        TintucModel Get_Tintuc_By_ID();
        List<TintucModel> Get_Tintuc_New();
        TintucModel get_chitiettintuc_by_id(int id);
    }
}
