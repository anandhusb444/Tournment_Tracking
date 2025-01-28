using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Tournment_Tracking.Models;
using Tournment_Tracking.Helper;
using System.Web;

namespace Tournment_Tracking
{
    public partial class TournamentViewer : Form
    {
        private H1Tournament form;
        private string tournamentName;
        private string filePathForMatch = Path.Combine(Directory.GetCurrentDirectory(), "MatchRound.json");
        private string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Tournament_Tracker.json");
        TournamentViewerHelper tournamentsHelper = new TournamentViewerHelper();

        

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

            //<summary>
            //the tournamentHelper is a class that calling the method for creating the rounds
            //<summary>

            List<string> listOfTeams = tournamentsHelper.PopulateRoundComboBox(tournamentName);

            roundOf.Items.Clear();
            int roundCount = (int)Math.Ceiling(Math.Log(listOfTeams.Count, 2));
            for (int k = 1; k <= roundCount; k++)
            {
                roundOf.Items.Add(k);
            }

            //show the match in the textbox

        }

        private void roundOf_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (roundOf.SelectedItem != null)
                {
                    int selectedRound = int.Parse(roundOf.SelectedItem.ToString());
                    //call the method for createing the match
                    tournamentsHelper.GetMatchRounds(selectedRound, tournamentName);

                    //call the method for showing the match on the text box
                    List<string> matchNames = tournamentsHelper.ShowMatchInTheTextBox();

                    string matchText = string.Join(Environment.NewLine, matchNames);
                    textBox1.Text = matchText;

                    List<string> teamNames = tournamentsHelper.ShowTeamName();

                    firstName.Text = teamNames[0];
                    SecondName.Text = teamNames[1];
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                tournamentsHelper.AddScore(int.Parse(textBox2.Text), int.Parse(textBox3.Text), firstName.Text);
                List<string> teams = tournamentsHelper.ShowTeamName();

                firstName.Text = teams[2];
                SecondName.Text = teams[3];

                

                tournamentsHelper.AddWinners();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}