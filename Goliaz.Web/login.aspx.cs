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
    public partial class login : System.Web.UI.Page
    {
        USERS _user;
        public USERS User
        {
            get 
            {
                if (Session["USER"] != null)
                {   
                    _user = (USERS)Session["USER"];
                }
                return _user; 
            }
            set 
            { 
                _user = value;
                Session["USER"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            USERS newUser = new USERS();
            string[] formats = { "dd/MM/yyyy" };
            newUser.birthDate = DateTime.ParseExact(txtBirthDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None);
            newUser.estado = "Not Confirmed";
            newUser.email = txtEmailReg.Text;
            newUser.gender = rdSex.SelectedValue;
            newUser.name = txtName.Text;
            newUser.nationality = Nationality.Value;
            newUser.pass = txtPasswordReg.Text;
            if (!string.IsNullOrEmpty(txtPoseidonPB.Text))
            {
                newUser.poseidon_pb = txtPoseidonPB.Text;
            }
            else
            {
                newUser.poseidon_pb = "Not performed";
            }
            if (!string.IsNullOrEmpty(txtVenusPB.Text))
            {
                newUser.venus_pb = txtVenusPB.Text;
            }
            else
            {
                newUser.venus_pb = "Not performed";
            }
            if (!string.IsNullOrEmpty(txtHadesPB.Text))
            {
                newUser.hades_pb = txtHadesPB.Text;
            }
            else
            {
                newUser.hades_pb = "Not performed";
            }
            newUser.REGISTER_DAY = DateTime.Now;
            User = UserDao.registerUser(newUser);
            if (User != null)
            {
                Goliaz.Framework.Correo sentCorreo = new Framework.Correo();
                string errorMensaje = "";
                bool respConfirmEmail = sentCorreo.SendConfirmEmailMessage(User, out errorMensaje);
                if (respConfirmEmail)
                {
                    Response.Redirect("index.aspx?newUser=true");
                }
                else
                {
                    if (!string.IsNullOrEmpty(errorMensaje))
                    {
                        LogErrorDao.ingresarError(errorMensaje);
                        User = UserDao.validateUser(User); 
                        Response.Redirect("index.aspx?newUser=true&error=envio");
                    }
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx?idUser=" + hdIdUser.Value);
        }
    }
}