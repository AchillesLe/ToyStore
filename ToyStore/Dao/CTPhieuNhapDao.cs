using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class CTPhieuNhapDao
    {
        public int AddCTPhieuNhap(CTPHIEUNHAP ct)
        {
            int s;
            using (ContextEntites cn = new ContextEntites())
            {
                try
                {
                    cn.CTPHIEUNHAPs.Add(ct);
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


        public List<CTPHIEUNHAP> dsPhieuNhapById(int maphieu)
        {
            List<CTPHIEUNHAP> listCT = new List<CTPHIEUNHAP>();
            using (ContextEntites con = new ContextEntites())
            {
                try
                {
                    var lct = con.CTPHIEUNHAPs.Where(x => x.MAPHIEU == maphieu);
                    foreach(var ct in lct)
                    {
                        CTPHIEUNHAP ctph = new CTPHIEUNHAP();
                        ctph.MAPHIEU = ct.MAPHIEU;
                        ctph.MADC = ct.MADC;
                        ctph.SL = ct.SL;
                        ctph.GIANHAP = ct.GIANHAP;
                        listCT.Add(ctph);
                    }
                }
                catch(Exception ex)
                {

                }
            }
            return listCT;
        }


        public CTPHIEUNHAP CTPHIEUNHAPbyID(int maphieu, int madc)
        {
            CTPHIEUNHAP ct = new CTPHIEUNHAP();
            using (ContextEntites context = new ContextEntites())
            {
                var a = context.CTPHIEUNHAPs.SingleOrDefault(x => x.MAPHIEU == maphieu && x.MADC == madc);
                ct = a;
            }
            return ct;//
        }
        public bool deleteCTPhieuNhap(int maPhieu)
        {
            bool check = false;
            using (ContextEntites con = new ContextEntites())
            {
                try
                {

                    var lpn = con.CTPHIEUNHAPs.Where(x => x.MAPHIEU == maPhieu).ToList();
                    foreach (var pn in lpn)
                    {
                        con.CTPHIEUNHAPs.Remove(pn);
                    }
                    if (con.SaveChanges() > 0)
                        check = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return check;
        }
        public bool deleteCTPhieuNhap(int maPhieu, int madc)
        {
            bool check = false;
            using (ContextEntites con = new ContextEntites())
            {
                try
                {

                    var lpn = con.CTPHIEUNHAPs.Where(x => (x.MAPHIEU == maPhieu && x.MADC == madc)).ToList();
                    foreach (var pn in lpn)
                    {
                        con.CTPHIEUNHAPs.Remove(pn);
                    }
                    if (con.SaveChanges() > 0)
                        check = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return check;
        }

        public bool editCTPhieuNhap(CTPHIEUNHAP ct)
        {
            bool chek = false;
            using (ContextEntites context = new ContextEntites())
            {
                try
                {
                    var s = context.CTPHIEUNHAPs.Single(x => (x.MADC == ct.MADC && x.MAPHIEU == ct.MAPHIEU));
                    s.SL = ct.SL;

                    if (context.SaveChanges() >= 0)
                        chek = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return chek;
            //change
        }
    }
}
