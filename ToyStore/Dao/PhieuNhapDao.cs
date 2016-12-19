using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class PhieuNhapDao
    {
        public int AddPhieuNhap(PHIEUNHAP pn)
        {
            int s;
            using (ContextEntites cn = new ContextEntites())
            {
                try
                {
                    cn.PHIEUNHAPs.Add(pn);
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
