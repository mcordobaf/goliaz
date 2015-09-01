<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="data.aspx.cs" Inherits="Goliaz.Web.Admin.data" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Day: <asp:DropDownList ID="ddlDay" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDay_SelectedIndexChanged" >
        </asp:DropDownList>
        <asp:Button ID="export" runat="server" Text="Export" OnClick="export_Click" />
       <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="false" ></asp:GridView>
    </div>
    </form>
</body>
</html>
