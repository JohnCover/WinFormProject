using System;
using System.IO;
using System.Windows.Forms;

namespace Lab2
{
    

    public partial class MembershipMaintenance : Form
    {

        MembershipList membership = new MembershipList();
        string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "file.txt");

        

        public MembershipMaintenance()
        {
            InitializeComponent();
        }

        private void ListChanged(MembershipList e)
        {
            //update list box
            this.members.Items.Clear();
            for (int i = 0; i < e.Count; i++)
            {
                this.members.Items.Add(e[i].getDisplayText());
            }
            //save
            e.save(path);
        }

        private void memberAdded(Member e)
        {
            membership = membership + e;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = members.SelectedIndex;
            var confirmResult = MessageBox.Show("Are you sure to delete " + membership[index].getDisplayText(),
                                                 "Confirm Delete!!",
                                                 MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
                membership = membership - membership[index];

        }

        private void members_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddMembership addWindow = new AddMembership();
            addWindow.newMember += new AddMembership.addMemberListener(memberAdded);
            addWindow.ShowDialog();
        }

        private void MembershipMaintenance_Load(object sender, EventArgs e)
        {
            membership.write(path);
            //wire event normally:
            //membership.Changed += new MembershipList.changeHolder(ListChanged);
            //wire event using lambda expression:
            membership.Changed += membershiplist =>
            {
                //update list box
                this.members.Items.Clear();
                for (int i = 0; i < membershiplist.Count; i++)
                {
                    this.members.Items.Add(membershiplist[i].getDisplayText());
                }
                //save
                membershiplist.save(path);
            };

            //initialize list box
            for (int i = 0; i < membership.Count; i++)
            {
                this.members.Items.Add(membership[i].getDisplayText());
            }

            //this.members.Items.AddRange();
        }
    }
}
