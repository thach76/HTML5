using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webSQLSinhVien
{
    public partial class DangKy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Xử lý đăng ký ở đây
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (username.Equals("") || password.Equals(""))
            {
                Response.Write("<script>alert('Vui lòng nhập đủ dữ liệu!.');</script>");
                return;
            }

            // Kiểm tra và xử lý logic đăng ký
            if (password == confirmPassword)
            {
                HttpCookie httpCookie = new HttpCookie("User");
                httpCookie["username"] = username;
                httpCookie["password"] = password;
                httpCookie.Expires = DateTime.Now.AddMinutes(0.5d);
                Response.Cookies.Add(httpCookie);
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                // Hiển thị thông báo lỗi nếu mật khẩu không khớp
                // (Cũng cần thêm xử lý thông báo lỗi khác)
                Response.Write("<script>alert('Mật khẩu không khớp.');</script>");
            }
        }
    }
}