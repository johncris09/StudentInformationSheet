using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;
 

using System.Threading; 

namespace Student
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Via Marie\Downloads\PIT_MANABO\Student\Student\Student.accdb");
        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SelectAll();

            for (int age = 1; age <= 50; age++ )
            {
                comboAge.Items.Add(age);


            }


            IDGenerator();
            
        }
        public void IDGenerator() {
            int rowindex = dataGridViewStudent.Rows.Count - 2;
            DataGridViewRow row = dataGridViewStudent.Rows[rowindex];
            int val = Convert.ToInt32(row.Cells["Student_ID"].Value);
            student_IDTextBox.Text = Convert.ToString(val + 1);
        }
        public void SelectAll() {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Student";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewStudent.DataSource = dt;
            con.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into Student (Student_Id, Last_Name, First_Name, Middle_Name, Sex, Age, Mailing_Address,Mailing_Address_Phone_Number, City, City_Phone_Number,Citizenship,Religion,BirthDate ,BirthPlace,Status,Guardians_Name,Guardians_Phone_Number,Parents_Name,Parents_Phone_Number,Street,Barangay,City_Address,Province, School_Name_In_Elementary,Date_Graduated_in_Elementary, School_Name_In_Secondary,Date_Graduated_In_Secondary,School_Name_In_College, Date_Graduated_In_College, School_Name_In_College_Course_Taken, Date_Graduated_In_Course_Taken, SchoolName_1, CourseEnrolled_1, Semester1,SchoolName2,CourseEnrolled2,Semester2,SchoolName3,CourseEnrolled3,Semester3,OrganizationName1,PositionHeld1,Term1,OrganizationName2,PositionHeld2,Term2,OrganizationName3,PositionHeld3,Term3, ActivityTItle1,Sponsor1,InclusiveDate1,ActivityTitle2,Sponsor2,InclusiveDate2,ActivityTitle3,Sponsor3,InclusiveDate3) values('" + student_IDTextBox.Text + "','" + Last_NameTextBox.Text + "','" + first_NameTextBox.Text + "','" + middle_NameTextBox.Text + "','" + comboSex.Text + "'," + comboAge.Text + ",'" + mailing_AddressTextBox.Text + "','" + mailing_Address_Phone_NumberTextBox.Text + "','" + cityTextBox.Text + "','" + city_Phone_NumberTextBox.Text + "','" + citizenshipTextBox.Text + "','" + religionTextBox.Text + "','" + birthDateDateTimePicker.Text + "','" + birthPlaceTextBox.Text + "','" + comboStatus.Text + "','" + guardians_NameTextBox.Text + "','" + guardians_Phone_NumberTextBox.Text + "','" + parents_NameTextBox.Text + "','" + parents_Phone_NumberTextBox.Text + "','" + streetTextBox.Text + "' ,'" + barangayTextBox.Text + "','" + city_AddressTextBox.Text + "','" + provinceTextBox.Text + "' ,'" + school_Name_In_ElementaryTextBox.Text + "' ,'" + date_Graduated_in_ElementaryDateTimePicker.Text + "','" + school_Name_In_SecondaryTextBox.Text + "' ,'" + date_Graduated_In_SecondaryDateTimePicker.Text + "'  ,'" + school_Name_In_CollegeTextBox.Text + "','" + date_Graduated_In_CollegeDateTimePicker.Text + "' ,'" + school_Name_In_College_Course_TakenTextBox.Text + "' ,'" + date_Graduated_In_Course_TakenDateTimePicker.Text + "','" + schoolName_1TextBox.Text + "' ,'" + courseEnrolled_1TextBox.Text + "','" + semester1TextBox.Text + "','" + schoolName2TextBox.Text + "','" + courseEnrolled2TextBox.Text + "','" + semester2TextBox.Text + "','" + schoolName3TextBox.Text + "','" + courseEnrolled3TextBox.Text + "','" + semester3TextBox.Text + "','" + organizationName1TextBox.Text + "','" + positionHeld1TextBox.Text + "','" + term1TextBox.Text + "','" + organizationName2TextBox.Text + "','" + positionHeld2TextBox.Text + "','" + term2TextBox.Text + "','" + organizationName3TextBox.Text + "' ,'" + positionHeld3TextBox.Text + "','" + term3TextBox.Text + "','" + activityTItle1TextBox.Text + "','" + sponsor1TextBox.Text + "','" + inclusiveDate1DateTimePicker.Text + "','" + activityTitle2TextBox.Text + "','" + sponsor2TextBox + "' ,'" + inclusiveDate2DateTimePicker.Text + "' ,'" + activityTitle3TextBox.Text + "','" + sponsor3TextBox.Text + "','" + inclusiveDate3DateTimePicker.Text + "')"; //,'" + ____ + "'
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted Successfully", "Student Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            SelectAll();
            IDGenerator();
            ClearAll();

        }

        public void ClearAll()
        {
            
            Last_NameTextBox.Text = "";
            first_NameTextBox.Text = "";
            middle_NameTextBox.Text = "";
            comboSex.Text = ""; 
            comboAge.Text = "";
            mailing_AddressTextBox.Text = ""; 
            mailing_Address_Phone_NumberTextBox.Text = ""; 
            cityTextBox.Text = "";
            city_Phone_NumberTextBox.Text = "";
            citizenshipTextBox.Text = ""; 
            religionTextBox.Text = ""; 
            birthDateDateTimePicker.Text = ""; 
            birthPlaceTextBox.Text = "";
            comboStatus.Text = "";
            guardians_NameTextBox.Text = ""; 
            guardians_Phone_NumberTextBox.Text = "";
            parents_NameTextBox.Text = ""; parents_Phone_NumberTextBox.Text = "";
            streetTextBox.Text = "";
            barangayTextBox.Text = "";
            city_AddressTextBox.Text = ""; 
            provinceTextBox.Text = ""; 
            school_Name_In_ElementaryTextBox.Text = ""; 
            date_Graduated_in_ElementaryDateTimePicker.Text = "";
            school_Name_In_SecondaryTextBox.Text = ""; 
            date_Graduated_In_SecondaryDateTimePicker.Text = "";
            school_Name_In_CollegeTextBox.Text = ""; 
            date_Graduated_In_CollegeDateTimePicker.Text = "";
            school_Name_In_College_Course_TakenTextBox.Text = ""; 
            date_Graduated_In_Course_TakenDateTimePicker.Text = "";
            schoolName_1TextBox.Text = "";
            courseEnrolled_1TextBox.Text = "";
            semester1TextBox.Text = ""; 
            schoolName2TextBox.Text = ""; 
            courseEnrolled2TextBox.Text = "";
            semester2TextBox.Text = ""; 
            schoolName3TextBox.Text = ""; 
            courseEnrolled3TextBox.Text = ""; 
            semester3TextBox.Text = "";
            organizationName1TextBox.Text = "";
            positionHeld1TextBox.Text = "";
            term1TextBox.Text = "";
            organizationName2TextBox.Text = ""; 
            positionHeld2TextBox.Text = ""; term2TextBox.Text = ""; 
            organizationName3TextBox.Text = ""; 
            positionHeld3TextBox.Text = "";
            term3TextBox.Text = ""; 
            activityTItle1TextBox.Text = "";
            sponsor1TextBox.Text = ""; 
            inclusiveDate1DateTimePicker.Text = ""; 
            activityTitle2TextBox.Text = ""; 
            sponsor2TextBox.Text = ""; 
            inclusiveDate2DateTimePicker.Text = ""; 
            activityTitle3TextBox.Text = ""; sponsor3TextBox.Text = ""; 
            inclusiveDate3DateTimePicker.Text = "";
        
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Student where Student_ID=" + getStudentID();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Dnsedeletedrted Successfully", "Student Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            SelectAll();
        }

        public int getStudentID() {
            int rowindex = dataGridViewStudent.CurrentRow.Index;
            DataGridViewRow row = dataGridViewStudent.Rows[rowindex];
            int Student_ID = Convert.ToInt32(row.Cells["Student_ID"].Value);
            return Student_ID;
        }


        //Edit
        private void button2_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridViewStudent.CurrentRow.Index;
            DataGridViewRow row = dataGridViewStudent.Rows[rowindex];




            student_IDTextBox.Text = Convert.ToString(row.Cells["Student_ID"].Value);
            Last_NameTextBox.Text = Convert.ToString(row.Cells["Last_Name"].Value);
            first_NameTextBox.Text = Convert.ToString(row.Cells["First_Name"].Value);
            middle_NameTextBox.Text = Convert.ToString(row.Cells["Middle_Name"].Value);
            comboSex.Text = Convert.ToString(row.Cells["Sex"].Value);
            comboAge.Text = Convert.ToString(row.Cells["Age"].Value);
            mailing_AddressTextBox.Text = Convert.ToString(row.Cells["Mailing_Address"].Value);
            mailing_Address_Phone_NumberTextBox.Text = Convert.ToString(row.Cells["Mailing_Address_Phone_Number"].Value);
            cityTextBox.Text = Convert.ToString(row.Cells["City"].Value);
            city_Phone_NumberTextBox.Text = Convert.ToString(row.Cells["City_Phone_Number"].Value);
            citizenshipTextBox.Text = Convert.ToString(row.Cells["Citizenship"].Value);
            religionTextBox.Text = Convert.ToString(row.Cells["Religion"].Value);
            birthDateDateTimePicker.Value = Convert.ToDateTime(row.Cells["BirthDate"].Value);
            birthPlaceTextBox.Text = Convert.ToString(row.Cells["BirthPlace"].Value);
            comboStatus.Text = Convert.ToString(row.Cells["Status"].Value);
            guardians_NameTextBox.Text = Convert.ToString(row.Cells["Guardians_Name"].Value);
            guardians_Phone_NumberTextBox.Text = Convert.ToString(row.Cells["Guardians_Phone_Number"].Value);
            parents_NameTextBox.Text = Convert.ToString(row.Cells["Parents_Name"].Value);
            parents_Phone_NumberTextBox.Text = Convert.ToString(row.Cells["Parents_Phone_Number"].Value);
            streetTextBox.Text = Convert.ToString(row.Cells["Street"].Value);
            barangayTextBox.Text = Convert.ToString(row.Cells["Barangay"].Value);
            city_AddressTextBox.Text = Convert.ToString(row.Cells["City_Address"].Value);
            provinceTextBox.Text = Convert.ToString(row.Cells["Province"].Value);
            school_Name_In_ElementaryTextBox.Text = Convert.ToString(row.Cells["School_Name_In_Elementary"].Value);
            date_Graduated_in_ElementaryDateTimePicker.Value = Convert.ToDateTime(row.Cells["Date_Graduated_in_Elementary"].Value);
            school_Name_In_SecondaryTextBox.Text = Convert.ToString(row.Cells["School_Name_In_Secondary"].Value);
            date_Graduated_In_SecondaryDateTimePicker.Value = Convert.ToDateTime(row.Cells["Date_Graduated_In_Secondary"].Value);
            school_Name_In_CollegeTextBox.Text = Convert.ToString(row.Cells["School_Name_In_College"].Value);
            date_Graduated_In_CollegeDateTimePicker.Value = Convert.ToDateTime(row.Cells["Date_Graduated_In_College"].Value);
            school_Name_In_College_Course_TakenTextBox.Text = Convert.ToString(row.Cells["School_Name_In_College_Course_Taken"].Value);
            date_Graduated_In_Course_TakenDateTimePicker.Value = Convert.ToDateTime(row.Cells["Date_Graduated_In_Course_Taken"].Value);
            schoolName_1TextBox.Text = Convert.ToString(row.Cells["SchoolName_1"].Value);
            courseEnrolled_1TextBox.Text = Convert.ToString(row.Cells["CourseEnrolled_1"].Value);
            semester1TextBox.Text = Convert.ToString(row.Cells["Semester1"].Value);
            schoolName2TextBox.Text = Convert.ToString(row.Cells["SchoolName2"].Value);
            courseEnrolled2TextBox.Text = Convert.ToString(row.Cells["CourseEnrolled2"].Value);
            semester2TextBox.Text = Convert.ToString(row.Cells["Semester2"].Value);
            schoolName3TextBox.Text = Convert.ToString(row.Cells["SchoolName3"].Value);
            courseEnrolled3TextBox.Text = Convert.ToString(row.Cells["CourseEnrolled3"].Value);
            semester3TextBox.Text = Convert.ToString(row.Cells["Semester3"].Value);
            organizationName1TextBox.Text = Convert.ToString(row.Cells["OrganizationName1"].Value);
            positionHeld1TextBox.Text = Convert.ToString(row.Cells["PositionHeld1"].Value);
            term1TextBox.Text = Convert.ToString(row.Cells["Term1"].Value);
            organizationName2TextBox.Text = Convert.ToString(row.Cells["OrganizationName2"].Value);
            positionHeld2TextBox.Text = Convert.ToString(row.Cells["PositionHeld2"].Value);
            term2TextBox.Text = Convert.ToString(row.Cells["Term2"].Value);
            organizationName3TextBox.Text = Convert.ToString(row.Cells["OrganizationName3"].Value);
            positionHeld3TextBox.Text = Convert.ToString(row.Cells["PositionHeld3"].Value);
            term3TextBox.Text = Convert.ToString(row.Cells["Term3"].Value);
            activityTItle1TextBox.Text = Convert.ToString(row.Cells["ActivityTItle1"].Value);
            sponsor1TextBox.Text = Convert.ToString(row.Cells["Sponsor1"].Value);
            inclusiveDate1DateTimePicker.Value = Convert.ToDateTime(row.Cells["InclusiveDate1"].Value);
            activityTitle2TextBox.Text = Convert.ToString(row.Cells["ActivityTitle2"].Value);
            sponsor2TextBox.Text = Convert.ToString(row.Cells["Sponsor2"].Value);
            inclusiveDate2DateTimePicker.Value = Convert.ToDateTime(row.Cells["InclusiveDate2"].Value);
            activityTitle3TextBox.Text = Convert.ToString(row.Cells["ActivityTitle3"].Value);
            sponsor3TextBox.Text = Convert.ToString(row.Cells["Sponsor3"].Value);
            inclusiveDate3DateTimePicker.Value = Convert.ToDateTime(row.Cells["InclusiveDate3"].Value);
            

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //int count = 0;
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Student where Last_Name like '%" + textBox1.Text + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            //count = Convert.ToInt32(dt.Rows.Count.ToString());
            dataGridViewStudent.DataSource = dt;
            con.Close();
            /*
            if (count == 0)
            {
                MessageBox.Show("reocrd not found");
            }
             */
        }


    }
}
