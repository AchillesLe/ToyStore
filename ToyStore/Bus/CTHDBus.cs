using Dao;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
    public class CTHDBus
    {
        CTHDDao ctHdDao = new CTHDDao();
        public List<CTHD> DSChiTiet()
        {
            return ctHdDao.DSChiTIET();
        }
        public List<CTHD> DSChiTiet(int mahd)
        {
            return ctHdDao.DSChiTIET(mahd);
        }
        public CTHD CTHDbyID(int mahd, int madc)
        {
            return ctHdDao.CTHDbyID(mahd, madc);
        }
        public int addCTHD(CTHD ct)
        {
            return ctHdDao.addCTHD(ct);
        }
        public int addCTHDs(List<CTHD> cts)
        {
            return ctHdDao.addCTHDs(cts);
        }
        public bool deleteCTHD(int mahd, int madc)
        {
            return ctHdDao.deleteCTHD(mahd, madc);
        }
        public bool editCTHD(CTHD ct)
        {
            return ctHdDao.editCTHD(ct);
        }
    }
}
