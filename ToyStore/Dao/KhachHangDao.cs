using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
namespace Dao
{
    public class KhachHangDao
    {
        public List<KHACHHANG> dsKhachHang()
        {
            List<KHACHHANG> listKhanghang = new List<KHACHHANG>();
            using (ContextEntites context = new ContextEntites())
            {
                var query = (from c in context.KHACHHANGs select new {c.CMT,c.DIEMTL,c.MAKH,c.SDT,c.TENKH });
                foreach (var a in query)
                {
                    KHACHHANG kh = new KHACHHANG();
                    kh.CMT = a.CMT;
                    kh.DIEMTL = a.DIEMTL;
                    kh.MAKH = a.MAKH;
                    kh.TENKH = a.TENKH;
                    kh.SDT = a.SDT;

                    listKhanghang.Add(kh);
                }             
            }
            return listKhanghang;
        }
        public KHACHHANG KhachHangById(int id)
        {
            KHACHHANG kh = new KHACHHANG();
            using (ContextEntites context = new ContextEntites())
            {
                KHACHHANG khachhang = context.KHACHHANGs.SingleOrDefault(x=>x.MAKH==id);
            }            
                return kh;
        }
        public int AddKH(KHACHHANG kh)
        {
            int s;
            using (ContextEntites cn = new ContextEntites())
            {
                cn.KHACHHANGs.Add(kh);
                s = cn.SaveChanges();
            }
            return s;
        }
        public bool deleteKH(int maKH)
        {
            bool check = false;
            using (ContextEntites con = new ContextEntites())
            {
                try
                {
                    KHACHHANG kh = con.KHACHHANGs.Single(x => x.MAKH == maKH);
                    con.KHACHHANGs.Remove(kh);
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
        public bool editKH(KHACHHANG kh)
        {
            bool chek = false;
            using (ContextEntites context = new ContextEntites())
            {
                try
                {
                    var s = context.KHACHHANGs.Single(x => x.MAKH == kh.MAKH);
                    s.TENKH = kh.TENKH;
                    s.SDT = kh.SDT;
                    s.DIEMTL = kh.DIEMTL;
                    s.CMT = kh.CMT;

                    if (context.SaveChanges() >= 0)
                        chek = true;
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return chek;
        }
        //fhjshfjkas
    }
}
