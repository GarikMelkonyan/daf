using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace DAF.Web.Helpers
{
	public class AKPage : Page
	{
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			//(this.Master as SiteMaster).ChangeActiveLanguageLinkStyle(Language);
			if (!Page.IsPostBack )
			{
				//Language = (int)GetLanguageEnumValue(Session[Constants.SS_CULTURE].ToString());
			}
		}

		protected void Redirect(PageNames pageToRedirect)
		{
			Response.Redirect(string.Format("~/{0}.aspx", pageToRedirect));
		}

		protected override void OnUnload(EventArgs e)
		{
			HttpContext.Current.Response.Cache.SetAllowResponseInBrowserHistory(true);
			base.OnUnload(e);
		}

        public virtual void DisplayErrorMessage(string message)
        {
            Response.Write(string.Format(@"<script>alert(""{0}"");</script>", message.Replace("<br />", " ")
                                                                                    .Replace("<br >", " ")
                                                                                    .Replace("<br>", " ")));
        }

        protected virtual void DisplaySuccessMessage(string message)
        {
            DisplayErrorMessage(message);
        }
	}

}