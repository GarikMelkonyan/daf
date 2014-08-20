<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
	CodeBehind="TextContentEdit.aspx.cs" Inherits="DAF.Web.Admin.TextContentEdit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="HTMLEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <table border="0" cellpadding="0" cellspacing="2">
        <tr>
            <td colspan="3" align="center">
                <asp:Label runat="server" ID="lblErrorMessage" Font-Bold="true" ForeColor="Red" Visible="false" />
            </td>
        </tr>
        <tr>
            <td align="right" style="white-space: nowrap">
                Title:
            </td>
            <td>
                &nbsp;
            </td>
            <td align="left" style="white-space: nowrap">
                <asp:TextBox runat="server" ID="txtTitle" CssClass="defText" />
            </td>
        </tr>
        
        <tr>
            <td valign="middle" align="right" style="white-space: nowrap">
                Content:
            </td>
            <td>
                &nbsp;
            </td>
            <td align="left">
                <HTMLEditor:Editor runat="server" Id="txtContent" Height="400px" AutoFocus="true" Width="750" />
            </td>
        </tr>
        
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" align="right">
                <asp:Button runat="server" ID="btnSave" CssClass="btnDefault" Text=" Save " OnClick="btnUpdate_Click" />
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
