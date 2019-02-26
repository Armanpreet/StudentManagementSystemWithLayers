<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Teachers.aspx.cs" Inherits="StudentManagementSystemWithLayers.Teachers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="XX-Large" ForeColor="#993300" Text="Teachers"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 80px">Name:</td>
            <td style="width: 216px">
                <asp:TextBox ID="txtTeacherName" runat="server" Width="244px"></asp:TextBox>
            </td>
            <td rowspan="3">&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:GridView ID="GridViewTeacher" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnSelectedIndexChanged="GridViewTeacher_SelectedIndexChanged">
                    <Columns>
                        <asp:ButtonField CommandName="Select" HeaderText="Select" ShowHeader="True" Text="Select" />
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:BoundField DataField="TeacherName" HeaderText="Teacher Name" />
                        <asp:BoundField DataField="Qualification" HeaderText="Qualification" />
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
                </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 80px">Qualification:</td>
            <td style="width: 216px">
                <asp:TextBox ID="txtQualification" runat="server" Width="242px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 80px">&nbsp;</td>
            <td style="width: 216px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="92px" />
                &nbsp;&nbsp;
                <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" Width="92px" />
                &nbsp;&nbsp;
                <asp:Button ID="BtnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" Width="92px" OnClientClick="return confirm('Are you sure you want delete this data?')" />
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 80px">&nbsp;</td>
            <td style="width: 216px">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtId" runat="server" type="hidden"></asp:TextBox>
            </td>
            
        </tr>
    </table>
</asp:Content>
