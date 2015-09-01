using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Goliaz.Dto;
using Goliaz.Dao;
using System.Data;
using System.Web.UI.HtmlControls;

namespace Goliaz.Web.Admin
{
    public partial class mantUsers : System.Web.UI.Page
    {

        //List<USERS> Users;
        List<USERS> _users;
        public List<USERS> Users
        {
            get
            {
                if (Session["USERS_EXTRAIDOS"] != null)
                {
                    _users = (List<USERS>)Session["USERS_EXTRAIDOS"];
                }
                return _users;
            }
            set
            {
                _users = value;
                Session["USERS_EXTRAIDOS"] = value;
            }
        }

        //DataTable _tablaUsuarios;

        //public DataTable TablaUsuarios
        //{
        //    get 
        //    {
        //        if (ViewState["TABLA_USERS"] != null)
        //        {
        //            _tablaUsuarios = (DataTable)ViewState["TABLA_USERS"];
        //        }
        //        return _tablaUsuarios; 
        //    }
        //    set {
        //        ViewState["TABLA_USERS"] = value;
        //        _tablaUsuarios = value; 
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadColumns();
                LoadUsers();
            }
        }

        private void LoadUsers()
        {
            if (Users == null || !string.IsNullOrEmpty(Request["recargar"]))
            {
                Users = UserDao.getUsers();
                //ArmarTable();
            }
            gvUsuarios.DataSource = Users;
            gvUsuarios.DataBind();
        }

        private void ArmarTable()
        {
            //DAYS excerciseForDay = DaysDao.getDay(int.Parse(ddlDay.SelectedValue)); 
            DAYS excerciseForDay = DaysDao.getDay(1); 

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
                        gvUsuarios.Columns.Add(columna);

                        tabla.Columns.Add(column);
                    }
                }


                for (int j = 0; j < Users.Count;j++)
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
                    //if (Users[j].DAYS_REPORT != null && Users[j].DAYS_REPORT.Count > 0)
                    //{
                    DAYS_REPORT diaSolicitado = UserDao.getDiaReportado(Users[j].idUser, 1);
                    if (diaSolicitado != null)
                    {
                        List<REPORT_DAY> diasReportados = DaysDao.getDiasReportados(diaSolicitado.idRegister);
                        for (int i = 0; i < diasReportados.Count; i++)
                        {
                            dw.SetField(diasReportados[i].Name + " " + diasReportados[i].DataInform, diasReportados[i].Inform);
                        }
                    }
                    //}
                    tabla.Rows.Add(dw);
                }

                //TablaUsuarios = tabla;
                //gvUsuarios.DataSource = TablaUsuarios;
                //gvUsuarios.DataBind();
            }
        }

        private void LoadColumns()
        {
            BoundField idColumn = new BoundField();
            idColumn.DataField = "idUser";
            idColumn.HeaderText = "ID";
            idColumn.SortExpression = "id";
            gvUsuarios.Columns.Add(idColumn);


            BoundField nameColumn = new BoundField();
            nameColumn.DataField = "name";
            nameColumn.HeaderText = "NAME";
            nameColumn.SortExpression = "name";
            gvUsuarios.Columns.Add(nameColumn);

            BoundField ageCOlumn = new BoundField();
            ageCOlumn.DataField = "age";
            ageCOlumn.HeaderText = "AGE";
            ageCOlumn.SortExpression = "age";
            gvUsuarios.Columns.Add(ageCOlumn);

            BoundField genderColumn = new BoundField();
            genderColumn.DataField = "gender";
            genderColumn.HeaderText = "GENDER";
            genderColumn.SortExpression = "gender";
            gvUsuarios.Columns.Add(genderColumn);

            BoundField countryCOlumn = new BoundField();
            countryCOlumn.DataField = "nationality";
            countryCOlumn.HeaderText = "COUNTRY";
            countryCOlumn.SortExpression = "country";
            gvUsuarios.Columns.Add(countryCOlumn);

            BoundField emailCOlumn = new BoundField();
            emailCOlumn.DataField = "email";
            emailCOlumn.HeaderText = "EMAIL";
            emailCOlumn.SortExpression = "email";
            gvUsuarios.Columns.Add(emailCOlumn);

            BoundField passColumn = new BoundField();
            passColumn.DataField = "pass";
            passColumn.HeaderText = "Password";
            gvUsuarios.Columns.Add(passColumn);

            BoundField hadesPBColumn = new BoundField();
            hadesPBColumn.DataField = "hades_pb";
            hadesPBColumn.HeaderText = "HADES STANDARD PB";
            gvUsuarios.Columns.Add(hadesPBColumn);

            BoundField poseidonPBColumn = new BoundField();
            poseidonPBColumn.DataField = "poseidon_pb";
            poseidonPBColumn.HeaderText = "POSEIDON STANDARD PB";
            gvUsuarios.Columns.Add(poseidonPBColumn);

            BoundField venus_pbColumn = new BoundField();
            venus_pbColumn.DataField = "venus_pb";
            venus_pbColumn.HeaderText = "VENUS STANDARD PB";
            gvUsuarios.Columns.Add(venus_pbColumn);
        }

        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row != null && e.Row.RowType != DataControlRowType.Header && e.Row.RowIndex >= 0)
            {
                Control ctrlEdit = e.Row.FindControl("EditColumn");
                if (ctrlEdit != null && ctrlEdit.GetType() == typeof(HtmlAnchor))
                {
                    HtmlAnchor anchorEdit = (HtmlAnchor)ctrlEdit;
                    anchorEdit.HRef = "javascript:EditUser(" + Users[e.Row.RowIndex].idUser.ToString() + ");";
                    //anchorEdit.HRef = "javascript:EditUser(" + TablaUsuarios.Rows[e.Row.RowIndex]["idUser"].ToString() + ");";
                }


                Control ctrlRemove = e.Row.FindControl("DeleteColumn");
                if (ctrlRemove != null && ctrlRemove.GetType() == typeof(HtmlAnchor))
                {
                    HtmlAnchor anchorRemove = (HtmlAnchor)ctrlRemove;
                    //anchorRemove.HRef = "javascript:DeleteUser(" + TablaUsuarios.Rows[e.Row.RowIndex]["idUser"].ToString() + ");";
                    anchorRemove.HRef = "javascript:DeleteUser(" + Users[e.Row.RowIndex].idUser.ToString() + ");";
                }
                
            }
        }

        private string SortDir(string sField)
        {
            string sDir = "asc";
            string sPrevField = (ViewState["SortField"] != null ? ViewState["SortField"].ToString() : "");
            if (sPrevField == sField)
                sDir = (ViewState["SortDir"].ToString() == "asc" ? "desc" : "asc");
            else
                ViewState["SortField"] = sField;

            ViewState["SortDir"] = sDir;
            return sDir;
        }

        protected void gvUsuarios_Sorting(object sender, GridViewSortEventArgs e)
        {
            switch (e.SortExpression)
            {
                case "id":
                    if (SortDir(e.SortExpression) == "asc")
                    {
                        Users = (from t in Users orderby t.idUser ascending select t).ToList();
                    }
                    else
                    {
                        Users = (from t in Users orderby t.idUser descending select t).ToList();
                    }
                    break;
                case "name":
                    //if (gvUsuarios.SortDirection == SortDirection.Ascending)
                    if (SortDir(e.SortExpression) == "asc")
                    {
                        Users = (from t in Users orderby t.name ascending select t).ToList();
                    }
                    else
                    {
                        Users = (from t in Users orderby t.name descending select t).ToList();
                    }
                    break;
                case "age":
                    //if (gvUsuarios.SortDirection == SortDirection.Ascending)
                    if (SortDir(e.SortExpression) == "asc")
                    {
                        Users = (from t in Users orderby t.age ascending select t).ToList();
                    }
                    else
                    {
                        Users = (from t in Users orderby t.age descending select t).ToList();
                    }
                    break;
                case "gender":
                    //if (gvUsuarios.SortDirection == SortDirection.Ascending)
                    if (SortDir(e.SortExpression) == "asc")
                    {
                        Users = (from t in Users orderby t.gender ascending select t).ToList();
                    }
                    else
                    {
                        Users = (from t in Users orderby t.gender descending select t).ToList();
                    }
                    break;
                case "country":
                    //if (gvUsuarios.SortDirection == SortDirection.Ascending)
                    if (SortDir(e.SortExpression) == "asc")
                    {
                        Users = (from t in Users orderby t.nationality ascending select t).ToList();
                    }
                    else
                    {
                        Users = (from t in Users orderby t.nationality descending select t).ToList();
                    }
                    break;
                case "email":
                    //if (gvUsuarios.SortDirection == SortDirection.Ascending)
                    if (SortDir(e.SortExpression) == "asc")
                    {
                        Users = (from t in Users orderby t.email ascending select t).ToList();
                    }
                    else
                    {
                        Users = (from t in Users orderby t.email descending select t).ToList();
                    }
                    break;
            }
            gvUsuarios.DataSource = Users;
            gvUsuarios.DataBind();
        }

        protected void export_Click(object sender, EventArgs e)
        {
            exporttoexcel();
        }

        public void exporttoexcel()
        {
            //if (TablaUsuarios != null)
            //{
            //    gvUsuarios.Columns[0].Visible = false;
            //    gvUsuarios.Columns[1].Visible = false;
            //    gvUsuarios.DataSource = TablaUsuarios;
            //    gvUsuarios.DataBind();

            //    Response.ClearContent();
            //    Response.AddHeader("Content-Disposition", "attachment;filename=UsersList" + DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
            //    Response.ContentType = "applicatio/excel";
            //    export.Visible = false;
            //}
            if (Users != null)
            {
                gvUsuarios.Columns[0].Visible = false;
                gvUsuarios.Columns[1].Visible = false;
                gvUsuarios.DataSource = Users;
                gvUsuarios.DataBind();

                Response.ClearContent();
                Response.AddHeader("Content-Disposition", "attachment;filename=UsersList" + DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
                Response.ContentType = "applicatio/excel";
                export.Visible = false;
            }
        }
    }
}