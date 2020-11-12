using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Helper;
using DAL.Interfaces;
using Model;

namespace DAL
{
    public class SanphamRespo : IsanphamRespo
    {
        private readonly IDatabaseHelper _dbHelper;
        public SanphamRespo(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }
        public List<SanphamModel> Get_ALL_Sanpham()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanphamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        public SanphamModel Get_Sanpham_By_ID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_item_get_by_id",
                     "@item_id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanphamModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanphamModel> Get_Sanpham_lq(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_lq", "@l_id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanphamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanphamModel> Get_Sanpham_New()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_new");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanphamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanphamModel> get_san_pham_by_iddm(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_san_pham_by_iddm", "@iddm", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanphamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanphamModel> get_san_pham_by_iddm()
        {
            throw new NotImplementedException();
        }

        public List<SanphamModel> get_san_pham(int pageIndex, int pageSize, out long total, int id_loai)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_item_search", "@page_index", pageIndex, "@page_size", pageSize, "@item_group_id", id_loai);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0)
                    total =  (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanphamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanphamModel> get_san_pham_search(int pageIndex, int pageSize, out long total, string search)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_item_search_2", "@page_index", pageIndex, "@page_size", pageSize, "@search", search);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0)
                    total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanphamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool create_san_pham(SanphamModel sp)
        {
            try
            {
                string msgErr = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgErr, "create_san_pham", "@tensp", sp.tensp, "@tacgia", sp.tacgia, "@gia", sp.gia,"@soluong", sp.soluong,"@anh", sp.anh,"@ngaynhap", sp.ngaynhap,"@maloai", sp.maloai,"@luotmua", sp.luotmua,"@motangan", sp.motangan,"@mota", sp.mota,"@rate", sp.rate);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool update_san_pham(int id, SanphamModel sp)
        {
            try
            {
                string msgErr = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgErr, "update_san_pham_3", "@masp", sp.masp,"@tensp", sp.tensp, "@tacgia", sp.tacgia, "@gia", sp.gia, "@soluong", sp.soluong, "@anh", sp.anh, "@maloai", sp.maloai, "@motangan", sp.motangan, "@mota", sp.mota);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool delete_san_pham(int id)
        {
            try
            {
                string msgErr = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgErr, "delete_san_pham", "@masp", id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
