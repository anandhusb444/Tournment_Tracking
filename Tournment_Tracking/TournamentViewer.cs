using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Tournment_Tracking.Models;

namespace Tournment_Tracking
{
    public partial class TournamentViewer : Form
    {
        private H1Tournament form;
        private string tournamentName;
        private string filePathForMatch = Path.Combine(Directory.GetCurrentDirectory(), "MatchRound.json");
        private string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Tournament_Tracker.json");

        public TournamentViewer()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        public TournamentViewer(H1Tournament initialValue)
        {
            InitializeComponent();
            form = initialValue;
            tournamentName = form.GetTournamentName;
            label7.Text = tournamentName;

            PopulateRoundComboBox(); // Populate rounds when the form is loaded
        }

        /// <summary>
        /// Populates the ComboBox with the list of rounds based on the number of entered teams.
        /// </summary>
        private void PopulateRoundComboBox()
        {
            try
            {
                List<string> listOfTeams = new List<string>();

                if (File.Exists(filePath))
                {
                    string data = File.ReadAllText(filePath);
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

                    roundOf.Items.Clear();
                    int roundCount = (int)Math.Ceiling(Math.Log(listOfTeams.Count, 2));
                    for (int k = 1; k <= roundCount; k++)
                    {
                        roundOf.Items.Add(k);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error populating ComboBox: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the selection of a round from the ComboBox and processes the matches.
        /// </summary>
        private void roundOf_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (roundOf.SelectedItem != null)
                {
                    int selectedRound = int.Parse(roundOf.SelectedItem.ToString());
                    GetMatchRounds(selectedRound);
                }
                else
                {
                    Console.WriteLine("No round selected.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in roundOf_SelectedIndexChanged: {ex.Message}");
            }
        }

        /// <summary>
        /// Generates and stores match rounds based on the selected round.
        /// </summary>
        private void GetMatchRounds(int selectround)
        {
            try
            {
                Random random = new Random();

                // Read match data from JSON
                JObject jsondata;
                if (File.Exists(filePathForMatch))
                {
                    string matchData = File.ReadAllText(filePathForMatch);
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
                    string data = File.ReadAllText(filePath);
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
                                    scoreTeam1 = 0,
                                    scoreTeam2 = 0,
                                    winner = null
                                });
                            }
                        }
                    }
                }

                newTournament.rounds.Add(round);

                AddTournamentToJson(jsondata, round);
                File.WriteAllText(filePathForMatch, jsondata.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetMatchRounds: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a round to the JSON object for match data.
        /// </summary>
        private void AddTournamentToJson(JObject jsonData, Round round)
        {
            try
            {
                JArray roundsArray = (JArray)jsonData["rounds"] ?? new JArray();

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

                roundsArray.Add(newRound);
                jsonData["rounds"] = roundsArray;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddTournamentToJson: {ex.Message}");
            }
        }
    }
}
