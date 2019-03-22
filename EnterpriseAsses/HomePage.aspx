<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="EnterpriseAsses.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div>City</div>
            <div>
                <asp:DropDownList ID="ddlcity" runat="server">
                    <asp:ListItem Value="0">Please Select</asp:ListItem>
                    <asp:ListItem Value="IRL-DU">Dublin</asp:ListItem>
                    <asp:ListItem Value="UK-Manu">Manchester</asp:ListItem>
                    <asp:ListItem Value="UK-LOND">London</asp:ListItem>
                    <asp:ListItem Value="GR-MUN">Munich</asp:ListItem>
                    <asp:ListItem Value="GR-BER">Berlin</asp:ListItem>
                    <asp:ListItem Value="IRL-LIM">Limerick</asp:ListItem>
                    <asp:ListItem Value="IND-MUM">Mumbai</asp:ListItem>
                    <asp:ListItem Value="IND-DEL">Delhi</asp:ListItem>
                    <asp:ListItem Value="UAE-DUB">Dubai</asp:ListItem>
                    <asp:ListItem Value="UAE-SHA">Sharjah</asp:ListItem>
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
    </form>
</body>
</html>
