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

            birthDateDateTimePicker.Value = Convert.ToDateTime(row.Cells["BirthDate"].Value);

            
        }


    }
}
