using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;

namespace Dao
{
    public class AccountDao
    {
        public List<ACCOUNT> DSACCOUNT()
        {
            List<ACCOUNT> listac = new List<ACCOUNT>();
            using (ContextEntites context = new ContextEntites())
            {
                var query = (from c in context.ACCOUNTs select c);
                foreach (var a in query)
                {
                    ACCOUNT ac = new ACCOUNT();
                    ac.ID = a.ID;
                    ac.USERNAME = a.USERNAME;
                    ac.PASS = a.PASS;
                    listac.Add(ac);
                }
            }
            return listac;
        }
        public ACCOUNT ACCOUNTByID(int ID)
        {
            ACCOUNT ac = new ACCOUNT();
            using (ContextEntites context = new ContextEntites())
            {
                var a = context.ACCOUNTs.SingleOrDefault(x => x.ID == ID);
                ac.ID = a.ID;
                ac.USERNAME = a.USERNAME;
                ac.PASS = a.PASS;

            }
            return ac;
        }
        public ACCOUNT ACCOUNTByName(string name)
        {
            ACCOUNT ac = new ACCOUNT();
            try
            {
                using (ContextEntites context = new ContextEntites())
                {
                   var c = context.ACCOUNTs.SingleOrDefault(x=>x.USERNAME==name);
                    ac.ID = c.ID;
                    ac.PASS = c.PASS;
                    ac.USERNAME = c.USERNAME;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return ac;
        }
        public int AddAc(ACCOUNT ac)
        {
            int s;
                using (ContextEntites context = new ContextEntites())
                {
                    ACCOUNT kh = new ACCOUNT();
                    kh.ID = ac.ID;
                    kh.PASS = ac.PASS;
                    kh.USERNAME = ac.USERNAME;
                    context.ACCOUNTs.Add(kh);
                    s = context.SaveChanges();
                }

            return s;
        }
        public bool deleteac(int AcID)
        {
            bool check = false;
            using (ContextEntites con = new ContextEntites())
            {
                try
                {
                    ACCOUNT kh = con.ACCOUNTs.Single(x => x.ID == AcID);
                    con.ACCOUNTs.Remove(kh);
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
        public bool editac(ACCOUNT kh)
        {
            bool chek = false;
            using (ContextEntites context = new ContextEntites())
            {
                try
                {
                    var s = context.ACCOUNTs.Single(x => x.ID == kh.ID);
                    s.ID = kh.ID;
                    s.PASS = kh.PASS;
                    s.USERNAME = kh.USERNAME;

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
        public bool checkPass(string username,string pass)
        {
            bool check = false;
            ACCOUNT ac = new ACCOUNT();
            using (ContextEntites context = new ContextEntites())
            {
                try
                {
                   // ACCOUNT ac = context.ACCOUNTs.SingleOrDefault(x => x.USERNAME.Equals(username) && x.PASS.Equals(pass));
                    var query = from c in context.ACCOUNTs where c.USERNAME.Equals( username)
                                && c.PASS.Equals( pass) select c;
                    foreach(var a in query)
                    {
                        ac.ID = a.ID;
                        ac.PASS = a.PASS;
                        ac.USERNAME = a.USERNAME;
                    }
                     if (ac!= null)
                        check = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return check;
        }
    }
}
