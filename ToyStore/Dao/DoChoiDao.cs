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
            using (ToyEntitesModel context = new ToyEntitesModel())
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
            using (ToyEntitesModel context = new ToyEntitesModel())
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
            using (ToyEntitesModel context = new ToyEntitesModel())
            {
                context.DOCHOIs.Add(dc);
                s = context.SaveChanges();            
            }
            return s;
        }
    }
}
