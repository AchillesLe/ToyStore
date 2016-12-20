using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
namespace Dao
{
    public class BaoCaoDao
    {
        public List<BAOCAO> dsBAOCAO()
        {
            List<BAOCAO> listbc = new List<BAOCAO>();
            using (ContextEntites context = new ContextEntites())
            {
                var query = (from c in context.BAOCAOs select c);
                foreach (var a in query)
                {
                    BAOCAO bc = new BAOCAO();
                    bc.TONGGIATRI = a.TONGGIATRI;
                    bc.NGAYBAOCAO = a.NGAYBAOCAO;

                    listbc.Add(bc);
                }
            }
            return listbc;
        }
        public List<BAOCAO> dsBAOCAO(DateTime date)
        {
            using (ContextEntites context = new ContextEntites())
            {
                List<BAOCAO> listbc = new List<BAOCAO>();
                try
                {
                    var query = from c in context.BAOCAOs where c.NGAYBAOCAO == date select c;
                    foreach (var a in query)
                    {
                        BAOCAO bc = new BAOCAO();
                        bc.NGAYBAOCAO = a.NGAYBAOCAO;
                        bc.TONGGIATRI = a.TONGGIATRI;
                        listbc.Add(bc);
                    }
                    return listbc;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return listbc;
            }
        }
        public List<BAOCAO> dsBAOCAOFromTo(DateTime datefrom, DateTime dateto)
        {
            List<BAOCAO> listbc = new List<BAOCAO>();
            using (ContextEntites context = new ContextEntites())
            {
                var query = (from c in context.BAOCAOs where (c.NGAYBAOCAO >= datefrom && c.NGAYBAOCAO <= dateto) select c);
                foreach (var a in query)
                {
                    BAOCAO bc = new BAOCAO();
                    bc.TONGGIATRI = a.TONGGIATRI;
                    bc.NGAYBAOCAO = a.NGAYBAOCAO;
                    listbc.Add(bc);
                }
            }
            return listbc;
        }
        public int AddBAOCAO(BAOCAO bc)
        {
            int s;
            using (ContextEntites cn = new ContextEntites())
            {
                try
                {
                    cn.BAOCAOs.Add(bc);
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
        public bool editbc(BAOCAO bc)
        {
            bool chek = false;
            using (ContextEntites context = new ContextEntites())
            {
                try
                {
                    var s = context.BAOCAOs.Single(x => x.NGAYBAOCAO == bc.NGAYBAOCAO);
                    s.NGAYBAOCAO = bc.NGAYBAOCAO;
                    s.TONGGIATRI = bc.TONGGIATRI;
                    if (context.SaveChanges() >= 0)
                        chek = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return chek;
        }
    }
}
