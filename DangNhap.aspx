<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="webSQLSinhVien.DangNhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="con_ten_no">
            <div class="dang_nhap">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Tài khoản: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUsername" runat="server"   CssClass="txtInput"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Mật khẩu: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox CssClass="txtInput" ID="txtPassword" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox CssClass="cbNhoToi" runat="server" Text="Nhớ tôi" ID="cbNhoToi" />
                        </td>
                        <td>
                            <a href="DangKy.aspx">Bạn chưa đăng ký tài khoản? Đến đăng ký!</a>
                        </td>
                    </tr>
                    <tr>
                        <td>

                        </td>
                        <td>
                            <asp:Button ID="btSingin" CssClass="btSingin" runat="server" Text="Đăng nhập" OnClick="btSingin_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
