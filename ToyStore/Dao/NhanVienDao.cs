using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
namespace Dao
{
    public class NhanVienDao
    {
        public List<NHANVIEN>DSNhanVien()
        {
            List<NHANVIEN> listNv = new List<NHANVIEN>();
            using (ContextEntites context =new ContextEntites())
            {
                var query = (from c in context.NHANVIENs select new
                { c.CMT,c.MANV,c.NGAYSINH,c.PHAI,c.SDT,c.TENNV,c.QUEQUAN,c.MACV ,c.NGAYVAOLAM } );
                 foreach(var a in query)
                {
                    NHANVIEN nv = new NHANVIEN();
                    nv.CMT = a.CMT;
                    nv.TENNV = a.TENNV;
                    nv.SDT = a.SDT;
                    nv.PHAI = a.PHAI;
                    nv.MACV = a.MACV;
                    nv.NGAYSINH = a.NGAYSINH;
                    nv.MANV = a.MANV;
                    nv.QUEQUAN = a.QUEQUAN;
                    nv.NGAYVAOLAM = a.NGAYVAOLAM;
                    listNv.Add(nv);//
                }                
            }
            return listNv;
        }
        public NHANVIEN NhanVienByID(int ID)
        {
            NHANVIEN nv = new NHANVIEN();
            using (ContextEntites context = new ContextEntites())
            {
                var a = context.NHANVIENs.SingleOrDefault(x => x.MANV==ID);
                nv.MANV = a.MANV;
                nv.NGAYSINH = a.NGAYSINH;
                nv.MACV = a.MACV;
                nv.PHAI = a.PHAI;
                nv.TENNV = a.TENNV;
                nv.SDT = a.SDT;
                nv.CMT = a.CMT;
                nv.QUEQUAN = a.QUEQUAN;
            }
            return nv;
        }
        public int addNV(NHANVIEN nv)
        {
            int s;
            using (ContextEntites context = new ContextEntites())
            {
                NHANVIEN  kh = new NHANVIEN();
                kh.MANV = nv.MANV;
                kh.CMT = nv.CMT;
                kh.NGAYSINH = nv.NGAYSINH;
                kh.MACV = nv.MACV;
                kh.PHAI = nv.PHAI;
                kh.QUEQUAN = nv.QUEQUAN;
                kh.SDT = nv.SDT;
                kh.NGAYVAOLAM = nv.NGAYVAOLAM;
                kh.TENNV = nv.TENNV;
                 context.NHANVIENs.Add(kh);
                s = context.SaveChanges();   
            }
            return s;
        }
        public bool deleteNV(int maNV)
        {
            bool check = false;
            using (ContextEntites con = new ContextEntites())
            {
                try
                {
                    NHANVIEN kh = con.NHANVIENs.Single(x => x.MANV == maNV);
                    con.NHANVIENs.Remove(kh);
                    if (con.SaveChanges() >= 0)
                    {
                        check = true;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return check;
        }
        public bool editNV(NHANVIEN kh)
        {
            bool chek = false;
            using (ContextEntites context = new ContextEntites())
            {
                try
                {
                    var s = context.NHANVIENs.Single(x => x.MANV == kh.MANV);
                    s.TENNV = kh.TENNV;
                    s.SDT = kh.SDT;
                    s.PHAI = kh.PHAI;
                    s.CMT = kh.CMT;
                    s.MACV = kh.MACV;
                    s.NGAYVAOLAM = kh.NGAYVAOLAM;
                    s.NGAYSINH = kh.NGAYSINH;
                    s.QUEQUAN = kh.QUEQUAN;
                   
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
