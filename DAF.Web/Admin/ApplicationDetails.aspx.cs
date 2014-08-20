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
    public partial class ApplicationDetails : AKPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var appID = Validation.ValidateRequestParam(Request.QueryString[Constants.RQ_ApplicationID]);
                if (appID < 0)
                {
                    WebHelper.RedirectToErrorPage(Errors.InvalidParameters);
                }
                var application = ApplicationManager.GetApplication(appID);
                lstDemos.DataSource = DemoManager.GetDemos();
                lstDemos.DataBind();
                lstDocuments.DataSource = DocumentManager.GetDocuments();
                lstDocuments.DataBind();
                img.ImageUrl = Constants.DefaultImageURL;
                if (application == null) return;

                txtTitle.Text = application.Title;
                txtShortDescription.Text = application.ShortDescription;
                txtLongDescription.Content = application.LongDescription;
                btnSave.CommandArgument = application.ID.ToString();
                if (!string.IsNullOrWhiteSpace(application.ImagePath))
                {
                    btnClearImage.CommandArgument = application.ImagePath;
                    img.ImageUrl = Constants.ApplicationImagesFolderPath + application.ImagePath;
                }
                
                if (application.ApplicationDemos != null)
                {
                    foreach (ApplicationDemo demo in application.ApplicationDemos)
                    {
                        lstDemos.SelectByValue(demo.DemoID.ToString());
                    }
                }
                if (application.ApplicationDocuments != null)
                {
                    foreach (ApplicationDocument document in application.ApplicationDocuments)
                    {
                        lstDocuments.SelectByValue(document.DocumentID.ToString());
                    }
                }
                txtFeatures.Text = string.Join(Environment.NewLine, application.Features.Select(s => s.Title));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SoftApplication application = new SoftApplication();
            application.Title = txtTitle.Text.Trim();
            application.ShortDescription = txtShortDescription.Text.Trim();
            application.LongDescription = txtLongDescription.Content;
            application.ID = AKConvert.ToInt64(btnSave.CommandArgument);
            application.DocumentIDs = (from ListItem li in lstDocuments.Items where li.Selected select AKConvert.ToInt64(li.Value)).ToList();
            application.DemoIDs = (from ListItem li in lstDemos.Items where li.Selected select AKConvert.ToInt64(li.Value)).ToList();
            application.FeatureNames = txtFeatures.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            try
            {
                ApplicationManager.SaveApplication(application);
                if (fuImage != null && fuImage.PostedFile != null && !string.IsNullOrEmpty(fuImage.FileName))
                {
                    string file = Constants.ApplicationImagesFolderPhisicalPath + application.ID + Path.GetExtension(fuImage.FileName);

                    fuImage.SaveAs(file);
                    ApplicationManager.UpdateApplicationImagePath(application.ID, Path.GetFileName(file));
                }
                RedirectBack();
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.ToString());
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RedirectBack();
        }

        private void RedirectBack()
        {
            WebHelper.Redirect(PageNames.ApplicationsManagement, FolderNames.Admin);
        }

        protected void btnClearImage_Click(object sender, EventArgs e)
        {
            var path = Constants.ApplicationImagesFolderPhisicalPath + btnClearImage.CommandArgument;

            if (File.Exists(path))
            {
                File.Delete(path);
                ApplicationManager.DeleteApplicationImage(AKConvert.ToInt64(btnSave.CommandArgument));
                img.ImageUrl = Constants.DefaultImageURL;
            }
        }
    }
}