using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tournment_Tracking.Models;
using Tournment_Tracking.Helper;
using System.IO;
using Newtonsoft.Json.Linq;




namespace Tournment_Tracking
{


    public partial class CreateTournament : Form
    {
        Tournament tournamentData = new Tournament();
        string tournamentName = "";
        private string filePath = @"D:\jsonFile\Tournament_Tracker.json";
        //private string filepath = Path.Combine(Environment.CurrentDirectory, "Tournament_Tracker");

        public CreateTournament()
        {
            InitializeComponent();
            this.MaximizeBox = false;

        }
        

        public string getTournamentName
        {
            get { return textboxName.Text; }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            AddTeams showTeams = new AddTeams(this);
            showTeams.Show();
        }

        private void addTournament_Click(object sender, EventArgs e)
        {
            tournamentData.tournamentName = textboxName.Text;
            tournamentData.entryfee = Decimal.Parse(tournamentFee.Text);
            JsonHelper.UpdateTournamentData(tournamentData.tournamentName, tournamentData.entryfee, "", "", "", "", "");

        }

        private void selectTeamBox_Click(object sender, EventArgs e)
        {
            try
            {
                if(File.Exists(filePath))
                {
                    string data = File.ReadAllText(filePath);
                    JObject jsonObject = JObject.Parse(data);

                    JArray tournaments = (JArray)jsonObject["tournaments"];

                    selectTeamBox.Items.Clear();
                    foreach(var tournament in tournaments)
                    {
                        JArray enterdTeams = (JArray)tournament["enterdTeams"];
                        foreach(var entredTeam in enterdTeams)
                        {
                            string teamName = entredTeam["teamName"].ToString();
                            selectTeamBox.Items.Add(teamName);
                        }
                    }
                          
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void selectTeamBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(selectTeamBox.Text != null)
                {
                    textBox3.Text = selectTeamBox.Text + Environment.NewLine;
                    if(File.Exists(filePath))
                    {
                        string data = File.ReadAllText(filePath);
                        JObject jsonData = JObject.Parse(data);

                        JArray jsonArray = (JArray)jsonData["tournaments"];

                        foreach(var tournament in jsonArray)
                        {
                            JArray enterdTeams = (JArray)tournament["enterdTeams"];
                            foreach(var enterdTeam in enterdTeams)
                            {
                                if(enterdTeam["teamName"].ToString() == selectTeamBox.Text)
                                {
                                    Console.WriteLine("the value selected is" );
                                    JArray TeamMembers = (JArray)enterdTeam["teamMember"];
                                    foreach(var teamMember in TeamMembers)
                                    {
                                        string memberName = $"{teamMember["firstName"]} {teamMember["lastName"]}";
                                        textBox3.AppendText(memberName + Environment.NewLine);
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("there is an issue in the code",ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrizeFrom showPrize = new PrizeFrom(this);
            showPrize.Show();

        }

        

        private void deletebtn2_Click(object sender, EventArgs e)
        {
            try
            {

                prizeTextBox.Text = "";
                if(File.Exists(filePath))
                {
                    string data = File.ReadAllText(filePath);
                    JObject jsonData = JObject.Parse(data);

                    JArray tournaments = (JArray)jsonData["tournaments"];

                    for (int i = 0; i < tournaments.Count; i++)
                    {
                        var tournament = tournaments[i];

                        if (tournament["tounrmentName"].ToString() == textboxName.Text)
                        {
                            if(tournament["prizes"].ToString() != null)
                            {
                                tournament["prizes"] = null;
                             
                                MessageBox.Show("prize Removed");
                                File.WriteAllText(filePath, jsonData.ToString());
                                break;
                            }
                        }

                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void textboxName_Leave(object sender, EventArgs e)
        {
            try
            {
                prizeTextBox.Clear();

                if (File.Exists(filePath))
                {
                    string data = File.ReadAllText(filePath);
                    JObject jsondata = JObject.Parse(data);

                    JArray tournaments = (JArray)jsondata["tournaments"];

                    foreach(var tournament in tournaments)
                    {
                        if(tournament["tounrmentName"].ToString() == textboxName.Text)
                        {
                            JArray prizeData = (JArray)tournament["prizes"];
                            foreach(var prize in prizeData)
                            {
                                string prizeName = prize["prizeName"].ToString();
                                string prizeAmount = prize["prizeAmount"].ToString();

                                prizeTextBox.AppendText(prizeName + Environment.NewLine);
                                prizeTextBox.AppendText(prizeAmount + Environment.NewLine);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void deletebtn1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = "";
                if(File.Exists(filePath))
                {
                    string data = File.ReadAllText(filePath);
                    JObject jsonData = JObject.Parse(data);

                    JArray tournaments = (JArray)jsonData["tournaments"];

                    for (int i = 0; i < tournaments.Count; i++)
                    {
                        JObject tournament = (JObject)tournaments[i];

                        if(tournament["tounrmentName"].ToString() == textboxName.Text)
                        {
                            JArray enterdTeams = (JArray)tournament["enterdTeams"];

                            for (int j = 0; j < enterdTeams.Count; j++)
                            {
                                JObject entedTeam = (JObject)enterdTeams[j];
                                entedTeam["teamName"] = "";

                                JArray teamMembers = (JArray)entedTeam["teamMember"];

                                for (int k = 0; k < teamMembers.Count; k++)
                                {
                                    JObject member = (JObject)teamMembers[k];

                                    member["firstName"] = "";
                                    member["lastName"] = "";
                                    member["email"] = "";
                                    member["phone"] = "";

                                }

                            }
                        }
                    }
                    File.WriteAllText(filePath, jsonData.ToString());

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
