using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using Tournment_Tracking.Models;

namespace Tournment_Tracking.Helper
{
    public class TournamentViewerHelper
    {
        string filePath_mainTournamnet = Path.Combine(Directory.GetCurrentDirectory(), "Tournament_Tracker.json");
        string filePath_matchTournament = Path.Combine(Directory.GetCurrentDirectory(), "MatchRound.json");
        public List<string> PopulateRoundComboBox(string tournamentName)
        {
            try
            {
                List<string> listOfTeams = new List<string>();

                if (File.Exists(filePath_mainTournamnet))
                {
                    string data = File.ReadAllText(filePath_mainTournamnet);
                    JObject jsonObject = JObject.Parse(data);

                    JArray tournaments = (JArray)jsonObject["tournaments"];

                    foreach (JObject tournament in tournaments)
                    {
                        if (tournament["tounrmentName"].ToString() != tournamentName)
                        {
                            continue;
                        }

                        JArray enteredTeams = (JArray)tournament["enterdTeams"];
                        foreach (JObject team in enteredTeams)
                        {
                            listOfTeams.Add(team["teamName"].ToString());
                        }
                    }
                }
                return listOfTeams;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error populating ComboBox: {ex.Message}");
                return null;
            }
        }

        public void GetMatchRounds(int selectround, string tournamentName)
        {
            try
            {


                // Read match data from JSON
                JObject jsondata;
                if (File.Exists(filePath_matchTournament))
                {
                    string matchData = File.ReadAllText(filePath_matchTournament);
                    jsondata = JObject.Parse(matchData);
                }
                else
                {
                    jsondata = new JObject { ["rounds"] = new JArray() };
                }

                Tournament newTournament = new Tournament()
                {
                    rounds = new List<Round>()
                };

                Round round = new Round()
                {
                    RounndNumber = selectround,
                    matches = new List<Models.Match>()
                };

                if (selectround == 1)
                {
                    string data = File.ReadAllText(filePath_mainTournamnet);
                    JObject jsonData = JObject.Parse(data);

                    JArray tournaments = (JArray)jsonData["tournaments"];

                    foreach (var tournament in tournaments)
                    {
                        if (tournament["tounrmentName"].ToString() == tournamentName)
                        {
                            var listOfTeams = ((JArray)tournament["enterdTeams"])
                                .Select(t => t["teamName"].ToString())
                                .ToList();

                            for (int i = 0; i < listOfTeams.Count - 1; i += 2)
                            {
                                round.matches.Add(new Models.Match
                                {
                                    team1 = listOfTeams[i],
                                    team2 = listOfTeams[i + 1],
                                    scoreTeam1 = null,
                                    scoreTeam2 = null,
                                    winner = null
                                });
                            }
                        }
                    }

                }
                else if (selectround == 2)
                {

                    List<string> newTeamData = GetWinnersRounds(selectround - 1);

                    string data = File.ReadAllText(filePath_mainTournamnet);
                    JObject jsonData = JObject.Parse(data);

                    JArray tournaments = (JArray)jsonData["tournaments"];

                    foreach (var tournament in tournaments)
                    {
                        if (tournament["tounrmentName"].ToString() == tournamentName)
                        {

                            for (int i = 0; i < newTeamData.Count - 1; i += 2)
                            {
                                round.matches.Add(new Models.Match
                                {
                                    team1 = newTeamData[i],
                                    team2 = newTeamData[i + 1],
                                    scoreTeam1 = null,
                                    scoreTeam2 = null,
                                    winner = null
                                });
                            }
                        }
                    }




                }
                newTournament.rounds.Add(round);

                AddRoundToTournamentJson(jsondata, round, tournamentName);
                File.WriteAllText(filePath_matchTournament, jsondata.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetMatchRounds: {ex.Message}");
            }
        }

        private void AddRoundToTournamentJson(JObject jsonData, Round round, string tournamentName)
        {
            try
            {
                // Ensure the "tournaments" array exists
                JArray tournaments = (JArray)jsonData["tournaments"];
                if (tournaments == null || tournaments.Count == 0)
                {
                    tournaments = new JArray();
                    jsonData["tournaments"] = tournaments;
                }

                JObject targetTournament = (JObject)tournaments.FirstOrDefault(t =>
                                     (string)t["tournamentName"] == tournamentName);

                if (targetTournament == null)
                {
                    // If the tournament doesn't exist, create a new one
                    targetTournament = new JObject
                    {
                        ["tournamentName"] = tournamentName,
                        ["rounds"] = new JArray()
                    };
                    tournaments.Add(targetTournament);
                }

                // Get the existing "rounds" array or create a new one
                JArray roundsArray = (JArray)targetTournament["rounds"] ?? new JArray();

                // Create the new round JSON object
                JObject newRound = new JObject
                {
                    ["RounndNumber"] = round.RounndNumber,
                    ["matches"] = new JArray(round.matches.Select(m => new JObject
                    {
                        ["team1"] = m.team1,
                        ["team2"] = m.team2,
                        ["scoreTeam1"] = m.scoreTeam1,
                        ["scoreTeam2"] = m.scoreTeam2,
                        ["winner"] = m.winner
                    }))
                };

                // Add the new round to the rounds array
                roundsArray.Add(newRound);

                // Update the "rounds" property in the target tournament
                targetTournament["rounds"] = roundsArray;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<string> ShowMatchInTheTextBox()
        {
            try
            {
                List<string> listOfTeamMatch = new List<string>();
                if (File.Exists(filePath_matchTournament))
                {
                    string data = File.ReadAllText(filePath_matchTournament);
                    JObject jsonData = JObject.Parse(data);

                    JArray tournamnets = (JArray)jsonData["tournaments"];

                    foreach (JObject tournament in tournamnets)
                    {
                        JArray rounds = (JArray)tournament["rounds"];

                        foreach (JObject round in rounds)
                        {
                            JArray matches = (JArray)round["matches"];

                            foreach (JObject match in matches)
                            {
                                string matchNames = $"{match["team1"]} VS {match["team2"]}";
                                listOfTeamMatch.Add(matchNames);
                            }
                        }
                    }
                }
                return listOfTeamMatch;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<string> ShowTeamName()
        {
            try
            {
                List<string> text = new List<string>();
                if (File.Exists(filePath_matchTournament))
                {
                    string data = File.ReadAllText(filePath_matchTournament);
                    JObject jsonData = JObject.Parse(data);

                    JArray tournaments = (JArray)jsonData["tournaments"];

                    foreach (JObject tournament in tournaments)
                    {
                        JArray rounds = (JArray)tournament["rounds"];

                        foreach (JObject round in rounds)
                        {
                            JArray matches = (JArray)round["matches"];

                            foreach (JObject match in matches)
                            {
                                text.Add(match["team1"].ToString());
                                text.Add(match["team2"].ToString());

                            }
                        }
                    }

                }
                return text;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void AddScore(int scoreTeam1, int scoreTeam2, string name)
        {
            try
            {
                if (File.Exists(filePath_matchTournament))
                {
                    string data = File.ReadAllText(filePath_matchTournament);
                    JObject jsondata = JObject.Parse(data);

                    JArray tournaments = (JArray)jsondata["tournaments"];

                    foreach (JObject tournament in tournaments)
                    {

                        JArray rounds = (JArray)tournament["rounds"];

                        foreach (JObject round in rounds)
                        {
                            JArray matches = (JArray)round["matches"];

                            foreach (JObject match in matches)
                            {
                                if (match["team1"].ToString() == name)
                                {
                                    if (match["scoreTeam1"].Type == JTokenType.Null && match["scoreTeam2"].Type == JTokenType.Null)
                                    {
                                        match["scoreTeam1"] = scoreTeam1;
                                        match["scoreTeam2"] = scoreTeam2;
                                    }
                                }

                            }
                        }
                    }
                    File.WriteAllText(filePath_matchTournament, jsondata.ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddWinners()
        {
            try
            {

                if (File.Exists(filePath_matchTournament))
                {
                    string data = File.ReadAllText(filePath_matchTournament);
                    JObject jsonData = JObject.Parse(data);

                    JArray tournaments = (JArray)jsonData["tournaments"];

                    foreach (JObject tournament in tournaments)
                    {
                        JArray rounds = (JArray)tournament["rounds"];

                        foreach (JObject rnd in rounds)
                        {
                            JArray matches = (JArray)rnd["matches"];

                            foreach (JObject match in matches)
                            {
                                if (match["scoreTeam1"].Type != JTokenType.Null)
                                {
                                    int score1 = match["scoreTeam1"].Value<int>();
                                    int score2 = match["scoreTeam2"].Value<int>();

                                    if (score1 > score2)
                                    {
                                        match["winner"] = match["team1"];
                                    }
                                    else
                                    {
                                        match["winner"] = match["team2"];
                                    }
                                }


                            }

                        }
                    }

                    File.WriteAllText(filePath_matchTournament, jsonData.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<string> GetWinnersRounds(int roundNumber)
        {
            try
            {
                List<string> winnersData = new List<string>();

                if (File.Exists(filePath_matchTournament))
                {
                    string data = File.ReadAllText(filePath_matchTournament);
                    JObject jsonData = JObject.Parse(data);

                    JArray tournaments = (JArray)jsonData["tournaments"];

                    foreach (JObject tournamnet in tournaments)
                    {
                        JArray rounds = (JArray)tournamnet["rounds"];

                        foreach (JObject rnd in rounds)
                        {

                            int isRoundmatch = rnd["RounndNumber"].Value<int>();

                            if (isRoundmatch == roundNumber)
                            {
                                JArray matches = (JArray)rnd["matches"];

                                foreach (JObject match in matches)
                                {
                                    winnersData.Add(match["winner"].ToString());

                                }

                            }

                        }
                    }
                }
                return winnersData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
