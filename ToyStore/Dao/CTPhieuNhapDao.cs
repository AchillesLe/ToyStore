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
    }
}
