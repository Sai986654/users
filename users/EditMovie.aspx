<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditMovie.aspx.cs" Inherits="users.EditMovie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Movie</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Movie ID:</td>
                    <td><asp:Label ID="lblId" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Movie Name:</td>
                    <td><asp:TextBox ID="txtMovieName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Director:</td>
                    <td><asp:TextBox ID="txtDirector" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
