using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class AddMembership : Form
    {
        MembershipList membership = new MembershipList();
        string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "file.txt");
        public delegate void addMemberListener(Member e);
        public event addMemberListener newMember;

        public virtual void OnMemberAdd(Member e)
        {
            newMember?.Invoke(e);
        }

        public AddMembership()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (ValidateEmail.EmailIsValid(this.emailTextBox.Text))
            {
                OnMemberAdd(new Member(this.firstNameTextBox.Text, this.lastNameTextBox.Text, this.emailTextBox.Text));
                this.Close();
            } else
            {
                MessageBox.Show("Invalid email!");
            }
               
            
        }

        private void AddMembership_Load(object sender, EventArgs e)
        {
            membership.write(path);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
