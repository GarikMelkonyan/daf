using System;
using DAF.Web.Helpers;

namespace DAF.Web
{
	public partial class ErrorPage : AKPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{

				Errors error;
				if (!Enum.TryParse<Errors>(Request.QueryString[Constants.RQ_ERROR_ID], out error))
				{
					error = Errors.UnknownError;
				}
				DisplayMessage(error);
			}
		}

		private void DisplayMessage(Errors error)
		{
			switch (error)
			{
			    case Errors.InvalidParameters:
			        lblErrorMessage.Text = "Invalid parameters";
			        break;
			    case Errors.ApplicationNotFound:
			        lblErrorMessage.Text = "Application not found";
			        break;
			    default:
			        lblErrorMessage.Text = "Unknown error";
                    break;
			}
		}
	}
}