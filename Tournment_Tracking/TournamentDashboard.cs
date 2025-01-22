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

namespace Tournment_Tracking
{
    public partial class H1Tournament : Form
    {
        public string GetTournamentName
        {
            get { return tournamentShowBox.Text; }
        }


        public H1Tournament()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

 

private void button2_Click(object sender, EventArgs e)
        {
            CreateTournament showTournament = new CreateTournament();
            showTournament.Show();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            try
            {

                string file = Directory.GetCurrentDirectory();
                string filePath = Path.Combine(file, "Tournament_Tracker.json");


                if(File.Exists(filePath))
                {
                    string data = File.ReadAllText(filePath);
                    JObject jsonData = JObject.Parse(data);

                    JArray tournments = (JArray)jsonData["tournaments"];

                    tournamentShowBox.Items.Clear();

                    for (int i=0; i<tournments.Count; i++)
                    {
                        string tournamentNames = tournments[i]["tounrmentName"].ToString();
                        tournamentShowBox.Items.Add(tournamentNames);
                    }

                    string tournamentName = tournamentShowBox.Text;
                    
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TournamentViewer formViewer = new TournamentViewer(this);
                formViewer.Show();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}


