using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Embratel_Vidyo.CDRApplication.Library.DataAccess
{
    public static class CdrDAL
    {
        public static MySqlDataReader GetReaderCdr()
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["CdrConnectionString"].ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand(string.Format(@"SELECT CallID,JoinTime,LeaveTime,RoomOwner,EndpointType from ConferenceCall2
                                                                WHERE CallState = 'COMPLETED' AND  (EndpointType = 'L' || EndpointType = 'C') "), con);

                con.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                        return dr;
                }

                return null;
            }
        }
    }
}
