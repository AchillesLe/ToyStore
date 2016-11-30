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
            return HDdao.deleteHD(mahd);
        }
        public bool edit(HOADON hd)
        {
            return HDdao.editHD(hd);
        }
    }
}
