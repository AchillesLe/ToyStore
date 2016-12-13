using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Presentation.toolTip1
{
    public class Validation
    {
        public static bool check_Phone(string phone)
        {
            if (Regex.IsMatch(phone, @"^0\d{9,10}$"))
                return true;
            else
                return false;
        }
        public static bool check_NgaySinh(DateTime ngaysinh)
        {
            string year = ngaysinh.ToString("yyyy");
            int intyear = Int32.Parse(year);

            if (Int32.Parse(DateTime.Now.ToString("yyyy")) - intyear >= 18)
                return true;
            else return false;
        }
        public static bool Check_cmt(string cmt)
        {
            if (Regex.IsMatch(cmt, @"^\d{9}$"))
                return true;
            else return false;
        }
    }
}
