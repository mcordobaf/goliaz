using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Goliaz.Dto;
using System.Globalization;

namespace Goliaz.Dao
{
    public class DaysDao
    {
        /// <summary>
        /// Allow to delete an attached exercise to a day
        /// </summary>
        /// <param name="idExercise">The specific Id of Exercise</param>
        /// <returns>true or false that it was deleted</returns>
        public static bool DeleteExercise(int idExercise)
        {
            bool resp = false;
            try
            {
                using (goliazco_FWEntities entity = new goliazco_FWEntities())
                {
                    DAYS_CONFIG exercise = (from t in entity.DAYS_CONFIG where t.idReportNum == idExercise select t).FirstOrDefault();
                    entity.DAYS_CONFIG.Remove(exercise);
                    entity.SaveChanges();
                    resp = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return resp;
        }

        public static bool saveNewDay(int day, string date, string state)
        {
            bool resp = false;
            try
            {
                using (goliazco_FWEntities entity = new goliazco_FWEntities())
                {
                    DAYS newDay = new DAYS();
                    string[] formats = { "dd/MM/yyyy" };
                    newDay.Day = day;
                    newDay.completeDay = DateTime.ParseExact(date, formats, new CultureInfo("en-US"), DateTimeStyles.None);
                    newDay.state = state;
                    entity.DAYS.Add(newDay);
                    entity.SaveChanges();
                    resp = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return resp;
        }
        public static List<DAYS> getDays()
        {
            List<DAYS> daysAvailables = null;
            try
            {
                using (goliazco_FWEntities entity = new goliazco_FWEntities())
                {
                    daysAvailables = (from t in entity.DAYS select t).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return daysAvailables;
        }

        public static List<REPORT_DAY> getDiasReportados(int iddia)
        {
            try
            {
                using (goliazco_FWEntities entity = new goliazco_FWEntities())
                {
                    return (from p in entity.REPORT_DAY where p.idRegister == iddia select p).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        public static DAYS getDay(int day)
        {
            DAYS getDay = null;
            goliazco_FWEntities entity =  null;
            try
            {
                entity = new goliazco_FWEntities();
                //getDay = (from t in entity.DAYS where t.Day == day select t).FirstOrDefault();
                getDay = (from t in entity.DAYS where t.idDay == day select t).FirstOrDefault();
                getDay.DAYS_CONFIG = (from t in entity.DAYS_CONFIG where t.idDay == getDay.idDay select t).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return getDay;
        }

        public static DAYS_REPORT getReportedDayByUser(int idUser, int day)
        {
            DAYS_REPORT reportedDay = null;
            goliazco_FWEntities entity = null;
            try
            {
                entity = new goliazco_FWEntities();
                entity.Configuration.LazyLoadingEnabled = true;
                reportedDay = (from t in entity.DAYS_REPORT where t.idUser == idUser && t.day == day select t).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return reportedDay;
        }

        public static List<DAYS> getActiveDaysForReport()
        {
            List<DAYS> activeDays = null;
            try
            {
                using (goliazco_FWEntities entity = new goliazco_FWEntities())
                {
                    activeDays = (from t in entity.DAYS where t.state == "Active" select t).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return activeDays;
        }

        public static bool SaveConfigForDay(int day, int idDay, string date, string state, int[] idDiasConfigurados, string[] names, string[] dataTypes, string[] descriptions)
        {
            bool resp = false;
            try
            {
                goliazco_FWEntities entity = new goliazco_FWEntities();
                if (idDay > 0)
                {
                    DAYS dayConfig = (from t in entity.DAYS where t.idDay == idDay select t).FirstOrDefault();
                    if (dayConfig != null)
                    {
                        string[] formats = { "dd/MM/yyyy" };
                        dayConfig.completeDay = DateTime.ParseExact(date, formats, new CultureInfo("en-US"), DateTimeStyles.None);
                        dayConfig.state = state;
                        int i = 0;
                        if (dayConfig.DAYS_CONFIG != null && dayConfig.DAYS_CONFIG.Count > 0)
                        {
                            for (i = 0; i < idDiasConfigurados.Length; i++)
                            {
                                DAYS_CONFIG diaYaConfigurado = (from t in dayConfig.DAYS_CONFIG where t.idReportNum == idDiasConfigurados[i] select t).FirstOrDefault();
                                diaYaConfigurado.name = names[i];
                                diaYaConfigurado.dataType = dataTypes[i];
                                diaYaConfigurado.description = descriptions[i];
                            }
                        }
                        if (names.Length > idDiasConfigurados.Length)
                        {

                            for (int j = i; j < names.Length; j++)
                            {
                                DAYS_CONFIG newConfigForDay = new DAYS_CONFIG();
                                newConfigForDay.name = names[j];
                                newConfigForDay.dataType = dataTypes[j];
                                newConfigForDay.description = descriptions[j];
                                dayConfig.DAYS_CONFIG.Add(newConfigForDay);
                            }
                        }
                    }
                    entity.SaveChanges();
                    resp = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return resp;
        }

        public static bool SaveInform(int idUser, int day, int idRegister, int[] idReportedDays, string[] names, string[] dataTypes, string[] inform)
        {
            bool resp = false;
            try
            {
                goliazco_FWEntities entity = new goliazco_FWEntities();
                if (idRegister > 0)
                {
                    DAYS_REPORT reportedDay = (from t in entity.DAYS_REPORT where t.idRegister == idRegister && t.idUser == idUser select t).FirstOrDefault();
                    reportedDay.date = DateTime.Now;
                    if (reportedDay != null)
                    {
                        int i;
                        for (i = 0; i < idReportedDays.Length; i++)
                        {
                            REPORT_DAY reporteDeDia = (from t in reportedDay.REPORT_DAY where t.idReportDay == idReportedDays[i] select t).FirstOrDefault();
                            reporteDeDia.Name = names[i];
                            reporteDeDia.DataInform = dataTypes[i];
                            reporteDeDia.Inform = inform[i];
                        }
                        if (names.Length > idReportedDays.Length)
                        {

                            for (int j = i; j < names.Length; j++)
                            {
                                REPORT_DAY newReport = new REPORT_DAY();
                                newReport.Name = names[j];
                                newReport.DataInform = dataTypes[j];
                                newReport.Inform = inform[j];
                                reportedDay.REPORT_DAY.Add(newReport);
                            }
                        }
                    }
                    entity.SaveChanges();
                    resp = true;
                }
                else
                {
                    entity.Configuration.LazyLoadingEnabled = true;
                    entity.Configuration.ValidateOnSaveEnabled = true;

                    DAYS_REPORT newReportedDay = new DAYS_REPORT();
                    newReportedDay.USERS = (from t in entity.USERS where t.idUser == idUser select t).FirstOrDefault();
                    newReportedDay.day = day;
                    newReportedDay.date = DateTime.Now;
                    for (int i = 0; i < names.Length; i++)
                    {
                        //THis is a new report any day. only report 1 excercise
                        REPORT_DAY reportForDay = new REPORT_DAY();
                        reportForDay.Inform = inform[i];
                        reportForDay.Name = names[i];
                        reportForDay.DataInform = dataTypes[i];
                        newReportedDay.REPORT_DAY.Add(reportForDay);
                    }
                    entity.DAYS_REPORT.Add(newReportedDay);
                    entity.SaveChanges();
                    resp = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return resp;
        }
    }
}
