using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Process;

namespace Controller
{
    class CheckError
    {
        public bool OverNubmer(string txt,int number)
        {
            bool result = true;
            if (txt.Length >= number)
            {
                result = false;
            }
                return result;
        }
        //hàm kiếm tra có phải là số hay không nếu là số thì trả về true ngược lại kí tự thì trả về false
        public bool isNumber(string txt)
        {
            string Str = txt.Trim();
            double Num;
            bool isNum = double.TryParse(Str, out Num);
            return isNum;
        }

        //hàm kiểm tra bảng có dữ liệu hay không 
        public bool isExists(string columName, string tableName)
        {
            bool result = true;//trả về bảng tồn tại
            ConnectSql connect = new ConnectSql();
            int i=int.Parse(connect.getLastID(columName,tableName));
            if (i == 0)
                result = false; //nếu bằng 0 thì không có dữ liệu trong bảng
            else result = true; //ngược lại thì tồn tại dữ liệu
            return result;
        }
    }
}
