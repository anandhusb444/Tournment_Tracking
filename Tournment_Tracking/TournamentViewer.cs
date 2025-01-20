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
                string tournamentName = form.GetTournamentName;

                string currentWorkingDirectory = Directory.GetCurrentDirectory();

                string fileName = "Tournament_Tracker.json";

                string filePath = Path.Combine(currentWorkingDirectory, fileName);
                int countOfTeam = 0;
                if (File.Exists(filePath))
                {
                    string data = File.ReadAllText(filePath);
                    JObject jsonObject = JObject.Parse(data);

                    JArray tournaments = (JArray)jsonObject["tournaments"];
                    MatchTeam matchTeam = new MatchTeam();
                    for (int i = 0; i < tournaments.Count; i++)
                    {
                        JObject touranment = (JObject)tournaments[i];

                        if(touranment["tounrmentName"].ToString() == tournamentName)
                        {
                            JArray enterdTeams = (JArray)touranment["enterdTeams"];
                            countOfTeam = enterdTeams.Count;

                            for (int teams = 0; teams < enterdTeams.Count; teams++)
                            {
                                JObject teamNames = (JObject)enterdTeams[teams];
                                


                            }



                        }

                    }
                    roundOf.Items.Clear();

                    int round = (int)Math.Log(countOfTeam, 2);

                    for (int k = 1; k <= round; k++)
                    {
                        roundOf.Items.Add(k);
                    }



                    


                    
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
