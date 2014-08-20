<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="ApplicationDetails.aspx.cs" Inherits="DAF.Web.Admin.ApplicationDetails" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit.HTMLEditor" Assembly="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script type="text/javascript">

        $('#<% = fuImage.ClientID %>').live('change', function () {
            ReadImg(this);
            return true;
        });

        function ReadImg(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    var data = e.target.result;
                    $('#<% = img.ClientID %>').attr('src', data);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <table>
        <tr>
            <td valign="middle">
                Image:
            </td>
            <td></td>
            <td>
                
                <asp:Image runat="server" ID="img" Height="100px" ClientIDMode="Static" /><br />
                <asp:FileUpload runat="server" ID="fuImage" ClientIDMode="Static" />
                <br />
                <asp:Button runat="server" ID="btnClearImage" Text="Delete image" OnClick="btnClearImage_Click" CssClass="btnDefault" />

            </td>
        </tr>
        <tr>
            <td>Name:
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTitle" CssClass="error"
                    ErrorMessage="Name is required" ToolTip="Name is required" SetFocusOnError="true"
                    ValidationGroup="vgApplication">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtTitle" CssClass="defText" />
            </td>
        </tr>
        <tr>
            <td>Short description:
            </td>
            <td>&nbsp;
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtShortDescription" CssClass="defText" TextMode="MultiLine" Height="100px" Width="780px" />
            </td>
        </tr>
        <tr>
            <td>Long description:
            </td>
            <td>&nbsp;
            </td>
            <td>
                <ajaxToolkit:Editor runat="server" ID="txtLongDescription" OutputXHTML="true" Width="800px" Height="400px" />
            </td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td>Features
            </td>
            <td></td>
            <td>
                <asp:TextBox runat="server" ID="txtFeatures" CssClass="defText" TextMode="MultiLine" Height="400px" />
            </td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel runat="server" GroupingText="Documents">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lstDocuments" DataTextField="Title" DataValueField="ID" Width="100%" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="Panel1" runat="server" GroupingText="Demos">
                    <asp:ListBox ID="lstDemos" runat="server" SelectionMode="Multiple" DataTextField="Title" DataValueField="ID" Width="100%" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Button runat="server" ID="btnSave" Text=" Save " OnClick="btnSave_Click" CssClass="btnDefault" ValidationGroup="vgApplication" />&nbsp;
                <asp:Button runat="server" ID="btnCancel" Text=" Cancel " OnClick="btnCancel_Click" CssClass="btnDefault" />
            </td>
        </tr>
    </table>
</asp:Content>
