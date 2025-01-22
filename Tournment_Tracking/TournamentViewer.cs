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
        public TournamentViewer()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        public TournamentViewer(H1Tournament initialValue)
        {
            InitializeComponent();
            form = initialValue;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            try
            {
                string filePathForMatch = Path.Combine(Directory.GetCurrentDirectory(), "MatchRound.json");
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Tournament_Tracker.json");
                string tournamentName = form.GetTournamentName;

                Random random = new Random();
                List<string> listOfTeams = new List<string>();


                if (File.Exists(filePath))
                {
                    string data = File.ReadAllText(filePath);
                    JObject jsonObject = JObject.Parse(data);

                    JArray tournaments = (JArray)jsonObject["tournaments"];
                    foreach (JObject tournament in tournaments)
                    {
                        if (tournament["tounrmentName"].ToString() == tournamentName)
                        {
                            JArray enteredTeams = (JArray)tournament["enterdTeams"];
                            foreach (JObject team in enteredTeams)
                            {
                                listOfTeams.Add(team["teamName"].ToString());
                            }
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
                            ["tournamentName"] = tournamentName,
                            ["rounds"] = new JArray
                                {
                                    new JObject
                                    {
                                        ["roundNumber"] = tournamentName,
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
                        };
                        File.WriteAllText(filePathForMatch, matchrounds.ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
