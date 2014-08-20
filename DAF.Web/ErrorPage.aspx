<%@ Page Title="Garik Melkonyan" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ErrorPage.aspx.cs" Inherits="DAF.Web.ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="contentBlock" style="margin-top: 40px;">
		<center>
			<asp:Label runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Large" ID="lblErrorMessage" />
		</center>
	</div>
    <br />
    <br />
</asp:Content>
