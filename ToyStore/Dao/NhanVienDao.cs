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
            using (ToyEntitesModel context =new ToyEntitesModel())
            {
                var query = (from c in context.NHANVIENs select new { c.CMT,c.MANV,c.NGAYSINH,c.PHAI,c.TENNV,c.SDT,c.PASS});
                 foreach(var a in query)
                {
                    NHANVIEN nv = new NHANVIEN();
                    nv.CMT = a.CMT;
                    nv.TENNV = a.TENNV;
                    nv.SDT = a.SDT;
                    nv.PHAI = a.PHAI;
                    nv.PASS = a.PASS;
                    nv.NGAYSINH = a.NGAYSINH;
                    nv.MANV = a.MANV;
                    listNv.Add(nv);
                }                
            }
            return listNv;
        }
        public NHANVIEN NhanVienByID(int ID)
        {
            NHANVIEN nv = new NHANVIEN();
            using (ToyEntitesModel context = new ToyEntitesModel())
            {
                var a = context.NHANVIENs.SingleOrDefault(x => x.MANV==ID);
                nv.MANV = a.MANV;
                nv.NGAYSINH = a.NGAYSINH;
                nv.PASS = a.PASS;
                nv.PHAI = a.PHAI;
                nv.TENNV = a.TENNV;
                nv.SDT = a.SDT;
                nv.CMT = a.CMT;
            }
            return nv;
        }
        public int addNV(NHANVIEN nv)
        {
            int s;
            using (ToyEntitesModel context = new ToyEntitesModel())
            {
                var a = context.NHANVIENs.Add(nv);
                s = context.SaveChanges();   
            }
            return s;
        }
        public bool deleteNV(int maNV)
        {
            bool check = false;
            using (ToyEntitesModel con = new ToyEntitesModel())
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
            using (ToyEntitesModel context = new ToyEntitesModel())
            {
                try
                {
                    var s = context.NHANVIENs.Single(x => x.MANV == kh.MANV);
                    s.TENNV = kh.TENNV;
                    s.SDT = kh.SDT;
                    s.PHAI = kh.PHAI;
                    s.CMT = kh.CMT;
                    s.NGAYSINH = kh.NGAYSINH;
                    s.PASS = kh.PASS;
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
        public bool checkPass(int manv,string pass)
        {
            bool check = false;
            using (ToyEntitesModel context = new ToyEntitesModel())
            {
                try
                {

                    var query = from c in context.NHANVIENs where c.MANV == manv && c.PASS == pass select c;
                    if (query != null)
                        check = true;
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
