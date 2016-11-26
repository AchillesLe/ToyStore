using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;

namespace Dao
{
    public class HoaDonDao
    {
        public List<HOADON> dsKhachHang()
        {
            List<HOADON> listHD = new List<HOADON>();
            using (ToyEntitesModel context = new ToyEntitesModel())
            {
                var query = (from c in context.HOADONs select new { c.MAHD,c.MAKH,c.MANV,c.NGAYHD,c.TRIGIA });
                foreach (var a in query)
                {
                    HOADON hd = new HOADON();
                    hd.TRIGIA = a.TRIGIA;
                    hd.MANV = a.MANV;
                    hd.NGAYHD = a.NGAYHD;
                    hd.MAKH = a.MAKH;
                    hd.MAHD = a.MAHD;

                    listHD.Add(hd);
                }
            }
            return listHD;
        }
        public HOADON HoaDonById(int id)
        {
            HOADON hd = new HOADON();
            using (ToyEntitesModel context = new ToyEntitesModel())
            {
               var s = context.HOADONs.SingleOrDefault(x => x.MAHD == id);
                hd.MAHD = s.MAHD;
                hd.MAKH = s.MAKH;
                hd.MANV = s.MANV;
                hd.NGAYHD = s.NGAYHD;
                hd.TRIGIA = s.TRIGIA;
            }
          
            return hd;
        }
        //public int AddHoaDon(HOADON hd)
        //{

        //}
    }
}
