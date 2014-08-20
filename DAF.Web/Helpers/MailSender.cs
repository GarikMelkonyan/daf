using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace DAF.Web.Helpers
{
	/// <summary>
	/// Summary description for MailSender
	/// </summary>
	public class MailSender
	{
		public static bool Send(string receiver, string sender, string subject, string mailBody, string smtpHost)
		{
			try
			{
				SmtpClient smtpClient = new SmtpClient(smtpHost)
											{
												Timeout = 100000,
												Credentials = CredentialCache.DefaultNetworkCredentials
											};
				MailMessage message = new MailMessage(sender, receiver)
										{
											Subject = subject,
											Body = mailBody,
											IsBodyHtml = true
										};
				//smtpClient.Send(message); todo: remove comment
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool Send(string sMailTo, string sMailFrom, string sSubject, string sBody, List<string> attachmentsFiles = null)
		{
			bool OK = true;
			SmtpClient MailObj = new SmtpClient();
			MailMessage msg = new MailMessage();
			try
			{
				msg.To.Add(sMailTo);
				msg.From = new MailAddress(sMailFrom);
				msg.Subject = sSubject;
				msg.Body = sBody;
				msg.Priority = MailPriority.High;
				msg.IsBodyHtml = true;
				if (attachmentsFiles != null && attachmentsFiles.Count != 0)
				{
					foreach (string file in attachmentsFiles)
					{
						msg.Attachments.Add(new Attachment(file));
					}
				}
				MailObj.Send(msg);
			}
			catch
			{
				//HttpContext.Current.Response.Write(ex.ToString());
				OK = false;
			}
			return OK;
		}
	}
}