using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Dto;
namespace Bus
{
    public class BaoCaoBus
    {
        BaoCaoDao bcdao = new BaoCaoDao();
        public List<BAOCAO> dsBAOCAO()
        {
            return bcdao.dsBAOCAO();
        }
        public List<BAOCAO> dsBAOCAO(DateTime date)
        {
            return bcdao.dsBAOCAO(date);
        }
        public List<BAOCAO> dsBAOCAO(DateTime dayfrom,DateTime dayto)
        {
            return bcdao.dsBAOCAOFromTo(dayfrom, dayto);
        }
        public int AddBaoCao(BAOCAO bc)
        {
            return bcdao.AddBAOCAO(bc);
        }
    }
}
