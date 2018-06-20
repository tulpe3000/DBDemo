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

namespace DBDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myConnectionString = "SERVER=localhost;" +
                            "DATABASE=chantal;" +
                            "UID=root;" +
                            "PASSWORD=; SslMode=none";

            MySqlConnection connection = new MySqlConnection(myConnectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM adressen";
            MySqlDataReader Reader;
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                string row = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                    row += Reader.GetValue(i).ToString() + ", ";
                listBox1.Items.Add(row);
            }
            connection.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //label1.Text=listBox1.SelectedItem.ToString();
            string str = listBox1.SelectedItem.ToString();
            string[] strArray = str.Split(',');

            //var linqQuery = from entry in strArray
            //                where strArray.I
            //                select number;


            label1.Text = strArray[0];

            label2.Text = (checkBox1.Checked) ? strArray[1] : "";
            label3.Text = (checkBox2.Checked) ? strArray[2] : "";
            label4.Text = (checkBox3.Checked) ? strArray[3] : "";
            label5.Text = (checkBox4.Checked) ? strArray[4] : "";
            label6.Text = (checkBox5.Checked) ? strArray[5] : "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Diese Codezeile lädt Daten in die Tabelle "db_buecherDataSet.buecher". Sie können sie bei Bedarf verschieben oder entfernen.
            this.buecherTableAdapter.Fill(this.db_buecherDataSet.buecher);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "it_persoenlichkeitenDataSet.personen". Sie können sie bei Bedarf verschieben oder entfernen.
            this.personenTableAdapter.Fill(this.it_persoenlichkeitenDataSet.personen);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "chantalDataSet.adressen". Sie können sie bei Bedarf verschieben oder entfernen.
            this.adressenTableAdapter.Fill(this.chantalDataSet.adressen);
            dataGridView1.DataSource = this.it_persoenlichkeitenDataSet;
            dataGridView1.DataMember = this.it_persoenlichkeitenDataSet.Tables[0].TableName;
            dataGridView1.RowHeadersVisible = false;
            dataGridView2.DataSource = this.db_buecherDataSet;
            dataGridView2.DataMember = this.db_buecherDataSet.Tables[0].TableName;
            dataGridView2.RowHeadersVisible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            MySqlCommandBuilder commandBuilderPerson = new MySqlCommandBuilder(this.personenTableAdapter.Adapter);          
            this.personenTableAdapter.Adapter.Update(this.it_persoenlichkeitenDataSet.Tables[0]);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlCommandBuilder commandBuilderBuch = new MySqlCommandBuilder(this.buecherTableAdapter.Adapter);
            this.buecherTableAdapter.Adapter.Update(this.db_buecherDataSet.Tables[0]);
        }
    }
}
