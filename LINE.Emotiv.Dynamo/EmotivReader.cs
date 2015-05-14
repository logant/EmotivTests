using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Autodesk.DesignScript.Runtime;

namespace LINE
{
    
    public static class Emotiv
    {
        // Emotiv Parameters
        static string time = "none";
        static bool eBlink = false;
        static bool eLWink = false;
        static bool eRWink = false;
        static bool eLookDown = false;
        static bool eLookUp = false;
        static bool eLookLeft = false;
        static bool eLookRight = false;
        static double eClench = 0.0;
        static double eEyebrow = 0.0;
        static string eLFAction = "none";
        static double eLFPower = 0.0;
        static string eUFAction = "none";
        static double eUFPower = 0.0;
        static double eSmile = 0.0;
        static string cAction = "none";
        static double cPower = 0.0;
        static bool cActive = false;
        static double aEngageBore = 0.0;
        static double aExciteLong = 0.0;
        static double aExciteShort = 0.0;
        static double aFrustration = 0.0;
        static double aMeditation = 0.0;
        static double aValance = 0.0;
        
        [MultiReturn("msg", "time", "blink", "leftWink", "rightWink", "lookDown", "lookUp", "lookLeft", "lookRight", "clench", "eyebrow", "lowerFaceAction", "lowerFacePower", "upperFaceAction", "upperFacePower", "smile", "engagement", "excitementLongTerm", "excitementShortTerm", "frustration", "meditation", "valance", "action", "power", "active")]
        public static Dictionary<string, object> Reader(string filePath)
        {
            // Read the most current data from the input database.
            string databaseFilePath = filePath;

            string outMessage = "Database Not Found";

            if (System.IO.File.Exists(databaseFilePath))
            {
                // read the data from the file.
                System.Data.SQLite.SQLiteConnection db = new System.Data.SQLite.SQLiteConnection("Data Source=" + databaseFilePath + ";Version=3;");
                db.Open();

                string connectionStr = "Data Source=" + databaseFilePath + ";Version=3;";
                string commandStr = "SELECT * FROM emotiv ORDER BY timestamp DESC LIMIT 1;";
                using (System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(commandStr, db))
                {
                    using (System.Data.SQLite.SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            time = reader.GetString(0);
                            eBlink = reader.GetBoolean(1);
                            eLWink = reader.GetBoolean(2);
                            eRWink = reader.GetBoolean(3);
                            eLookDown = reader.GetBoolean(4);
                            eLookUp = reader.GetBoolean(5);
                            eLookLeft = reader.GetBoolean(6);
                            eLookRight = reader.GetBoolean(7);
                            eClench = reader.GetDouble(8);
                            eEyebrow = reader.GetDouble(9);
                            eLFAction = reader.GetString(10);
                            eLFPower = reader.GetDouble(11);
                            eUFAction = reader.GetString(12);
                            eUFPower = reader.GetDouble(13);
                            eSmile = reader.GetDouble(14);
                            cAction = reader.GetString(15);
                            cPower = reader.GetDouble(16);
                            cActive = reader.GetBoolean(17);
                            aEngageBore = reader.GetDouble(18);
                            aExciteLong = reader.GetDouble(19);
                            aExciteShort = reader.GetDouble(20);
                            aFrustration = reader.GetDouble(21);
                            aMeditation = reader.GetDouble(22);
                            aValance = reader.GetDouble(23);
                        }
                        outMessage = "Data acquired from database file.";
                    }
                }
                db.Close();

            }

            return new Dictionary<string, object>
            {
                {"msg", outMessage},
                {"time", time},
                {"blink", eBlink},
                {"leftWink", eLWink},
                {"rightWink", eRWink},
                {"lookDown", eLookDown},
                {"lookUp", eLookUp},
                {"lookLeft", eLookLeft},
                {"lookRight", eLookRight},
                {"clench", eClench},
                {"eyebrow", eEyebrow},
                {"lowerFaceAction", eLFAction},
                {"lowerFacePower", eLFPower},
                {"upperFaceAction", eUFAction},
                {"upperFacePower", eUFPower},
                {"smile", eSmile},
                {"engagement", aEngageBore},
                {"excitementLongTerm", aExciteLong},
                {"excitementShortTerm", aExciteShort},
                {"frustration", aFrustration},
                {"meditation", aMeditation},
                {"valance", aValance},
                {"action", cAction},
                {"power", cPower},
                {"active", cActive}
            };
        }
    }
}
