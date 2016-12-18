using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Dto;

namespace Bus
{
    public class AccountBus
    {
        AccountDao acdao = new AccountDao();
        public List<ACCOUNT> DSACCOUNT()
        {

            return acdao.DSACCOUNT();
        }
        public ACCOUNT ACCOUNTByID(int ID)
        {
            return acdao.ACCOUNTByID(ID);
        }
        public ACCOUNT ACCOUNTByName(string name)
        {
            return acdao.ACCOUNTByName(name);
        }
        public bool Addac(ACCOUNT ac)
        {
            return acdao.AddAc(ac);
        }
        public bool deleteac(int AcID)
        {
            return acdao.deleteac(AcID);
        }
        public bool editac(ACCOUNT ac)
        {
            return acdao.editac(ac);
        }
        public bool checkac(string username, string pass)
        {
            return acdao.checkPass(username, pass);
        }
    }
}
