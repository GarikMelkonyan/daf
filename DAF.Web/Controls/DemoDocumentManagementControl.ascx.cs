using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAF.Business;
using DAF.DataAccess;
using DAF.Web.Helpers;

namespace DAF.Web.Controls
{
    public enum DocDemo
    {
        Document,
        Demo
    }
    public partial class DemoDocumentManagementControl : System.Web.UI.UserControl
    {
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public DocDemo ControlType { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDocuments();
            }
        }

        private void LoadDocuments()
        {
            if (ControlType == DocDemo.Document)
            {
                lstDocuments.DataSource = DocumentManager.GetDocuments();
            }
            else
            {
                lstDocuments.DataSource = DemoManager.GetDemos();
            }
            lstDocuments.DataBind();
        }

        protected void lstDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDocuments.SelectedIndex == -1)
            {
                ClearEditForm();
                return;
            }

            LoadDocument(AKConvert.ToInt64(lstDocuments.SelectedValue));
        }

        private void LoadDocument(long id)
        {
            IDocumentDemo doc = null;
            if (ControlType == DocDemo.Document)
            {
                doc = DocumentManager.GetDocument(id);
                hpDocument.NavigateUrl = Constants.DocumentsFolderPath + doc.Path;
            }
            else
            {
                doc = DemoManager.GetDemo(id);
                hpDocument.NavigateUrl = Constants.DemosFolderPath + doc.Path;
            }

            txtTitle.Text = doc.Title;
            hpDocument.Text = Path.GetFileName(doc.Path);

            txtFileName.Text = Path.GetFileNameWithoutExtension(doc.Path);
            btnSave.CommandArgument = doc.ID.ToString();
        }

        private void ClearEditForm()
        {
            hpDocument.Text = txtTitle.Text = txtFileName.Text = btnSave.CommandArgument = string.Empty;
            hpDocument.NavigateUrl = string.Empty;
            fuDocument.Dispose();
            lstDocuments.ClearSelection();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            IDocumentDemo document = null;
            if (ControlType == DocDemo.Document)
            {
                document = new Document();
            }
            else
            {
                document = new Demo();
            }

            document.ID = AKConvert.ToInt64(btnSave.CommandArgument);
            document.Title = txtTitle.Text.Trim();
            if (fuDocument != null && fuDocument.PostedFile != null && !string.IsNullOrEmpty(fuDocument.FileName))
            {
                document.Path = txtFileName.Text + Path.GetExtension(fuDocument.FileName);
            }
            else
            {
                document.Path = txtFileName.Text + Path.GetExtension(hpDocument.Text);
                var newFileName = txtFileName.Text + Path.GetExtension(hpDocument.Text);
                if (hpDocument.Text != newFileName)
                {
                    File.Move(Constants.DocumentsFolderPhisicalPath + hpDocument.Text, Constants.DocumentsFolderPhisicalPath + newFileName);
                }
            }

            try
            {
                string documentPath = string.Empty;
                if (ControlType == DocDemo.Document)
                {
                    DocumentManager.SaveDocument(document);
                    documentPath = Constants.DocumentsFolderPhisicalPath + document.Path;
                }
                else
                {
                    DemoManager.SaveDemo(document);
                    documentPath = Constants.DemosFolderPhisicalPath + document.Path;
                }

                if (File.Exists(documentPath) && fuDocument.HasFile)
                {
                    File.Delete(documentPath);
                }
                fuDocument.SaveAs(documentPath);
                ClearEditForm();
                LoadDocuments();
            }
            catch (Exception ex)
            {
                (Page as AKPage).DisplayErrorMessage(ex.ToString());
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearEditForm();
        }

        protected void ibAdd_Click(object sender, ImageClickEventArgs e)
        {
            ClearEditForm();
            txtTitle.Focus();
        }

        protected void ibDelete_Click(object sender, ImageClickEventArgs e)
        {
            if (lstDocuments.SelectedIndex == -1) return;
            try
            {
                string filePath = string.Empty;
                if (ControlType == DocDemo.Document)
                {
                    filePath = Constants.DocumentsFolderPhisicalPath + DocumentManager.DeleteDocument(AKConvert.ToInt64(lstDocuments.SelectedValue));
                }
                else
                {
                    filePath = Constants.DemosFolderPhisicalPath + DemoManager.DeleteDemo(AKConvert.ToInt64(lstDocuments.SelectedValue));
                }
                ClearEditForm();
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                LoadDocuments();
            }
            catch (Exception ex)
            {
                (Page as AKPage).DisplayErrorMessage(ex.ToString());
            }
            ClearEditForm();
        }
    }
}