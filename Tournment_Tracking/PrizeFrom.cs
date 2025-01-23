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
using Tournment_Tracking.Models;
using Newtonsoft.Json.Linq;

namespace Tournment_Tracking
{
    public partial class PrizeFrom : Form
    {
        public CreateTournament form;

        public PrizeFrom()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }
        public PrizeFrom(CreateTournament intialValue)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            form = intialValue;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Tournament_Tracker.json");
               // string filePath = Path.Combine(Environment.CurrentDirectory, "Tournament_Tracker");

                if (File.Exists(filePath))
                {
                    Prize prizeData = new Prize();

                    prizeData.prizeNumber = Convert.ToInt32(textBox1.Text);
                    prizeData.prizeName = textBox2.Text;
                    prizeData.prizeAmount = Convert.ToInt32(textBox3.Text);
                    prizeData.prizepercentage = textBox4.Text;


                    string data = File.ReadAllText(filePath);
                    JObject jsonData = JObject.Parse(data);
                    JArray tournaments = (JArray)jsonData["tournaments"];

                    //jsonData["prize"] = new JArray();

                    //JArray prizeArray = (JArray)jsonData["prize"];
                    //tournaments.Add(prizeArray);

                    string tournamentName = form.getTournamentName;
                    foreach (var tournament in tournaments)
                    {
                        if (tournament["tounrmentName"].ToString() == tournamentName)
                        {
                            if(tournament["prizes"] == null || tournament["prizes"].Type != JTokenType.Array)
                            {
                                tournament["prizes"] = new JArray();
                            }
                            
                            JObject newPrizeData = new JObject
                            {
                                ["prizeNumber"] = prizeData.prizeNumber,
                                ["prizeName"] = prizeData.prizeName,
                                ["prizeAmount"] = prizeData.prizeAmount,
                                ["prizePercentage"] = prizeData.prizepercentage
                            };
                            //if(tournament["prizes"] == null)
                            //{
                            //    tournament["prizes"] = new JArray();
                            //}

                            ((JArray)tournament["prizes"]).Add(newPrizeData);
                            MessageBox.Show("Prize as been added");
                            File.WriteAllText(filePath, jsonData.ToString());

                        }
                       
                    }
                    //if(jsonData["tournamentName"].ToString() == tournamentName)
                    //{
                       
                    //}

                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
