using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class PhieuNhapDao
    {
        public List<PHIEUNHAP> dsPhieuNhap()
        {
            List<PHIEUNHAP> listPhieuPhap = new List<PHIEUNHAP>();
            using (ContextEntites context = new ContextEntites())
            {
                var query = (from c in context.PHIEUNHAPs where c.TONGGIA>0 select c);
                foreach (var a in query)
                {
                    PHIEUNHAP phieu = new PHIEUNHAP();
                    phieu.MANV = a.MANV;
                    phieu.MAPHIEU = a.MAPHIEU;
                    phieu.NGAYNHAP = a.NGAYNHAP;
                    phieu.TONGGIA = a.TONGGIA;

                    listPhieuPhap.Add(phieu);
                }
            }
            return listPhieuPhap;
        }

        public List<PHIEUNHAP> dsPhieuNhap(DateTime date_from, DateTime date_to)
        {
            List<PHIEUNHAP> listPhieuPhap = new List<PHIEUNHAP>();
            using (ContextEntites context = new ContextEntites())
            {
                var query = (from c in context.PHIEUNHAPs
                             where c.NGAYNHAP >= date_from && c.NGAYNHAP <= date_to
                             select c);

                foreach (var a in query)
                {
                    PHIEUNHAP phieu = new PHIEUNHAP();
                    phieu.MANV = a.MANV;
                    phieu.MAPHIEU = a.MAPHIEU;
                    phieu.NGAYNHAP = a.NGAYNHAP;
                    phieu.TONGGIA = a.TONGGIA;

                    listPhieuPhap.Add(phieu);
                }
            }
            return listPhieuPhap;
        }

        public int AddPhieuNhap(PHIEUNHAP pn)
        {
            int s;
            using (ContextEntites cn = new ContextEntites())
            {
                try
                {
                    cn.PHIEUNHAPs.Add(pn);
                    s = cn.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    s = 0;
                }
            }
            return s;
        }

        public bool deletePhieuNhap(int maPhieu)
        {
            bool check = false;
            using (ContextEntites con = new ContextEntites())
            {
                try
                {

                    PHIEUNHAP pn = con.PHIEUNHAPs.Single(x => x.MAPHIEU == maPhieu);
                    con.PHIEUNHAPs.Remove(pn);
                    if (con.SaveChanges() >= 0)
                    {
                        check = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return check;
        }
    }
}
