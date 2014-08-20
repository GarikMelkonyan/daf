using System;
using System.ComponentModel;
using DAF.DataAccess;
using DAF.Web.Helpers;

namespace DAF.Web.Controls
{
    public partial class TextControl : System.Web.UI.UserControl
    {
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public string TitleCssClass { get; set; }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public string TextCssClass { get; set; }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public string ControlName { get; set; }

        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //public int Language { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (string.IsNullOrEmpty(ControlName)) throw new NullReferenceException();
            lblText.CssClass = TextCssClass;
            lblTitle.CssClass = TitleCssClass;
            trEditButton.Visible = Page.User.Identity.IsAuthenticated; //.IsInRole(Constants.ROLE_ADMINISTRATOR);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadTexts();
            }
        }

        private void LoadTexts()
        {
            TextContent text = CacheManager.GetTextContent(ControlName);
            if (text != null)
            {
                lblTitle.Text = text.Title;
                lblText.Text = text.Content;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            URL url = new URL(PageNames.TextContentEdit, FolderNames.Admin);
            url.Parameters[Constants.RQ_TEXT_CONTENT_ID] = ControlName;
            Response.Redirect(url.ToString());
        }
    }
}