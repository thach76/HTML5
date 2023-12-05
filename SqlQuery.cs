using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace webSQLSinhVien
{
    class SinhVien
    {
        public string MaSV { get; set; }
        public string HoSV { get; set; }
        public string TenSV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string MaKhoa { get; set; }
    }

    public class SqlQuery
    {
        public static string conn = "Data Source=LAPTOP-AT4UKP9G;Initial Catalog=QuanLySinhVien;Integrated Security=True";

        public static DataTable SelectAll()
        {
            using (SqlConnection myConn = new SqlConnection(conn))
            {
                myConn.Open();
                DataTable dataTable = new DataTable();
                using (SqlCommand myCmd = new SqlCommand("SELECT * FROM [QuanLySinhVien].[dbo].[SinhVien];", myConn))
                {
                    using (SqlDataAdapter myDataAdapter = new SqlDataAdapter(myCmd))
                    {
                        myDataAdapter.Fill(dataTable);
                    }
                }
                return dataTable;
            }
        }

        public static bool ReadSql(string sql)
        {
            using (SqlConnection myConn = new SqlConnection(conn))
            {
                myConn.Open();
                using (SqlCommand myCmd = new SqlCommand(sql, myConn))
                {
                    using (SqlDataReader reader = myCmd.ExecuteReader())
                    {
                        return !reader.Read();
                    }
                }
            }
        }
    }

}