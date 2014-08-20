<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApplicationView.aspx.cs" Inherits="DAF.Web.ApplicationView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td align="center">
                <h2>
                    <asp:Literal runat="server" ID="ltrTitle" />
                </h2>
            </td>
        </tr>
        <tr>
            <td>
                <section class="col1">
                    <asp:Image runat="server" ID="img" Width="275px" />
                </section>

                <section class="col2">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblShortDescription" runat="server" />

                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Repeater runat="server" ID="rptDocuments">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("DocumentPath") %>' Text='<%# Eval("Title") %>' OnClick="lbDocument_Click" CssClass="button" />
                                    </ItemTemplate>
                                    <SeparatorTemplate>
                                        &nbsp;
                                    </SeparatorTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Repeater runat="server" ID="rptDemos">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("DemoPath") %>' Text='<%# Eval("Title") %>' OnClick="lbDemo_Click" CssClass="button" />
                                    </ItemTemplate>
                                    <SeparatorTemplate>
                                        &nbsp;
                                    </SeparatorTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </table>
                </section>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <section class="col1">
                    <asp:Repeater runat="server" ID="rptFeatures">
                        <HeaderTemplate>
                            <ul style="list-style: circle;">
                        </HeaderTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                        <ItemTemplate>
                            <li>
                                <b><asp:Literal runat="server" Text='<%# Eval("Title") %>' /></b>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </section>
                <section class="col2">
                    <asp:Literal runat="server" ID="ltrLongDescription" />
                </section>
            </td>
        </tr>
    </table>
</asp:Content>
