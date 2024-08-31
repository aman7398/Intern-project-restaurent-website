using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.Runtime.Serialization.Json;
/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
    # region All private method
    public void openConnection()
    {
        if (_mcon == null)
        {
            _mcon = new SqlConnection(ConfigurationManager.AppSettings["connect".ToString()]);
            //_mcon = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        }
        if (_mcon.State == ConnectionState.Closed)
        {
            _mcon.Open();
        }
        _mcom = new SqlCommand();
        _mcom.Connection = _mcon;
    }
    //My Design Function

    private void closeConnection()
    {
        if (_mcon.State == ConnectionState.Open)
            _mcon.Close();
    }
    /// <summary>
    /// 
    /// </summary>
    /// 


    private void Dispose()
    {
        if (_mcon != null)
            _mcon.Dispose();
        _mcon = null;
    }


    # endregion

    # region All property

    private SqlConnection _mcon;

    public SqlConnection mcon
    {
        get { return _mcon; }
        set { _mcon = value; }
    }

    private SqlTransaction _mtr;

    public SqlTransaction mtr
    {
        get { return _mtr; }
        set { _mtr = value; }
    }

    private SqlCommand _mcom;

    public SqlCommand mcom
    {
        get { return _mcom; }
        set { _mcom = value; }
    }

    private SqlDataAdapter _mda;

    public SqlDataAdapter mda
    {
        get { return _mda; }
        set { _mda = value; }
    }
    private SqlDataReader _mdr;

    public SqlDataReader mdr
    {
        get { return _mdr; }
        set { _mdr = value; }
    }
    private string _str;

    public string str
    {
        get { return _str; }
        set { _str = value; }
    }
    private Int32 _maxId;

    public Int32 maxId
    {
        get { return _maxId; }
        set { _maxId = value; }
    }

    private int _count;
    public int count
    {
        get { return _count; }
        set { _count = value; }
    }

    private string _bname;
    public string bname
    {
        get { return _bname; }
        set { _bname = value; }
    }

    private string _bemail;
    public string bemail
    {
        get { return _bemail; }
        set { _bemail = value; }
    }

    private string _bmob;
    public string bmob
    {
        get { return _bmob; }
        set { _bmob = value; }
    }

    private string _badrs;
    public string badrs
    {
        get { return _badrs; }
        set { _badrs = value; }
    }

    private string _bcity;
    public string bcity
    {
        get { return _bcity; }
        set { _bcity = value; }
    }
    private string _bpin;
    public string bpin
    {
        get { return _bpin; }
        set { _bpin = value; }
    }

    # endregion
    public int checkmob1(string mob)
    {
        str = "select count(*) from userdetails where status!='10' and (mob='" + mob + "' or altmob='" + mob + "')";
        int o = Convert.ToInt32(ExecuteScaler(str));
        return o;
    }
    public int checkemail1(string email)
    {
        str = "select count(*) from userdetails where status!='10' and (email='" + email + "' or email='" + email + "')";
        int o = Convert.ToInt32(ExecuteScaler(str));
        return o;
    }


    public int checkmobWhTr1(string mob)
    {
        int o = 0;
        //if (!string.IsNullOrEmpty(mob))
        //{
        //    str = "select count(*) from userdetails where status!='10' and (mob='" + mob + "' or altmob='" + mob + "')";
        //    int i1 = Convert.ToInt32(ExecuteScalerWhTr(str));
        //    if (i1 > 0)
        //        o = 1;
        //}
        return o;
    }
    public int checkemailWhTr1(string email)
    {
        int o = 0;
        //if (!string.IsNullOrEmpty(email))
        //{
        //    str = "select count(*) from userdetails where status!='10' and (email='" + email + "' or email='" + email + "')";
        //    int i1 = Convert.ToInt32(ExecuteScalerWhTr(str));
        //    if (i1 > 0)
        //        o = 1;
        //}
        return o;
    }
    public int ExecuteSql1(string strSql)
    {
        openConnection();
        //_mcom.CommandType = CommandType.Text;
        _mcom.CommandType = CommandType.Text;
        _mcom.CommandText = strSql;
        _mcom.CommandTimeout = 200;
        int result = _mcom.ExecuteNonQuery();
        closeConnection();
        return result;
    }
    public string convertString(string orignalstring)
    {
        string ss = orignalstring.Replace('"', ' ');
        string pp = ss.Replace("'", "");
        return pp;
    }
    public void ExecuteSql(string strSql)
    {
        openConnection();
        _mcom.CommandType = CommandType.Text;
        _mcom.CommandText = strSql;
        _mcom.CommandTimeout = 200;
        _mcom.ExecuteNonQuery();
        closeConnection();
    }
    public void ExecuteSqlWhTr(string strSql)
    {
        _mcom.CommandType = CommandType.Text;
        _mcom.CommandText = strSql;
        _mcom.Transaction = _mtr;
        _mcom.CommandTimeout = 200;
        _mcom.ExecuteNonQuery();
    }
    public int ExecuteSqlWhTr1(string strSql)
    {
        _mcom.CommandType = CommandType.Text;
        _mcom.CommandText = strSql;
        _mcom.Transaction = _mtr;
        _mcom.CommandTimeout = 200;
        int result = _mcom.ExecuteNonQuery();
        return result;
    }
    public int MaxIdWhTr(string strSql)
    {
        int st;
        _mcom.CommandType = CommandType.Text;
        _mcom.CommandText = strSql;
        _mcom.Transaction = _mtr;
        _mcom.CommandTimeout = 200;
        object o = _mcom.ExecuteScalar();
        if (o.ToString() == "")
        {
            st = 1000;
        }
        else
        {
            st = Convert.ToInt32(o) + 1;
        }
        return st;
    }
    public DataTable GetDataTable(string strsql)
    {
        openConnection();
        DataTable dt = new DataTable();
        _mda = new SqlDataAdapter();
        _mcom.CommandType = CommandType.Text;
        _mcom.CommandText = strsql;
        _mcom.CommandTimeout = 200;
        _mda.SelectCommand = _mcom;
        _mda.Fill(dt);
        closeConnection();
        return dt;
    }
    public DataTable GetDataTableWTTR(string strsql)
    {
        DataTable dt = new DataTable();
        _mda = new SqlDataAdapter();
        _mcom.CommandType = CommandType.Text;
        _mcom.CommandText = strsql;
        _mcom.Transaction = _mtr;
        _mcom.CommandTimeout = 200;
        _mda.SelectCommand = _mcom;
        _mda.Fill(dt);
        return dt;
    }
    public DateTime getdatetime()
    {
        DateTime d1 = new DateTime();
        // return d1 = System.DateTime.Now;
        return d1 = Convert.ToDateTime(System.DateTime.UtcNow.AddHours(+5.50).ToString());
    }
    public void fail_save(string page_name, string error_msg, int line_no)
    {
        maxId = TabCounter("eid");
        str = "insert into failsave(id,page_name,err_msg,line_no,date)values('" + maxId + "','" + page_name + "','" + error_msg + "','" + line_no + "','" + getdatetime() + "') ";
        ExecuteSql(str);
        UpdateTabcounter(maxId + 1, "eid");

    }
    public string randomNo1(int len)
    {
        Random r = new Random();
        string a = "";
        Int32 n;
        for (int i = 0; i < len; i++)
        {
            n = r.Next(1, 9);
            a = a + n.ToString();
        }
        return a;
    }
    public string randomNo(Int32 len)
    {
        Random r = new Random();
        string temp = null;
        Int32 n;
        char[] y = new char[50];
        y = "0123456789".ToCharArray();
        for (Int32 x = 0; x < len; x++)
        {
            n = r.Next(0, 10);
            temp = temp + y[n];
        }
        return temp.ToString();
    }
    public string randomNo2(Int32 len)
    {
        Random r = new Random();
        string temp = null;
        Int32 n;
        char[] y = new char[50];
        y = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
        for (Int32 x = 0; x < len; x++)
        {
            n = r.Next(0, 62);
            temp = temp + y[n];
        }
        return temp.ToString();
    }
    public string randomNo3(Int32 len) // for return numeric and skip first char 0
    {
        Random r = new Random();
        string temp = null;
        Int32 n;
        char[] y = new char[50];
        y = "0123456789".ToCharArray();
        for (Int32 x = 0; x < len; x++)
        {
            n = r.Next(0, 10);
            if (x == 0)
            {
                if (y[n] == '0')
                    n = r.Next(1, 10);
            }
            else
                n = r.Next(0, 10);
            temp = temp + y[n];
        }
        return temp.ToString();
    }
    public object ExecuteScaler(string strSql)
    {
        openConnection();
        _mcom.CommandType = CommandType.Text;
        _mcom.CommandText = strSql;
        _mcom.CommandTimeout = 200;
        object o = _mcom.ExecuteScalar();
        closeConnection();
        return o;
    }
    public object ExecuteScalerWhTr(string strSql)
    {
        _mcom.CommandType = CommandType.Text;
        _mcom.CommandText = strSql;
        _mcom.Transaction = _mtr;
        _mcom.CommandTimeout = 200;
        object o = _mcom.ExecuteScalar();
        return o;
    }        
    public int TabCounterWhTr(string tablename)
    {
        str = "select (counterid) from tabcounter where tablename='" + tablename + "'";
        int no = Convert.ToInt32(ExecuteScalerWhTr(str));
        return no;
    }
    public void UpdateTabcounterWhTr(int count, string tablename)
    {
        str = "update tabcounter set counterid=" + count + "  where tablename='" + tablename + "'";
        ExecuteScalerWhTr(str);
    }    
    public string getuid(string userid)
    {
        string uid = "";
        str = "select count(*) from logininfo where status!='10' and (uid='" + userid + "' or userid='" + userid + "')";
        int count = Convert.ToInt16(ExecuteScaler(str));
        if (count > 0)
        {
            str = "select uid from logininfo where status!='10' and (uid='" + userid + "' or userid='" + userid + "')";
            uid = ExecuteScaler(str).ToString();
        }
        else
            uid = "0";
        return uid;
    }
    public string getuid1(string userid)
    {
        string uid = "";
        str = "select count(*) from logininfo where status!='10' and (userid='" + userid + "' or uid='" + userid + "')";
        int count = Convert.ToInt16(ExecuteScalerWhTr(str));
        if (count > 0)
        {
            str = "select uid from logininfo where status!='10' and (userid='" + userid + "' or uid='" + userid + "')";
            uid = ExecuteScalerWhTr(str).ToString();
        }
        else
            uid = "0";
        return uid;
    }
    public string getuserid(string uid)
    {
        string userid = "";
        str = "select count(*) from logininfo where status!='10' and (userid='" + userid + "' or uid='" + userid + "')";
        int count = Convert.ToInt16(ExecuteScaler(str));
        if (count > 0)
        {
            str = "select userid from logininfo where status!='10' and (userid='" + userid + "' or uid='" + userid + "')";
            userid = ExecuteScaler(str).ToString();
        }
        else
            userid = "0";
        return userid;
    }
    public int TabCounter(string tablename)
    {
        str = "select (counterid) from tabcounter where tablename='" + tablename + "'";
        int no = Convert.ToInt32(ExecuteScaler(str));
        return no;
    }
    public void UpdateTabcounter(int count, string tablename)
    {
        str = "update tabcounter set counterid=" + count + "  where tablename='" + tablename + "'";
        ExecuteScaler(str);
    }    
    public void cal(int start, int end, DropDownList ddl, string ss)
    {
        for (int i = start; i <= end; i++)
        {
            if (i.ToString().Length == 1)
            {
                ddl.Items.Add("0" + i.ToString());
            }
            else
            {
                ddl.Items.Add(i.ToString());
            }
            //ddl.Items.Add(i.ToString());
        }
        ddl.Items.Insert(0, ss);
    }    
    public string ShrinkURL(string strURL)
    {
        string URL = "";
        string strHTML = "";
        try
        {
            URL = "http://tinyurl.com/api-create.php?url=" +
               strURL.ToLower();

            System.Net.HttpWebRequest objWebRequest;
            System.Net.HttpWebResponse objWebResponse;

            System.IO.StreamReader srReader;

            objWebRequest = (System.Net.HttpWebRequest)System.Net
               .WebRequest.Create(URL);
            objWebRequest.Method = "GET";

            objWebResponse = (System.Net.HttpWebResponse)objWebRequest
               .GetResponse();
            srReader = new System.IO.StreamReader(objWebResponse
               .GetResponseStream());

            strHTML = srReader.ReadToEnd();

            srReader.Close();
            objWebResponse.Close();
            objWebRequest.Abort();
        }
        catch (Exception ex)
        { }
        return (strHTML);

    }    
    public string urlShorter(string url)
    {
        string key = "AIzaSyCTdSU0WW3BwHbIswZ9Fg59SHEXNcT3IlA";
        string finalURL = "";
        string post = "{\"longUrl\": \"" + url + "\"}";
        string shortUrl = url;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/urlshortener/v1/url?key=" + key);
        try
        {
            request.ServicePoint.Expect100Continue = false;
            request.Method = "POST";
            request.ContentLength = post.Length;
            request.ContentType = "application/json";
            request.Headers.Add("Cache-Control", "no-cache");
            using (Stream requestStream = request.GetRequestStream())
            {
                byte[] postBuffer = Encoding.ASCII.GetBytes(post);
                requestStream.Write(postBuffer, 0, postBuffer.Length);
            }
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader responseReader = new StreamReader(responseStream))
                    {
                        string json = responseReader.ReadToEnd();
                        const string MATCH_PATTERN = @"""id"": ?""(?<id>.+)""";
                        finalURL = Regex.Match(json, MATCH_PATTERN).Groups["id"].Value;
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
        return finalURL;
    }
    public DataTable getuserDetails(string userid)
    {
        DataTable dtu = new DataTable();
        str = "select uid,userid,formInfo,formNumber,name,class,fthrMob,fthrEmail,formCharge,registrationFee,admissionFee,totalAmt,(case isPaid when '0' then 'Unpaid' when '1' then 'Paid' end)isPaid from studentReg where status!='10' and (userid='" + userid + "' or uid='" + userid + "')";
        dtu = GetDataTable(str);
        return dtu;
    }
    public string NumberToWords(int number)
    {
        if (number == 0)
            return "zero";

        if (number < 0)
            return "minus " + NumberToWords(Math.Abs(number));

        string words = "";

        if ((number / 1000000) > 0)
        {
            words += NumberToWords(number / 1000000) + " million ";
            number %= 1000000;
        }

        if ((number / 1000) > 0)
        {
            words += NumberToWords(number / 1000) + " thousand ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += NumberToWords(number / 100) + " hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "")
                words += "and ";

            var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += "-" + unitsMap[number % 10];
            }
        }

        return words;
    }
    public DataTable getClass(string id)
    {
        DataTable dtc = new DataTable();
        try
        {
            string key = "";
            if (!string.IsNullOrEmpty(id))
                key = " and id='" + id + "'";
            str = "select id,name,formCharge,registrationFee,AdmissionFee,status from mstClassWithFee where status='1' " + key + "";
            dtc = GetDataTable(str);
        }
        catch(Exception ex)
        {

        }
        return dtc;
    }
    public DataTable getClassWTTR(string id)
    {
        DataTable dtc = new DataTable();
        try
        {
            string key = "";
            if (!string.IsNullOrEmpty(id))
                key = " and id='" + id + "'";
            str = "select id,name,formCharge,registrationFee,AdmissionFee,status from mstClassWithFee where status='1' " + key + "";
            dtc = GetDataTableWTTR(str);
        }
        catch (Exception ex)
        {

        }
        return dtc;
    }
    public string getMob(string uid)
    {
        string mob = "";
        DataTable dt = new DataTable();
        string key = "";
        if (!string.IsNullOrEmpty(uid))
            key = " and (uid='" + uid + "' or userid='" + uid + "')";
        str = "select mob from studentReg where status='1' " + key + "";
        dt = GetDataTable(str);
        if(dt.Rows.Count>0)
        {
            mob = dt.Rows[0]["mob"].ToString().Trim();
        }
        return mob;
    }
    public string getEmail(string uid)
    {
        string email = "";
        DataTable dt = new DataTable();
        string key = "";
        if (!string.IsNullOrEmpty(uid))
            key = " and (uid='" + uid + "' or userid='" + uid + "')";
        str = "select email from studentReg where status='1' " + key + "";
        dt = GetDataTable(str);
        if (dt.Rows.Count > 0)
        {
            email = dt.Rows[0]["email"].ToString().Trim();
        }
        return email;
    }

    public int fillWallet(string uid, double amt, string type, string remark)
    {
        double total = 0, bal = 0, d = 0; int n = 0;
        DataTable dt = new DataTable();
        try
        {
            openConnection();
            mtr = mcon.BeginTransaction();
            if (amt > 0)
            {
                str = "select isnull(amt,0)amt from wallet where uid='" + uid + "'";
                dt = GetDataTableWTTR(str);
                if (dt.Rows.Count > 0)
                {
                    bal = Convert.ToDouble(dt.Rows[0]["amt"].ToString());
                }
                if (type == "Dr")
                {
                    d = bal - amt;
                    str = "update wallet set amt=" + d + " where uid='" + uid + "'";
                    int w1 = ExecuteSqlWhTr1(str);
                }
                else
                {
                    d = bal + amt;
                    str = "update wallet set amt=" + d + " where uid='" + uid + "'";
                    int w2 = ExecuteSqlWhTr1(str);
                }
                maxId = TabCounterWhTr("wid");
                str = "insert into walletHistory(id, uid, total, amt, balance, type, remark, date, status)values('" + maxId + "','" + uid + "','" + total + "','" + amt + "','" + d + "','" + type + "','" + remark + "','" + getdatetime() + "','1')";
                int w3 = ExecuteSqlWhTr1(str);
                UpdateTabcounterWhTr(maxId + 1, "wid");
                n = 1;
            }
            mtr.Commit();
            mcon.Close();
        }
        catch (Exception ex)
        {
            mtr.Rollback();
            mcon.Close();
        }
        return n;
    }

    public int fillPayment(string uid,string batchid, double amt,string type, string sdate,string edate,string totaledate, string remark)
    {
        int n = 0;
        DataTable dt = new DataTable();
        try
        {
            openConnection();
            mtr = mcon.BeginTransaction();
            if (amt > 0)
            {
                str = "update payment set edate='" + totaledate + "' where uid='" + uid + "' and batchid='" + batchid + "'";
                int p1 = ExecuteSqlWhTr1(str);
                maxId = TabCounterWhTr("wid");
                str = "insert into paymentHistory(id, uid,batchid, amt, type,sdate,edate, remark, date, status)values('" + maxId + "','" + uid + "','" + batchid + "','" + amt + "','" + type + "','" + sdate + "','" + edate + "','" + remark + "','" + getdatetime() + "','1')";
                int p2 = ExecuteSqlWhTr1(str);
                UpdateTabcounterWhTr(maxId + 1, "wid");
                n = 1;
            }
            mtr.Commit();
            mcon.Close();
        }
        catch (Exception ex)
        {
            mtr.Rollback();
            mcon.Close();
        }
        return n;
    }
    public void calculateEMI(string uid, string userid, string aprvdAmt, string tnur, string rate)
    {
        DataTable dt = new DataTable();
        double approvedAmt = 0, roi = 0, interest = 0, totalAmt = 0, emiAmt = 0;
        int tenure = 0, countEmi = 0;
        if (!string.IsNullOrEmpty(aprvdAmt))
            approvedAmt = Convert.ToDouble(aprvdAmt);
        if (!string.IsNullOrEmpty(tnur))
        {
            string tn1 = tnur.Replace("Year", "").Trim();
            tn1 = tn1.Replace("Years", "").Trim();
            tn1 = tn1.Replace("s", "").Trim();
            if (!string.IsNullOrEmpty(tn1.ToString().Trim()))
                tenure = Convert.ToInt32(tn1);
        }
        if (!string.IsNullOrEmpty(rate))
            roi = Convert.ToDouble(rate.Replace("%", "").Trim());
        countEmi = tenure;
        if (roi > 1)
            roi = roi / 1200;
        double principle = 0;
        double balance = approvedAmt;
        double TotalInterest = 0;
        emiAmt = Math.Round(balance * ((roi * Math.Pow((1 + roi),
             tenure)) / (Math.Pow(1 + roi, tenure) - 1)));
        totalAmt = emiAmt * tenure;
        TotalInterest = totalAmt - balance;
        DateTime dte = getdatetime().AddMonths(+2);

        str = "update userDetails set emiAmt='" + emiAmt + "',TotalInterest='" + TotalInterest + "',totalAmt='" + totalAmt + "' where uid='" + uid + "' and userid='" + userid + "'";
        int i1 = ExecuteSqlWhTr1(str);        
    }
}