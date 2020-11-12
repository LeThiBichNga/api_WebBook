using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Helper;
using DAL.Interfaces;
using Model;

namespace DAL
{
  public  class TintucRespo: ItintucRespo
    {
        private readonly IDatabaseHelper _dbHelper;
        public TintucRespo(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }

      
        public List<TintucModel> Get_ALL_Tintuc()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_tintuc_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TintucModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TintucModel get_chitiettintuc_by_id(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_chitiettintuc_by_id",
                     "@ctt_id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TintucModel>().SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TintucModel> Get_Tintuc_New()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_tintuc_new");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TintucModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
          public bool create_tin_tuc(TintucModel tt)
        {
            try
            {
                string msgErr = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgErr, "create_tin_tuc", "@tieude", tt.tieude, "@hinhanh", tt.hinhanh, "@tomtat", tt.tomtat, "@noidung", tt.noidung, "@ngaydang", tt.ngaydang);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool delete_tin_tuc(int id)
        {
            try
            {
                string msgErr = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgErr, "delete_tin_tuc", "@matt", id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool update_tin_tuc(int id, TintucModel tt)
        {
            try
            {
                string msgErr = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgErr, "update_tin_tuc", "@matt", tt.matt, "@tieude", tt.tieude, "@hinhanh", tt.hinhanh, "@tomtat", tt.tomtat, "@noidung", tt.noidung, "@ngaydang", tt.ngaydang);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        TintucModel ItintucRespo.Get_Tintuc_By_ID()
        {
            throw new NotImplementedException();
        }
    }
}
