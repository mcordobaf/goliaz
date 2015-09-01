using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Goliaz.Dao;
using Goliaz.Dto;
using System.ServiceModel.Activation;

namespace Goliaz.Wcf
{
    [ServiceContract(Namespace="Services")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class wcfGoliaz 
    {

        [OperationContract]
        public bool SaveChangesUser(int idUser, string name, string email, string country, string gender, string birthDate, string poseidonPB, string hadesPB, string venusPB)
        {
            return UserDao.SaveChangesUser(idUser, name, email, country, gender, birthDate, poseidonPB, hadesPB, venusPB);    
        }

        [OperationContract]
        public bool DeleteExercise(int idExercise)
        {
            return DaysDao.DeleteExercise(idExercise);
        }

        [OperationContract]
        public int loginUser(string email, string pass)
        {
            USERS getUser = UserDao.loginUser(email, pass);
            int resp = 0;
            if (getUser != null)
            {
                resp = getUser.idUser;
            }
            return resp;
        }

        [OperationContract]
        public bool DeleteUser(int idUser)
        {
            return UserDao.DeleteUser(idUser);
        }

        [OperationContract]
        public bool SaveInform(int idUser, int day, int idRegister, List<int> idReportedDays, List<string> names, List<string> dataTypes, List<string> inform)
        {
            return DaysDao.SaveInform(idUser, day, idRegister, idReportedDays.ToArray(), names.ToArray(), dataTypes.ToArray(), inform.ToArray());
        }

        [OperationContract]
        public bool SaveConfigDay(int day, int idDay, string date, string state, List<int> idDiasConfigurados, List<string> names, List<string> dataTypes, List<string> descriptions)
        {
            return DaysDao.SaveConfigForDay(day, idDay, date, state, idDiasConfigurados.ToArray(), names.ToArray(), dataTypes.ToArray(), descriptions.ToArray());
        }

        [OperationContract]
        public bool saveNewDay(int day, string date, string state)
        {
            return DaysDao.saveNewDay(day, date, state);
        }
    }
}
