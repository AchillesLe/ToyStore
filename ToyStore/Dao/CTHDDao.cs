using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
namespace Dao
{
    public class CTHDDao
    {
        public List<CTHD> DSNhanVien()
        {
            List<CTHD> listCTHD = new List<CTHD>();
            using (ToyEntitesModel context = new ToyEntitesModel())
            {
                var query = (from c in context.CTHDs select c);
                foreach (var c in query)
                {
                    CTHD ct = new CTHD();
                    // nv.
                    ct.MADC = c.MADC;
                    ct.MAHD = c.MAHD;
                    ct.SL = c.SL;
                    listCTHD.Add(ct);
                }
            }
            return listCTHD;
        }
        public CTHD CTHDbyID(int mahd,int madc)
        {
            CTHD ct = new CTHD();
            using (ToyEntitesModel context = new ToyEntitesModel())
            {
                var a = context.CTHDs.SingleOrDefault(x => x.MAHD == mahd && x.MADC==madc);
                ct.MADC = a.MADC;
                
            }
            return nv;//
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
                catch (Exception ex)
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
    }
}
