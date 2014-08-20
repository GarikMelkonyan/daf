using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAF.Web.Helpers;

namespace DAF.Web.Admin
{
    public partial class ApplicationDocumentsManagement : AKPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                LoadApplications();
                LoadDocuments();
            }
        }

        private void LoadApplications()
        {
            throw new NotImplementedException();
        }

        private void LoadDocuments()
        {
            throw new NotImplementedException();
        }

        protected void lstApplications_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void chklstAppDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void chklstDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}