<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Goliaz.Web.Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .divStyle {
            width: 680px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hdIdDayReported" runat="server" Value="0" />
        <div id="div1" class="divStyle" runat="server" style="display:none;" >
            <asp:HiddenField ID="hdReport1" runat="server" />
            <asp:Label ID="lblReport1" runat="server" Width="200" ></asp:Label>
            <asp:DropDownList ID="ddlDataTypeReport1" runat="server" style="display:none;"  Width="100" >
            </asp:DropDownList>
            <asp:TextBox ID="txtReport1" runat="server" Width="60"></asp:TextBox>
            <asp:Label ID="lblDescReport1" runat="server" Width="300" ></asp:Label>
        </div>
        <div id="div2" class="divStyle" runat="server" style="display:none;" >
            <asp:HiddenField ID="hdReport2" runat="server" />
            <asp:Label ID="lblReport2" runat="server" Width="200" ></asp:Label>
            <asp:DropDownList ID="ddlDataTypeReport2" runat="server" style="display:none;" Width="100" >
            </asp:DropDownList>
            <asp:TextBox ID="txtReport2" runat="server" Width="60"></asp:TextBox>
            <asp:Label ID="lblDescReport2" runat="server" Width="300" ></asp:Label>
        </div>
        <div id="div3" class="divStyle" runat="server" style="display:none;">
            <asp:HiddenField ID="hdReport3" runat="server" />
            <asp:Label ID="lblReport3" runat="server" Width="200" ></asp:Label>
            <asp:DropDownList ID="ddlDataTypeReport3" runat="server" style="display:none;" Width="100" >
            </asp:DropDownList>
            <asp:TextBox ID="txtReport3" runat="server" Width="60"></asp:TextBox>
            <asp:Label ID="lblDescReport3" runat="server" Width="300" ></asp:Label>
        </div>
        <div id="div4" class="divStyle" runat="server" style="display:none;">
            <asp:HiddenField ID="hdReport4" runat="server" />
            <asp:Label ID="lblReport4" runat="server" Width="200" ></asp:Label>
            <asp:DropDownList ID="ddlDataTypeReport4" runat="server" style="display:none;" Width="100" >
            </asp:DropDownList>
            <asp:TextBox ID="txtReport4" runat="server" Width="60"></asp:TextBox>
            <asp:Label ID="lblDescReport4" runat="server" Width="300" ></asp:Label>
        </div>
        <div id="div5" class="divStyle" runat="server" style="display:none;">
            <asp:HiddenField ID="hdReport5" runat="server" />
            <asp:Label ID="lblReport5" runat="server" Width="200" ></asp:Label>
            <asp:DropDownList ID="ddlDataTypeReport5" runat="server" style="display:none;" Width="100" >
            </asp:DropDownList>
            <asp:TextBox ID="txtReport5" runat="server" Width="60"></asp:TextBox>
            <asp:Label ID="lblDescReport5" runat="server" Width="300" ></asp:Label>
        </div>
        <div id="div6" class="divStyle" runat="server" style="display:none;">
            <asp:HiddenField ID="hdReport6" runat="server" />
            <asp:Label ID="lblReport6" runat="server" Width="200" ></asp:Label>
            <asp:DropDownList ID="ddlDataTypeReport6" runat="server" style="display:none;" Width="100" >
            </asp:DropDownList>
            <asp:TextBox ID="txtReport6" runat="server" Width="60"></asp:TextBox>
            <asp:Label ID="lblDescReport6" runat="server" Width="300" ></asp:Label>
        </div>
        <div id="div7" class="divStyle" runat="server" style="display:none;">
            <asp:HiddenField ID="hdReport7" runat="server" />
            <asp:Label ID="lblReport7" runat="server" Width="200" ></asp:Label>
            <asp:DropDownList ID="ddlDataTypeReport7" runat="server" style="display:none;" Width="100" >
            </asp:DropDownList>
            <asp:TextBox ID="txtReport7" runat="server" Width="60"></asp:TextBox>
            <asp:Label ID="lblDescReport7" runat="server" Width="300" ></asp:Label>
        </div>
        <div id="div8" class="divStyle" runat="server" style="display:none;">
            <asp:HiddenField ID="hdReport8" runat="server" />
            <asp:Label ID="lblReport8" runat="server" Width="200" ></asp:Label>
            <asp:DropDownList ID="ddlDataTypeReport8" runat="server" style="display:none;" Width="100" >
            </asp:DropDownList>
            <asp:TextBox ID="txtReport8" runat="server" Width="60"></asp:TextBox>
            <asp:Label ID="lblDescReport8" runat="server" Width="300" ></asp:Label>
        </div>
        <div id="div9" class="divStyle" runat="server" style="display:none;">
            <asp:HiddenField ID="hdReport19" runat="server" />
            <asp:Label ID="lblReport9" runat="server" Width="200" ></asp:Label>
            <asp:DropDownList ID="ddlDataTypeReport9" runat="server" style="display:none;" Width="100" >
            </asp:DropDownList>
            <asp:TextBox ID="txtReport9" runat="server" Width="60"></asp:TextBox>
            <asp:Label ID="lblDescReport9" runat="server" Width="300" ></asp:Label>
        </div>
        <div id="div10" class="divStyle" runat="server" style="display:none;">
            <asp:HiddenField ID="hdReport10" runat="server" />
            <asp:Label ID="lblReport10" runat="server" Width="200" ></asp:Label>
            <asp:DropDownList ID="ddlDataTypeReport10" runat="server" style="display:none;" Width="100" >
            </asp:DropDownList>
            <asp:TextBox ID="txtReport10" runat="server" Width="60"></asp:TextBox>
            <asp:Label ID="lblDescReport10" runat="server" Width="300" ></asp:Label>
        </div>
    </form>
</body>
</html>
