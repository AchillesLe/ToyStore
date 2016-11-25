﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dao;
namespace Bus
{
    public class DoChoiBus
    {
        DoChoiDao dcdao = new DoChoiDao();
        public List<DOCHOI>dsDoChoi()
        {
            return dcdao.DSDoChoi();
        }
        public DOCHOI DochoiById(int ID)
        {

            return dcdao.DochoiById(ID);
        }
        public int AddDoChoi(DOCHOI dc)
        {
            return dcdao.AddDoChoi(dc);
        }
    }
}
