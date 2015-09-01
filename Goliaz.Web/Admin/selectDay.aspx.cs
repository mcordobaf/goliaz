using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Goliaz.Dto;
using Goliaz.Dao;
using System.Globalization;

namespace Goliaz.Web.Admin
{
    public partial class selectDay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadAvailableDays();
        }
        
        private void loadAvailableDays()
        {
            List<DAYS> getDays = DaysDao.getDays();
            if (getDays != null)
            {
                int cont = 0;
                foreach (DAYS dia in getDays)
                {
                    DateTime configuredDate = (DateTime)dia.completeDay;
                    //ddlDay.Items.Insert(cont, new ListItem("Day " + dia.Day.ToString() + " " + CreateDateSuffix(configuredDate) + " of " + configuredDate.ToString("MMMM", new CultureInfo("en-US")), dia.Day.ToString()));
                    ddlDay.Items.Insert(cont, new ListItem("Day " + dia.Day.ToString() + " " + CreateDateSuffix(configuredDate) + " of " + configuredDate.ToString("MMMM", new CultureInfo("en-US")), dia.idDay.ToString()));
                    cont++;                
                }
                ddlDay.Items.Insert(cont, new ListItem("Add new day...", "0"));
                ddlDay.SelectedIndex = 0;
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