﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace MahaSangram
{
    public partial class Scorecard : UserControl
    {
        int a, b, c, d, balls, runs, i, k, l, wickets, f, maxovers=8, j, x=0, y, z, firstplayer=0, secondplayer=1, aa=0, selectedbowlerindex;
        string[] pet;
        double overs;
        int[] record = new int[150];
        string[] playersnames;
        string[] players1 = new string[11];
        string[] players2 = new string[11];
        string[] teamname = new string[2];
        double[] povers = new double[11];
        bool firstinnings, firstteambatting , firstteamtoss, strike = true, temp, firstteamwinner;
        Overs O = new Overs();
        Toss T = new Toss();
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        private SqlCommand query = new SqlCommand();
        private SqlDataReader teams, players;
        NextBatsmen NB = new NextBatsmen();
        string remainingbatsmen, remainingbowler, selectedbowler;
        string[] players1id = new string[11];
        string[] players2id = new string[11];
        string[] swapplayers = new string[11];
        string[] swapplayersid = new string[11];
        NextBowler NBW = new NextBowler();
       
        public Scorecard()
        {
           InitializeComponent();
           this.O.button1clicklistner(new EventHandler(setover));
           this.T.button1clicklistner(new EventHandler(settoss));
           this.T.button2clicklistner(new EventHandler(settoss));
           this.NB.button1clicklistner(new EventHandler(setbatsmen));
           this.NBW.button1clicklistner(new EventHandler(setbowler));
           connection.Open();
           query.Connection = connection;
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(metroRadioButton1.Checked==true)
            {
                Submit.Enabled = true;
            }
        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton2.Checked == true)
            {
                Submit.Enabled = true;
                metroRadioButton11.Checked = false;
                metroRadioButton12.Checked = false;
                metroRadioButton14.Checked = false;
                metroRadioButton15.Checked = false;
                metroRadioButton16.Checked = false;
            }
        }

        private void metroRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton3.Checked == true)
            {
                Submit.Enabled = true;
                metroRadioButton11.Checked = false;
                metroRadioButton12.Checked = false;
                metroRadioButton14.Checked = false;
                metroRadioButton15.Checked = false;
                metroRadioButton16.Checked = false;
            }
        }

        private void metroRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton4.Checked == true)
            {
                Submit.Enabled = true;
                metroRadioButton11.Checked = false;
                metroRadioButton12.Checked = false;
                metroRadioButton14.Checked = false;
                metroRadioButton15.Checked = false;
                metroRadioButton16.Checked = false;
            }
        }

        private void metroRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton5.Checked == true)
            {
                Submit.Enabled = true;
                metroRadioButton11.Checked = false;
                metroRadioButton12.Checked = false;
                metroRadioButton13.Checked = false;
                metroRadioButton14.Checked = false;
                metroRadioButton15.Checked = false;
                metroRadioButton16.Checked = false;
            }
        }

        private void metroRadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton6.Checked == true)
            {
                Submit.Enabled = true;
                metroRadioButton7.Checked = false;
                metroRadioButton9.Checked = false;
                metroRadioButton10.Checked = false;
                metroRadioButton11.Checked = false;
                metroRadioButton12.Checked = false;
                metroRadioButton13.Checked = false;
                metroRadioButton14.Checked = false;
                metroRadioButton15.Checked = false;
                metroRadioButton16.Checked = false;
            }
        }

        private void metroRadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton7.Checked == true)
            {
                Submit.Enabled = true;
                metroRadioButton6.Checked = false;
                metroRadioButton11.Checked = false;
                metroRadioButton12.Checked = false;
                metroRadioButton14.Checked = false;
            }
        }

        private void metroRadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton8.Checked == true)
            {
                Submit.Enabled = true;
                metroRadioButton11.Checked = false;
                metroRadioButton12.Checked = false;
                metroRadioButton14.Checked = false;
                metroRadioButton15.Checked = false;
                metroRadioButton16.Checked = false;
            }
        }

        private void metroRadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton9.Checked == true)
            {
                Submit.Enabled = true;
                metroRadioButton6.Checked = false;
                metroRadioButton11.Checked = false;
                metroRadioButton12.Checked = false;
                metroRadioButton14.Checked = false;
                metroRadioButton15.Checked = false;
            }
        }

        private void metroRadioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton10.Checked == true)
            {
                Submit.Enabled = true;
                metroRadioButton6.Checked = false;
                metroRadioButton11.Checked = false;
                metroRadioButton12.Checked = false;
                metroRadioButton14.Checked = false;
                metroRadioButton15.Checked = false;
            }
        }

        private void metroRadioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton11.Checked == true)
            {
                Submit.Enabled = true;
                metroRadioButton1.Checked = false;
                metroRadioButton2.Checked = false;
                metroRadioButton3.Checked = false;
                metroRadioButton4.Checked = false;
                metroRadioButton5.Checked = false;
                metroRadioButton6.Checked = false;
                metroRadioButton7.Checked = false;
                metroRadioButton8.Checked = false;
                metroRadioButton9.Checked = false;
                metroRadioButton10.Checked = false;
            }
        }

        private void metroRadioButton12_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton12.Checked == true)
            {
                Submit.Enabled = true;
                metroRadioButton1.Checked = false;
                metroRadioButton2.Checked = false;
                metroRadioButton3.Checked = false;
                metroRadioButton4.Checked = false;
                metroRadioButton5.Checked = false;
                metroRadioButton6.Checked = false;
                metroRadioButton7.Checked = false;
                metroRadioButton8.Checked = false;
                metroRadioButton9.Checked = false;
                metroRadioButton10.Checked = false;
            }
        }

        private void metroRadioButton13_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton13.Checked == true)
            {
                Submit.Enabled = true;
                metroRadioButton5.Checked = false;
                metroRadioButton6.Checked = false;
            }
        }

        private void metroRadioButton14_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton14.Checked == true)
            {
                Submit.Enabled = true;
                metroRadioButton1.Checked = false;
                metroRadioButton2.Checked = false;
                metroRadioButton3.Checked = false;
                metroRadioButton4.Checked = false;
                metroRadioButton5.Checked = false;
                metroRadioButton6.Checked = false;
                metroRadioButton8.Checked = false;
                metroRadioButton9.Checked = false;
                metroRadioButton10.Checked = false;
            }
        }

        private void metroRadioButton15_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton15.Checked == true)
            {
                Submit.Enabled = true;
                metroRadioButton1.Checked = false;
                metroRadioButton2.Checked = false;
                metroRadioButton3.Checked = false;
                metroRadioButton4.Checked = false;
                metroRadioButton5.Checked = false;
                metroRadioButton6.Checked = false;
                metroRadioButton8.Checked = false;
                metroRadioButton9.Checked = false;
                metroRadioButton10.Checked = false;
            }
        }

        private void metroRadioButton16_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton16.Checked == true)
            {
                Submit.Enabled = true;
                metroRadioButton1.Checked = false;
                metroRadioButton2.Checked = false;
                metroRadioButton3.Checked = false;
                metroRadioButton4.Checked = false;
                metroRadioButton5.Checked = false;
                metroRadioButton6.Checked = false;
                metroRadioButton8.Checked = false;
                metroRadioButton9.Checked = false;
                metroRadioButton10.Checked = false;
            }
        }

        public string Data
        {
            set
            {
                playersnames = value.Split(new Char[] { ',' });
            }
        }

        public void ScorecardBackclicklistner(EventHandler handler)
        {
            this.ScorecardBack.Click += handler;
        }

        private void ScorecardBack_Click(object sender, EventArgs e)
        {

        }

        private void Reset_Click(object sender, EventArgs e)
        {
            metroRadioButton1.Checked = false;
            metroRadioButton2.Checked = false;
            metroRadioButton3.Checked = false;
            metroRadioButton4.Checked = false;
            metroRadioButton5.Checked = false;
            metroRadioButton6.Checked = false;
            metroRadioButton7.Checked = false;
            metroRadioButton8.Checked = false;
            metroRadioButton9.Checked = false;
            metroRadioButton10.Checked = false;
            metroRadioButton11.Checked = false;
            metroRadioButton12.Checked = false;
            metroRadioButton13.Checked = false;
            metroRadioButton14.Checked = false;
            metroRadioButton15.Checked = false;
            metroRadioButton16.Checked = false;
            Submit.Enabled = false;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if(Submit.Text=="Submit")
            {
                generatecode();
                settempvariables();
                updatetables();
                generateGraph();
                updatelables();
                                
                metroRadioButton1.Checked = false;
                metroRadioButton2.Checked = false;
                metroRadioButton3.Checked = false;
                metroRadioButton4.Checked = false;
                metroRadioButton5.Checked = false;
                metroRadioButton6.Checked = false;
                metroRadioButton7.Checked = false;
                metroRadioButton8.Checked = false;
                metroRadioButton9.Checked = false;
                metroRadioButton10.Checked = false;
                metroRadioButton11.Checked = false;
                metroRadioButton12.Checked = false;
                metroRadioButton13.Checked = false;
                metroRadioButton14.Checked = false;
                metroRadioButton15.Checked = false;
                metroRadioButton16.Checked = false;
                Submit.Enabled = false;

                if (overs == maxovers || wickets==10)
                {
                    if (firstinnings == true)
                    {
                        Submit.Text = "END INNINGS";
                    }
                    else
                    {
                        Submit.Text = "END MATCH";
                        if(firstteambatting==true)
                        {
                            MessageBox.Show(teamname[1] + "has won the match by " + (Convert.ToInt32(label7.Text) - runs) + " runs");
                            firstteamwinner = false;
                        }
                        else
                        {
                            MessageBox.Show(teamname[0] + "has won the match by " + (Convert.ToInt32(label3.Text) - runs) + " runs");
                            firstteamwinner = true;
                        }
                    }

                    Submit.Enabled = true;
                    metroRadioButton1.Enabled = false;
                    metroRadioButton2.Enabled = false;
                    metroRadioButton3.Enabled = false;
                    metroRadioButton4.Enabled = false;
                    metroRadioButton5.Enabled = false;
                    metroRadioButton6.Enabled = false;
                    metroRadioButton7.Enabled = false;
                    metroRadioButton8.Enabled = false;
                    metroRadioButton9.Enabled = false;
                    metroRadioButton10.Enabled = false;
                    metroRadioButton11.Enabled = false;
                    metroRadioButton12.Enabled = false;
                    metroRadioButton13.Enabled = false;
                    metroRadioButton14.Enabled = false;
                    metroRadioButton15.Enabled = false;
                    metroRadioButton16.Enabled = false;
                    Reset.Enabled = false;
                }
            }
            else if (Submit.Text == "END INNINGS")
            {
                firstinnings = false;
                runs = 0;
                overs = 0;
                balls = 0;
                wickets = 0;

                Submit.Text = "Submit";
                                
                if(firstteambatting==true)
                {
                    firstteambatting=false;
                }
                else
                {
                    firstteambatting=true;
                }

                metroRadioButton1.Enabled = true;
                metroRadioButton2.Enabled = true;
                metroRadioButton3.Enabled = true;
                metroRadioButton4.Enabled = true;
                metroRadioButton5.Enabled = true;
                metroRadioButton6.Enabled = true;
                metroRadioButton7.Enabled = true;
                metroRadioButton8.Enabled = true;
                metroRadioButton9.Enabled = true;
                metroRadioButton10.Enabled = true;
                metroRadioButton11.Enabled = true;
                metroRadioButton12.Enabled = true;
                metroRadioButton13.Enabled = true;
                metroRadioButton14.Enabled = true;
                metroRadioButton15.Enabled = true;
                metroRadioButton16.Enabled = true;
                Submit.Enabled = false;
                Reset.Enabled = true;

                setopeningbatsmenandbowler();

                if (firstteambatting == true)
                {
                    dataGridView1.Visible = true;
                    dataGridView2.Visible = true;
                    dataGridView3.Visible = true;
                    dataGridView4.Visible = false;
                    dataGridView5.Visible = false;
                    dataGridView6.Visible = false;

                }
                else
                {
                    dataGridView4.Visible = true;
                    dataGridView5.Visible = true;
                    dataGridView6.Visible = true;
                    dataGridView1.Visible = false;
                    dataGridView2.Visible = false;
                    dataGridView3.Visible = false;
                }

                strike = true;
                firstplayer = 0;
                secondplayer = 1;
            }
            else
            {
                query.CommandText = "update teams set Matches = Matches + 1 where team_name = '" + teamname[0] + "' OR team_name = '" + teamname[1] + "'";
                teams = query.ExecuteReader();
                teams.Close();
           
                if(firstteamwinner==true)
                {
                    query.CommandText = "update teams set Won = Won + 1 where team_name = '" + teamname[0] + "'";
                    teams = query.ExecuteReader();
                    teams.Close();
                    query.CommandText = "update teams set Lost = Lost + 1 where team_name = '" + teamname[1] + "'";
                    teams = query.ExecuteReader();
                    teams.Close();
                }
                else
                {
                    query.CommandText = "update teams set Won = Won + 1 where team_name = '" + teamname[1] + "'";
                    teams = query.ExecuteReader();
                    teams.Close();
                    query.CommandText = "update teams set Lost = Lost + 1 where team_name = '" + teamname[0] + "'";
                    teams = query.ExecuteReader();
                    teams.Close();
                }
             
                for (x = 0; x < 11; x++)
                {
                    query.CommandText = "update Players set Matches_Played =  Matches_Played + 1 where Player_Id = '" + players1id[x] + "'";
                    players = query.ExecuteReader();
                    players.Close();
                    query.CommandText = "update Players set Matches_Played =  Matches_Played + 1 where Player_Id = '" + players2id[x] + "'";
                    players = query.ExecuteReader();
                    players.Close();

                    if(string.Equals(dataGridView1.Rows[x].Cells[1].Value,"Still To Bat") == false)
                    {
                        query.CommandText = "update Players set Innings = Innings + 1 , Runs = Runs + '" + dataGridView1.Rows[x].Cells[2].Value + "' , Balls_Played = Balls_Played + '" + dataGridView1.Rows[x].Cells[3].Value + "' , Sixes = Sixes + '" + dataGridView2.Rows[x].Cells[8].Value + "' , Fours = Fours + '" + dataGridView2.Rows[x].Cells[7].Value + "' , Triples = Triples + '" + dataGridView2.Rows[x].Cells[6].Value + "' , Doubles = Doubles + '" + dataGridView2.Rows[x].Cells[5].Value + "' , Singles = Singles + '" + dataGridView2.Rows[x].Cells[4].Value + "' , Dots = Dots + '" + dataGridView2.Rows[x].Cells[3].Value + "' where Player_Id = '" + players1id[x] + "'";
                        players = query.ExecuteReader();
                        players.Close();
                    }
                    
                    if (string.Equals(dataGridView4.Rows[x].Cells[1].Value,"Still To Bat") == false)
                    {
                        query.CommandText = "update Players set Innings = Innings + 1 , Runs = Runs + '" + dataGridView4.Rows[x].Cells[2].Value + "' , Balls_Played = Balls_Played + '" + dataGridView4.Rows[x].Cells[3].Value + "' , Sixes = Sixes + '" + dataGridView5.Rows[x].Cells[8].Value + "' , Fours = Fours + '" + dataGridView5.Rows[x].Cells[7].Value + "' , Triples = Triples + '" + dataGridView5.Rows[x].Cells[6].Value + "' , Doubles = Doubles + '" + dataGridView5.Rows[x].Cells[5].Value + "' , Singles = Singles + '" + dataGridView5.Rows[x].Cells[4].Value + "' , Dots = Dots + '" + dataGridView5.Rows[x].Cells[3].Value + "' where Player_Id = '" + players2id[x] + "'";
                        players = query.ExecuteReader();
                        players.Close();
                    }
                }
            }

            if(firstinnings==false)
            {
                if(firstteambatting==true)
                {
                    if(runs>Convert.ToInt32(label7.Text))
                    {
                        Submit.Text = "END MATCH";
                        Submit.Enabled = true;
                        metroRadioButton1.Enabled = false;
                        metroRadioButton2.Enabled = false;
                        metroRadioButton3.Enabled = false;
                        metroRadioButton4.Enabled = false;
                        metroRadioButton5.Enabled = false;
                        metroRadioButton6.Enabled = false;
                        metroRadioButton7.Enabled = false;
                        metroRadioButton8.Enabled = false;
                        metroRadioButton9.Enabled = false;
                        metroRadioButton10.Enabled = false;
                        metroRadioButton11.Enabled = false;
                        metroRadioButton12.Enabled = false;
                        metroRadioButton13.Enabled = false;
                        metroRadioButton14.Enabled = false;
                        metroRadioButton15.Enabled = false;
                        metroRadioButton16.Enabled = false;
                        Reset.Enabled = false;
                        MessageBox.Show(teamname[0] + "has won the match by " + Convert.ToString(10 - wickets) + " wickets with " + Convert.ToString((maxovers*6) - balls) + " balls remaining");
                        firstteamwinner = true;
                    }
                }
                else
                {
                    if (runs > Convert.ToInt32(label3.Text))
                    {
                        Submit.Text = "END MATCH";
                        Submit.Enabled = true;
                        metroRadioButton1.Enabled = false;
                        metroRadioButton2.Enabled = false;
                        metroRadioButton3.Enabled = false;
                        metroRadioButton4.Enabled = false;
                        metroRadioButton5.Enabled = false;
                        metroRadioButton6.Enabled = false;
                        metroRadioButton7.Enabled = false;
                        metroRadioButton8.Enabled = false;
                        metroRadioButton9.Enabled = false;
                        metroRadioButton10.Enabled = false;
                        metroRadioButton11.Enabled = false;
                        metroRadioButton12.Enabled = false;
                        metroRadioButton13.Enabled = false;
                        metroRadioButton14.Enabled = false;
                        metroRadioButton15.Enabled = false;
                        metroRadioButton16.Enabled = false;
                        Reset.Enabled = false;
                        MessageBox.Show(teamname[1] + "has won the match by " + Convert.ToString(10 - wickets) + " wickets with " + Convert.ToString((maxovers*6) - balls) + " balls remaining");
                        firstteamwinner = false;
                    }
                }
            }
        }

        public void initiate()
        {
            T.Data = teamname[0] + "," + teamname[1];
            T.Dock = DockStyle.None;
            this.Controls.Add(T);
            T.BringToFront();
            O.Dock = DockStyle.None;
            this.Controls.Add(O);
            O.BringToFront();

            for (x = 0; x < 11; x++)
            {
                players1[x] = playersnames[x + 1];
                players2[x] = playersnames[x + 12];
            }

            teamname[0] = playersnames[23];
            teamname[1] = playersnames[24];

            label1.Text = teamname[0];
            label2.Text = teamname[1];

            listBox1.Items.Add(teamname[0]);
            listBox1.Items.Add(teamname[1]);

            label3.Text = label5.Text = label7.Text = label9.Text = Convert.ToString("0");
            label6.Text = label10.Text = Convert.ToString("0.0");

            T.Data = teamname[0] + "," + teamname[1];
            T.Dock = DockStyle.Fill;
            this.Controls.Add(T);
            T.BringToFront();
          
            O.Dock = DockStyle.None;
            
            this.Controls.Add(O);
           
            O.BringToFront();

            firstinnings = true;

            chart1.Series.Add(teamname[0]);
            chart1.Series.Add(teamname[1]);
            chart2.Series.Add(teamname[0]);
            chart2.Series.Add(teamname[1]);

            chart1.Series[teamname[0]].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[teamname[1]].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chart1.Series[teamname[0]].Points.AddXY(0, 0);
            chart1.Series[teamname[1]].Points.AddXY(0, 0);

            for (x = 0; x < 11; x++)
            {
                query.CommandText = "select Player_Id from Players where Team = '" + teamname[0] + "' AND Name = '" + players1[x] + "'";
                players = query.ExecuteReader();
                while (players.Read())
                {
                    players1id[x] = players[0].ToString();
                }
                players.Close();

                query.CommandText = "select Player_Id from Players where Team = '" + teamname[1] + "' AND Name = '" + players2[x] + "'";
                players = query.ExecuteReader();
                while (players.Read())
                {
                    players2id[x] = players[0].ToString();
                }
                players.Close();
            }
        }

        private void updatelables()
        {
            if(firstteambatting==true)
            {
                label3.Text = Convert.ToString(runs);
                label5.Text = Convert.ToString(wickets);
                label6.Text = Convert.ToString(overs);
            }
            else
            {
                label7.Text = Convert.ToString(runs);
                label9.Text = Convert.ToString(wickets);
                label10.Text = Convert.ToString(overs);
            }

            if (c == 1)
            {
                label16.Text = Convert.ToString(Convert.ToInt32(label16.Text) + Convert.ToInt32(1));
            }

            else if (c == 2)
            {
                label17.Text = Convert.ToString(Convert.ToInt32(label17.Text) + Convert.ToInt32(1));
            }

            if (d == 1)
            {
                label18.Text = Convert.ToString(Convert.ToInt32(label18.Text) + Convert.ToInt32(b));
            }

            else if (d == 2)
            {
                label19.Text = Convert.ToString(Convert.ToInt32(label19.Text) + Convert.ToInt32(b));
            }

            if ((c > 0 && c < 3) || (d > 0 && d < 3))
            {
                label20.Text = Convert.ToString(Convert.ToInt32(label16.Text) + Convert.ToInt32(label17.Text) + Convert.ToInt32(label18.Text) + Convert.ToInt32(label19.Text));
            }

            if (f > 0 && f < 7)
            {
                label15.Text = label15.Text + runs + "/" + wickets + "(" + "jo bhi player out hua hoga" + "," + overs + ")" + "   " + ",";
            }

            if(b==1 || b==3)
            {
                if(strike==true)
                {
                    strike = false;
                }
                else
                {
                    strike = true;
                }
            }

            if (balls % 6 == 0)
            {
                if (strike == true)
                {
                    strike = false;
                }
                else
                {
                    strike = true;
                }
            }

            if (balls % 6 == 0 && c != 1 && c != 2)
            {
                remainingbowler = "";
              
                if (overs < maxovers)
                {
                    if (firstteambatting == true)
                    {
                        for (i = 0; i <= 10; i++)
                        {
                            if (players2[i] != selectedbowler)
                            {
                                remainingbowler = remainingbowler + players2[i];
                                if (i <= 9)
                                {
                                    remainingbowler = remainingbowler + ",";
                                }
                            }
                        }
                    }
                    else
                    {
                        for (i = 0; i <= 10; i++)
                        {
                            if (players1[i] != selectedbowler)
                            {
                                remainingbowler = remainingbowler + players1[i];
                                if (i <= 9)
                                {
                                    remainingbowler = remainingbowler + ",";
                                }
                            }
                        }
                    }

                    NBW.Data = remainingbowler;
                    NBW.Dock = DockStyle.None;
                    this.Controls.Add(NBW);
                    NBW.BringToFront();
                    NBW.initiate();
                }
            }

            if (f > 0 && f < 7)
            {
                remainingbatsmen = "";

                if (wickets != 10)
                {
                    if (firstteambatting == true)
                    {
                        for (i = wickets; i < 10; i++)
                        {
                            remainingbatsmen = remainingbatsmen + players1[i + 1];
                            if (i < 9)
                            {
                                remainingbatsmen = remainingbatsmen + ",";
                            }
                        }
                    }
                    else
                    {
                        for (i = wickets; i < 10; i++)
                        {
                            remainingbatsmen = remainingbatsmen + players2[i + 1];
                            if (i < 9)
                            {
                                remainingbatsmen = remainingbatsmen + ",";
                            }
                        }
                    }

                    NB.Data = remainingbatsmen;
                    NB.Dock = DockStyle.None;
                    this.Controls.Add(NB);
                    NB.BringToFront();
                    NB.initiate();
                }
            }
        }

        
      
        public void generateGraph()
        {
            if(firstteambatting==true)
            {
                chart1.Series[teamname[0]].Points.AddXY(balls, runs);

                if(balls%6==0)
                {
                    chart2.Series[teamname[0]].Points.AddXY(overs, aa);
                }
            }
            else
            {
                chart1.Series[teamname[1]].Points.AddXY(balls, runs);
                if (balls % 6 == 0)
                {
                    chart2.Series[teamname[1]].Points.AddXY(overs, aa);
                }
            }
            
            if (balls % 6 == 0)
            {
                aa = 0;
            }
        }

        private void generatecode()
        {
            a = b = c = d = f = 0;

            if (metroRadioButton2.Checked == true)
                b = 1;
            else if (metroRadioButton3.Checked == true)
                b = 2;
            else if (metroRadioButton4.Checked == true)
                b = 3;
            else if (metroRadioButton5.Checked == true)
                b = 4;
            else if (metroRadioButton6.Checked == true)
                b = 6;

            if (metroRadioButton7.Checked == true)
                c = 1;
            else if (metroRadioButton8.Checked == true)
                c = 2;

            else if (metroRadioButton9.Checked == true)
                d = 1;
            else if (metroRadioButton10.Checked == true)
                d = 2;

            if (metroRadioButton11.Checked == true)
                f = 1;
            else if (metroRadioButton12.Checked == true)
                f = 2;
            else if (metroRadioButton13.Checked == true)
                f = 3;
            else if (metroRadioButton14.Checked == true)
                f = 4;
            else if (metroRadioButton15.Checked == true)
                f = 5;
            else if (metroRadioButton16.Checked == true)
                f = 6;

            a = (1000 * b) + (100 * c) + (10 * d) + f;

            
        }

        private void settempvariables()
        {
            record[x] = a;
            x++;
            if (c != 1 && c != 2)
            {
                balls++;
                runs += b;
                overs += 0.1;
            }
            else
            {
                runs += b + 1;
            }

            if (balls % 6 == 0 && c != 1 && c != 2)
            {
                overs = Convert.ToInt32(overs);
            }

            if (f > 0 && f < 7)
            {
                wickets++;
            }
        }

        private void updatetables()
        {
            aa += b;

            if(firstteambatting == true)
            {
                if(strike == true)
                {
                    if(f == 1)
                    {
                        dataGridView1.Rows[firstplayer].Cells[1].Value = "b  " + dataGridView3.Rows[selectedbowlerindex].Cells[0].Value;
                    }
                    else if (f == 2)
                    {
                        dataGridView1.Rows[firstplayer].Cells[1].Value = "c  ____ b  " + dataGridView3.Rows[selectedbowlerindex].Cells[0].Value;
                    }
                    else if (f == 3)
                    {
                        dataGridView1.Rows[firstplayer].Cells[1].Value = "Run Out";
                    }
                    else if (f == 4)
                    {
                        dataGridView1.Rows[firstplayer].Cells[1].Value = "lbw  " + dataGridView3.Rows[selectedbowlerindex].Cells[0].Value;
                    }
                    else if (f == 5)
                    {
                        dataGridView1.Rows[firstplayer].Cells[1].Value = "stumping  " + dataGridView3.Rows[selectedbowlerindex].Cells[0].Value;
                    }
                    else if (f == 6)
                    {
                        dataGridView1.Rows[firstplayer].Cells[1].Value = "hit wicket  " + dataGridView3.Rows[selectedbowlerindex].Cells[0].Value;
                    }
                   
                    if (c != 1 && c != 2)
                    {
                        dataGridView2.Rows[firstplayer].Cells[2].Value = Convert.ToInt32(dataGridView2.Rows[firstplayer].Cells[2].Value.ToString()) + 1;
                        dataGridView2.Rows[firstplayer].Cells[1].Value = Convert.ToInt32(dataGridView2.Rows[firstplayer].Cells[1].Value.ToString()) + b;
                        dataGridView1.Rows[firstplayer].Cells[3].Value = Convert.ToInt32(dataGridView1.Rows[firstplayer].Cells[3].Value.ToString()) + 1;
                        dataGridView1.Rows[firstplayer].Cells[2].Value = Convert.ToInt32(dataGridView1.Rows[firstplayer].Cells[2].Value.ToString()) + b;
                    }
                    else
                    {
                        dataGridView2.Rows[firstplayer].Cells[1].Value = Convert.ToInt32(dataGridView2.Rows[firstplayer].Cells[1].Value.ToString()) + b + 1;
                        dataGridView1.Rows[firstplayer].Cells[2].Value = Convert.ToInt32(dataGridView1.Rows[firstplayer].Cells[2].Value.ToString()) + b + 1;
                    }

                    if (b == 0)
                    {
                        dataGridView2.Rows[firstplayer].Cells[3].Value = Convert.ToInt32(dataGridView2.Rows[firstplayer].Cells[3].Value.ToString()) + 1;
                    }
                    else if (b == 1)
                    {
                        dataGridView2.Rows[firstplayer].Cells[4].Value = Convert.ToInt32(dataGridView2.Rows[firstplayer].Cells[4].Value.ToString()) + 1;
                    }
                    else if (b == 2)
                    {
                        dataGridView2.Rows[firstplayer].Cells[5].Value = Convert.ToInt32(dataGridView2.Rows[firstplayer].Cells[5].Value.ToString()) + 1;
                    }
                    else if (b == 3)
                    {
                        dataGridView2.Rows[firstplayer].Cells[6].Value = Convert.ToInt32(dataGridView2.Rows[firstplayer].Cells[6].Value.ToString()) + 1;
                    }
                    else if (b == 4)
                    {
                        dataGridView2.Rows[firstplayer].Cells[7].Value = Convert.ToInt32(dataGridView2.Rows[firstplayer].Cells[7].Value.ToString()) + 1;
                    }
                    else
                    {
                        dataGridView2.Rows[firstplayer].Cells[8].Value = Convert.ToInt32(dataGridView2.Rows[firstplayer].Cells[8].Value.ToString()) + 1;
                    }

                    dataGridView2.Rows[firstplayer].Cells[9].Value = ((Convert.ToDouble(dataGridView2.Rows[firstplayer].Cells[1].Value.ToString())) / (Convert.ToDouble(dataGridView2.Rows[firstplayer].Cells[2].Value.ToString()))) * 100;
                }
                else
                {
                    if (f == 1)
                    {
                        dataGridView1.Rows[secondplayer].Cells[1].Value = "b  " + dataGridView3.Rows[selectedbowlerindex].Cells[0].Value;
                    }
                    else if (f == 2)
                    {
                        dataGridView1.Rows[secondplayer].Cells[1].Value = "c  ____ b  " + dataGridView3.Rows[selectedbowlerindex].Cells[0].Value;
                    }
                    else if (f == 3)
                    {
                        dataGridView1.Rows[secondplayer].Cells[1].Value = "Run Out";
                    }
                    else if (f == 4)
                    {
                        dataGridView1.Rows[secondplayer].Cells[1].Value = "lbw  " + dataGridView3.Rows[selectedbowlerindex].Cells[0].Value;
                    }
                    else if (f == 5)
                    {
                        dataGridView1.Rows[secondplayer].Cells[1].Value = "stumping  " + dataGridView3.Rows[selectedbowlerindex].Cells[0].Value;
                    }
                    else if (f == 6)
                    {
                        dataGridView1.Rows[secondplayer].Cells[1].Value = "hit wicket  " + dataGridView3.Rows[selectedbowlerindex].Cells[0].Value;
                    }

                    if (c != 1 && c != 2)
                    {
                        dataGridView2.Rows[secondplayer].Cells[2].Value = Convert.ToInt32(dataGridView2.Rows[secondplayer].Cells[2].Value.ToString()) + 1;
                        dataGridView2.Rows[secondplayer].Cells[1].Value = Convert.ToInt32(dataGridView2.Rows[secondplayer].Cells[1].Value.ToString()) + b;
                        dataGridView1.Rows[secondplayer].Cells[3].Value = Convert.ToInt32(dataGridView1.Rows[secondplayer].Cells[3].Value.ToString()) + 1;
                        dataGridView1.Rows[secondplayer].Cells[2].Value = Convert.ToInt32(dataGridView1.Rows[secondplayer].Cells[2].Value.ToString()) + b;
                    }
                    else
                    {
                        dataGridView2.Rows[secondplayer].Cells[1].Value = Convert.ToInt32(dataGridView2.Rows[secondplayer].Cells[1].Value.ToString()) + b + 1;
                        dataGridView1.Rows[secondplayer].Cells[2].Value = Convert.ToInt32(dataGridView1.Rows[secondplayer].Cells[2].Value.ToString()) + b + 1;
                    }

                    if (b == 0)
                    {
                        dataGridView2.Rows[secondplayer].Cells[3].Value = Convert.ToInt32(dataGridView2.Rows[secondplayer].Cells[3].Value.ToString()) + 1;
                    }
                    else if (b == 1)
                    {
                        dataGridView2.Rows[secondplayer].Cells[4].Value = Convert.ToInt32(dataGridView2.Rows[secondplayer].Cells[4].Value.ToString()) + 1;
                    }
                    else if (b == 2)
                    {
                        dataGridView2.Rows[secondplayer].Cells[5].Value = Convert.ToInt32(dataGridView2.Rows[secondplayer].Cells[5].Value.ToString()) + 1;
                    }
                    else if (b == 3)
                    {
                        dataGridView2.Rows[secondplayer].Cells[6].Value = Convert.ToInt32(dataGridView2.Rows[secondplayer].Cells[6].Value.ToString()) + 1;
                    }
                    else if (b == 4)
                    {
                        dataGridView2.Rows[secondplayer].Cells[7].Value = Convert.ToInt32(dataGridView2.Rows[secondplayer].Cells[7].Value.ToString()) + 1;
                    }
                    else
                    {
                        dataGridView2.Rows[secondplayer].Cells[8].Value = Convert.ToInt32(dataGridView2.Rows[secondplayer].Cells[8].Value.ToString()) + 1;
                    }

                    dataGridView2.Rows[secondplayer].Cells[9].Value = ((Convert.ToDouble(dataGridView2.Rows[secondplayer].Cells[1].Value.ToString())) / (Convert.ToDouble(dataGridView2.Rows[secondplayer].Cells[2].Value.ToString()))) * 100;
                }

                if (c != 1 && c != 2)
                {
                    dataGridView3.Rows[selectedbowlerindex].Cells[1].Value = Convert.ToDouble(dataGridView3.Rows[selectedbowlerindex].Cells[1].Value.ToString()) + 0.1;
                    dataGridView3.Rows[selectedbowlerindex].Cells[3].Value = Convert.ToInt32(dataGridView3.Rows[selectedbowlerindex].Cells[3].Value.ToString()) + b;
                }
                else
                {
                    dataGridView3.Rows[selectedbowlerindex].Cells[3].Value = Convert.ToInt32(dataGridView3.Rows[selectedbowlerindex].Cells[3].Value.ToString()) + b + 1;
                }

                if (balls % 6 == 0 && c != 1 && c != 2)
                {
                    dataGridView3.Rows[selectedbowlerindex].Cells[1].Value = Convert.ToDouble(dataGridView3.Rows[selectedbowlerindex].Cells[1].Value.ToString()) + 0.4;
                    if (aa == 0)
                    {
                        dataGridView3.Rows[selectedbowlerindex].Cells[2].Value = Convert.ToInt32(dataGridView3.Rows[selectedbowlerindex].Cells[2].Value.ToString()) + 1;
                    }
                }

                if (f > 0 && f < 7 && f != 3)
                {
                    dataGridView3.Rows[selectedbowlerindex].Cells[4].Value = Convert.ToInt32(dataGridView3.Rows[selectedbowlerindex].Cells[4].Value.ToString()) + 1;
                }

                dataGridView3.Rows[selectedbowlerindex].Cells[5].Value = (Convert.ToDouble(dataGridView3.Rows[selectedbowlerindex].Cells[3].Value.ToString()) / (Convert.ToDouble((Convert.ToInt32(Convert.ToDouble(dataGridView3.Rows[selectedbowlerindex].Cells[1].Value.ToString())) * 6) + (balls % 6))) * 6);

                if (b == 0)
                {
                    dataGridView3.Rows[selectedbowlerindex].Cells[6].Value = Convert.ToInt32(dataGridView3.Rows[selectedbowlerindex].Cells[6].Value.ToString()) + 1;
                }
                else if (b == 4)
                {
                    dataGridView3.Rows[selectedbowlerindex].Cells[7].Value = Convert.ToInt32(dataGridView3.Rows[selectedbowlerindex].Cells[7].Value.ToString()) + 1;
                }
                else if (b == 6)
                {
                    dataGridView3.Rows[selectedbowlerindex].Cells[8].Value = Convert.ToInt32(dataGridView3.Rows[selectedbowlerindex].Cells[8].Value.ToString()) + 1;
                }

                if (c != 0)
                {
                    dataGridView3.Rows[selectedbowlerindex].Cells[9].Value = Convert.ToInt32(dataGridView3.Rows[selectedbowlerindex].Cells[9].Value.ToString()) + 1;
                }

                if (d != 0)
                {
                    dataGridView3.Rows[selectedbowlerindex].Cells[9].Value = Convert.ToInt32(dataGridView3.Rows[selectedbowlerindex].Cells[9].Value.ToString()) + b;
                }
            }
            else
            {
                if (strike == true)
                {
                    if (f == 1)
                    {
                        dataGridView4.Rows[firstplayer].Cells[1].Value = "b  " + dataGridView6.Rows[selectedbowlerindex].Cells[0].Value;
                    }
                    else if (f == 2)
                    {
                        dataGridView4.Rows[firstplayer].Cells[1].Value = "c  ____ b  " + dataGridView6.Rows[selectedbowlerindex].Cells[0].Value;
                    }
                    else if (f == 3)
                    {
                        dataGridView4.Rows[firstplayer].Cells[1].Value = "Run Out";
                    }
                    else if (f == 4)
                    {
                        dataGridView4.Rows[firstplayer].Cells[1].Value = "lbw  " + dataGridView6.Rows[selectedbowlerindex].Cells[0].Value;
                    }
                    else if (f == 5)
                    {
                        dataGridView4.Rows[firstplayer].Cells[1].Value = "stumping  " + dataGridView6.Rows[selectedbowlerindex].Cells[0].Value;
                    }
                    else if (f == 6)
                    {
                        dataGridView4.Rows[firstplayer].Cells[1].Value = "hit wicket  " + dataGridView6.Rows[selectedbowlerindex].Cells[0].Value;
                    }

                    if (c != 1 && c != 2)
                    {
                        dataGridView5.Rows[firstplayer].Cells[2].Value = Convert.ToInt32(dataGridView5.Rows[firstplayer].Cells[2].Value.ToString()) + 1;
                        dataGridView5.Rows[firstplayer].Cells[1].Value = Convert.ToInt32(dataGridView5.Rows[firstplayer].Cells[1].Value.ToString()) + b;
                        dataGridView4.Rows[firstplayer].Cells[3].Value = Convert.ToInt32(dataGridView4.Rows[firstplayer].Cells[3].Value.ToString()) + 1;
                        dataGridView4.Rows[firstplayer].Cells[2].Value = Convert.ToInt32(dataGridView4.Rows[firstplayer].Cells[2].Value.ToString()) + b;
                    }
                    else
                    {
                        dataGridView5.Rows[firstplayer].Cells[1].Value = Convert.ToInt32(dataGridView5.Rows[firstplayer].Cells[1].Value.ToString()) + b + 1;
                        dataGridView4.Rows[firstplayer].Cells[2].Value = Convert.ToInt32(dataGridView5.Rows[firstplayer].Cells[2].Value.ToString()) + b + 1;
                    }

                    if (b == 0)
                    {
                        dataGridView5.Rows[firstplayer].Cells[3].Value = Convert.ToInt32(dataGridView5.Rows[firstplayer].Cells[3].Value.ToString()) + 1;
                    }
                    else if (b == 1)
                    {
                        dataGridView5.Rows[firstplayer].Cells[4].Value = Convert.ToInt32(dataGridView5.Rows[firstplayer].Cells[4].Value.ToString()) + 1;
                    }
                    else if (b == 2)
                    {
                        dataGridView5.Rows[firstplayer].Cells[5].Value = Convert.ToInt32(dataGridView5.Rows[firstplayer].Cells[5].Value.ToString()) + 1;
                    }
                    else if (b == 3)
                    {
                        dataGridView5.Rows[firstplayer].Cells[6].Value = Convert.ToInt32(dataGridView5.Rows[firstplayer].Cells[6].Value.ToString()) + 1;
                    }
                    else if (b == 4)
                    {
                        dataGridView5.Rows[firstplayer].Cells[7].Value = Convert.ToInt32(dataGridView5.Rows[firstplayer].Cells[7].Value.ToString()) + 1;
                    }
                    else
                    {
                        dataGridView5.Rows[firstplayer].Cells[8].Value = Convert.ToInt32(dataGridView5.Rows[firstplayer].Cells[8].Value.ToString()) + 1;
                    }

                    dataGridView5.Rows[firstplayer].Cells[9].Value = ((Convert.ToDouble(dataGridView5.Rows[firstplayer].Cells[1].Value.ToString())) / (Convert.ToDouble(dataGridView5.Rows[firstplayer].Cells[2].Value.ToString()))) * 100;
                }
                else
                {
                    if (f == 1)
                    {
                        dataGridView4.Rows[secondplayer].Cells[1].Value = "b  " + dataGridView6.Rows[selectedbowlerindex].Cells[0].Value;
                    }
                    else if (f == 2)
                    {
                        dataGridView4.Rows[secondplayer].Cells[1].Value = "c  ____ b  " + dataGridView6.Rows[selectedbowlerindex].Cells[0].Value;
                    }
                    else if (f == 3)
                    {
                        dataGridView4.Rows[secondplayer].Cells[1].Value = "Run Out";
                    }
                    else if (f == 4)
                    {
                        dataGridView4.Rows[secondplayer].Cells[1].Value = "lbw  " + dataGridView6.Rows[selectedbowlerindex].Cells[0].Value;
                    }
                    else if (f == 5)
                    {
                        dataGridView4.Rows[secondplayer].Cells[1].Value = "stumping  " + dataGridView6.Rows[selectedbowlerindex].Cells[0].Value;
                    }
                    else if (f == 6)
                    {
                        dataGridView4.Rows[secondplayer].Cells[1].Value = "hit wicket  " + dataGridView6.Rows[selectedbowlerindex].Cells[0].Value;
                    }

                    if (c != 1 && c != 2)
                    {
                        dataGridView5.Rows[secondplayer].Cells[2].Value = Convert.ToInt32(dataGridView5.Rows[secondplayer].Cells[2].Value.ToString()) + 1;
                        dataGridView5.Rows[secondplayer].Cells[1].Value = Convert.ToInt32(dataGridView5.Rows[secondplayer].Cells[1].Value.ToString()) + b;
                        dataGridView4.Rows[secondplayer].Cells[3].Value = Convert.ToInt32(dataGridView4.Rows[secondplayer].Cells[3].Value.ToString()) + 1;
                        dataGridView4.Rows[secondplayer].Cells[2].Value = Convert.ToInt32(dataGridView4.Rows[secondplayer].Cells[2].Value.ToString()) + b;
                    }
                    else
                    {
                        dataGridView5.Rows[secondplayer].Cells[1].Value = Convert.ToInt32(dataGridView5.Rows[secondplayer].Cells[1].Value.ToString()) + b + 1;
                    }

                    if (b == 0)
                    {
                        dataGridView5.Rows[secondplayer].Cells[3].Value = Convert.ToInt32(dataGridView5.Rows[secondplayer].Cells[3].Value.ToString()) + 1;
                    }
                    else if (b == 1)
                    {
                        dataGridView5.Rows[secondplayer].Cells[4].Value = Convert.ToInt32(dataGridView5.Rows[secondplayer].Cells[4].Value.ToString()) + 1;
                    }
                    else if (b == 2)
                    {
                        dataGridView5.Rows[secondplayer].Cells[5].Value = Convert.ToInt32(dataGridView5.Rows[secondplayer].Cells[5].Value.ToString()) + 1;
                    }
                    else if (b == 3)
                    {
                        dataGridView5.Rows[secondplayer].Cells[6].Value = Convert.ToInt32(dataGridView5.Rows[secondplayer].Cells[6].Value.ToString()) + 1;
                    }
                    else if (b == 4)
                    {
                        dataGridView5.Rows[secondplayer].Cells[7].Value = Convert.ToInt32(dataGridView5.Rows[secondplayer].Cells[7].Value.ToString()) + 1;
                    }
                    else
                    {
                        dataGridView5.Rows[secondplayer].Cells[8].Value = Convert.ToInt32(dataGridView5.Rows[secondplayer].Cells[8].Value.ToString()) + 1;
                    }

                    dataGridView5.Rows[secondplayer].Cells[9].Value = ((Convert.ToDouble(dataGridView5.Rows[secondplayer].Cells[1].Value.ToString())) / (Convert.ToDouble(dataGridView5.Rows[secondplayer].Cells[2].Value.ToString()))) * 100;
                }

                if (c != 1 && c != 2)
                {
                    dataGridView6.Rows[selectedbowlerindex].Cells[1].Value = Convert.ToDouble(dataGridView6.Rows[selectedbowlerindex].Cells[1].Value.ToString()) + 0.1;
                    dataGridView6.Rows[selectedbowlerindex].Cells[3].Value = Convert.ToInt32(dataGridView6.Rows[selectedbowlerindex].Cells[3].Value.ToString()) + b;
                }
                else
                {
                    dataGridView6.Rows[selectedbowlerindex].Cells[3].Value = Convert.ToInt32(dataGridView6.Rows[selectedbowlerindex].Cells[3].Value.ToString()) + b + 1;
                }

                if (balls % 6 == 0 && c != 1 && c != 2)
                {
                    dataGridView6.Rows[selectedbowlerindex].Cells[1].Value = Convert.ToDouble(dataGridView6.Rows[selectedbowlerindex].Cells[1].Value.ToString()) + 0.4;
                    if (aa == 0)
                    {
                        dataGridView6.Rows[selectedbowlerindex].Cells[2].Value = Convert.ToInt32(dataGridView6.Rows[selectedbowlerindex].Cells[2].Value.ToString()) + 1;
                    }
                }

                if (f > 0 && f < 7 && f != 3)
                {
                    dataGridView6.Rows[selectedbowlerindex].Cells[4].Value = Convert.ToInt32(dataGridView6.Rows[selectedbowlerindex].Cells[4].Value.ToString()) + 1;
                }

                dataGridView6.Rows[selectedbowlerindex].Cells[5].Value = (Convert.ToDouble(dataGridView6.Rows[selectedbowlerindex].Cells[3].Value.ToString()) / (Convert.ToDouble((Convert.ToInt32(Convert.ToDouble(dataGridView6.Rows[selectedbowlerindex].Cells[1].Value.ToString())) * 6) + (balls % 6)))) * 6;

                if (b == 0)
                {
                    dataGridView6.Rows[selectedbowlerindex].Cells[6].Value = Convert.ToInt32(dataGridView6.Rows[selectedbowlerindex].Cells[6].Value.ToString()) + 1;
                }
                else if (b == 4)
                {
                    dataGridView6.Rows[selectedbowlerindex].Cells[7].Value = Convert.ToInt32(dataGridView6.Rows[selectedbowlerindex].Cells[7].Value.ToString()) + 1;
                }
                else if (b == 6)
                {
                    dataGridView6.Rows[selectedbowlerindex].Cells[8].Value = Convert.ToInt32(dataGridView6.Rows[selectedbowlerindex].Cells[8].Value.ToString()) + 1;
                }

                if (c != 0)
                {
                    dataGridView6.Rows[selectedbowlerindex].Cells[9].Value = Convert.ToInt32(dataGridView6.Rows[selectedbowlerindex].Cells[9].Value.ToString()) + 1;
                }

                if (d != 0)
                {
                    dataGridView6.Rows[selectedbowlerindex].Cells[9].Value = Convert.ToInt32(dataGridView6.Rows[selectedbowlerindex].Cells[9].Value.ToString()) + b;
                }
            }
        }

        public void setover(object sender, EventArgs e)
        {
            maxovers = Convert.ToInt32( O.Data);
            this.Controls.Remove(O);
        }

        public void settoss(object sender, EventArgs e)
        {
            pet = T.Data.Split(new Char[] { ',' });

            if(pet[0]== Convert.ToString(1))
            {
                if (pet[1]== teamname[0])
                {
                    firstteamtoss = true;
                    if (pet[2]== "Batting")
                    {
                        firstteambatting = true;
                        label21.Text = teamname[0] +" has won the toss and elected to Bat first";
                    }
                    else
                    {
                        firstteambatting = false;
                        label21.Text = teamname[0] + " has won the toss and elected to Field first";
                    }
                }
                else 
                {
                    firstteamtoss = false;
                    if (pet[2]== "Batting")
                    {
                        firstteambatting = false;
                        label21.Text = teamname[1] + " has won the toss and elected to Bat first";
                    }
                    else
                    {
                        firstteambatting = true;
                        label21.Text = teamname[1] + " has won the toss and elected to Field first";
                    }
                }
                this.Controls.Remove(T);
                initializedatagridviews();
                setopeningbatsmenandbowler();
            }
        }

        public void setbatsmen(object sender, EventArgs e)
        {
            pet = NB.Data.Split(new Char[] { ',' });

            if(wickets==0)
            {
                swapplayers[0] = pet[0];
                swapplayers[1] = pet[1];

                if (firstteambatting == true)
                {
                    for (x = 0, y = 2; x < 11; x++)
                    {
                        if (players1[x] != swapplayers[0] && players1[x] != swapplayers[1])
                        {
                            swapplayers[y] = players1[x];
                            swapplayersid[y] = players1id[x];
                            y++;
                        }
                        else if (players1[x] == swapplayers[0] )
                        {
                            swapplayersid[0] = players1id[x];
                            dataGridView2.Rows.InsertCopy(x, 0);
                            for (z = 0; z < 10; z++)
                            {
                                dataGridView2.Rows[0].Cells[z].Value = dataGridView2.Rows[x + 1].Cells[z].Value;
                            }
                            dataGridView2.Rows.RemoveAt(x + 1);
                            dataGridView1.Rows.InsertCopy(x, 0);
                            dataGridView1.Rows[0].Cells[0].Value = dataGridView1.Rows[x + 1].Cells[0].Value;
                            dataGridView1.Rows[0].Cells[1].Value = "";
                            dataGridView1.Rows[0].Cells[2].Value = 0;
                            dataGridView1.Rows[0].Cells[3].Value = 0;
                            dataGridView1.Rows.RemoveAt(x + 1);
                        }
                        else if(Convert.ToString(dataGridView1.Rows[0].Cells[0].Value) != swapplayers[0])
                        {
                            swapplayersid[1] = players1id[x];
                            dataGridView2.Rows.InsertCopy(x, 0);
                            for (z = 0; z < 10; z++)
                            {
                                dataGridView2.Rows[0].Cells[z].Value = dataGridView2.Rows[x + 1].Cells[z].Value;
                            }
                            dataGridView2.Rows.RemoveAt(x + 1);
                            dataGridView1.Rows.InsertCopy(x, 0);
                            dataGridView1.Rows[0].Cells[0].Value = dataGridView1.Rows[x + 1].Cells[0].Value;
                            dataGridView1.Rows[0].Cells[1].Value = "";
                            dataGridView1.Rows[0].Cells[2].Value = 0;
                            dataGridView1.Rows[0].Cells[3].Value = 0;
                            dataGridView1.Rows.RemoveAt(x + 1);
                        }
                        else
                        {
                            swapplayersid[1] = players1id[x];
                            dataGridView2.Rows.InsertCopy(x, 1);
                            for (z = 0; z < 10; z++)
                            {
                                dataGridView2.Rows[1].Cells[z].Value = dataGridView2.Rows[x + 1].Cells[z].Value;
                            }
                            dataGridView2.Rows.RemoveAt(x + 1);
                            dataGridView1.Rows.InsertCopy(x, 1);
                            dataGridView1.Rows[1].Cells[0].Value = dataGridView1.Rows[x + 1].Cells[0].Value;
                            dataGridView1.Rows[1].Cells[1].Value = "";
                            dataGridView1.Rows[1].Cells[2].Value = 0;
                            dataGridView1.Rows[1].Cells[3].Value = 0;
                            dataGridView1.Rows.RemoveAt(x + 1);                                
                        }
                    }

                    for (x = 0; x < 11; x++)
                    {
                        players1[x] = swapplayers[x];
                        players1id[x] = swapplayersid[x];
                    }
                }
                else
                {
                    for (x = 0, y = 2; x < 11; x++)
                    {
                        if (players2[x] != swapplayers[0] && players2[x] != swapplayers[1])
                        {
                            swapplayers[y] = players2[x];
                            swapplayersid[y] = players2id[x];
                            y++;
                        }
                        else if (players2[x] == swapplayers[0])
                        {
                            swapplayersid[0] = players2id[x];
                            dataGridView5.Rows.InsertCopy(x, 0);
                            for (z = 0; z < 10; z++)
                            {
                                dataGridView5.Rows[0].Cells[z].Value = dataGridView5.Rows[x + 1].Cells[z].Value;
                            }
                            dataGridView5.Rows.RemoveAt(x + 1);
                            dataGridView4.Rows.InsertCopy(x, 0);
                            dataGridView4.Rows[0].Cells[0].Value = dataGridView4.Rows[x + 1].Cells[0].Value;
                            dataGridView4.Rows[0].Cells[1].Value = "";
                            dataGridView4.Rows[0].Cells[2].Value = 0;
                            dataGridView4.Rows[0].Cells[3].Value = 0;
                            dataGridView4.Rows.RemoveAt(x + 1);
                        }
                        else if (Convert.ToString(dataGridView4.Rows[0].Cells[0].Value) != swapplayers[0])
                        {
                            swapplayersid[1] = players2id[x];
                            dataGridView5.Rows.InsertCopy(x, 0);
                            for (z = 0; z < 10; z++)
                            {
                                dataGridView5.Rows[0].Cells[z].Value = dataGridView5.Rows[x + 1].Cells[z].Value;
                            }
                            dataGridView5.Rows.RemoveAt(x + 1);
                            dataGridView4.Rows.InsertCopy(x, 0);
                            dataGridView4.Rows[0].Cells[0].Value = dataGridView4.Rows[x + 1].Cells[0].Value;
                            dataGridView4.Rows[0].Cells[1].Value = "";
                            dataGridView4.Rows[0].Cells[2].Value = 0;
                            dataGridView4.Rows[0].Cells[3].Value = 0;
                            dataGridView4.Rows.RemoveAt(x + 1);
                        }
                        else
                        {
                            swapplayersid[1] = players2id[x];
                            dataGridView5.Rows.InsertCopy(x, 1);
                            for (z = 0; z < 10; z++)
                            {
                                dataGridView5.Rows[1].Cells[z].Value = dataGridView5.Rows[x + 1].Cells[z].Value;
                            }
                            dataGridView5.Rows.RemoveAt(x + 1);
                            dataGridView4.Rows.InsertCopy(x, 1);
                            dataGridView4.Rows[1].Cells[0].Value = dataGridView4.Rows[x + 1].Cells[0].Value;
                            dataGridView4.Rows[1].Cells[1].Value = "";
                            dataGridView4.Rows[1].Cells[2].Value = 0;
                            dataGridView4.Rows[1].Cells[3].Value = 0;
                            dataGridView4.Rows.RemoveAt(x + 1);
                        }
                    }

                    for (x = 0; x < 11; x++)
                    {
                        players2[x] = swapplayers[x];
                        players2id[x] = swapplayersid[x];
                    }
                }
            }
            else
            {
                swapplayers[wickets+1] = pet[0];

                if (firstteambatting == true)
                {
                    for (x = 0, y = 0; x < 11; x++,y++)
                    {
                        if (y == (wickets + 1))
                        {
                            x--;
                        }
                        else
                        {
                            if (players1[x] != swapplayers[wickets+1])
                            {
                                swapplayers[y] = players1[x];
                                swapplayersid[y] = players1id[x];
                            }
                            else
                            {
                                swapplayersid[wickets + 1] = players1id[x];
                                dataGridView2.Rows.InsertCopy(x , wickets + 1);
                                for (z = 0; z < 10; z++)
                                {
                                    dataGridView2.Rows[wickets + 1].Cells[z].Value = dataGridView2.Rows[x + 1].Cells[z].Value;
                                }
                                dataGridView2.Rows.RemoveAt(x + 1);
                                dataGridView1.Rows.InsertCopy(x, wickets + 1);
                                dataGridView1.Rows[wickets + 1].Cells[0].Value = dataGridView1.Rows[x + 1].Cells[0].Value;
                                dataGridView1.Rows[wickets + 1].Cells[1].Value = "";
                                dataGridView1.Rows[wickets + 1].Cells[2].Value = 0;
                                dataGridView1.Rows[wickets + 1].Cells[3].Value = 0;
                                dataGridView1.Rows.RemoveAt(x + 1);
                                x++;
                            }
                        }
                    }

                    for (x = 0; x < 11; x++)
                    {
                        players1[x] = swapplayers[x];
                        players1id[x] = swapplayersid[x];
                    }       
                }
                else
                {
                    for (x = 0, y = 0; x < 11; x++, y++)
                    {
                        if (y == (wickets + 1))
                        {
                            x--;
                        }
                        else
                        {
                            if (players2[x] != swapplayers[wickets + 1])
                            {
                                swapplayers[y] = players2[x];
                                swapplayersid[y] = players2id[x];
                            }
                            else
                            {
                                swapplayersid[wickets + 1] = players2id[x];
                                dataGridView5.Rows.InsertCopy(x, wickets + 1);
                                for (z = 0; z < 10; z++)
                                {
                                    dataGridView5.Rows[wickets + 1].Cells[z].Value = dataGridView5.Rows[x + 1].Cells[z].Value;
                                }
                                dataGridView5.Rows.RemoveAt(x + 1);
                                dataGridView4.Rows.InsertCopy(x, wickets + 1);
                                dataGridView4.Rows[wickets + 1].Cells[0].Value = dataGridView4.Rows[x + 1].Cells[0].Value;
                                dataGridView4.Rows[wickets + 1].Cells[1].Value = "";
                                dataGridView4.Rows[wickets + 1].Cells[2].Value = 0;
                                dataGridView4.Rows[wickets + 1].Cells[3].Value = 0;
                                dataGridView4.Rows.RemoveAt(x + 1);
                                x++;
                            }
                        }
                    }

                    for (x = 0; x < 11; x++)
                    {
                        players2[x] = swapplayers[x];
                        players2id[x] = swapplayersid[x];
                    }
                }


                if (strike == true)
                {
                    firstplayer = wickets + 1;
                }
                else
                {
                    secondplayer = wickets + 1;
                }
            }

            this.Controls.Remove(NB);
        }

        private void initializedatagridviews()
        {
            if (firstteambatting == true)
            {
                dataGridView1.Visible = true;
                dataGridView2.Visible = true;
                dataGridView3.Visible = true;
                dataGridView4.Visible = false;
                dataGridView5.Visible = false;
                dataGridView6.Visible = false;
                
            }
            else
            {
                dataGridView4.Visible = true;
                dataGridView5.Visible = true;
                dataGridView6.Visible = true;
                dataGridView1.Visible = false;
                dataGridView2.Visible = false;
                dataGridView3.Visible = false;
            }

            for (i = 0; i < 11; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = players1[i];
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = players1[i];
                dataGridView1.Rows[i].Cells[1].Value = "Still To Bat";
                for (j = 1; j < 10; j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = 0;
                }

                dataGridView5.Rows.Add();
                dataGridView5.Rows[i].Cells[0].Value = players2[i];
                dataGridView4.Rows.Add();
                dataGridView4.Rows[i].Cells[0].Value = players2[i];
                dataGridView4.Rows[i].Cells[1].Value = "Still To Bat";
                for (j = 1; j < 10; j++)
                {
                    dataGridView5.Rows[i].Cells[j].Value = 0;
                }
            }

            dataGridView2.AllowUserToAddRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView5.AllowUserToAddRows = false;
            dataGridView4.AllowUserToAddRows = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.Text==teamname[0])
            {
                dataGridView1.Visible = true;
                dataGridView2.Visible = true;
                dataGridView3.Visible = true;
                dataGridView4.Visible = false;
                dataGridView5.Visible = false;
                dataGridView6.Visible = false;
            }
            else
            {
                dataGridView4.Visible = true;
                dataGridView5.Visible = true;
                dataGridView6.Visible = true;
                dataGridView1.Visible = false;
                dataGridView2.Visible = false;
                dataGridView3.Visible = false;
            }
        }

        private void setopeningbatsmenandbowler()
        {
            remainingbatsmen = "";

            if (firstteambatting == true)
            {
                for (i = 0; i < 11; i++)
                {
                    remainingbatsmen = remainingbatsmen + players1[i];
                    if (i < 10)
                    {
                        remainingbatsmen = remainingbatsmen + ",";
                    }
                }
            }
            else
            {
                for (i = 0; i < 11; i++)
                {
                    remainingbatsmen = remainingbatsmen + players2[i];
                    if (i < 10)
                    {
                        remainingbatsmen = remainingbatsmen + ",";
                    }
                }
            }

            NB.Data = remainingbatsmen;
            NB.Dock = DockStyle.None;
            this.Controls.Add(NB);
            NB.BringToFront();
            NB.initiate();
            NB.initiate2();

            remainingbowler = "";
            if (firstteambatting == true)
            {
                for (i = 0; i < 11; i++)
                {
                    remainingbowler = remainingbowler + players2[i];
                    if (i < 10)
                    {
                        remainingbowler = remainingbowler + ",";
                    }
                }
            }
            else
            {
                for (i = 0; i < 11; i++)
                {
                    remainingbowler = remainingbowler + players1[i];
                    if (i < 10)
                    {
                        remainingbowler = remainingbowler + ",";
                    }
                }
            }

            NBW.Data = remainingbowler;
            NBW.Dock = DockStyle.None;
            this.Controls.Add(NBW);
            NBW.BringToFront();
            NBW.initiate();
        }

        public void setbowler(object sender, EventArgs e)
        {
            selectedbowler = NBW.Data;
            this.Controls.Remove(NBW);

            if(firstteambatting==true)
            {
                temp = true;
                dataGridView3.AllowUserToAddRows = false;
                dataGridView6.AllowUserToAddRows = false;

                for (x = 0; x < dataGridView3.Rows.Count; x++)
                {
                    if(dataGridView3.Rows[x].Cells[0].Value == selectedbowler)
                    {
                        temp = false;
                        selectedbowlerindex = x;
                    }
                }

                if(temp==true)
                {
                    dataGridView3.Rows.Add();
                    dataGridView3.Rows[x].Cells[0].Value = selectedbowler;
                    for (y = 1; y < 10; y++)
                    {
                        dataGridView3.Rows[x].Cells[y].Value = 0;
                    }
                    selectedbowlerindex = x;
                }
            }
            else
            {
                for (x = 0; x < dataGridView6.Rows.Count; x++)
                {
                    if (dataGridView6.Rows[x].Cells[0].Value == selectedbowler)
                    {
                        temp = false;
                        selectedbowlerindex = x;
                    }
                }

                if (temp == true)
                {
                    dataGridView6.Rows.Add();
                    dataGridView6.Rows[x].Cells[0].Value = selectedbowler;
                    for (y = 1; y < 10; y++)
                    {
                        dataGridView6.Rows[x].Cells[y].Value = 0;
                    }
                    selectedbowlerindex = x;
                }
            }
        }
    }
}


