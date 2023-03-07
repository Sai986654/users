<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieDetails.aspx.cs" Inherits="MovieDetailsCRUD.Default" %>

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
                    <td>Movie Name:</td>
                    <td><asp:TextBox ID="txtMovieName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Start Date:</td>
                    <td><asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Duration:</td>
                    <td><asp:TextBox ID="txtDuration" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Description:</td>
                    <td><asp:TextBox ID="txtDescription" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Author:</td>
                    <td><asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" /></td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="gvMovieDetails" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="MovieName" HeaderText="Movie Name" />
                    <asp:BoundField DataField="StartDate" HeaderText="Start Date" />
                    <asp:BoundField DataField="Duration" HeaderText="Duration" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Author" HeaderText="Author" />
                    <asp:ButtonField ButtonType="Button" Text="Edit" CommandName="EditRow" />
                    <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="DeleteRow" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
