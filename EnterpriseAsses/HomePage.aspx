<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="EnterpriseAsses.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div>Country</div>
            <div>
                <asp:DropDownList ID="ddlcountry" runat="server"  style="margin-bottom: 0px">
                
                </asp:DropDownList>

            </div>

            <div>Adults</div>
            <div>
                <asp:DropDownList ID="ddlAdult" runat="server">

                     <asp:ListItem Value="0">Please Select</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                </asp:DropDownList></div>
        </div>
        <div>Child</div>
        <div>
            <asp:DropDownList ID="ddlchild" runat="server">
                  <asp:ListItem Value="0">Please Select</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />
        <div>
            <asp:Button ID="btnsearch" runat="server" Text="Button" OnClick="btnsearch_Click" /></div>
        <br />
        <asp:button runat="server" id="btncurrency" Text="Currency Converter" OnClick="btncurrencyconvert_Click" />  
    </form>
</body>
</html>
