using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO.Ports;
using System.Text.RegularExpressions;


namespace PROJEKAT_KUI2019
{
    public partial class KUI : Form
    {
        
        MySqlConnection konekcija = new MySqlConnection("Server=localhost;Database=mydatabase;Uid=root;Pwd=;");
        int trenutni_id = 0;
        

        public KUI()
        {
            
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
         
            
            toolStripLabel1.Text = DateTime.Now.ToString();
            try
            {
                serialPort1.Open();   
               
            }
            catch
            {
                MessageBox.Show("greska");
            }
           
        }


        private void s(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            String napon =serialPort1.ReadLine();
            String temperatura = serialPort1.ReadLine();
            String vlaznost = serialPort1.ReadLine();
            String tempc = serialPort1.ReadLine();


            textBox1.Text = napon;
            textBox2.Text = temperatura;
            textBox3.Text = vlaznost;
            textBox4.Text = tempc;
            richTextBox1.AppendText(DateTime.Now.ToString()+"\n");
            richTextBox1.AppendText(textBox1.Text);
            richTextBox1.AppendText(textBox2.Text);
            richTextBox1.AppendText(textBox3.Text);
            richTextBox1.AppendText(textBox4.Text);
            richTextBox1.AppendText("*****************************\n");
            String datum = DateTime.Now.ToString();
            float ntc = (float)Convert.ToDouble(napon);
            float dht_temperatura = (float)Convert.ToDouble(temperatura);
            float dht_vlaznost = (float)Convert.ToDouble(vlaznost);
            float ds_temperatura = (float)Convert.ToDouble(tempc);
            progressBar1.Value = Convert.ToInt32(dht_temperatura);
            try
            {
                konekcija.Open();
                MySqlCommand upit = konekcija.CreateCommand();
                upit.CommandText = "INSERT INTO `mjerenja`(`ID`, `vrijeme_datum`, `temperatura_dht`, `vlaznost_dht`, `ntc`, `temperatura_ds`) VALUES ('" + trenutni_id + "','" + datum + "','" + dht_temperatura + "','" + dht_vlaznost + "','" + ntc + "','" + ds_temperatura + "');";
                upit.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Greska");
            }
            konekcija.Close();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
           
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

       

        
    }
}
