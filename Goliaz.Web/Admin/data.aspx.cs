using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Goliaz.Dao;
using Goliaz.Dto;
using System.IO;
using System.Data;

namespace Goliaz.Web.Admin
{
    public partial class data : System.Web.UI.Page
    {
        List<USERS> Users;
        
        List<DAYS> _diasActivos;
        public List<DAYS> DiasActivos
        {
            get 
            {
                if (ViewState["DIAS_ACTIVOS"] != null)
                {
                    _diasActivos = (List<DAYS>)ViewState["DIAS_ACTIVOS"];
                }
                return _diasActivos; 
            }
            set 
            {
                ViewState["DIAS_ACTIVOS"] = value;
                _diasActivos = value; 
            }
        }

        DataTable _tablaUsuarios;
        public DataTable TablaUsuarios
        {
            get 
            {
                if (ViewState["TABLA_USERS"] != null)
                {
                    _tablaUsuarios = (DataTable)ViewState["TABLA_USERS"];
                }
                return _tablaUsuarios; 
            }
            set {
                ViewState["TABLA_USERS"] = value;
                _tablaUsuarios = value; 
            }
        }

        private void AvailableDays()
        {
            DiasActivos = DaysDao.getActiveDaysForReport();
            foreach (DAYS dia in DiasActivos)
            {
                ddlDay.Items.Add(new ListItem("Day " + dia.Day.ToString(), dia.idDay.ToString()));
            }
            ddlDay.SelectedIndex = 0;
        }

