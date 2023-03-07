<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="users.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Movie ID:</td>
                    <td><asp:TextBox ID="txtId" runat="server"></asp:TextBox></td>
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
                    <td colspan="2"><asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" /></td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="gvMovieDetails" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Movie ID" />
                    <asp:BoundField DataField="Name" HeaderText="Movie Name" />
                    <asp:BoundField DataField="Director" HeaderText="Director" />
                    <asp:ButtonField ButtonType="Button" Text="Edit" CommandName="EditRow" />
                    <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="DeleteRow" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
