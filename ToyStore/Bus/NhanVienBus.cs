using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dao;

namespace Bus
{
    public class NhanVienBus
    {
        public List<NHANVIEN>DSNhanVien()
        {
            NhanVienDao nvdao = new NhanVienDao();

            return nvdao.DSNhanVien();
        }
    }
}
