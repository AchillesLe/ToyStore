using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
namespace Dao
{
    public class ChucVuDao
    {
        public List<CHUCVU> DSCHUCVU()
        {
            List<CHUCVU> listCV = new List<CHUCVU>();
            using (ContextEntites context = new ContextEntites())
            {
                var query = (from c in context.CHUCVUs select c);
                foreach (var a in query)
                {
                    CHUCVU cv = new CHUCVU();
                    cv.MACV = a.MACV;
                    cv.TENCV = a.TENCV;
                    listCV.Add(cv);
                }
            }
            return listCV;
        }
        public CHUCVU CHUCVUByID(string Macv)
        {
            CHUCVU cv = new CHUCVU();
            using (ContextEntites context = new ContextEntites())
            {
                var a = context.CHUCVUs.SingleOrDefault(x => x.MACV == Macv);
                cv.MACV = a.MACV;
                cv.TENCV = a.TENCV;

            }
            return cv;
        }
        public int AddCV(CHUCVU ac)
        {
            int s;
            using (ContextEntites context = new ContextEntites())
            {
                CHUCVU kh = new CHUCVU();
                kh.MACV = ac.MACV;
                kh.TENCV = ac.TENCV;
                context.CHUCVUs.Add(kh);
                s = context.SaveChanges();
            }
            return s;
        }
        public bool deleteCV(string Macv)
        {
            bool check = false;
            using (ContextEntites con = new ContextEntites())
            {
                try
                {
                    CHUCVU kh = con.CHUCVUs.Single(x => x.MACV == Macv);
                    con.CHUCVUs.Remove(kh);
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
        public bool editCV(CHUCVU kh)
        {
            bool chek = false;
            using (ContextEntites context = new ContextEntites())
            {
                try
                {
                    var s = context.CHUCVUs.Single(x => x.MACV == kh.MACV);
                    s.MACV = kh.MACV;
                    s.TENCV = kh.TENCV;
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
        public CHUCVU GetCVbyName(string name)
        {
            CHUCVU cv = new CHUCVU();
            try
            {
                using (ContextEntites context = new ContextEntites())
                {
                   cv = context.CHUCVUs.SingleOrDefault(x => x.TENCV == name);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return cv;
        }
     
    }
}
