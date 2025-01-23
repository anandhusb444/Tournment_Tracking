using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Tournment_Tracking.Helper
{
    class JsonHelper
    {
        private static string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Tournament_Tracker.json");

       

        public static void UpdateTournamentData(string tournamentName,
            Decimal entryFee,
            string teamName,
            string firstName,
            string lastName,
            string email,
            string phone)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string data = File.ReadAllText(filePath);
                    JObject jsonObject = JObject.Parse(data);

                    JArray tournamentArray = (JArray)jsonObject["tournaments"];

                    JObject newTournament = new JObject
                    {
                        ["tounrmentName"] = tournamentName,
                        ["EntryFee"] = entryFee,
                        ["enterdTeams"] = new JArray
                        {
                            new JObject
                            {
                                 ["teamName"] = teamName,
                                 ["teamMember"] = new JArray
                                 {
                                    new JObject
                                    {

                                        ["firstName"] = firstName,
                                        ["lastName"] = lastName,
                                        ["email"] = email,
                                        ["phone"] = phone

                                    }
                            }    }
                        }

                    };

                    tournamentArray.Add(newTournament);
                    File.WriteAllText(filePath, jsonObject.ToString());

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
