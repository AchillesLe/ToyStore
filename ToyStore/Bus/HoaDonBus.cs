using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dao;
namespace Bus
{
    public class HoaDonBus
    {
        HoaDonDao HDdao = new HoaDonDao();
        public List<HOADON>DsHoaDon()
        {
            return HDdao.dsHoaDon();           
        }
        public List<HOADON> DsHoaDonFromTo(DateTime datefrom, DateTime dateto)
        {
            return HDdao.dsHoaDonFromTo(datefrom, dateto);
        }
        public List<HOADON> dsHoaDonById(int id)
        {
            return HDdao.dsHoaDonById(id);
        }
        public HOADON HoadonByID(int id)
        {
            return HDdao.HoaDonById(id);
        }
        public int AddHoaDon(HOADON hd)
        {
            return HDdao.AddHoaDon(hd);
        }
        public bool delete(int mahd)
        {
            bool ck = true;
            CTHDDao ctDao = new CTHDDao();
            ck = ck && ctDao.deleteCTHD(mahd);
            ck = ck && HDdao.deleteHD(mahd);
            return ck;
        }
        public bool edit(HOADON hd)
        {
            return HDdao.editHD(hd);
        }
    }
}
