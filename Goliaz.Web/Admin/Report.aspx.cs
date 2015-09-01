using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Goliaz.Dao;
using Goliaz.Dto;
using System.Web.UI.HtmlControls;

namespace Goliaz.Web.Admin
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["Day"]))
            {
                loadOptions();
                LoadDayRegisteredToBeModified();
            }
        }

        private void loadOptions()
        {
            for (int i = 1; i <= 10;i++ )
            {
                DropDownList ddl = (DropDownList)FindControl("ddlDataTypeReport" + i);
                ddl.Items.Insert(0, "Time");
                ddl.Items.Insert(1, "Integer");
                ddl.Items.Insert(2, "Broken/Unbroken");
            }
        }

        private void LoadDayRegisteredToBeModified()
        {
            DAYS diaReported = DaysDao.getDay(int.Parse(Request["Day"]));
            if (diaReported != null)
            {

                hdIdDayConfigured.Value = diaReported.idDay.ToString();
                txtDateOfDay.Text = ((DateTime)diaReported.completeDay).ToString("dd/MM/yyyy");
                ddlStateDay.SelectedValue = diaReported.state;
                int cont = 1;
                if (diaReported.DAYS_CONFIG != null && diaReported.DAYS_CONFIG.Count > 0)
                {
                    foreach (DAYS_CONFIG confDay in diaReported.DAYS_CONFIG)
                    {
                        HiddenField hdField = (HiddenField)FindControl("hdReport" + cont);
                        hdField.Value = confDay.idReportNum.ToString();

                        CheckBox cbField = (CheckBox)FindControl("CheckBox" + cont);
                        cbField.Checked = true;
                        cbField.Enabled = false;

                        TextBox lbl = (TextBox)FindControl("txtReport" + cont);
                        lbl.Text = confDay.name;

                        DropDownList ddl = (DropDownList)FindControl("ddlDataTypeReport" + cont);
                        ddl.SelectedValue = confDay.dataType;

                        TextBox txtDesc = (TextBox)FindControl("txtDescription" + cont);
                        txtDesc.Text = confDay.description;

                        HtmlAnchor anchorDel = (HtmlAnchor)FindControl("anchorDelete" + cont);
                        anchorDel.Visible = true;
                        anchorDel.HRef = "javascript:DeleteExercise(" + confDay.idReportNum.ToString() + ");";

                        cont++;
                    }
                }
            }
        }
    }
}