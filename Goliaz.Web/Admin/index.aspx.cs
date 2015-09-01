using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Goliaz.Dto;
using Goliaz.Dao;

namespace Goliaz.Web.Admin
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadInformation();
            LoadDays();
        }

        private void LoadDays()
        {
            List<DAYS> dias = DaysDao.getDays();
            for (int i = 1;i <= 30;i++){
                //if (dias != null && dias.Count > 0)
                //{
                //    if ((from t in dias where ((int)t.Day) == i select t).FirstOrDefault() == null)
                //    {
                        ddlDayNew.Items.Add(i.ToString());
                //    }
                //}
                //else
                //{
                //    ddlDayNew.Items.Add(i.ToString());
                //}
            }
        }

        private void LoadInformation()
        {
            ddlState.Items.Insert(0, "Active");
            ddlState.Items.Insert(1, "Inactive");
        }
    }
}