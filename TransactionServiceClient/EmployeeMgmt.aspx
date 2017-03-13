<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeMgmt.aspx.cs" Inherits="TransactionServiceClient.EmployeeMgmt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 50%">
    <fieldset>
        <legend>Create Employee</legend>
        <table width="100%">     
            <tr>
                <td style="text-align: right">Name:</td>
                <td>
                    <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Salary:</td>
                <td>
                    <asp:TextBox ID="txtEmployeeSalary" runat="server"></asp:TextBox>
                </td>
            </tr>			
            <tr>
                <td style="text-align: right">&nbsp;</td>
                <td>
                    <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create" />
                </td>
            </tr>
			<tr>
                <td style="text-align: right">Status:</td>
                <td>
                    <asp:TextBox ID="txtStatus" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </fieldset>
    </div>
    </form>
</body>
</html>
