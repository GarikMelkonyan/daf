using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAF.Business;
using DAF.Web.Helpers;

namespace DAF.Web.Admin
{
    public partial class ApplicationsManagement : AKPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadApplications();
            }
        }

        private void LoadApplications()
        {
            lstApplications.DataSource = ApplicationManager.GetApplications();
            lstApplications.DataBind();
        }

        protected void ibAdd_Click(object sender, ImageClickEventArgs e)
        {
            WebHelper.Redirect(PageNames.ApplicationDetails, FolderNames.Admin);
        }

        protected void ibEdit_Click(object sender, ImageClickEventArgs e)
        {
            if (lstApplications.SelectedIndex == -1) return;

            URL url = new URL(PageNames.ApplicationDetails, FolderNames.Admin);
            url.Parameters[Constants.RQ_ApplicationID] = lstApplications.SelectedValue;
            url.Redirect();
        }

        protected void ibDelete_Click(object sender, ImageClickEventArgs e)
        {
            if (lstApplications.SelectedIndex == -1) return;

            try
            {
                ApplicationManager.DeleteApplication(AKConvert.ToInt64(lstApplications.SelectedValue));
                LoadApplications();
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.ToString());
            }
        }
    }
}