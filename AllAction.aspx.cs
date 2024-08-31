using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AllAction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    #region Apply
    public class Apply
    {
        public string name { get; set; }
        public string mob { get; set; }
        public string email { get; set; } 
        public string comment { get; set; }
        public string loantype { get; set; }
        public string city { get; set; }
        public string Evnt { get; set; }
    }

    [WebMethod(enableSession: true)]
    [ScriptMethod]
    public static string ApplyFormEvents(Apply apply)
    {
        int status = 0;
        string tr = "0";
        Class1 cs = new Class1();
        SendEmail se = new SendEmail();
        string ermsg = "";
        try
        {
            if (!string.IsNullOrEmpty(apply.Evnt.Trim()))
            {
                if (apply.Evnt.Trim() == "Submit")
                {
                    string body1 = "Dear Admin, There is an Online Enquiry by Mr./Ms./Mrs. <b>" + apply.name + "</b>.<br />His/Her other information is given below- <br /><br />Email : " + apply.email + "<br /><br />Mobile No. : " + apply.mob + "<br />and some massage : " + apply.comment + "<br /><br />Thanks Team<br />Aditya";
                  ermsg = se.sendMail("", body1, "yadavaditya0902@gmail.com", "Online Enquiry By " + apply.name + "");
                

                    tr = "1";
                }
                else
                {
                    status = -4;
                    tr = "-4";
                }
            }
            else
            {
                status = -4;
                tr = "-4";
            }
        }
        catch (Exception ex)
        {
            status = -2;
            tr = status.ToString();
        }
        return tr;
    }

    #endregion
  

}