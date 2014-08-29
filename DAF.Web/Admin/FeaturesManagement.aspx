<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="FeaturesManagement.aspx.cs" Inherits="DAF.Web.Admin.FeaturesManagement" %>
<%@ Register TagPrefix="ajaxControlToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <asp:DropDownList runat="server" ID="ddlApplications" DataValueField="ID" DataTextField="Title" AutoPostBack="true" 
        OnSelectedIndexChanged="ddlApplications_SelectedIndexChanged" CssClass="defSelect" />
    <br />
    <br />
    <table style="width:100%">
        <tr>
            <td style="width:100%">
                <asp:ListBox runat="server" ID="lstFeatures" DataTextField="Title" DataValueField="ID" Width="100%" Height="500px" />
            </td>
            <td style="width:50px">
                <asp:ImageButton ID="ibAdd" runat="server" ImageUrl="~/Images/Add.png" Width="25px" Height="25px" OnClick="ibAdd_Click" />
                <br />
                <asp:ImageButton ID="ibEdit" runat="server" ImageUrl="~/Images/Edit.png" Width="25px" Height="25px"  OnClick="ibEdit_Click" />
                <br />
                <asp:ImageButton ID="ibDelete" runat="server" ImageUrl="~/Images/Delete.png" Width="25px" Height="25px" OnClick="ibDelete_Click" />
            </td>
        </tr>
    </table>
    
    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="ibDelete"
        DisplayModalPopupID="ModalPopupExtender1" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="ibDelete"
        PopupControlID="PNL" OkControlID="ButtonOk" CancelControlID="ButtonCancel" BackgroundCssClass="modalBackground" />
    <asp:Panel ID="PNL" runat="server" Style="display: none; width: 400px; background-color: White; border-width: 2px; border-color: Black; border-style: solid; padding: 20px;">
        <asp:Literal ID="Literal1" runat="server" Text="Are You sure You want to delete this feature ?" />
		<br />
        <br />
        <div style="text-align: right;">
            <asp:Button ID="ButtonOk" runat="server" Text=" Delete " CssClass="btnDefault" />
            <asp:Button ID="ButtonCancel" runat="server" Text=" Cancel " CssClass="btnDefault" />
        </div>
    </asp:Panel>

</asp:Content>
