<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="EnterpriseAsses.Results" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:lightpink">
    <form id="form1" runat="server">
       
            <div>
                <table>
                    <tr>
                        <td>From</td>
                        <td>  <asp:DropDownList ID="ddlFromcountry" runat="server"></asp:DropDownList></td>
                    </tr>

                    <tr>
                        <td>To</td>
                        <td>  <asp:DropDownList ID="ddlToCountry" runat="server"></asp:DropDownList></td>
                    </tr>

                    <tr>
                        <td> Enter Amount</td>
                        <td> <asp:TextBox ID="txtamount" runat="server"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>Conversion Amount</td>
                        <td><asp:TextBox ID="txtconvertamount" runat="server" ReadOnly="true"></asp:TextBox></td>

                    </tr>

                    <tr>
                        <td> <asp:Button ID="btnconvert" runat="server" Text="Convert" OnClick="btnconvert_Click" /></td>
                    </tr>
                </table>




                
              
          
        </div>
    </form>
</body>
</html>
