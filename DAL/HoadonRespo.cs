using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Helper;
using DAL.Interfaces;
using Model;

namespace DAL
{
    public class HoadonRespo : IhoadonRespo
    {
        private readonly IDatabaseHelper _dbHelper;
        public HoadonRespo(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }
        public List<DonhangModel> Get_ALL_Hoadon()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_don_hang_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DonhangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HoadonModel Get_Hoadon_By_ID()
        {
            throw new NotImplementedException();
        }
        public bool Dat_Hang(string maid, string ten_kh, string noi_giao, string sdt, int thanh_tien, List<chitietdonhangModel> listjson_chitiet)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_dat_hang_create", "@ma_hoa_don", maid, "@ngay_dat", DateTime.Now, "@ten_kh", ten_kh, "@noi_giao", noi_giao, "@sdt", sdt, "@thanh_tien",thanh_tien, "@listjson_chitiet", listjson_chitiet != null ? MessageConvert.SerializeObject(listjson_chitiet) : null);
                if (!string.IsNullOrEmpty(msgError)||(!string.IsNullOrEmpty(dt.ToString())&&dt!=null))
                    throw new Exception(msgError);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Get_tien(int thang, int nam)
        {
            string msgError = "";
            var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_don_hang_all");
            var ds = result.ConvertTo<DonhangModel>().ToList();
            int s = ds.Where(x=>x.tinhtrang==1&&x.ngaydat.Year == nam&&x.ngaydat.Month == thang).Sum(x=>x.thanhtien);
            return s;
        }
    }
}
