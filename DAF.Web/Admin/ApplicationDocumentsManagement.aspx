<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="ApplicationDocumentsManagement.aspx.cs" Inherits="DAF.Web.Admin.ApplicationDocumentsManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <asp:ListBox runat="server" ID="lstApplications" DataTextField="Title" DataValueField="ID" OnSelectedIndexChanged="lstApplications_SelectedIndexChanged" AutoPostBack="true" CssClass="defSelect" />
    <br />
    <br />
    <asp:Panel runat="server" GroupingText="Application Documents">
        <asp:CheckBoxList runat="server" ID="chklstAppDocuments" DataTextField="Title" DataValueField="ID" OnSelectedIndexChanged="chklstAppDocuments_SelectedIndexChanged" />
    </asp:Panel>
    <br />
    <br />
    <asp:Panel runat="server" GroupingText="Documents">
        <asp:CheckBoxList runat="server" ID="chklstDocuments" DataTextField="Title" DataValueField="ID" OnSelectedIndexChanged="chklstDocuments_SelectedIndexChanged" />
    </asp:Panel>
</asp:Content>
