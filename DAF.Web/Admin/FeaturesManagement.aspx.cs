using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAF.Business;
using DAF.DataAccess;
using DAF.Web.Helpers;

namespace DAF.Web.Admin
{
    public partial class FeaturesManagement : AKPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WebHelper.LoadDropDown(ddlApplications, ApplicationManager.GetApplications(), "Main Features");
                var appID = Validation.ValidateRequestParam(Request.QueryString[Constants.RQ_ApplicationID]);
                if (appID > 0)
                {
                    ddlApplications.SelectByValue(appID);
                }

                LoadFeatures();
            }
        }

        protected void ddlApplications_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFeatures();
        }

        private void LoadFeatures()
        {
            lstFeatures.DataSource = FeaturesManager.GetFeatures(ddlApplications.SelectedValue == "0" ? (long?)null : AKConvert.ToInt64(ddlApplications.SelectedValue));
            lstFeatures.DataBind();
        }

        protected void ibAdd_Click(object sender, ImageClickEventArgs e)
        {
            if (lstFeatures.SelectedIndex == -1) return;

            RedirectToFeatureDetailPage();
        }

        private void RedirectToFeatureDetailPage(string featureID = null)
        {
            URL url = new URL(PageNames.FeatureDetail, FolderNames.Admin);
            if (!string.IsNullOrWhiteSpace(featureID))
            {
                url.Parameters[Constants.RQ_ITEM_ID] = featureID;
            }
            url.Redirect();
        }

        protected void ibEdit_Click(object sender, ImageClickEventArgs e)
        {
            if (lstFeatures.SelectedIndex == -1) return;
            RedirectToFeatureDetailPage(lstFeatures.SelectedValue);
        }

        protected void ibDelete_Click(object sender, ImageClickEventArgs e)
        {
            if (lstFeatures.SelectedIndex == -1) return;
            if (FeaturesManager.DeleteFeature(AKConvert.ToInt64(lstFeatures.SelectedValue)))
            {
                LoadFeatures();
            }
            else
            {
                DisplayErrorMessage("Can not delete feature");
            }
        }
    }
}