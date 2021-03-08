using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace Project
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
               pictureBox1.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
         
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.Color.Aqua;
            button2.BackColor = System.Drawing.Color.GhostWhite;
            button3.BackColor = System.Drawing.Color.GhostWhite;
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            pictureBox1.Visible = false; 
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.Color.Aqua;
            button1.BackColor = System.Drawing.Color.GhostWhite;
            button3.BackColor = System.Drawing.Color.GhostWhite;
            panel2.Visible = true;
            panel1.Visible = false;
           panel3.Visible = false;
            pictureBox1.Visible = false;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.Color.Aqua;
            button2.BackColor = System.Drawing.Color.GhostWhite;
            button1.BackColor = System.Drawing.Color.GhostWhite;
            panel3.Visible = true;
            panel2.Visible = false;
            panel1.Visible = false;
            pictureBox1.Visible = false;
        
            


            MySqlConnection con = new MySqlConnection("user id=ashraf;persistsecurityinfo=True;server=127.0.0.1;database=project;password=camry551;");
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select*from addpatient inner join patientmore on addpatient.pid = patientmore.pid;";
            MySqlDataAdapter DA = new MySqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            int i =cmd.ExecuteNonQuery();
            dataGridView2.DataSource = DS.Tables[0];

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           try
           {
                String name = txtName.Text;
                String adress = txtAdress.Text;
                long contact = Convert.ToInt64(txtNumber.Text);
                int age = Convert.ToInt32(txtAge.Text);
                String gender = comboGender.Text;
                String blood = txtBlood.Text;
                int id = Convert.ToInt32(txtİd.Text);

                MySqlConnection con = new MySqlConnection("user id=ashraf;persistsecurityinfo=True;server=127.0.0.1;database=project;password=camry551;");
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Insert into AddPatient values('"+name+"','"+adress+"',"+contact+","+age+",'"+gender+"','"+blood+"',"+id+")";
           
                int i=cmd.ExecuteNonQuery();
         
                MessageBox.Show("Məlumat daxil edildi");
                txtName.Clear();
                txtBlood.Clear();
                txtNumber.Clear();
                txtAdress.Clear();
                txtİd.Clear();
                txtAge.Clear();
                comboGender.ResetText();

            }
            catch(Exception)
            {
                if (txtName.Text==""|| txtNumber.Text==""|| txtİd.Text==""|| comboGender.Text==""|| txtAge.Text == "" || txtBlood.Text == "" || txtAdress.Text == "") {
                    MessageBox.Show("Butun xanalari doldurun");
                }

                else {
                    MessageBox.Show("Melumatı düzgün daxil edin");
                }
            }
       
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
               int pid = Convert.ToInt32(textBox1.Text);
                MySqlConnection con = new MySqlConnection("user id=ashraf;persistsecurityinfo=True;server=127.0.0.1;database=project;password=camry551;");
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = " Select * from AddPatient where pid= " + pid + "";
                MySqlDataAdapter DA = new MySqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                int i = cmd.ExecuteNonQuery();
                dataGridView1.DataSource = DS.Tables[0];
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try {
                int pid = Convert.ToInt32(textBox1.Text);
                String sympt = txtSymptom.Text;
                String diag = txtDiagnos.Text;
                String med = txtMedicine.Text;
                String ward = comboWard.Text;
                String wardtype = comboWardtype.Text;

                MySqlConnection con = new MySqlConnection("user id=ashraf;persistsecurityinfo=True;server=127.0.0.1;database=project;password=camry551;");
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Insert into PatientMore values("+pid+",'"+sympt+"','"+diag+"','"+med+"','"+ward+"','"+wardtype+"')";
                MySqlDataAdapter DA = new MySqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
       MessageBox.Show("Məlumat daxil edildi");
                 
                int i = cmd.ExecuteNonQuery();
       

            }
            catch (Exception){
                MessageBox.Show("Məlumatı düzgün daxil edin");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar)&& !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            comboBox1.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            textBox8.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
            textBox9.Text = dataGridView2.CurrentRow.Cells[10].Value.ToString();
            comboBox2.Text = dataGridView2.CurrentRow.Cells[11].Value.ToString();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            String name = textBox2.Text;
            String adress = textBox3.Text;
            String contact = textBox4.Text;
            String age = textBox5.Text;
            String gender = comboBox1.Text;
            String blood = textBox6.Text;
            String id = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            String sympt =textBox7.Text;
            String diag = textBox8.Text;
            String med = textBox9.Text;
            String ward = comboBox2.Text;
            MessageBox.Show(id);
                MySqlConnection con = new MySqlConnection("user id=ashraf;persistsecurityinfo=True;server=127.0.0.1;database=project;password=camry551;");
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
            cmd.CommandText = "update addpatient set Name = '"+name+"' where pid ="+id+";"+
            "update addpatient set Full_Address ='" + adress + "' where pid=" + id + ";" +
           "update addpatient set Contact =" + contact + " where pid=" + id + ";" +
            "update addpatient set Age =" + age + " where pid=" + id + ";" +
            "update addpatient set Gender ='" + gender + "' where pid=" + id + ";" +
            "update addpatient set Blood_Group ='" + blood + "' where pid=" + id + ";" +
            "update patientmore set Symptoms ='" + sympt + "' where pid =" + id + ";" +
            "update patientmore set Diagnosis ='" + diag + "' where pid =" + id + ";" +
            "update patientmore set Medicines ='" + med + "' where pid =" + id + ";" +
            "update patientmore set Ward ='" + ward + "' where pid =" + id + ";";
           
            cmd.ExecuteNonQuery();

                MessageBox.Show("Məlumat daxil edildi");
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            String id = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            MySqlConnection con = new MySqlConnection("user id=ashraf;persistsecurityinfo=True;server=127.0.0.1;database=project;password=camry551;");
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from addpatient where pid = "+id+";"+
                "delete from addpatient where pid = "+id+";";

            cmd.ExecuteNonQuery();

            MessageBox.Show("Məlumat silindi");
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
    } 
}
