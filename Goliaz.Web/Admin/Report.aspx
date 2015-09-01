<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Goliaz.Web.Admin.Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="cache-control" content="no-cache" />

    <style>
        .divStyle {
            width: 680px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hdIdDayConfigured" runat="server" Value="0" />
        <br />
        <div class="divStyle" >
            Date:
            <asp:TextBox ID="txtDateOfDay" runat="server" Width="90" ></asp:TextBox>
            State:
            <asp:DropDownList ID="ddlStateDay" runat="server" >
                <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                <asp:ListItem Text="Inactive" Value="Inactive"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />
        <div>
            <span style="font-weight:bold; margin-left: 20px;" >Name</span>
            <span style="font-weight:bold; margin-left: 165px;" >Data Type</span>
            <span style="font-weight:bold; margin-left: 30px;" >Description</span>
        </div>
        <div id="div1" class="divStyle" runat="server" >
            <asp:CheckBox ID="CheckBox1" runat="server" />
            <asp:HiddenField ID="hdReport1" runat="server" />
            <asp:TextBox ID="txtReport1" runat="server" Width="200"></asp:TextBox>
            <asp:DropDownList ID="ddlDataTypeReport1" runat="server" Width="100" ></asp:DropDownList>
            <asp:TextBox ID="txtDescription1" runat="server" TextMode="MultiLine" Width="200" Rows="2" ></asp:TextBox>
            <a id="anchorDelete1" title="Delete" visible="false" runat="server" href="#" ><img style="border: 0px; width:20px;" src="../images/remove-icon.png" alt="Delete" /></a>
        </div>
        <div id="div2" class="divStyle" runat="server" >
            <asp:HiddenField ID="hdReport2" runat="server" />
            <asp:CheckBox ID="CheckBox2" runat="server" />
            <asp:TextBox ID="txtReport2" runat="server" Width="200"></asp:TextBox>
            <asp:DropDownList ID="ddlDataTypeReport2" runat="server" Width="100" ></asp:DropDownList>
            <asp:TextBox ID="txtDescription2" runat="server" TextMode="MultiLine" Width="200" Rows="2" ></asp:TextBox>
            <a id="anchorDelete2" title="Delete"  visible="false" runat="server" href="#" ><img style="border: 0px; width:20px;" src="../images/remove-icon.png" alt="Delete" /></a>
        </div>
        <div id="div3" class="divStyle" runat="server" >
            <asp:HiddenField ID="hdReport3" runat="server" />
            <asp:CheckBox ID="CheckBox3" runat="server" />
            <asp:TextBox ID="txtReport3" runat="server" Width="200" ></asp:TextBox>
            <asp:DropDownList ID="ddlDataTypeReport3" runat="server" Width="100" ></asp:DropDownList>
            <asp:TextBox ID="txtDescription3" runat="server" TextMode="MultiLine" Width="200" Rows="2"></asp:TextBox>
            <a id="anchorDelete3" title="Delete"  runat="server" visible="false" href="#" ><img style="border: 0px; width:20px;" src="../images/remove-icon.png" alt="Delete" /></a>
        </div>
        <div id="div4" class="divStyle" runat="server" >
            <asp:HiddenField ID="hdReport4" runat="server" />
            <asp:CheckBox ID="CheckBox4" runat="server" />
            <asp:TextBox ID="txtReport4" runat="server" Width="200"></asp:TextBox>
            <asp:DropDownList ID="ddlDataTypeReport4" runat="server" Width="100" ></asp:DropDownList>
            <asp:TextBox ID="txtDescription4" runat="server" TextMode="MultiLine" Width="200" Rows="2"></asp:TextBox>
            <a id="anchorDelete4" title="Delete" runat="server" visible="false" href="#" ><img style="border: 0px; width:20px;" src="../images/remove-icon.png" alt="Delete" /></a>
        </div>
        <div id="div5" class="divStyle" runat="server" >
            <asp:HiddenField ID="hdReport5" runat="server" />
            <asp:CheckBox ID="CheckBox5" runat="server" />
            <asp:TextBox ID="txtReport5" runat="server" Width="200"></asp:TextBox>
            <asp:DropDownList ID="ddlDataTypeReport5" runat="server" Width="100" ></asp:DropDownList>
            <asp:TextBox ID="txtDescription5" runat="server" TextMode="MultiLine" Width="200" Rows="2"></asp:TextBox>
            <a id="anchorDelete5" runat="server" title="Delete"  visible="false" href="#" ><img style="border: 0px; width:20px;" src="../images/remove-icon.png" alt="Delete" /></a>
        </div>
        <div id="div6" class="divStyle" runat="server" >
            <asp:HiddenField ID="hdReport6" runat="server" />
            <asp:CheckBox ID="CheckBox6" runat="server" />
            <asp:TextBox ID="txtReport6" runat="server" Width="200"></asp:TextBox>
            <asp:DropDownList ID="ddlDataTypeReport6" runat="server" Width="100" ></asp:DropDownList>
            <asp:TextBox ID="txtDescription6" runat="server" TextMode="MultiLine" Width="200" Rows="2"></asp:TextBox>
            <a id="anchorDelete6" runat="server" title="Delete" visible="false" href="#" ><img style="border: 0px; width:20px;" src="../images/remove-icon.png" alt="Delete" /></a>
        </div>
        <div id="div7" class="divStyle" runat="server" >
            <asp:HiddenField ID="hdReport7" runat="server" />
            <asp:CheckBox ID="CheckBox7" runat="server" />
            <asp:TextBox ID="txtReport7" runat="server" Width="200"></asp:TextBox>
            <asp:DropDownList ID="ddlDataTypeReport7" runat="server" Width="100" ></asp:DropDownList>
            <asp:TextBox ID="txtDescription7" runat="server" TextMode="MultiLine" Width="200" Rows="2"></asp:TextBox>
            <a id="anchorDelete7" runat="server" visible="false" title="Delete"  href="#" ><img style="border: 0px; width:20px;" src="../images/remove-icon.png" alt="Delete" /></a>
        </div>
        <div id="div8" class="divStyle" runat="server" >
            <asp:HiddenField ID="hdReport8" runat="server" />
            <asp:CheckBox ID="CheckBox8" runat="server" />
            <asp:TextBox ID="txtReport8" runat="server" Width="200"></asp:TextBox>
            <asp:DropDownList ID="ddlDataTypeReport8" runat="server" Width="100" ></asp:DropDownList>
            <asp:TextBox ID="txtDescription8" runat="server" TextMode="MultiLine" Width="200" Rows="2"></asp:TextBox>
            <a id="anchorDelete8" title="Delete"  runat="server" visible="false" href="#" ><img style="border: 0px; width:20px;" src="../images/remove-icon.png" alt="Delete" /></a>
        </div>
        <div id="div9" class="divStyle" runat="server" >
            <asp:HiddenField ID="hdReport9" runat="server" />
            <asp:CheckBox ID="CheckBox9" runat="server" />
            <asp:TextBox ID="txtReport9" runat="server" Width="200"></asp:TextBox>
            <asp:DropDownList ID="ddlDataTypeReport9" runat="server" Width="100" ></asp:DropDownList>
            <asp:TextBox ID="txtDescription9" runat="server" TextMode="MultiLine" Width="200" Rows="2"></asp:TextBox>
            <a id="anchorDelete9" title="Delete"  runat="server" href="#" visible="false" ><img style="border: 0px; width:20px;" src="../images/remove-icon.png" alt="Delete" /></a>
        </div>
        <div id="div10" class="divStyle" runat="server" >
            <asp:HiddenField ID="hdReport10" runat="server" />
            <asp:CheckBox ID="CheckBox10" runat="server" />
            <asp:TextBox ID="txtReport10" runat="server" Width="200" ></asp:TextBox>
            <asp:DropDownList ID="ddlDataTypeReport10" runat="server" Width="100" ></asp:DropDownList>
            <asp:TextBox ID="txtDescription10" runat="server" TextMode="MultiLine" Width="200" Rows="2"></asp:TextBox>
            <a id="anchorDelete10" title="Delete"  runat="server" href="#" visible="false" ><img style="border: 0px; width:20px;" src="../images/remove-icon.png" alt="Delete" /></a>
        </div>
        <div id="divMensajeErrores" style="display:none; color: red;">
        </div>
    </form>
</body>
</html>
