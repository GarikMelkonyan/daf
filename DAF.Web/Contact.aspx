<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="DAF.Web.Contact" %>
<%@ Register TagPrefix="AK" TagName="TextControl" Src="~/Controls/TextControl.ascx" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section class="col1">
        <AK:TextControl runat="server" ControlName="Contact" />
    </section>
    <section class="col2">
        <h2 class="pad_bot1">Contact Form</h2>
        <div class="ContactForm">
            <div class="wrapper">
                <span>Your Name:
                </span>
                <div>
                    <asp:TextBox runat="server" ID="txtName" Width="500px" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" CssClass="error"
                        ErrorMessage="Name is required" ToolTip="Name is required" SetFocusOnError="true"
                        ValidationGroup="vgEmail">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Error.gif" />
                    </asp:RequiredFieldValidator>

                </div>
            </div>
            <div class="wrapper">
                <span>Your E-mail:
                    
                </span>
                <div>
                    <asp:TextBox runat="server" ID="txtEmail" Width="500px" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" CssClass="error"
                        ErrorMessage="Email is required" ToolTip="Email is required" SetFocusOnError="true"
                        ValidationGroup="vgEmail">
                        <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/Error.gif" />
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtEmail" ErrorMessage="Email not in correct"
                        runat="server" ToolTip="Email not in correct" ValidationGroup="vgEmail" SetFocusOnError="true"
                        ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Error.gif" />
                    </asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="textarea_box">
                <span style="width: 100%">Your Message:
                </span>
                <div style="float: left">
                    <asp:TextBox runat="server" ID="txtMessage" TextMode="MultiLine" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMessage" CssClass="error"
                        ErrorMessage="Message is required" ToolTip="Message is required" SetFocusOnError="true"
                        ValidationGroup="vgEmail">
                        <asp:Image runat="server" ImageUrl="~/Images/Error.gif" />
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <br />
            <div style="padding-right: 30px">
                <asp:LinkButton runat="server" CssClass="button" Text="Clear" OnClick="lbClear_Click" ID="lbClear" />
                <asp:LinkButton runat="server" CssClass="button" Text="Send" ValidationGroup="vgEmail" OnClick="lbSend_Click" ID="lbSend" />
            </div>
        </div>
    </section>
</asp:Content>
