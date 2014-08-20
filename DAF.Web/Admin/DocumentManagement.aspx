<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="DocumentManagement.aspx.cs" Inherits="DAF.Web.Admin.DocumentManagement" %>
<%@ Register TagPrefix="AK" TagName="DemoDocumentManagementControl" Src="~/Controls/DemoDocumentManagementControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <AK:DemoDocumentManagementControl runat="server" ControlType="Document" />
</asp:Content>
