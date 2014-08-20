using System;
using DAF.Business;
using DAF.DataAccess;
using DAF.Web.Helpers;

namespace DAF.Web.Admin
{
	public partial class TextContentEdit : AKPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (!string.IsNullOrEmpty(Request.QueryString[Constants.RQ_TEXT_CONTENT_ID]))
				{
					LoadTextContent(Request.QueryString[Constants.RQ_TEXT_CONTENT_ID]);
				}
				else
				{
					WebHelper.RedirectToErrorPage(Errors.InvalidParameters);
				}
			}
		}

		private void LoadTextContent(string textContentControlName)
		{
			TextContent text = TextContentManager.GetTextContent(textContentControlName);
			if (text != null)
			{
				txtContent.Content = text.Content ?? string.Empty;
				txtTitle.Text = text.Title ?? string.Empty;
			}
			btnSave.CommandArgument = textContentControlName;
		}

		protected void btnUpdate_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(btnSave.CommandArgument))
			{
				TextContent tc = new TextContent
									{
										Content = txtContent.Content,
										Title = txtTitle.Text,
										ControlName = btnSave.CommandArgument
									};
				if (TextContentManager.UpdateTextContent(tc))
				{
					//UICacheManager.RefreshTextContent(tc.ControlName);
					Response.Redirect(string.Format("~/{0}.aspx", tc.ControlName));
				}
				else
				{
					DisplayErrorMessage();
				}
			}
		}

		private void DisplayErrorMessage()
		{
			lblErrorMessage.Text = "Can not update text content";
			lblErrorMessage.Visible = true;
		}
	}
}
