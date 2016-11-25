using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
namespace Dao
{
    public class KhachHangDao
    {
        public List<KHACHHANG> dsKhachHang()
        {
            List<KHACHHANG> listKhanghang = new List<KHACHHANG>();
            using (ToyEntityModel context = new ToyEntityModel())
            {
                var query = (from c in context.KHACHHANGs select new {c.CMT,c.DIEMTL,c.MAKH,c.SDT,c.TENKH });
                foreach (var a in query)
                {
                    KHACHHANG kh = new KHACHHANG();
                    kh.CMT = a.CMT;
                    kh.DIEMTL = a.DIEMTL;
                    kh.MAKH = a.MAKH;
                    kh.TENKH = a.TENKH;
                    kh.SDT = a.SDT;

                    listKhanghang.Add(kh);
                }             
            }
            return listKhanghang;
        }
        public KHACHHANG KhachHangById(int id)
        {
            KHACHHANG kh = new KHACHHANG();
            using (ToyEntityModel context = new ToyEntityModel())
            {
                KHACHHANG khachhang = context.KHACHHANGs.SingleOrDefault(x=>x.MAKH==id);
            }
                ///////to do something
                return kh;
        }
    }
}
