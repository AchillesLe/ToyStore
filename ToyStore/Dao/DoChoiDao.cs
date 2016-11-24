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
            using (ToyEntityModel context = new ToyEntityModel())
            {
                var query = (from c in context.DOCHOIs select c).ToList();
                foreach(var a in query)
                {
                    DOCHOI dc = new DOCHOI();
                    dc.MADC = a.MADC;
                    dc.NUOCSX = a.NUOCSX;
                    dc.SL = a.SL;
                    dc.TENDC = a.TENDC;

                    listDoChoi.Add(dc);
                }
                return listDoChoi;

            }
               
        }

    }
}
