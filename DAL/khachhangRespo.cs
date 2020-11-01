using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using Model;
using DAL.Helper;
using System.Linq;

namespace DAL
{
    public class khachhangRespo : IkhachhangRespo
    {
        private readonly IDatabaseHelper _dbHelper;
        public khachhangRespo(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }

        public KhachhangModel Check_login(string email, string pass)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "check_login", "@username",email, "@password",pass);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhachhangModel>().SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<KhachhangModel> Get_ALL_Khachhang()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_khachhang_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhachhangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public KhachhangModel Get_Khachhang_By_ID()
        {
            throw new NotImplementedException();
        }
    }
}
