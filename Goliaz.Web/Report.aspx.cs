using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Goliaz.Dto;
using Goliaz.Dao;
using System.Web.UI.HtmlControls;

namespace Goliaz.Web
{
    public partial class Report : System.Web.UI.Page
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
        public DAYS_REPORT diaReported { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["Day"]) && LoggedUser != null) 
            {
                LoadDayUnregistered();
                LoadDayRegisteredToBeModified();
                //LoadDayUnregistered();
            }
        }

        private void LoadDayRegisteredToBeModified()
        {
            diaReported =  DaysDao.getReportedDayByUser(LoggedUser.idUser, int.Parse(Request["Day"]));
            if (diaReported != null)
            {
                hdIdDayReported.Value = diaReported.idRegister.ToString();
                int cont = 1;
                foreach (REPORT_DAY confDay in diaReported.REPORT_DAY)
                {
                    if (confDay != null && confDay.Name != null)
                    {
                        if (confDay.Name == lblReport1.Text && confDay.DataInform == ddlDataTypeReport1.SelectedValue)
                        {
                            cont = 1;
                        }
                        if (confDay.Name == lblReport2.Text && confDay.DataInform == ddlDataTypeReport2.SelectedValue)
                        {
                            cont = 2;
                        }
                        if (confDay.Name == lblReport3.Text && confDay.DataInform == ddlDataTypeReport3.SelectedValue)
                        {
                            cont = 3;
                        }
                        if (confDay.Name == lblReport4.Text && confDay.DataInform == ddlDataTypeReport4.SelectedValue)
                        {
                            cont = 4;
                        }
                        if (confDay.Name == lblReport5.Text && confDay.DataInform == ddlDataTypeReport5.SelectedValue)
                        {
                            cont = 5;
                        }
                        if (confDay.Name == lblReport6.Text && confDay.DataInform == ddlDataTypeReport6.SelectedValue)
                        {
                            cont = 6;
                        }
                        if (confDay.Name == lblReport7.Text && confDay.DataInform == ddlDataTypeReport7.SelectedValue)
                        {
                            cont = 7;
                        }
                        if (confDay.Name == lblReport8.Text && confDay.DataInform == ddlDataTypeReport8.SelectedValue)
                        {
                            cont = 8;
                        }
                        if (confDay.Name == lblReport9.Text && confDay.DataInform == ddlDataTypeReport9.SelectedValue)
                        {
                            cont = 9;
                        }
                        if (confDay.Name == lblReport10.Text && confDay.DataInform == ddlDataTypeReport10.SelectedValue)
                        {
                            cont = 10;
                        }
                    }

                    HtmlGenericControl divPanel = (HtmlGenericControl)FindControl("div" + cont);
                    divPanel.Style.Remove("display");

                    HiddenField hdField = (HiddenField)FindControl("hdReport" + cont);
                    hdField.Value = confDay.idReportDay.ToString();

                    Label lbl = (Label)FindControl("lblReport" + cont);
                    lbl.Text = confDay.Name;

                    DropDownList ddl = (DropDownList)FindControl("ddlDataTypeReport" + cont);
                    ddl.Items.Insert(0, confDay.DataInform);

                    TextBox txt = (TextBox)FindControl("txtReport" + cont);
                    txt.Text = confDay.Inform;

                    switch (confDay.DataInform)
                    {
                        case "Time":
                            txt.CssClass = "validateTime";
                            break;
                        case "Integer":
                            txt.MaxLength = 4;
                            txt.CssClass = "validateOnlyNumber";
                            break;
                        case "Broken/Unbroken":
                            txt.CssClass = "validateOnlyBOrU";
                            txt.MaxLength = 1;
                            break;
                    }
                    //cont++;
                }
            }
        }

        private void LoadDayUnregistered()
        {
            DAYS dia = DaysDao.getDay(int.Parse(Request["Day"]));
            if (dia != null)
            {
                int contador2 = 1;
                int contador3 = 0;
                //if (diaReported != null && diaReported.REPORT_DAY != null && diaReported.REPORT_DAY.Count > 0)
                //{
                //    contador3 += diaReported.REPORT_DAY.Count;
                //    contador2 += diaReported.REPORT_DAY.Count;
                //}
                List<DAYS_CONFIG> listado = dia.DAYS_CONFIG.ToList();
                if (contador2 <= listado.Count)
                {
                    for (int i = contador3; i < listado.Count; i++)
                    {
                        Label lbl = (Label)FindControl("lblReport" + contador2);
                        lbl.Text = listado[i].name;

                        HtmlGenericControl divPanel = (HtmlGenericControl)FindControl("div" + contador2);
                        divPanel.Style.Remove("display");

                        DropDownList ddl = (DropDownList)FindControl("ddlDataTypeReport" + contador2);
                        ddl.Items.Insert(0, listado[i].dataType);

                        TextBox txt = (TextBox)FindControl("txtReport" + contador2);
                        switch (listado[i].dataType)
                        {
                            case "Time":
                                txt.CssClass = "validateTime";
                                break;
                            case "Integer":
                                txt.CssClass = "validateOnlyNumber";
                                txt.MaxLength = 4;
                                break;
                            case "Broken/Unbroken":
                                txt.CssClass = "validateOnlyBOrU";
                                txt.MaxLength = 1;
                                break;
                        }
                        contador2++;
                    }
                }
                int otroCont = 1;
                for (int k = 0; k < listado.Count; k++)
                {
                    Label lblDesc = (Label)FindControl("lblDescReport" + otroCont);
                    lblDesc.Text = listado[k].description;
                    otroCont++;
                }
                //foreach (DAYS_CONFIG confDay in dia.DAYS_CONFIG)
                //{
                    
                //}
            }
        }
    }
}