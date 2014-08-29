using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAF.Business;
using DAF.DataAccess;
using DAF.Web.Helpers;

namespace DAF.Web.Admin
{
    public partial class FeatureDetail : AKPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                WebHelper.LoadDropDown(ddlApplications, ApplicationManager.GetApplications(), "Main Feature");
                var appID = Validation.ValidateRequestParam(Request.QueryString[Constants.RQ_ApplicationID]);
                if (appID > 0)
                {
                    ddlApplications.SelectByValue(appID);
                }
                var id = Validation.ValidateRequestParam(Request.QueryString[Constants.RQ_ITEM_ID]);
                if (id <= 0) return;

                Feature feature = FeaturesManager.GetFeature(id);
                if (feature == null) return;

                txtName.Text = feature.Title;
                txtDescription.Text = feature.Description;
                if (feature.ApplicationID.HasValue)
                {
                    ddlApplications.SelectByValue(feature.ApplicationID.Value);
                }
                if (!string.IsNullOrWhiteSpace(feature.ImageName))
                {
                    img.ImageUrl = Constants.FeatureImagesFolderPath + feature.ImageName;
                }
                else
                {
                    img.ImageUrl = Constants.DefaultImageURL;
                }
                btnSave.CommandArgument = feature.ID.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Feature feature = new Feature
            {
                ID = AKConvert.ToInt64(btnSave.CommandArgument),
                Title = txtName.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };
            if (ddlApplications.SelectedValue != "0")
            {
                feature.ApplicationID = AKConvert.ToInt64(ddlApplications.SelectedValue);
            }
            if (FeaturesManager.SaveFeature(feature))
            {
                if (fuImage != null && fuImage.PostedFile != null && !string.IsNullOrEmpty(fuImage.FileName))
                {
                    string file = Constants.FeatureImagesFolderPhisicalPath + feature.ID + Path.GetExtension(fuImage.FileName);
                        
                    fuImage.SaveAs(file);
                    FeaturesManager.UpdateFeatureImage(feature.ID, Path.GetFileName(file));
                }
                CacheManager.RefreshFeatures();
                RedirectBack();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RedirectBack();
        }

        private void RedirectBack()
        {
            URL url = new URL(PageNames.FeaturesManagement, FolderNames.Admin);
            var appid = Request.QueryString[Constants.RQ_ApplicationID];
            if (!string.IsNullOrWhiteSpace(appid))
            {
                url.Parameters[Constants.RQ_ApplicationID] = appid;
            }
            url.Redirect();
        }

        protected void btnClearImage_Click(object sender, EventArgs e)
        {
            var path = Constants.FeatureImagesFolderPhisicalPath + btnClearImage.CommandArgument;

            if (File.Exists(path))
            {
                File.Delete(path);
                img.ImageUrl = Constants.DefaultImageURL;
            }
        }
    }
}