using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Dto;
namespace Bus
{
   public class ChucVuBus
    {

        ChucVuDao cvdao = new ChucVuDao();
        public List<CHUCVU> DSCHUCVU()
        {

            return cvdao.DSCHUCVU();
        }
        public CHUCVU CHUCVUByID(string macv)
        {
            return cvdao.GETChucVuByID(macv);
        }
        public int AddCV(CHUCVU cv)
        {
            return cvdao.AddCV(cv);
        }
        public bool deleteac(string macv)
        {
            return cvdao.deleteCV(macv);
        }
        public bool editCV(CHUCVU ac)
        {
            return cvdao.editCV(ac);
        }
        public CHUCVU GetCVbyName(string name)
        {
            return cvdao.GetCVbyName(name);
        }
    }
}
