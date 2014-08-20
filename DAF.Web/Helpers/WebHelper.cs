using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

namespace DAF.Web.Helpers
{
    public class WebHelper
    {
        internal static void RedirectToErrorPage(Errors error)
        {
            URL url = new URL(PageNames.ErrorPage);
            url.Parameters[Constants.RQ_ERROR_ID] = ((int)error).ToString();
            HttpContext.Current.Response.Redirect(url.ToString());
        }

        internal static void LoadDropDown<T>(DropDownList ddl, IList<T> list)
        {
            ddl.Items.Clear();
            ddl.DataSource = list;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        internal static void LoadDropDown<T>(DropDownList ddl, IList<T> list, bool isForSearch)
        {
            ddl.Items.Clear();
            ddl.DataSource = list;
            ddl.DataBind();
            if (isForSearch)
            {
                ddl.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                ddl.Items.Insert(0, new ListItem("--All--", "0"));
            }
        }

        internal static void LoadDropDown<T>(DropDownList ddl, IList<T> list, string firtsItemText)
        {
            ddl.Items.Clear();
            ddl.DataSource = list;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(firtsItemText, "0"));
        }

        public static void LoadYearDropDown(DropDownList ddlYear)
        {
            ddlYear.Items.Clear();
            for (int i = DateTime.UtcNow.Year; i > DateTime.UtcNow.Year - 100; i--)
            {
                ddlYear.Items.Add(new ListItem(i.ToString()));
            }
            ddlYear.DataBind();
            ddlYear.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public static void Redirect(PageNames pageName, FolderNames folderName, bool isWithoutExtension = true)
        {
            HttpContext.Current.Response.Redirect(string.Format("~/{0}/{1}{2}", folderName, pageName, isWithoutExtension ? string.Empty : ".aspx"));
        }

    }

    public static class ExtensionMethods
    {
        public static void SelectByValue(this DropDownList ddl, string value)
        {
            if (value == null) value = string.Empty;

            var item = ddl.Items.FindByValue(value);
            if (item != null)
            {
                ddl.ClearSelection();
                item.Selected = true;
            }
        }

        public static void SelectByValue(this RadioButtonList rbl, string value)
        {
            if (value == null) value = string.Empty;

            var item = rbl.Items.FindByValue(value);
            if (item != null)
            {
                rbl.ClearSelection();
                item.Selected = true;
            }
        }
        
        public static void SelectByValue(this ListBox lst, string value)
        {
            if (value == null) value = string.Empty;

            var item = lst.Items.FindByValue(value);
            if (item != null)
            {
                //lst.ClearSelection();
                item.Selected = true;
            }
        }

        public static void SelectByValue(this DropDownList ddl, long value)
        {
            SelectByValue(ddl, value.ToString());
        }

        public static void SelectByText(this DropDownList ddl, string text)
        {
            var item = ddl.Items.FindByText(text);
            if (item != null)
            {
                ddl.ClearSelection();
                item.Selected = true;
            }
        }

        public static string ReplaceCharsToValidURL(this string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return string.Empty;
            return url.Replace(' ', '-').Replace('/', '-').Replace(",", "-");
        }


    }
}