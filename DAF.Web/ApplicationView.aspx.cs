using DAF.Business;
using DAF.DataAccess;
using DAF.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DAF.Web
{
    public partial class ApplicationView : AKPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Page.RouteData.Values[Constants.RQ_Application] == null)
                {
                    WebHelper.RedirectToErrorPage(Errors.InvalidParameters);
                    return;
                }
                string[] arg = Page.RouteData.Values[Constants.RQ_Application].ToString().Split('-');
                if (arg.Length > 0)
                {
                    long appID = long.Parse(arg[0]);
                    if (appID <= 0)
                    {
                        WebHelper.RedirectToErrorPage(Errors.InvalidParameters);
                        return;
                    }
                    var app = ApplicationManager.GetApplication(appID);
                    if (app == null)
                    {
                        WebHelper.RedirectToErrorPage(Errors.InvalidParameters);
                        return;
                    }
                    LoadApplication(app);
                }
                else
                {
                    WebHelper.RedirectToErrorPage(Errors.InvalidParameters);
                }
            }
        }

        private void LoadApplication(SoftApplication app)
        {
            ltrTitle.Text = this.Title = img.AlternateText = app.Title;
            lblShortDescription.Text = app.ShortDescription;
            ltrLongDescription.Text = app.LongDescription;
            if (string.IsNullOrWhiteSpace(app.ImagePath))
            {
                img.Visible = false;
            }
            else
            {
                img.ImageUrl = Constants.ApplicationImagesFolderPath + app.ImagePath;
            }
            if (app.ApplicationDemos != null)
            {
                rptDemos.DataSource = DemoManager.GetApplicationDemos(app.ID);
                rptDemos.DataBind();
            }
            if (app.Features != null)
            {
                rptFeatures.DataSource = app.Features;
                rptFeatures.DataBind();
            }
            if (app.ApplicationDocuments != null)
            {
                rptDocuments.DataSource = DocumentManager.GetDocuments(app.ID);
                rptDocuments.DataBind();
            }
        }

        protected void lbDocument_Click(object sender, EventArgs e)
        {
            Response.WriteFile(Constants.DocumentsFolderPath + ((LinkButton)sender).CommandArgument);
        }

        protected void lbDemo_Click(object sender, EventArgs e)
        {
            Response.WriteFile(Constants.DemosFolderPath + ((LinkButton)sender).CommandArgument);
        }
    }
}