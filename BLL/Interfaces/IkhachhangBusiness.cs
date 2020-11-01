using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IkhachhangBusiness
    {
        List<KhachhangModel> Get_ALL_Khachhang();
        KhachhangModel Get_Khachhang_By_ID();
        KhachhangModel Check_login(string email, string pass);
    }
}
