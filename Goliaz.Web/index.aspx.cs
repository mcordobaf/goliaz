using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Goliaz.Dao;
using Goliaz.Dto;
using System.Globalization;

namespace Goliaz.Web
{
    public partial class index : System.Web.UI.Page
    {
        USERS _loggedUser;
        public USERS LoggedUser
        {
            get 
            {
                if (Session["USER"] != null)
                {
                    _loggedUser = (USERS)Session["USER"]; 
                }
                return _loggedUser; 
            }
            set 
            { 
                _loggedUser = value;
                Session["USER"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["idUser"]))
            {
                LoggedUser = UserDao.getUser(int.Parse(Request["idUser"]));
            }
            if (!string.IsNullOrEmpty(Request["error"]))
            {
                hdIsNew.Value = "isnew";
                pMensaje.InnerHtml = "Congratulations! Your registration has been confirmed!. Now.  please go to the <a href='http://www.freeleticsworld.com/goliaz-faq/' >Frequently Asked Questions</a> which will tell you everything you need to know.<br /><br /> Have a great challenge!";
                LoadAvailableDaysToReport();
            }
            else if (!string.IsNullOrEmpty(Request["newUser"]) && string.IsNullOrEmpty(Request["error"]))
            {
                hdIsNew.Value = "isnew";
                pMensaje.InnerHtml = "Thank you! We're almost finished. Please check your email inbox (or spam) to confirm your registration.";
            }

            if (LoggedUser != null)
            {
                hdIdUser.Value = LoggedUser.idUser.ToString();
                LoadAvailableDaysToReport();
            }
            else if (LoggedUser == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        private void LoadAvailableDaysToReport()
        {
            List<DAYS> activedDays = DaysDao.getActiveDaysForReport();
            if (activedDays != null)
            {
                int cont = 0;
                foreach (DAYS activeDay in activedDays)
                {
                    DateTime configuredDate =  (DateTime)activeDay.completeDay;
                    ddlDay.Items.Insert(cont, new ListItem("Day " + activeDay.Day.ToString() + " " + CreateDateSuffix(configuredDate) + " of " + configuredDate.ToString("MMMM", new CultureInfo("en-US")), activeDay.idDay.ToString()));
                    cont++;
                }
            }
        }

        public string CreateDateSuffix(DateTime date)
        {
            // Get day...
            var day = date.Day;

            // Get day modulo...
            var dayModulo = day % 10;

            // Convert day to string...
            var suffix = day.ToString(CultureInfo.InvariantCulture);

            // Combine day with correct suffix...
            suffix += (day == 11 || day == 12 || day == 13) ? "th" :
                (dayModulo == 1) ? "st" :
                (dayModulo == 2) ? "nd" :
                (dayModulo == 3) ? "rd" :
                "th";

            // Return result...
            return suffix;
        }
    }
}