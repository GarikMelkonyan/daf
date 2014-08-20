<%@ Page Title="Applications" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Applications.aspx.cs" Inherits="DAF.Web.Applications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater runat="server" ID="rptApplications" OnItemDataBound="rptApplications_ItemDataBound">
        <ItemTemplate>
            <h2 class="pad_bot1">
                <asp:Literal runat="server" Text='<%# Eval("Title") %>' />
            </h2>
            <div class="wrapper">
                <figure class="left marg_right1">
                    <asp:Image runat="server" ID="img" alt="" Height="150px" />
                </figure>

                <p class="pad_bot3">
                    <asp:Literal runat="server" Text='<%# Eval("ShortDescription") %>' />
                </p>
                <asp:LinkButton runat="server" CssClass="button right" OnClick="lbShowMore_Click" ID="lbShowMore" >Read More</asp:LinkButton>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
