using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL.Interfaces
{
    public interface IkhachhangRespo
    {

        List<KhachhangModel> Get_ALL_Khachhang();
        KhachhangModel Get_Khachhang_By_ID();

        KhachhangModel Check_login(string email, string pass);
    }
}
