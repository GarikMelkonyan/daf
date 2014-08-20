<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="FeatureDetail.aspx.cs" Inherits="DAF.Web.Admin.FeatureDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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

<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">
    <table>
        <tr>
            <td valign="middle">
                Application:
            </td>
            <td></td>
            <td>
                <asp:DropDownList runat="server" ID="ddlApplications" DataValueField="ID" DataTextField="Title" CssClass="defSelect" />
            </td>
        </tr>
        <tr>
            <td>Name:
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="Name is required" CssClass="error" ControlToValidate="txtName" runat="server"
                    SetFocusOnError="true" ValidationGroup="vgFeature">
                    *
                </asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtName" CssClass="defText" />
            </td>
        </tr>
        <tr>
            <td valign="middle">Description:
            </td>
            <td></td>
            <td>
                <asp:TextBox runat="server" ID="txtDescription" CssClass="defText" />
            </td>
        </tr>
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
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button runat="server" ID="btnSave" Text=" Save " OnClick="btnSave_Click" CssClass="btnDefault" ValidationGroup="vgFeature"/>&nbsp;
                <asp:Button runat="server" ID="btnCancel" Text=" Cancel " OnClick="btnCancel_Click" CssClass="btnDefault" />
            </td>
        </tr>
    </table>
</asp:Content>
