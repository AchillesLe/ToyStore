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
        public List<HOADON> dsHoaDon()
        {
            List<HOADON> listHD = new List<HOADON>();
            using (ContextEntites context = new ContextEntites())
            {
                var query = (from c in context.HOADONs select new { c.MAHD,c.MANV,c.NGAYHD,c.TRIGIA });
                foreach (var a in query)
                {
                    HOADON hd = new HOADON();
                    hd.TRIGIA = a.TRIGIA;
                    hd.MANV = a.MANV;
                    hd.NGAYHD = a.NGAYHD;
                    hd.MAHD = a.MAHD;

                    listHD.Add(hd);
                }
            }
            return listHD;
        }
        public List<HOADON> dsHoaDon(DateTime date)
        {
            using (ContextEntites context = new ContextEntites())
            {
                List<HOADON> listhd = new List<HOADON>();
                try
                {
                    var query = from c in context.HOADONs where c.NGAYHD == date select c;
                    foreach(var a in query)
                    {
                        HOADON hd = new HOADON();
                        hd.MAHD = a.MAHD;
                        hd.MANV = a.MANV;
                        hd.NGAYHD = a.NGAYHD;
                        hd.TRIGIA = a.TRIGIA;
                        listhd.Add(hd);
                    }
                    return listhd;
                }
                catch(Exception ex)
                {
                    HOADON hd = new HOADON();
                    hd.MAHD = -1;
                    hd.MANV = -1;
                    hd.NGAYHD = DateTime.Now;
                    hd.TRIGIA = 0;
                    listhd.Add(hd);
                    return listhd;
                }
              
            }
        }
        public List<HOADON> dsHoaDonFromTo(DateTime datefrom, DateTime dateto)
        {
            List<HOADON> listHD = new List<HOADON>();
            using (ContextEntites context = new ContextEntites())
            {
                var query = (from c in context.HOADONs where (c.NGAYHD >= datefrom && c.NGAYHD <= dateto) select new { c.MAHD, c.MANV, c.NGAYHD, c.TRIGIA });
                foreach (var a in query)
                {
                    HOADON hd = new HOADON();
                    hd.TRIGIA = a.TRIGIA;
                    hd.MANV = a.MANV;
                    hd.NGAYHD = a.NGAYHD;
                    hd.MAHD = a.MAHD;

                    listHD.Add(hd);
                }
            }
            return listHD;
        }
        public HOADON HoaDonById(int id)
        {
            HOADON hd = new HOADON();
            using (ContextEntites context = new ContextEntites())
            {
               var s = context.HOADONs.SingleOrDefault(x => x.MAHD == id);
                hd.MAHD = s.MAHD;
                hd.MANV = s.MANV;
                hd.NGAYHD = s.NGAYHD;
                hd.TRIGIA = s.TRIGIA;
            }
          
            return hd;
        }
        public List<HOADON> dsHoaDonById(int id)
        {
            List<HOADON> listHD = new List<HOADON>();
            using (ContextEntites context = new ContextEntites())
            {
                var query = (from c in context.HOADONs where (c.MAHD == id) select new { c.MAHD, c.MANV, c.NGAYHD, c.TRIGIA });
                if(query.Count() > 0)
                foreach (var a in query)
                {
                    HOADON hd = new HOADON();
                    hd.TRIGIA = a.TRIGIA;
                    hd.MANV = a.MANV;
                    hd.NGAYHD = a.NGAYHD;
                    hd.MAHD = a.MAHD;

                    listHD.Add(hd);
                }
            }
            return listHD;
        }
        public int AddHoaDon(HOADON hd)
        {
            int s = 0;
            using (ContextEntites cn = new ContextEntites())
            {
                try
                {
                    cn.HOADONs.Add(hd);

                    var bc = cn.BAOCAOs.Where(x=>(x.NGAYBAOCAO == hd.NGAYHD));

                    if (!(bc.Count() > 0))
                    {
                        BAOCAO b = new BAOCAO();
                        b.NGAYBAOCAO = hd.NGAYHD;
                        b.TONGGIATRI = 0;
                        cn.BAOCAOs.Add(b);
                    }

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
        public bool deleteHD(int maHD)
        {
            bool check = false;
            using (ContextEntites con = new ContextEntites())
            {
                try
                {

                    HOADON hd = con.HOADONs.Single(x => x.MAHD == maHD);
                    con.HOADONs.Remove(hd);
                    

                    if (con.SaveChanges() >= 0)
                    {
                        check = true;
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }           
            }
                return check;
        }
        public bool editHD(HOADON hd)
        {
            bool chek = false;
            using (ContextEntites context=new ContextEntites())
            {
                try
                {
                    var s = context.HOADONs.Single(x => x.MAHD == hd.MAHD);
                    s.MANV = hd.MANV;
                    s.NGAYHD = hd.NGAYHD;
                    s.TRIGIA = hd.TRIGIA;

                    if (context.SaveChanges() >= 0)
                    {       
                        var bc = context.BAOCAOs.SingleOrDefault(x => x.NGAYBAOCAO == hd.NGAYHD );
                        bc.NGAYBAOCAO = hd.NGAYHD;
                        bc.TONGGIATRI += hd.TRIGIA;
                        int m = context.SaveChanges();
                        chek = true;
                    }

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
                return chek;
        }
    }
}
