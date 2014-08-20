<%@ Page Title="Support" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Support.aspx.cs" Inherits="DAF.Web.Support" %>

<%@ Register TagPrefix="AK" TagName="TextControl" Src="~/Controls/TextControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <AK:TextControl runat="server" ControlName="Support" />
</asp:Content>
