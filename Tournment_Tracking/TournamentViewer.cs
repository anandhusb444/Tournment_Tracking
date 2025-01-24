using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;
using Tournment_Tracking.Models;
using System.Text.RegularExpressions;


namespace Tournment_Tracking
{

    public partial class TournamentViewer : Form
    {
        H1Tournament form;
        string tournamentName;
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
            ShowTeamOnTextBox();


        }
        string filePathForMatch = Path.Combine(Directory.GetCurrentDirectory(), "MatchRound.json");
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Tournament_Tracker.json");


        private void comboBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random();
                List<string> listOfTeams = new List<string>();

                if (File.Exists(filePath))
                {
                    string data = File.ReadAllText(filePath);
                    string matchData = File.ReadAllText(filePathForMatch);
                    //JObject matchJsonObject = JObject.Parse(matchData);
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
                    int roundCount = (int)Math.Log(listOfTeams.Count, 2);
                    for (int k = 1; k <= roundCount; k++)
                    {
                        roundOf.Items.Add($"Round {k}");
                    }

                    HashSet<int> UsedInex = new HashSet<int>();
                    JArray matchesArray = new JArray();
                    int count = 1;
                    JObject matchJsonData = JObject.Parse(matchData);
                    JArray matchTournament = (JArray)matchJsonData["tournaments"];

                    JObject isTournamentExist = matchTournament.FirstOrDefault(team => team["tounrmentName"].ToString() == tournamentName) as JObject;
                    while (UsedInex.Count < listOfTeams.Count)
                    {
                        List<string> matchPair = new List<string>();

                        while (matchPair.Count < 2)
                        {
                            int randomNumber = random.Next(listOfTeams.Count);
                            if (!UsedInex.Contains(randomNumber))
                            {
                                matchPair.Add(listOfTeams[randomNumber]);
                                UsedInex.Add(randomNumber);
                            }
                        }

                        JObject matchrounds = new JObject
                        {
                            ["tournaments"] = new JArray
                            {
                                new JObject
                                {
                                    ["tournamentName"] = tournamentName,
                                    ["rounds"] = new JArray
                                {
                                    new JObject
                                    {
                                        ["roundNumber"] = count,
                                        ["matches"] = new JArray
                                        {
                                            new JObject
                                            {
                                                 ["team1"] = matchPair[0],
                                                 ["team2"] = matchPair[1],
                                                 ["winner"] = null,
                                                 ["score"] = new JObject
                                                 {
                                                    ["scoreTeam1"] = null,
                                                    ["scoreTeam2"] = null,
                                                 }
                                            }

                                        }
                                    }
                                }
                                }
                            }

                        };

                        File.WriteAllText(filePathForMatch, matchrounds.ToString());
                        ShowTeamOnTextBox();//calling the showTeamTextBox to the team vs

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void ShowTeamOnTextBox()
        {
            try
            {
                if (File.Exists(filePathForMatch))
                {
                    string teamVs = "";
                    string data = File.ReadAllText(filePathForMatch);
                    JObject jsonData = JObject.Parse(data);

                    JArray torunamnets = (JArray)jsonData["tournaments"];

                    foreach (JObject tournament in torunamnets)
                    {
                        JArray rounds = (JArray)tournament["rounds"];

                        foreach (JObject round in rounds)
                        {
                            JArray matches = (JArray)round["matches"];

                            foreach (JObject match in matches)
                            {
                                teamVs = $"{match["team1"]} VS {match["team2"]}";
                            }
                        }
                    }

                    textBox1.AppendText(teamVs);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(filePathForMatch))
                {
                    string data = File.ReadAllText(filePathForMatch);
                    JObject matchJsondata = JObject.Parse(data);

                    JArray matchTournaments = (JArray)matchJsondata["tournaments"];

                    foreach (var tournament in matchTournaments)
                    {
                        JArray rounds = (JArray)tournament["rounds"];

                        foreach (JObject round in rounds)
                        {
                            JArray matches = (JArray)round["matches"];

                            foreach (JObject match in matches)
                            {
                                JObject score = (JObject)match["score"];

                                int score1 = int.Parse(textBox2.Text);
                                int score2 = int.Parse(textBox3.Text);


                                score["scoreTeam1"] = textBox2.Text;
                                score["scoreTeam2"] = textBox3.Text;

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
                    File.WriteAllText(filePathForMatch, matchJsondata.ToString());
                    MessageBox.Show("Score has been added");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

