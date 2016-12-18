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
                    bc.MABC = a.MABC;

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
                        bc.MABC = a.MABC;
                        bc.NGAYBAOCAO = a.NGAYBAOCAO;
                        bc.TONGGIATRI = a.TONGGIATRI;
                        listbc.Add(bc);
                    }
                   
                }
                catch (Exception ex)
                {
                    //BAOCAO bc = new BAOCAO();
                    //bc.MABC = -1;
                    //bc.NGAYBAOCAO = DateTime.Now;
                    //bc.TONGGIATRI = 0;
                    //listbc.Add(bc);
                    //return listbc;
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
                    bc.MABC = a.MABC;
                    bc.NGAYBAOCAO = a.NGAYBAOCAO;
                    listbc.Add(bc);
                }
            }
            return listbc;
        }
        public BAOCAO BAOCAOById(int id)
        {
            BAOCAO bc = new BAOCAO();
            using (ContextEntites context = new ContextEntites())
            {
                var s = context.BAOCAOs.SingleOrDefault(x => x.MABC == id);
                bc.NGAYBAOCAO = s.NGAYBAOCAO;
                bc.TONGGIATRI = s.TONGGIATRI;
                bc.MABC = s.MABC;
            }

            return bc;
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
        public bool deletebc(int mabc)
        {
            bool check = false;
            using (ContextEntites con = new ContextEntites())
            {
                try
                {

                    BAOCAO bc = con.BAOCAOs.Single(x => x.MABC == mabc);
                    con.BAOCAOs.Remove(bc);
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
        public bool editbc(BAOCAO bc)
        {
            bool chek = false;
            using (ContextEntites context = new ContextEntites())
            {
                try
                {
                    var s = context.BAOCAOs.Single(x => x.MABC == bc.MABC);
                    s.NGAYBAOCAO = bc.NGAYBAOCAO;
                    s.TONGGIATRI = bc.TONGGIATRI;
                    s.MABC = bc.MABC;
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
