using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Dto;

namespace Bus
{
    
    public class KhachHangBus
    {
        KhachHangDao khdao = new KhachHangDao();
        public List<KHACHHANG>DSkhachhang()
        {
            return khdao.dsKhachHang();
        }
        public KHACHHANG KhachHangByID(int id)
        {
            return khdao.KhachHangById(id);
        }
        public int addKh(KHACHHANG kh)
        {
            return khdao.AddKH(kh);
        }
        public bool delete(int makh)
        {
            return khdao.deleteKH(makh);
        }
        public bool edit(KHACHHANG kh)
        {
            return khdao.editKH(kh);
        }
    }
}
