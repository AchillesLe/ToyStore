using Dao;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
    public class PhieuNhapBus
    {
        PhieuNhapDao phDao = new PhieuNhapDao();
        public List<PHIEUNHAP> dsPhieuNhap()
        {
            return phDao.dsPhieuNhap();
        }

        public List<PHIEUNHAP> dsPhieuNhap(DateTime from, DateTime to)
        {
            return phDao.dsPhieuNhap(from, to);
        }

        public int AddPhieuNhap(PHIEUNHAP pn, List<CTPHIEUNHAP> listCt)
        {
            int c = 0;
            c = phDao.AddPhieuNhap(pn);
            CTPhieuNhapDao ctDao = new CTPhieuNhapDao();
            DoChoiDao dcDao = new DoChoiDao();
            foreach (CTPHIEUNHAP it in listCt)
            {
                it.MAPHIEU = pn.MAPHIEU;
                c += ctDao.AddCTPhieuNhap(it);
                c += dcDao.addSLDC(it.MADC, it.SL) ? 1 : 0;
            }
            return c;
        }

        public bool deletePhieuNhap(int maPhieu)
        {
            CTPhieuNhapDao ctDao = new CTPhieuNhapDao();
            bool ck = false;
            ck = ctDao.deleteCTPhieuNhap(maPhieu);
            ck = ck && phDao.deletePhieuNhap(maPhieu);
            
            return ck;
        }
    }
}
