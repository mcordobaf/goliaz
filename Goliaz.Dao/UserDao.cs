using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Goliaz.Dto;
using System.Globalization;

namespace Goliaz.Dao
{
    public class UserDao
    {
        public static USERS validateUser(USERS user)
        {
            try
            {
                using (goliazco_FWEntities entity = new goliazco_FWEntities())
                {
                    user = (from t in entity.USERS where t.idUser == user.idUser select t).FirstOrDefault();
                    user.estado = "Confirmed";
                    entity.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public static int GetAge(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            return (a - b) / 10000;
        }

        public static USERS loginUser(string email, string pass)
        {
            USERS getLogedUser = null;
            try
            {
                using (goliazco_FWEntities entity = new goliazco_FWEntities())
                {
                    getLogedUser = (from t in entity.USERS where t.email == email && t.pass == pass select t).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return getLogedUser;
        }

        public static DAYS_REPORT getDiaReportado(int idUser, int day)
        {
            DAYS_REPORT dia = null;
            try
            {
                using (goliazco_FWEntities entity = new goliazco_FWEntities())
                {
                    dia = (from t in entity.DAYS_REPORT where t.idUser == idUser && t.day == day select t).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dia;
        }

        public static List<USERS> getUsers()
        {
            List<USERS> usersList = null;
            try
            {
                using (goliazco_FWEntities entity = new goliazco_FWEntities())
                {
                    usersList = (from t in entity.USERS orderby t.name select t).ToList();
                    foreach (USERS user in usersList)
                    {
                        user.age = GetAge(user.birthDate);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return usersList;
        }

        public static USERS registerUser(USERS user)
        {
            goliazco_FWEntities entity = null;
            try
            {
                using (entity = new goliazco_FWEntities())
                {
                    entity.USERS.Add(user);
                    entity.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public static USERS updateUser(USERS user, string codeNew)
        {
            goliazco_FWEntities entity = null;
            USERS updateUser = null;
            try
            {
                using (entity = new goliazco_FWEntities())
                {
                    updateUser = (from t in entity.USERS where t.idUser == user.idUser select t).FirstOrDefault();
                    updateUser.codeConfirm = codeNew;
                    entity.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return updateUser;
        }

        public static USERS getAndSetConfirmUser(string email, string code, out string mensaje)
        {
            goliazco_FWEntities entity = null;
            USERS updateUser = null;
            mensaje = "";
            try
            {
                using (entity = new goliazco_FWEntities())
                {
                    updateUser = (from t in entity.USERS where t.email == email && t.codeConfirm == code select t).FirstOrDefault();
                    if (updateUser != null)
                    {
                        updateUser.codeConfirm = "";
                        updateUser.estado = "Confirmed";
                        entity.SaveChanges();
                    }
                    else
                    {
                        mensaje = "User not found or link not longer available";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return updateUser;
        }

        public static bool DeleteUser(int idUser)
        {
            bool resp = false;
            try
            {
                using (goliazco_FWEntities entity = new goliazco_FWEntities())
                {
                    USERS userDeleted = (from t in entity.USERS where t.idUser == idUser select t).FirstOrDefault();
                    //if (userDeleted.DAYS_REPORT != null && userDeleted.DAYS_REPORT.Count > 0)
                    //{
                    //    foreach (DAYS_REPORT diaReportado in userDeleted.DAYS_REPORT)
                    //    {
                    //        if (diaReportado != null)
                    //        {
                    //            if (diaReportado.REPORT_DAY != null && diaReportado.REPORT_DAY.Count > 0)
                    //            {
                    //                foreach (REPORT_DAY rep in diaReportado.REPORT_DAY)
                    //                {
                    //                    entity.REPORT_DAY.Remove(rep);
                    //                }
                    //            }
                    //            entity.DAYS_REPORT.Remove(diaReportado);
                    //        }
                    //    }
                    //}
                    if (userDeleted != null)
                    {
                        entity.USERS.Remove(userDeleted);
                        entity.SaveChanges();
                        resp = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return resp;
        }

        public static bool SaveChangesUser(int idUser, string name, string email, string country, string gender, string birthDate, string poseidonPB, string hadesPB, string venusPB)
        {
            bool resp = false;
            try
            {
                using (goliazco_FWEntities entity = new goliazco_FWEntities())
                {
                    USERS currentUser = (from t in entity.USERS where t.idUser == idUser select t).FirstOrDefault();
                    if (currentUser != null)
                    {
                        currentUser.name = name;
                        currentUser.email = email;
                        currentUser.nationality = country;
                        currentUser.gender = gender;
                        if (!string.IsNullOrEmpty(poseidonPB))
                            currentUser.poseidon_pb = poseidonPB;
                        if (!string.IsNullOrEmpty(hadesPB))
                            currentUser.hades_pb = hadesPB;
                        if (!string.IsNullOrEmpty(venusPB))
                            currentUser.venus_pb = venusPB;
                        string[] formats = { "dd/MM/yyyy" };
                        currentUser.birthDate = DateTime.ParseExact(birthDate, formats, new CultureInfo("en-US"), DateTimeStyles.None);
                        entity.SaveChanges();
                        resp = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return resp;
        }

        public static USERS getUser(int idUser)
        {
            USERS user = null;
            try
            {
                using (goliazco_FWEntities entity = new goliazco_FWEntities())
                {
                    user = (from t in entity.USERS where t.idUser == idUser select t).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return user;
        }
    }
}
