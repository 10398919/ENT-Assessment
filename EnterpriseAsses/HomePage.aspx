<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="EnterpriseAsses.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body style="background-color:lightpink">
    <form id="form1" runat="server">
        <div>

            <div>Get details by</div>

            <asp:radiobutton runat="server" GroupName="region" Text="Region" ID="rdbregion" AutoPostBack="true" OnCheckedChanged="rdbregion_CheckedChanged"></asp:radiobutton>

            <asp:radiobutton runat="server" GroupName="region" Text="Get all Countries" AutoPostBack="true" ID="rdballcountry" OnCheckedChanged="rdballcountry_CheckedChanged"></asp:radiobutton>
            <br />
            <br />
            <asp:TextBox ID="txtregion" runat="server" style="display:none"></asp:TextBox>
            <br />
            <asp:Button ID="btnregion" runat="server" Text="GO" style="display:none" OnClick="btnregion_Click"  />
            <br />
            <div>Country</div>
            <div>
                <asp:DropDownList ID="ddlcountry" runat="server"  style="margin-bottom: 0px">
                
                </asp:DropDownList>
            </div>

            <div>
                <br />
                <table runat="server" id="table" style="display:none" >
                    <tr runat="server" >
                        <td>Country Name:</td>
                        <td runat="server">
                            <asp:Label ID="countname" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    
                    <tr runat="server" >
                        <td>Capital:</td>
                        <td runat="server">
                            <asp:Label ID="tdcapital" runat="server" ></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td runat="server" >Region:</td>
                        <td runat="server">
                            <asp:Label ID="tdregion" runat="server" ></asp:Label>
                        </td>
                    </tr>

                    <tr runat="server" >
                        <td>Sub-Region:</td>
                        <td runat="server">
                            <asp:Label ID="tdsubregion" runat="server" ></asp:Label>
                        </td>
                    </tr>

                      <tr runat="server" >
                        <td>Calling Codes:</td>
                        <td runat="server">
                            <asp:Label ID="tdcallin" runat="server" ></asp:Label>
                        </td>
                    </tr>


                    <tr>
                        <td>Area:</td>
                        <td>
                            <asp:Label ID="tdArea" runat="server" ></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td>Population:</td>
                        <td>
                            <asp:Label ID="tdpop" runat="server" ></asp:Label>
                        </td>
                    </tr>

                    <tr runat="server" >
                        <td runat="server" >Latitude:</td>
                        <td runat="server">
                            <asp:Label ID="tdlat" runat="server" ></asp:Label>
                        </td>

                    </tr>

                    <tr runat="server" >
                        <td runat="server" >Longitude:</td>
                        <td runat="server">
                            <asp:Label ID="logt" runat="server" ></asp:Label>
                        </td>

                    </tr>

                    
                    <tr runat="server" >
                        <td>Currency:</td>
                        <td runat="server">
                            <asp:Label ID="curr" runat="server" ></asp:Label>
                        </td>

                    </tr>

                </table>

            </div>


           
        </div>
              <br />
        <div>
            <asp:Button ID="btnsearch" runat="server" Text="Get Details" OnClick="btnsearch_Click" /></div>
            <br />

            <asp:button runat="server" id="btncurrency" Text="Currency Converter" OnClick="btncurrencyconvert_Click" />       
    </form>
</body>
</html>
