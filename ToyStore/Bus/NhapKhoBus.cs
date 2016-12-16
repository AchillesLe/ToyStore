using Dao;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
    public class NhapKhoBus
    {
        NhapKhoDao nkDao = new NhapKhoDao();
        public int addNhapKho(List<NHAPKHO> nks)
        {
            int ck = 0;
            DoChoiDao dcDao = new DoChoiDao();
            foreach(NHAPKHO it in nks)
            {
                ck += nkDao.addNhapKho(it);
                dcDao.addSLDC(it.MADC, (int)it.SL);
            }

            return ck;
        }
    }
}
