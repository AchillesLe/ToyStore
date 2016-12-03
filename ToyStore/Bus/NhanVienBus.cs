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
        NhanVienDao nvdao = new NhanVienDao();
        public List<NHANVIEN>DSNhanVien()
        {
          
            return nvdao.DSNhanVien();
        }
        public NHANVIEN NhanVienByID(int ID)
        {
            return nvdao.NhanVienByID(ID);
        }
        public int AddNV(NHANVIEN nv)
        {
            return nvdao.addNV(nv);
        }
        public bool deleteNV(int manv)
        {
            return nvdao.deleteNV(manv);
        }
        public bool editNV(NHANVIEN nv)
        {
            return nvdao.editNV(nv);
        }
        public bool checkNV(int manv,string pass)
        {
            return nvdao.checkPass(manv, pass);
        }
    }
}
