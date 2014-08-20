<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextControl.ascx.cs"
    Inherits="DAF.Web.Controls.TextControl" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="right" runat="server" id="trEditButton">
            <asp:Button runat="server" ID="btnEdit" CssClass="btnDefault" OnClick="btnEdit_Click" Text="Edit" />
        </td>
    </tr>
    <tr>
        <td align="center">
            <h2>
                <asp:Label runat="server" ID="lblTitle" />
            </h2>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:Label runat="server" ID="lblText" />
        </td>
    </tr>
    
</table>
