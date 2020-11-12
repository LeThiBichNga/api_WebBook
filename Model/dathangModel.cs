using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class dathangModel
    {
        public string maid { get; set; }
        public string ten_kh { get; set; }
        public string noi_giao { get; set; }
        public string sdt { get; set; }
        public int thanh_tien { get; set; }
        public List<chitietdonhangModel> listjson_chitiet { get; set; }
    }
}
