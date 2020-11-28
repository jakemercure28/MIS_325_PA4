<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Auto Reservation System.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 74%;
            height: 607px;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            width: 180px;
        }
        .auto-style12 {
            height: 42px;
            width: 180px;
            text-align: center;
            background-color: #CCFFCC;
        }
        .auto-style13 {
            height: 36px;
            width: 180px;
            text-align: center;
            background-color: #CCFFCC;
        }
        .auto-style14 {
            width: 180px;
            height: 80px;
            text-align: center;
        }
        .auto-style16 {
            width: 180px;
            height: 33px;
            text-align: center;
            background-color: #CCFFCC;
        }
        .auto-style18 {
            width: 180px;
            height: 34px;
            text-align: center;
            background-color: #CCFFCC;
        }
        .auto-style21 {
            text-align: center;
            width: 99px;
        }
        .auto-style22 {
            height: 42px;
            background-color: #CCFFCC;
            width: 99px;
        }
        .auto-style23 {
            height: 36px;
            background-color: #CCFFCC;
            width: 99px;
        }
        .auto-style24 {
            height: 33px;
            background-color: #CCFFCC;
            width: 99px;
        }
        .auto-style25 {
            height: 34px;
            text-align: left;
            background-color: #CCFFCC;
            width: 99px;
        }
        .auto-style26 {
            height: 80px;
            text-align: left;
            width: 99px;
            background-color: #CCFFCC;
        }
        .auto-style27 {
            height: 80px;
            text-align: right;
            width: 99px;
            background-color: #CCFFCC;
        }
        .auto-style28 {
            width: 99px;
        }
        .auto-style29 {
            height: 42px;
            background-color: #CCFFCC;
            width: 12px;
        }
        .auto-style30 {
            height: 36px;
            background-color: #CCFFCC;
            width: 12px;
        }
        .auto-style31 {
            height: 33px;
            background-color: #CCFFCC;
            width: 12px;
        }
        .auto-style32 {
            height: 34px;
            text-align: left;
            background-color: #CCFFCC;
            width: 12px;
        }
        .auto-style33 {
            height: 80px;
            text-align: left;
            width: 12px;
        }
        .auto-style34 {
            height: 80px;
            text-align: right;
            width: 12px;
        }
        .auto-style35 {
            width: 12px;
        }
        .auto-style36 {
            text-align: left;
            color: #0000FF;
        }
        .auto-style37 {
            color: #0000FF;
        }
        .auto-style38 {
            width: 99px;
            background-color: #CCFFCC;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" colspan="2">WSU Auto Reservation System</td>
                <td class="auto-style21">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">Start Date: (mm/dd/yyyy)</td>
                <td class="auto-style29">
                    <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
                <td class="auto-style22">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">End Date: (mm/dd/yyyy)</td>
                <td class="auto-style30">
                    <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
                <td class="auto-style23">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">Start Mileage:</td>
                <td class="auto-style31">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style24">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">End Mileage:</td>
                <td class="auto-style32">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style25">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14">Select Vehicle Type:</td>
                <td class="auto-style33">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="Sedan1">Sedan1</asp:ListItem>
                        <asp:ListItem Value="Sedan2">Sedan2</asp:ListItem>
                        <asp:ListItem Value="Sedan3">Sedan3</asp:ListItem>
                        <asp:ListItem Value="Van1">Van1</asp:ListItem>
                        <asp:ListItem Value="Van2">Van2</asp:ListItem>
                        <asp:ListItem Value="Van3">Van3</asp:ListItem>
                        <asp:ListItem Value="Pickup1">Pickup1</asp:ListItem>
                        <asp:ListItem Value="Pickup2">Pickup2</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style26">
                    <span class="auto-style37">Grand Totals</span><asp:GridView ID="GridView3" runat="server">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style14">Additional Costs (Optional):</td>
                <td class="auto-style34">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Width="238px">
                        <asp:ListItem Value="25">Light cleaning</asp:ListItem>
                        <asp:ListItem Value="75">Heavy cleaning</asp:ListItem>
                        <asp:ListItem Value="150">Light damage</asp:ListItem>
                        <asp:ListItem Value="300">Heavy damage</asp:ListItem>
                        <asp:ListItem Value="25">Late fee</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
                <td class="auto-style27">
                    <div class="auto-style36">
                        Vehicle Type Usage</div>
                    <asp:GridView ID="GridView4" runat="server">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="Button1" runat="server" Text="Create Invoice" />
                </td>
                <td class="auto-style35">
                    <asp:TextBox ID="TextBox3" runat="server" Height="117px" TextMode="MultiLine" Width="420px"></asp:TextBox>
                </td>
                <td class="auto-style38">
                    <span class="auto-style37">Individual Vehicle Usage</span><asp:GridView ID="GridView2" runat="server">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style35">
                    <span class="auto-style37">Invoice Ledger</span><asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                </td>
                <td class="auto-style28">
                    &nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
