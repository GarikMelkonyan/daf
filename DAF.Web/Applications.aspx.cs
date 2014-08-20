using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAF.Business;
using DAF.DataAccess;
using DAF.Web.Helpers;

namespace DAF.Web
{
    public partial class Applications : AKPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptApplications.DataSource = ApplicationManager.GetApplications();
                rptApplications.DataBind();
            }
        }

        protected void rptApplications_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item != null && e.Item.DataItem != null)
            {
                SoftApplication app = e.Item.DataItem as SoftApplication;
                ((LinkButton)e.Item.FindControl("lbShowMore")).CommandArgument = string.Format("{0}-{1}", app.ID, app.Title.ReplaceCharsToValidURL());
                if (!string.IsNullOrWhiteSpace(app.ImagePath))
                {
                    ((Image) e.Item.FindControl("img")).ImageUrl = Constants.ApplicationImagesFolderPath + app.ImagePath;
                }
                else
                {
                    ((Image) e.Item.FindControl("img")).ImageUrl = Constants.DefaultImageURL;
                }
            }
        }

        protected void lbShowMore_Click(object sender, EventArgs e)
        {
            var url = Page.GetRouteUrl(Constants.RN_Application_View, new {app = (sender as LinkButton).CommandArgument});
            Response.Redirect(url);
        }
    }
}