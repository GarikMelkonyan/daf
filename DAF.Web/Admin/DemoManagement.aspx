<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="DemoManagement.aspx.cs" Inherits="DAF.Web.Admin.DemoManagement" %>
<%@ Register TagPrefix="AK" TagName="DemoDocumentManagementControl" Src="~/Controls/DemoDocumentManagementControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <AK:DemoDocumentManagementControl runat="server" ControlType="Demo" />
</asp:Content>
