using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace webSQLSinhVien
{
    class SinhVien
    {
        public string MaSV {  get; set; }
        public string HoSV { get; set; }
        public string TenSV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string MaKhoa { get; set; }
    }

    class SqlQuery
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
    public partial class WebQuanLySinhVien : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
        }

        private void Select()
        {
            DataTable sv = SqlQuery.SelectAll();
            GridViewSinhVien.DataSource = sv;
            GridViewSinhVien.DataBind();
        }

        protected void btSelect_Click(object sender, EventArgs e)
        {
            Select();
        }

        private void MessageNotify(string message)
        {
            string script = $"<script type='text/javascript'>alert('{message}');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            string masv = txtMasv.Text;
            string hosv = txtHosv.Text;
            string tensv = txtTensv.Text;
            string ngaysinh = txtNgaySinh.Value;
            string gioitinh = DropDownListGioiTinh.Text;
            string makhoa = txtMakhoa.Text;
            if (masv.Equals("") || hosv.Equals("") || tensv.Equals("") || ngaysinh.Equals("") || gioitinh.Equals("") || makhoa.Equals(""))
            {
                MessageNotify("Vui lòng nhập đủ dữ liệu");
                return;
            }
            string cmd = $"INSERT INTO [QuanLySinhVien].[dbo].[SinhVien] ([MaSV] ,[HoSV] ,[TenSV],[NgaySinh],[GioiTinh],[MaKhoa]) VALUES  ('{masv}','{hosv}','{tensv}','{ngaysinh}','{gioitinh}','{makhoa}')";
            if (SqlQuery.ReadSql(cmd))
            {
                MessageNotify("Bạn đã thêm người dùng thành công");
            }
            else
            {
                MessageNotify("Bạn đã thêm người dùng không thành công");
            }
            Select();
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            string masv = txtMasv.Text;
            string hosv = txtHosv.Text;
            string tensv = txtTensv.Text;
            string ngaysinh = txtNgaySinh.Value;
            string gioitinh = DropDownListGioiTinh.Text;
            string makhoa = txtMakhoa.Text;
            if (masv.Equals("") || hosv.Equals("") || tensv.Equals("") || ngaysinh.Equals("") || gioitinh.Equals("") || makhoa.Equals(""))
            {
                MessageNotify("Vui lòng nhập đủ dữ liệu");
                return;
            }
            string cmd = $"UPDATE [QuanLySinhVien].[dbo].[SinhVien] SET [HoSV] = '{hosv}',[TenSV] = '{tensv}',[NgaySinh] = '{ngaysinh}',[GioiTinh] = '{gioitinh}',[MaKhoa] = '{makhoa}' WHERE [MaSV] = '{masv}';";
            if (SqlQuery.ReadSql(cmd))
            {
                MessageNotify("Bạn đã sửa người dùng thành công");
            }
            else
            {
                MessageNotify("Bạn đã sửa người dùng không thành công");
            }
            Select();
        }

        protected void btRemove_Click(object sender, EventArgs e)
        {
            string masv = txtMasv.Text;
            if (masv.Equals(""))
            {
                MessageNotify("Vui lòng nhập đủ dữ liệu");
                return;
            }
            string cmd = $"DELETE [QuanLySinhVien].[dbo].[SinhVien] WHERE [MaSV] = '{masv}';";
            if (SqlQuery.ReadSql(cmd))
            {
                MessageNotify("Bạn đã xóa người dùng thành công");
            }
            else
            {
                MessageNotify("Bạn đã xóa người dùng không thành công");
            }
            Select();
        }

        protected void btCancel_Click(object sender, EventArgs e)
        {
            txtMasv.Text = "";
            txtHosv.Text = "";
            txtTensv.Text = "";
            txtNgaySinh.Value = DateTime.Now.ToString();
            DropDownListGioiTinh.Text = "";
            txtMakhoa.Text = "";
        }

        protected void btExit_Click(object sender, EventArgs e)
        {
            
        }

        protected void btTotal_Click(object sender, EventArgs e)
        {

        }

        protected void btRandom_Click(object sender, EventArgs e)
        {
            string maxMaSV = "";
            using (SqlConnection myConn = new SqlConnection(SqlQuery.conn))
            {
                myConn.Open();
                using (SqlCommand myCmd = new SqlCommand("SELECT MAX([MaSV]) FROM [QuanLySinhVien].[dbo].[SinhVien];", myConn))
                {
                    using (SqlDataReader reader = myCmd.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            maxMaSV = reader.GetString(0);
                        }
                    }
                }
            }
            try
            {
                int so = int.Parse(maxMaSV.Substring(1));
                so += 1;
                txtMasv.Text = "s0" + (so);
                txtHosv.Text = "Hoang Van " + so;
                txtTensv.Text = "Thach" + so;
                DateTime ngaySinh = new DateTime(2003, 7, 3);
                txtNgaySinh.Value = ngaySinh.ToString("yyyy-MM-dd");
                //txtNgaySinh.Value = DateTime.Now.ToString();
                DropDownListGioiTinh.Text = "Nam";
                txtMakhoa.Text = "CNTT";
            }
            catch (FormatException)
            {
                Console.WriteLine("Chuỗi không chứa số nguyên hợp lệ.");
            }

        }

        
    }
}
