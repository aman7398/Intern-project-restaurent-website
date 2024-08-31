using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
/// <summary>
/// Summary description for SendEmail
/// </summary>
public class SendEmail
{
  
	public SendEmail()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string sendMail(string uid, string body, string to, string sub)
    {
        string msg = "";
        int nn = 0;
        try
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("India Loan Solutions <no_reply@easyfoundationloan.com>");
            mailMessage.To.Add(to);
            mailMessage.Subject = sub;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.High;
            mailMessage.Body = body;
            //System.Net.NetworkCredential networkCredentials = new System.Net.NetworkCredential("fbt@quartztechindia.com", "059b62ea-37fc-41d4-bd90-168297b61006");
            //System.Net.NetworkCredential networkCredentials = new System.Net.NetworkCredential("no_reply@everydaysfinances.com", "OvevDiJ6");
            System.Net.NetworkCredential networkCredentials = new System.Net.NetworkCredential("pintukumarmahto00001@gmail.com", "aorpokgbjbrwweon");
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = networkCredentials;

            // gmail Start
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            // gmail end

            //smtpClient.Host = "us2.smtp.mailhostbox.com"; /*"smtp.elasticemail.com";*/ //"us2.smtp.mailhostbox.com";
            //smtpClient.Port = 25;/*2525;*/
            
            smtpClient.Send(mailMessage);
            nn = 1;
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }
        return msg;
    }
}