        private void ArmarTable()
        {

            DAYS excerciseForDay = null;
            if (!string.IsNullOrEmpty(ddlDay.SelectedValue))
                excerciseForDay = DaysDao.getDay(int.Parse(ddlDay.SelectedValue));

            if (Users != null)
            {
                DataTable tabla = new DataTable("Usuarios");

                DataColumn dtColumnIdUser = new DataColumn("idUser");
                tabla.Columns.Add(dtColumnIdUser);

                DataColumn dtName = new DataColumn("name");
                tabla.Columns.Add(dtName);

                DataColumn dtAge = new DataColumn("age");
                tabla.Columns.Add(dtAge);
                DataColumn dtGender = new DataColumn("gender");
                tabla.Columns.Add(dtGender);
                DataColumn dtNationality = new DataColumn("nationality");
                tabla.Columns.Add(dtNationality);
                DataColumn dtEmail = new DataColumn("email");
                tabla.Columns.Add(dtEmail);
                DataColumn dtPass = new DataColumn("pass");
                tabla.Columns.Add(dtPass);
                DataColumn dtHades = new DataColumn("hades_pb");
                tabla.Columns.Add(dtHades);
                DataColumn dtPoseidon = new DataColumn("poseidon_pb");
                tabla.Columns.Add(dtPoseidon);
                DataColumn dtVenus = new DataColumn("venus_pb");
                tabla.Columns.Add(dtVenus);
                 DataColumn dtRegisterDay = new DataColumn("register_day");
                tabla.Columns.Add(dtRegisterDay);

                if (excerciseForDay != null && excerciseForDay.DAYS_CONFIG != null && excerciseForDay.DAYS_CONFIG.Count > 0)
                {
                    List<DAYS_CONFIG> excer = excerciseForDay.DAYS_CONFIG.ToList();
                    for (int i = 0; i < excer.Count; i++)
                    {
                        DataColumn column = new DataColumn(excer[i].name + " " + excer[i].dataType);

                        BoundField columna = new BoundField();
                        columna.DataField = excer[i].name + " " + excer[i].dataType;
                        columna.HeaderText = excer[i].name + " " + excer[i].dataType;
                        columna.SortExpression = excer[i].name + " " + excer[i].dataType;
                        gvData.Columns.Add(columna);

                        tabla.Columns.Add(column);
                    }
                }


                for (int j = 0; j < Users.Count; j++)
                {
                    DataRow dw = tabla.NewRow();
                    dw.SetField("idUser", Users[j].idUser);
                    dw.SetField("name", Users[j].name);
                    dw.SetField("age", Users[j].age);
                    dw.SetField("gender", Users[j].gender);
                    dw.SetField("nationality", Users[j].nationality);
                    dw.SetField("email", Users[j].email);
                    dw.SetField("pass", Users[j].pass);
                    dw.SetField("hades_pb", Users[j].hades_pb);
                    dw.SetField("poseidon_pb", Users[j].poseidon_pb);
                    dw.SetField("venus_pb", Users[j].venus_pb);
                    if (Users[j].REGISTER_DAY != null)
                        dw.SetField("register_day", Users[j].REGISTER_DAY.ToString());
                    DAYS_REPORT diaSolicitado = null;
                    if (!string.IsNullOrEmpty(ddlDay.SelectedValue)) 
                        diaSolicitado = UserDao.getDiaReportado(Users[j].idUser, int.Parse(ddlDay.SelectedValue));
                    if (diaSolicitado != null)
                    {
                        List<REPORT_DAY> diasReportados = DaysDao.getDiasReportados(diaSolicitado.idRegister);
                        for (int i = 0; i < diasReportados.Count; i++)
                        {
                            if (tabla.Columns.Contains(diasReportados[i].Name + " " + diasReportados[i].DataInform))
                            {
                                dw.SetField(diasReportados[i].Name + " " + diasReportados[i].DataInform, diasReportados[i].Inform);
                            }
                        }
                    }
                    tabla.Rows.Add(dw);
                }

                TablaUsuarios = tabla;
                gvData.DataSource = TablaUsuarios;
                gvData.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (DiasActivos == null)
            {
                AvailableDays();
            }
            if (TablaUsuarios == null)
            {
                LoadColumns();
                LoadInformation();
                ArmarTable();
            }
            else
            {
                gvData.DataSource = TablaUsuarios;
                gvData.DataBind();
            }
        }

        private void LoadInformation()
        {
            Users = UserDao.getUsers();
            if (Users != null)
            {
                gvData.DataSource = Users;
                gvData.DataBind();
            }
        }

        private void LoadColumns()
        {
            BoundField nameColumn = new BoundField();
            nameColumn.DataField = "name";
            nameColumn.HeaderText = "NAME";
            gvData.Columns.Add(nameColumn);

            BoundField ageCOlumn = new BoundField();
            ageCOlumn.DataField = "age";
            ageCOlumn.HeaderText = "AGE";
            gvData.Columns.Add(ageCOlumn);

            BoundField genderColumn = new BoundField();
            genderColumn.DataField = "gender";
            genderColumn.HeaderText = "GENDER";
            gvData.Columns.Add(genderColumn);

            BoundField countryCOlumn = new BoundField();
            countryCOlumn .DataField = "nationality";
            countryCOlumn .HeaderText = "COUNTRY";
            gvData.Columns.Add(countryCOlumn);

            BoundField emailCOlumn = new BoundField();
            emailCOlumn.DataField = "email";
            emailCOlumn.HeaderText = "EMAIL";
            gvData.Columns.Add(emailCOlumn);

            BoundField hadesPBColumn = new BoundField();
            hadesPBColumn.DataField = "hades_pb";
            hadesPBColumn.HeaderText = "HADES STANDARD PB";
            gvData.Columns.Add(hadesPBColumn);

            BoundField poseidonPBColumn = new BoundField();
            poseidonPBColumn.DataField = "poseidon_pb";
            poseidonPBColumn.HeaderText = "POSEIDON STANDARD PB";
            gvData.Columns.Add(poseidonPBColumn);

            BoundField venus_pbColumn = new BoundField();
            venus_pbColumn.DataField = "venus_pb";
            venus_pbColumn.HeaderText = "VENUS STANDARD PB";
            gvData.Columns.Add(venus_pbColumn);

        }

        protected void export_Click(object sender, EventArgs e)
        {
            exporttoexcel();
        }

        public void exporttoexcel()
        {
            if (TablaUsuarios != null)
            {
                ddlDay.Visible = false;
                export.Visible = false;
                gvData.DataSource = TablaUsuarios;
                gvData.DataBind();

                Response.ClearContent();
                Response.AddHeader("Content-Disposition", "attachment;filename=UsersList" + DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
                Response.ContentType = "applicatio/excel";
                export.Visible = false;
               
            }
        }

        protected void ddlDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvData.Columns.Clear();
            LoadColumns();
            LoadInformation();
            ArmarTable();
        }
    }
}