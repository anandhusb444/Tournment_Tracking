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
using System.IO;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Windows.Forms.VisualStyles;
using Newtonsoft.Json;

namespace Tournment_Tracking
{
    public partial class AddTeams : Form
    {

        Teams teamData = new Teams();
        Person personData = new Person();
        Tournament tournamentData = new Tournament();
        CreateTournament form;

        
       

        //private string filePath = Path.Combine(Environment.CurrentDirectory, "Tournament_Tracker");
        public AddTeams()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        public AddTeams(CreateTournament initialValue)
        {
            InitializeComponent();
            form = initialValue;
        }

        string filePath = @"C:\Users\anand\Downloads\Tournment_Tracking\Tournment_Tracking\Tournment_Tracking\bin\Debug\Tournament_Tracker.json";




        private void CreateTeamBtn_Click(object sender, EventArgs e)
        {
            try
            {
                teamData.teamName = teamNameBox.Text;
                personData.firstName = textBox2.Text;
                personData.lastName = textBox3.Text;
                personData.email = textBox4.Text;
                personData.phone = textBox5.Text;


                if (File.Exists(filePath))
                {
                    string data = File.ReadAllText(filePath);

                    JObject jsonObject = JObject.Parse(data);
                    JArray tournaments = (JArray)jsonObject["tournaments"];
                    string tournamentName = form.getTournamentName;

                    foreach (JObject tournament in tournaments)
                    {


                        if (tournament["tounrmentName"].ToString() != tournamentName)
                        {
                            continue;
                        }

                        JArray enterdTeams = (JArray)tournament["enterdTeams"];
                        JObject existingTeam = enterdTeams.FirstOrDefault(team => team["teamName"].ToString() == teamData.teamName) as JObject;

                        if (existingTeam != null)
                        {
                            AddOrUpdateTeamMember((JArray)existingTeam["teamMember"]);
                        }
                        else
                        {
                            // Create a new team
                            JObject newTeam = new JObject
                            {
                                ["teamName"] = teamData.teamName,
                                ["teamMember"] = new JArray
                                {
                                    new JObject
                                    {
                                        ["firstName"] = personData.firstName,
                                        ["lastName"] = personData.lastName,
                                        ["email"] = personData.email,
                                        ["phone"] = personData.phone
                                    }
                                }
                            };
                            enterdTeams.Add(newTeam);
                        }
                    }

                File.WriteAllText(filePath, jsonObject.ToString());
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private void AddOrUpdateTeamMember(JArray teamMembers)
        {
            // Check if the team member already exists
            var existingMember = teamMembers.FirstOrDefault(member =>
                member["email"].ToString() == personData.email);

            if (existingMember != null)
            {
                // Update existing member details
                existingMember["firstName"] = personData.firstName;
                existingMember["lastName"] = personData.lastName;
                existingMember["phone"] = personData.phone;
            }
            else
            {
                // Add a new team member
                JObject newMember = new JObject
                {
                    ["firstName"] = personData.firstName,
                    ["lastName"] = personData.lastName,
                    ["email"] = personData.email,
                    ["phone"] = personData.phone
                };
                teamMembers.Add(newMember);
            }
        }


        private void SelectMembersBox_Click(object sender, EventArgs e)
        {
                try
                {
                    if(File.Exists(filePath))
                    {
                        string data = File.ReadAllText(filePath);
                        JObject jsonData = JObject.Parse(data);

                        JArray Tournaments = (JArray)jsonData["tournaments"];
                        SelectMembersBox.Items.Clear();

                        HashSet<string> addMember = new HashSet<string>();
                       
                        foreach(var tournament in Tournaments)
                        {
                            JArray enterdTeams = (JArray)tournament["enterdTeams"];

                            foreach(var entredTeam in enterdTeams)
                            {
                                JArray teamMembers = (JArray)entredTeam["teamMember"];
                                
                                foreach(var teamMember in teamMembers)
                                {
                                    string firstName = teamMember["firstName"].ToString();
                                    string lastName = teamMember["lastName"].ToString();
                                    string memberName = $"{firstName} {lastName}";

                                    if(!addMember.Contains(memberName))
                                    {
                                        SelectMembersBox.Items.Add(memberName);
                                        addMember.Add(memberName);
                                    }
                                    
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

        private void teamNameBox_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = teamNameBox.Text + Environment.NewLine;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox6.AppendText(SelectMembersBox.SelectedItem.ToString() + Environment.NewLine);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string palyerName = $"{textBox2.Text} {textBox3.Text}";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.AppendText(palyerName + Environment.NewLine);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
