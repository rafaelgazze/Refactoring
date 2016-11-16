using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Embratel_Vidyo.CDRApplication.Library;
using Embratel_Vidyo.CDRApplication.Library.Application;
using Embratel_Vidyo.CDRApplication.Library.DataAccess;

namespace Embratel_Vidyo.CDRApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = CdrDAL.GetReaderCdr();
            while (reader.Read())
            {
                IManagement management;
                if (Convert.ToChar(reader["EndpointType"]) == 'L')
                {
                    management = new ManagementLegacy
                    {
                        UserName = reader["RoomOwner"].ToString(),
                        DataInicial = Convert.ToDateTime(reader["JoinTime"].ToString()),
                        DataFinal = Convert.ToDateTime(reader["LeaveTime"].ToString()),
                        CallId = Convert.ToInt32(reader["CAllID"].ToString())
                    };
                }
                else
                {
                    management = new ManagementRecord()
                    {
                        UserName = reader["RoomOwner"].ToString(),
                        DataInicial = Convert.ToDateTime(reader["JoinTime"].ToString()),
                        DataFinal = Convert.ToDateTime(reader["LeaveTime"].ToString()),
                        CallId = Convert.ToInt32(reader["CAllID"].ToString())
                    };
                }

                management.Insert();
            }



        }
    }
}
