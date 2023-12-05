<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="webSQLSinhVien.DangKy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/StyleSheet2.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Đăng ký</h2>
            <div>
                <label>Tên đăng nhập:</label>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Mật khẩu:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <label>Xác nhận mật khẩu:</label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:CheckBox CssClass="cbNhoToi" runat="server" Text="Nhớ tôi" ID="cbNhoToi" />
                <a href="DangNhap.aspx">Bạn chưa đã có tài khoản? Đến đăng nhập!</a>
            </div>
            <div>
                <asp:Button ID="btnRegister" runat="server" Text="Đăng ký" OnClick="btnRegister_Click" />
            </div>
        </div>
    </form>
</body>
</html>
