using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Goliaz.Dao;
using Goliaz.Dto;

namespace Goliaz.Web.Admin
{
    public partial class EditUser : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["idUser"]))
            {

                USERS user = UserDao.getUser(int.Parse(Request["idUser"]));
                if (user != null)
                {
                    hdIdUser.Value = user.idUser.ToString();
                    txtName.Text = user.name;
                    txtEmail.Text = user.email;
                    txtBirthDate.Text = user.birthDate.ToString("dd/MM/yyyy");
                    Nationality.SelectedValue = user.nationality;
                    rdSex.SelectedValue = user.gender;
                    if (!string.IsNullOrEmpty(user.hades_pb) && user.hades_pb != "Not performed")
                    {
                        txtHadesPB.Text = user.hades_pb;
                    }
                    if (!string.IsNullOrEmpty(user.poseidon_pb) && user.poseidon_pb != "Not performed")
                    {
                        txtPoseidonPB.Text = user.poseidon_pb;
                    }
                    if (!string.IsNullOrEmpty(user.venus_pb) && user.venus_pb != "Not performed")
                    {
                        txtVenusPB.Text = user.venus_pb;
                    }
                }
            }
        }
    }
}