<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DemoDocumentManagementControl.ascx.cs" Inherits="DAF.Web.Controls.DemoDocumentManagementControl" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<table style="width: 100%">
        <tr>
            <td style="width: 100%">
                <asp:ListBox runat="server" ID="lstDocuments" DataTextField="Title" DataValueField="ID" Width="100%" OnSelectedIndexChanged="lstDocuments_SelectedIndexChanged" AutoPostBack="true" />
            </td>
            <td style="width: 50px">
                <asp:ImageButton ID="ibAdd" runat="server" ImageUrl="~/Images/Add.png" Width="25px" Height="25px" OnClick="ibAdd_Click" />
                <br />
                <asp:ImageButton ID="ibDelete" runat="server" ImageUrl="~/Images/Delete.png" Width="25px" Height="25px" OnClick="ibDelete_Click" />
            </td>
        </tr>
    </table>
    <br />
    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="ibDelete"
        DisplayModalPopupID="ModalPopupExtender1" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="ibDelete"
        PopupControlID="PNL" OkControlID="ButtonOk" CancelControlID="ButtonCancel" BackgroundCssClass="modalBackground" />
    <asp:Panel ID="PNL" runat="server" Style="display: none; width: 400px; background-color: White; border-width: 2px; border-color: Black; border-style: solid; padding: 20px;">
        <asp:Literal ID="Literal1" runat="server" Text="Are You sure You want to delete this item ?" />
		<br />
        <br />
        <div style="text-align: right;">
            <asp:Button ID="ButtonOk" runat="server" Text=" Delete " CssClass="btnDefault" />
            <asp:Button ID="ButtonCancel" runat="server" Text=" Cancel " CssClass="btnDefault" />
        </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnlEdit">
        <table>
            <tr>
                <td>
                    Name:
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vgDocument" ControlToValidate="txtTitle" 
                        CssClass="error" SetFocusOnError="true" ErrorMessage="Name is requered" 
                        ToolTip="Name is requered">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTitle" CssClass="defText" />
                </td>
            </tr>
            <tr>
                <td>
                    File name:
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="vgDocument" ControlToValidate="txtFileName" 
                        CssClass="error" SetFocusOnError="true" ErrorMessage="File name is requered" 
                        ToolTip="File name is requered">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtFileName" CssClass="defText" />
                </td>
            </tr>
            <tr>
                <td>
                    Document:
                </td>
                <td>
                    
                </td>
                <td>
                    <asp:HyperLink runat="server" ID="hpDocument" Target="_blank" />
                    <br />
                    <asp:FileUpload runat="server" ID="fuDocument" />
                </td>
            </tr>
            <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Button runat="server" ID="btnSave" Text=" Save " OnClick="btnSave_Click" CssClass="btnDefault" ValidationGroup="vgFeature"/>&nbsp;
                <asp:Button runat="server" ID="btnCancel" Text=" Cancel " OnClick="btnCancel_Click" CssClass="btnDefault" />
            </td>
        </tr>
        </table>
    </asp:Panel>