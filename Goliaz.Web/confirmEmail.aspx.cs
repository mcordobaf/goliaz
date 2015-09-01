using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Goliaz.Dao;
using Goliaz.Dto;

namespace Goliaz.Web
{
    public partial class confirmEmail : System.Web.UI.Page
    {
        USERS _usuario;

        public USERS Usuario
        {
            get {
                if (Session["USER"] != null)
                {
                    _usuario = (USERS)Session["USER"];
                }
                return _usuario; 
            }
            set { 
                _usuario = value;
                Session["USER"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["em"]) && !string.IsNullOrEmpty(Request["code"]))
            {
                try
                {
                    string mensaje = "";
                    Usuario = UserDao.getAndSetConfirmUser(Request["em"], Server.UrlDecode(Request["code"]), out mensaje);
                    if (Usuario != null)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "showMessage", "setTimeout(showMessage, 2000);", true);
                        btnGoto.Visible = true;
                    }
                    else
                    {
                        btnGoto.Visible = false;
                        if (!string.IsNullOrEmpty(mensaje))
                        {
                            errorParrafo.InnerText = mensaje;

                        }
                        else
                        {
                            errorParrafo.InnerText = "This link is not longer available";
                        }
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "showError", "setTimeout(showError, 2000);", true);

                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "showError", "setTimeout(showError, 2000);", true);
                    errorParrafo.InnerText = "Error: " + ex.Message;
                }
            }
        }

        protected void btnGoto_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}