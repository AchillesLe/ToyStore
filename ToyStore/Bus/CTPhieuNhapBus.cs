using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dao;

namespace Bus
{
    public class CTPhieuNhapBus
    {
        CTPhieuNhapDao ctDao = new CTPhieuNhapDao();
        public List<CTPHIEUNHAP> dsPhieuNhapByID(int maphieu)
        {
            return ctDao.dsPhieuNhapById(maphieu);
        }
        public bool deleteCTPhieuNhap(CTPHIEUNHAP item)
        {
            bool ck = false;
            DoChoiDao dcDao = new DoChoiDao();
            ck = dcDao.addSLDC(item.MADC, -1 * item.SL);
            ck = ck && ctDao.deleteCTPhieuNhap(item.MAPHIEU);
            return ck;
        }

        public bool editCTPhieuNhap(CTPHIEUNHAP item)
        {
            bool ck = false;

            int delta = item.SL - ctDao.CTPHIEUNHAPbyID(item.MAPHIEU, item.MADC).SL;
            DoChoiDao dcDao = new DoChoiDao();
            ck = dcDao.addSLDC(item.MADC, delta);
            ck = ck && ctDao.editCTPhieuNhap(item);
            return ck;
        }
    }
}
