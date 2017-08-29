<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebReportingTool.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body  { text-align: center; } /* center all items within body, this property is inherited */
        form { display: inline-block; } /* reduces the width of the form to only what is necessary */
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 300px;
        }
        .auto-style3 {
            width: 268px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:ImageButton ID="ImageButton1" runat="server" Height="55px" ImageUrl="https://image.prntscr.com/image/mG939zUbS2CsVx-xQUnZuQ.png" OnClick="ImageButton1_Click" Width="268px" />
        
        <asp:Button ID="BTN_Home" runat="server" Height="40px" OnClick="Button1_Click" Text="Home" Width="140px" />
        
        <asp:Button ID="BTN_Page2" runat="server" Height="40px" OnClick="Button2_Click" Text="B" Width="140px" />
        
        <asp:Button ID="BTN_Page3" runat="server" Height="40px" OnClick="Button3_Click" Text="C" Width="140px" />
        
        <asp:ImageButton ID="ImageButton2" runat="server" Height="50px" ImageUrl="https://image.prntscr.com/image/zi8XYbUzS7ScsofKeOKC6g.png" OnClick="ImageButton2_Click" Width="110px" />
        <asp:ImageButton ID="ImageButton3" runat="server" Height="44px" ImageUrl="https://image.prntscr.com/image/3GIsfEI4QyG5sVS52O_wOA.png" OnClick="ImageButton3_Click" Width="129px" />
        <br />
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
            
            <asp:View ID="View1" runat="server">
                <br />
                a
            </asp:View>
            
            <asp:View ID="View2" runat="server">
                <br />
                b
            </asp:View>
            
            <asp:View ID="View3" runat="server">
                <br />
                c
            </asp:View>
            
            <asp:View ID="View4" runat="server">
                <br />
                Login
            </asp:View>
            
            <asp:View ID="View5" runat="server">
                <br />
                Register<br />
                <br />
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style2">User Name</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="TXB_Reg_UserName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="User name required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">E-mail</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="TXB_Reg_Email" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="E-mail required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Password</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="TXB_Reg_Password" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Password required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Confirm Password</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="TXB_Reg_ConfirmPassword" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Password confirmation required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                        <td>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords do not match"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
