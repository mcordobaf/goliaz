<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mantUsers.aspx.cs" Inherits="Goliaz.Web.Admin.mantUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mantenedor de Usuarios</title>
    <script src="../js/jquery-1.11.3.min.js"></script>
    <script src="../js/jquery-ui.js" type="text/javascript" ></script>
    <script src="../js/watermark.js" type="text/javascript" ></script>
    <script src="../js/jquery.inputmask.bundle.js" type="text/javascript" ></script>
    <script src="../js/jsMantUsers.js" type="text/javascript" ></script>

    <link href="../css/jquery-ui.css" type="text/css" rel="stylesheet" />
    <style>
        body {
            font-size: 12px !important;
            font-family: Arial,sans-serif;
        }

        .ui-widget-header {
            background: #1661dd !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptManager1" runat="server" >
            <Services>
                <asp:ServiceReference Path="~/Services/wcfGoliaz.svc" />
            </Services>
        </asp:ScriptManager>
        <div id="divEditUser" >
        </div>
        <asp:Button ID="export" runat="server" Text="Export" OnClick="export_Click" />
        <div>
            <asp:GridView ID="gvUsuarios" runat="server" AllowSorting="true" AutoGenerateColumns="false" OnRowDataBound="gvUsuarios_RowDataBound" OnSorting="gvUsuarios_Sorting" >
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href="#" runat="server" id="EditColumn" title="Edit User" style="width:30px; border: 0px; margin: 0px; padding: 0px;" >
                                <img alt="Edit" src="../images/edit-icon.png" style="width:30px; border: 0px; margin: 0px; padding: 0px;" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href="#" runat="server" id="DeleteColumn" title="Delete User" style="width:30px; border: 0px; margin: 0px; padding: 0px;" >
                                <img alt="Edit" src="../images/remove-icon.png" style="width:30px; border: 0px; margin: 0px; padding: 0px;" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
