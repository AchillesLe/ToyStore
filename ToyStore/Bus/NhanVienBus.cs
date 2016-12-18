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
        public bool AddNV(NHANVIEN nv)
        {
            return nvdao.addNV(nv);
        }
        public bool add(NHANVIEN nv,ACCOUNT ac)
        {
            return nvdao.add(nv,ac);
        }
        public bool deleteNV(int manv)
        {
            return nvdao.deleteNV(manv);
        }
        public bool editNV(NHANVIEN nv)
        {
            return nvdao.editNV(nv);
        }
        public int MaNVNow()
        {
            return nvdao.GetMaNVNow();
        }
        
    }
}
