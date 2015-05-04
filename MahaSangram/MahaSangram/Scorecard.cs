﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MahaSangram
{
    public partial class Scorecard : UserControl
    {
        int a, b, c, d, balls, runs, i, k, l, wickets, f, maxovers=8, j, x=0;
        string[] pet;
        double overs;
        int[] record = new int[150];
        string[] playersnames;
        string[] players1 = new string[11];
        string[] players2 = new string[11];
        string[] teamname = new string[2];
        double[] povers = new double[11];
        bool firstinnings, firstteambatting ,firstteamtoss ;
        overs O = new overs();
        Toss T = new Toss();
        private SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Github\MahaSangram\MahaSangram\MahaSangram\MSDatabase.mdf;Integrated Security=True;User Instance=True");
        private SqlCommand query = new SqlCommand();
        private SqlDataReader teams, players;
        nextbatsmen NB = new nextbatsmen();
        string remainingbatsmen;

        public Scorecard()
        {
           InitializeComponent();
           this.O.button1clicklistner(new EventHandler(setover));
           this.T.button1clicklistner(new EventHandler(settoss));
           this.T.button2clicklistner(new EventHandler(settoss));
           this.NB.button1clicklistner(new EventHandler(setbatsmen));
           connection.Open();
           query.Connection = connection;
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Submit.Enabled = true;
        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Submit.Enabled = true;
            metroRadioButton11.Checked = false;
            metroRadioButton12.Checked = false;
            metroRadioButton14.Checked = false;
            metroRadioButton15.Checked = false;
            metroRadioButton16.Checked = false;
        }

        private void metroRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Submit.Enabled = true;
            metroRadioButton11.Checked = false;
            metroRadioButton12.Checked = false;
            metroRadioButton14.Checked = false;
            metroRadioButton15.Checked = false;
            metroRadioButton16.Checked = false;
        }

        private void metroRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Submit.Enabled = true;
            metroRadioButton11.Checked = false;
            metroRadioButton12.Checked = false;
            metroRadioButton14.Checked = false;
            metroRadioButton15.Checked = false;
            metroRadioButton16.Checked = false;
        }

        private void metroRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Submit.Enabled = true;
            metroRadioButton11.Checked = false;
            metroRadioButton12.Checked = false;
            metroRadioButton13.Checked = false;
            metroRadioButton14.Checked = false;
            metroRadioButton15.Checked = false;
            metroRadioButton16.Checked = false;
        }

        private void metroRadioButton6_CheckedChanged(object sender, EventArgs e)
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

        private void metroRadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            Submit.Enabled = true;
            metroRadioButton6.Checked = false;
            metroRadioButton11.Checked = false;
            metroRadioButton12.Checked = false;
            metroRadioButton14.Checked = false;
        }

        private void metroRadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            Submit.Enabled = true;
            metroRadioButton11.Checked = false;
            metroRadioButton12.Checked = false;
            metroRadioButton14.Checked = false;
            metroRadioButton15.Checked = false;
            metroRadioButton16.Checked = false;
        }

        private void metroRadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            Submit.Enabled = true;
            metroRadioButton6.Checked = false;
            metroRadioButton11.Checked = false;
            metroRadioButton12.Checked = false;
            metroRadioButton14.Checked = false;
            metroRadioButton15.Checked = false;
        }

        private void metroRadioButton10_CheckedChanged(object sender, EventArgs e)
        {
            Submit.Enabled = true;
            metroRadioButton6.Checked = false;
            metroRadioButton11.Checked = false;
            metroRadioButton12.Checked = false;
            metroRadioButton14.Checked = false;
            metroRadioButton15.Checked = false;
        }

        private void metroRadioButton11_CheckedChanged(object sender, EventArgs e)
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

        private void metroRadioButton12_CheckedChanged(object sender, EventArgs e)
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

        private void metroRadioButton13_CheckedChanged(object sender, EventArgs e)
        {
            Submit.Enabled = true;
            metroRadioButton5.Checked = false;
            metroRadioButton6.Checked = false;
        }

        private void metroRadioButton14_CheckedChanged(object sender, EventArgs e)
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

        private void metroRadioButton15_CheckedChanged(object sender, EventArgs e)
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

        private void metroRadioButton16_CheckedChanged(object sender, EventArgs e)
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
                generateScorecard();
                                
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
            }
            else
            {
                Submit.Text = "Submit";
                //end match ki coding
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
                    }
                }
            }
        }

        public void initiate()
        {
            T.Data = teamname[0] + "," + teamname[1];
            T.Dock = DockStyle.Fill;
            this.Controls.Add(T);
            T.BringToFront();
            O.Dock = DockStyle.Fill;
            this.Controls.Add(O);
            O.BringToFront();

            for (i = 0; i < 11; i++)
            {
                players1[i] = playersnames[i + 1];
                players2[i] = playersnames[i + 12];
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

            
        }

        private void initializedatagridviews()
        {
            if (firstteambatting == true)
            {
                for (i = 0; i < 11; i++)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[0].Value = players1[i];
                    for (j = 1; j < 10; j++)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = 0;
                    }
                }
            }
            else
            {
                for (i = 0; i < 11; i++)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[0].Value = players2[i];
                    for (j = 1; j < 10; j++)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = 0;
                    }
                }
            }

            dataGridView2.AllowUserToAddRows = false;
        }
        
        private void generateScorecard()
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

            else if (d == 1)
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
        }

        int aa = 0;
      
        public void generateGraph()
        {
            aa += b;

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

            if (balls % 6 == 0)
            {
                overs = Convert.ToInt32(overs);
                // user control bowler
            }

            if (f > 0 && f < 7)
            {
                wickets++;
                               
                if(firstteambatting==true && wickets!=10)
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
                        remainingbatsmen = remainingbatsmen + players2[i + 1] + ",";
                        if (i < 9)
                        {
                            remainingbatsmen = remainingbatsmen + ",";
                        }
                    }
                }

                NB.Data = remainingbatsmen;
                remainingbatsmen = "";
                NB.Dock = DockStyle.None;
                this.Controls.Add(NB);
                NB.BringToFront();
                NB.initiate();
            }
        }

        private void updatetables()
        {
            /*
            DataGridViewRow row;
            row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = "Chaitanya"; player name var
            row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[1].Value = "bas ho gaya ab out";
            row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[2].Value = 50;
            row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[3].Value = 20;
            row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            dataGridView1.Rows.Add(row);
            */
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
            }
        }

        public void setbatsmen(object sender, EventArgs e)
        {
            MessageBox.Show(NB.Data);
            this.Controls.Remove(NB);
        }
    }
}
