using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL.Interfaces
{
   public interface IhoadonRespo
    {
       List<DonhangModel> Get_ALL_Hoadon();
       HoadonModel Get_Hoadon_By_ID();
       bool Dat_Hang(string maid, string ten_kh, string noi_giao, string sdt, int thanh_tien, List<chitietdonhangModel> listjson_chitiet);
        int Get_tien(int thang, int nam);
    }
}
