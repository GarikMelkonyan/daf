using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAF.DataAccess;
using DAF.Web.Helpers;

namespace DAF.Web
{
    public partial class _Default : AKPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Page.IsPostBack)
                {
                    rptFeatures.DataSource = CacheManager.GetMainFeatures();
                    rptFeatures.DataBind();
                }
            }
        }

        protected void rptFeatures_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item != null && e.Item.DataItem != null)
            {
                var feature = e.Item.DataItem as Feature;
                if (!string.IsNullOrWhiteSpace(feature.ImageName))
                {
                    ((Image) e.Item.FindControl("img")).ImageUrl = Constants.FeatureImagesFolderPath + feature.ImageName;
                }
                else
                {
                    ((Image)e.Item.FindControl("img")).ImageUrl = Constants.DefaultImageURL;
                }
            }
        }
    }
}