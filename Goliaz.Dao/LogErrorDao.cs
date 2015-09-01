using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Goliaz.Dto;

namespace Goliaz.Dao
{
    public class LogErrorDao
    {
        public static bool ingresarError(string error)
        {
            bool resp = true;
            try
            {
                using (goliazco_FWEntities entity = new goliazco_FWEntities())
                {
                    LOG_ERROR logerror = new LOG_ERROR();
                    logerror.fecha = DateTime.Now;
                    logerror.error = error;
                    entity.LOG_ERROR.Add(logerror);
                    entity.SaveChanges();
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
