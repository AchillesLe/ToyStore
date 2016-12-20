using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dao;
namespace Bus
{
    public class DoChoiBus
    {
        DoChoiDao dcdao = new DoChoiDao();
        public List<DOCHOI> dsDoChoi()
        {
            return dcdao.DSDoChoi();
        }

        public List<DOCHOI> DSDoChoibyID(int madc)
        {
            return dcdao.DSDoChoibyID(madc);
        }

        public DOCHOI DochoiById(int ID)
        {

            return dcdao.DochoiById(ID);
        }

        public int AddDoChoi(DOCHOI dc)
        {
            return dcdao.AddDoChoi(dc);
        }
        public int AddDSDoChoi(List<DOCHOI> list)
        {
            int i = 0;
            foreach (DOCHOI dc in list)
            {
                dcdao.AddDoChoi(dc);
                i++;
            }
            return i;
        }
        public bool deleteDC(int madc)
        {
            return dcdao.deleteDC(madc);
        }

        public bool editDC(DOCHOI dc)
        {
            return dcdao.editDC(dc);
        }

        public bool reduceDCs(List<DOCHOI> dcs)
        {
            bool a = true;
            foreach (DOCHOI dc in dcs)
            {
                a = (a && dcdao.reduceDC(dc, (int)dc.SL));
            }
            return a;
        }
    }
}
