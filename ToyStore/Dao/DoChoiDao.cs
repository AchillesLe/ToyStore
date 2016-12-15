using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
namespace Dao
{
    public class DoChoiDao
    {
        
        public List<DOCHOI>DSDoChoi()
        {
            List<DOCHOI> listDoChoi = new List<DOCHOI>();
            using (ContextEntites context = new ContextEntites())
            {
                var query = (from c in context.DOCHOIs select new { c.MADC, c.SL, c.TENDC, c.NUOCSX,c.LOAI,c.GIA });
                foreach(var a in query)
                {
                    DOCHOI dc = new DOCHOI();
                    dc.MADC = a.MADC;
                    dc.NUOCSX = a.NUOCSX;
                    dc.SL = a.SL;
                    dc.TENDC = a.TENDC;
                    dc.LOAI = a.LOAI;
                    dc.GIA = a.GIA;

                    listDoChoi.Add(dc);
                }               
            }
            return listDoChoi;
        }
        public DOCHOI DochoiById(int ID)
        {
            DOCHOI dc = new DOCHOI();
            using (ContextEntites context = new ContextEntites())
            {
                var a= context.DOCHOIs.Single(x => x.MADC == ID);               
                dc.MADC = a.MADC;
                dc.NUOCSX = a.NUOCSX;
                dc.SL = a.SL;
                dc.TENDC = a.TENDC;
                dc.LOAI = a.LOAI;
                dc.GIA = a.GIA;      
            }
            return dc;
        }
        public int AddDoChoi(DOCHOI dc)
        {
            int s;
            using (ContextEntites context = new ContextEntites())
            {
                //try
                //{
                    context.DOCHOIs.Add(dc);
                    s = context.SaveChanges();
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e.ToString());
                //}          
            }
            return s;
        }
        public bool deleteDC(int maDC)
        {
            bool check = false;
            using (ContextEntites con = new ContextEntites())
            {
                try
                {
                    DOCHOI hd = con.DOCHOIs.Single(x => x.MADC == maDC);
                    con.DOCHOIs.Remove(hd);
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
        public bool editDC(DOCHOI dc)
        {
            bool chek = false;
            using (ContextEntites context = new ContextEntites())
            {
                try
                {
                    var s = context.DOCHOIs.Single(x => x.MADC == dc.MADC);
                    s.TENDC = dc.TENDC;
                    s.SL = dc.SL;
                    s.NUOCSX = dc.NUOCSX;
                    s.LOAI = dc.LOAI;
                    s.GIA = dc.GIA;
                    if (context.SaveChanges() >= 0)
                        chek = true;
                }
                catch(Exception ec)
                {
                    Console.WriteLine(ec.ToString());
                }
            }
            return chek;
        }
        public bool reduceDC(DOCHOI dc, int sl)
        {
            bool chek = false;
            using (ContextEntites context = new ContextEntites())
            {
                try
                {
                    var s = context.DOCHOIs.Single(x => x.MADC == dc.MADC);
                    s.SL = dc.SL - sl;
                    if (context.SaveChanges() >= 0)
                        chek = true;
                }
                catch (Exception ec)
                {
                    Console.WriteLine(ec.ToString());
                }
            }
            return chek;
        }
    }
}
