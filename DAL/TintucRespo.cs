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

        TintucModel ItintucRespo.Get_Tintuc_By_ID()
        {
            throw new NotImplementedException();
        }
    }
}
