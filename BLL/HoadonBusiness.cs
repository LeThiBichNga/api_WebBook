using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
    public class HoadonBusiness : IhoadonBusiness
    {
        private readonly IhoadonRespo _Respo;
        public HoadonBusiness(IhoadonRespo respo)
        {
            _Respo = respo;
        }

        public bool Dat_Hang(string maid, string ten_kh, string noi_giao, string sdt, int thanh_tien, List<chitietdonhangModel> listjson_chitiet)
        {
            return _Respo.Dat_Hang(maid, ten_kh, noi_giao, sdt, thanh_tien,listjson_chitiet);
        }

        public List<DonhangModel> Get_ALL_Hoadon()
        {
            return _Respo.Get_ALL_Hoadon();
        }

        public HoadonModel Get_Hoadon_By_ID()
        {
            throw new NotImplementedException();
        }

        public int Get_tien(int thang, int nam)
        {
            return _Respo.Get_tien(thang, nam);
        }
    }
}
