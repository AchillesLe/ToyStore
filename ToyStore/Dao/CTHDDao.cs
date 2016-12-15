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
        public List<CTHD> DSChiTIET()
        {
            List<CTHD> listCTHD = new List<CTHD>();
            using (ContextEntites context = new ContextEntites())
            {
                var query = (from c in context.CTHDs select c);
                foreach (var c in query)
                {
                    CTHD ct = new CTHD();
                    // nv.
                    ct.MADC = c.MADC;
                    ct.MAHD = c.MAHD;
                    ct.SL = c.SL;
                    ct.GIA = c.GIA;
                    listCTHD.Add(ct);
                }
            }
            return listCTHD;
        }
        public List<CTHD> DSChiTIET(int mahd)
        {
            List<CTHD> listCTHD = new List<CTHD>();
            using (ContextEntites context = new ContextEntites())
            {
                var query = (from c in context.CTHDs where c.MAHD == mahd select c);
                foreach (var c in query)
                {
                    CTHD ct = new CTHD();
                    // nv.
                    ct.MADC = c.MADC;
                    ct.MAHD = c.MAHD;
                    ct.SL = c.SL;
                    ct.GIA = c.GIA;
                    listCTHD.Add(ct);
                }
            }
            return listCTHD;
        }
        public CTHD CTHDbyID(int mahd,int madc)
        {
            CTHD ct = new CTHD();
            using (ContextEntites context = new ContextEntites())
            {
                var a = context.CTHDs.SingleOrDefault(x => x.MAHD == mahd && x.MADC==madc);
                ct.MADC = a.MADC;
                
            }
            return ct;//
        }
        public int addCTHD(CTHD ct)
        {
            int s;
            CTHD add = new CTHD();
            add.MAHD = ct.MAHD;
            add.MADC = ct.MADC;
            add.SL = ct.SL;
            add.GIA = ct.GIA;
            using (ContextEntites context = new ContextEntites())
            {
                var a = context.CTHDs.Add(add);
                s = context.SaveChanges();
            }
            return s;
        }
        public int addCTHDs(List<CTHD> cts)
        {
            int s = 0;
            foreach(CTHD ct in cts)
            {
                
                using (ContextEntites context = new ContextEntites())
                {
                    var a = context.CTHDs.Add(ct);
                    s += context.SaveChanges();
                }
            }
            return s;
        }
        public bool deleteCTHD(int mahd, int madc)
        {
            bool check = false;
            using (ContextEntites con = new ContextEntites())
            {
                try
                {
                    CTHD ct = con.CTHDs.Single(x => (x.MADC == madc && x.MAHD == mahd));
                    con.CTHDs.Remove(ct);
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
        public bool deleteCTHD(int mahd)
        {
            bool check = false;
            using (ContextEntites con = new ContextEntites())
            {
                try
                {
                    var cts = con.CTHDs.Where(x => (x.MAHD == mahd));
                    foreach(CTHD ct in cts)
                    {
                        con.CTHDs.Remove(ct);
                    }
                    
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
        public bool editCTHD(CTHD ct)
        {
            bool chek = false;
            using (ContextEntites context = new ContextEntites())
            {
                try
                {
                    var s = context.CTHDs.Single(x => (x.MADC == ct.MADC && x.MAHD == ct.MAHD));
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
