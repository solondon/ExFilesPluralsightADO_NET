<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPDemo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Employee Id:"></asp:Label>
        <asp:TextBox ID="TextBoxEID" runat="server"></asp:TextBox>
&nbsp;
        <asp:LinkButton ID="LinkButtonGetEmployee" runat="server" OnClick="LinkButtonGetEmployee_Click">Go</asp:LinkButton>
        <br />
        <br />
        <table class="auto-style1">
            <tr>
                <td>First Name</td>
                <td>
                    <asp:TextBox ID="TextBoxFName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Last Name</td>
                <td>
                    <asp:TextBox ID="TextBoxLName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Department</td>
                <td>
                    <asp:TextBox ID="TextBoxDepartment" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="LinkButtonUpdateDepartmentName" runat="server" OnClick="LinkButtonUpdateDepartmentName_Click">Update</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelDeptId" runat="server" Text="0"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:LinkButton ID="LinkButtonDeleteLog" runat="server" OnClick="LinkButtonDeleteLog_Click">Delete Log</asp:LinkButton>
        <br />
    
    </div>
    </form>
</body>
</html>
