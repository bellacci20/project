using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class MainForm : Form
    {
        StudentClass student = new StudentClass();
        public MainForm()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            studentCount();
        }

        //displays student count
        private void studentCount ()
        {
            label_totalStd.Text = "Total Students: " + student.totalStudent();
            label_maleStd.Text = "Male: " + student.maleStudent();
            label_female_Std.Text = "Female: " + student.femaleStudent();
        }

        private void customizeDesign()
        {
            panel_stdsubmenu.Visible = false;
            panel_crssubmenu.Visible = false;
            panel_scrsubmenu.Visible = false;   
        }

        private void hideSubmenu()
        {
            if (panel_stdsubmenu.Visible == true)
                panel_stdsubmenu.Visible = false;
            if (panel_crssubmenu.Visible == true)
                panel_crssubmenu.Visible = false;
            if (panel_scrsubmenu.Visible == true)
                panel_scrsubmenu.Visible = false;
        }

        private void showSubmenu (Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;    
        }

        private void button_std_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_stdsubmenu);
        }

        #region StdSubmenu

        private void button_stdreg_Click(object sender, EventArgs e)
        {
            openChildForm(new RegisterForm());
            //
            hideSubmenu();
        }

        private void button_mngstd_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageStudentForm()); 
            //
            hideSubmenu();
        }

        private void button_statstd_Click(object sender, EventArgs e)
        {
            //
            hideSubmenu();
        }

        private void button_prntstd_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintStudent());
            
            //
            hideSubmenu();
        }
        #endregion StdSubmenu
        private void button_crs_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_crssubmenu);
        }
        #region CourseSubmenu
        private void button_newcrs_Click(object sender, EventArgs e)
        {
            openChildForm(new CourseForm());
            //
            hideSubmenu();
        }

        private void button_managecrs_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageCourseForm());
            //
            hideSubmenu();
        }
        private void button_prntcrs_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintCourseForm());
            //
            hideSubmenu();
        }
        #endregion CourseSubmenu
        private void button_scr_Click(object sender, EventArgs e)
        {
            
            showSubmenu(panel_scrsubmenu);
        }
        #region ScoreSubmenu
        private void button_newscr_Click(object sender, EventArgs e)
        {
            openChildForm(new ScoreForm());
            //
            hideSubmenu();
        }

        private void button_managescr_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageScoreForm());
            //

            hideSubmenu();
        }

        private void button_prntscr_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintCourseForm());
            hideSubmenu();
        }
        #endregion ScoreSubmenu

        //below shows register form in mainform
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm; 
            childForm.BringToFront();
            childForm.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button_ext_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            this.Hide();
            login.Show();
        }
        
    }
}
