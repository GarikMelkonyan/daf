using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAF.Web.Helpers;

namespace DAF.Web
{
    public partial class Contact : AKPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbClear_Click(object sender, EventArgs e)
        {
            txtEmail.Text = txtName.Text = txtMessage.Text = string.Empty;   
        }

        protected void lbSend_Click(object sender, EventArgs e)
        {
            if (MailSender.Send(Constants.InfoMail, txtEmail.Text, "Message from " + txtName.Text, txtMessage.Text))
            {
                DisplaySuccessMessage("Message sent");
                lbClear_Click(sender, e);
            }
            else
            {
                DisplayErrorMessage("Can not send message, please try again later");
            }
        }
    }
}