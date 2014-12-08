using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Process;
using System.Data.SqlClient;

namespace Controller
{
    public class CheckError
    {
        public bool OverNubmer(string txt,int number)
        {
            bool result = true;
            if (txt.Length > number)
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
        ConnectSql myConnect;
        //hàm kiểm tra bảng có dữ liệu hay không 
        public bool isExists(string stringSQLConnect)
        {
            myConnect = new ConnectSql();
            SqlCommand cmd = new SqlCommand(stringSQLConnect , myConnect.getConnection);
            Int32 count = (Int32)cmd.ExecuteScalar();
            return count != 0 ? true : false;
        }
        //ham kiem tra du lieu co nhap hay khong
        public bool isData(string txt)
        {
            return txt.Length == 0 ? false : true;
        }
        
    }
}
