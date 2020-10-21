using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
    public class TintucBusiness : ItintucBusiness
    {
        private readonly ItintucRespo _Respo;
        public TintucBusiness(ItintucRespo respo)
        {
            _Respo = respo;
        }


        public List<TintucModel> Get_tintuc_new()
        {
            return _Respo.Get_Tintuc_New();
        }

        List<TintucModel> ItintucBusiness.Get_ALL_Tintuc()
        {
            return _Respo.Get_ALL_Tintuc();
        }

        TintucModel ItintucBusiness.get_chitiettintuc_by_id(int id)
        {
            return _Respo.get_chitiettintuc_by_id(id);
        }

        TintucModel ItintucBusiness.Get_Tintuc_By_ID()
        {
            return _Respo.Get_Tintuc_By_ID();
        }

      
    }
}
