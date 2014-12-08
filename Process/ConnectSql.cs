using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Process
{
    public class ConnectSql
    {
        private string stringConnect = "server=.;database=database;uid=sa;pwd= ;integrated security=SSPI;Connect Timeout=5";
        public SqlConnection connect;
        public DataTable dataTable = new DataTable();
        public ConnectSql()
		{		
				OpenConnection();
		}
		public void OpenConnection()
		{

            connect = new SqlConnection(stringConnect);
            if (connect.State == ConnectionState.Closed)
                connect.Open();				
					
		}
        public void CloseConnection()
        {
            connect = new SqlConnection(stringConnect);
            if (connect.State == ConnectionState.Open)
                connect.Close();
        }
		//public bool TestConnection()
		//{
			//ConnectSQL msgSQL = new ConnectSQL();
			//msgSQL.Show("Connecting to SQL Server...");

			//SqlConnection test_Con = new SqlConnection(str_Connection);
			//try
		//{
		//		test_Con.Open();
			//	//MessageBox.Show("Đã kết nối được với SQL Server ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				//test_Con.Close();
				//msgSQL.Close();
				//return true;
		//	}
			//catch
			//{
//				MessageBox.Show("Không kết nối được với SQL Server!!!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
					//Application.Exit();
				//		return false;	
			//}
		//}

		public SqlConnection getConnection
		{
            get { return connect; }
		}
		public DataSet getDataset(string str)
		{
            SqlDataAdapter da = new SqlDataAdapter(str, connect);
			DataSet ds=new DataSet();
			da.Fill(ds);
			return ds;
		}
		public DataTable getDataTable(string sql) 
		{
			SqlDataAdapter da = new SqlDataAdapter(sql, getConnection);
			DataTable dt = new DataTable();
			da.Fill(dt);
			return dt;
		}
        public string getLastID(string columName, string tableName, string condition)
        {
            string stringSQL="",a = "";
            if(condition=="") stringSQL = "SELECT TOP 1(" + columName + ") FROM " + tableName + " ORDER BY " + columName + " DESC";
            else stringSQL = "select top 1("+columName+") from "+tableName+" where "+columName+" like '"+condition+"%' ";
            if (connect.State == ConnectionState.Open) connect.Close();
            connect.Open();
            SqlCommand cmd = new SqlCommand(stringSQL,getConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
                a += sdr[0].ToString();
            connect.Close();
            return a;
        }
    }
}
