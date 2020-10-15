﻿using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL.Interfaces
{
    public interface IsanphamRespo
    {
        List<SanphamModel> Get_ALL_Sanpham();
        SanphamModel Get_Sanpham_By_ID(int id);
        List<SanphamModel> Get_Sanpham_New();
        List<SanphamModel> Get_Sanpham_lq(int id);
        List<SanphamModel> get_san_pham_by_iddm(int id);
    }
}
