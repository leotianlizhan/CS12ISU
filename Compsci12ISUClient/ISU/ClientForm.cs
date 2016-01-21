/*
Tianli Zhan
Jan 13, 2016
Form of the client, handles everything related to display
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ISU
{
    public partial class ClientForm : Form
    {
        //stores a client model wrapper
        private ClientModelWrapper _client = new ClientModelWrapper();
        //stores the club currently being managed
        private Club _focusClub;

        public ClientForm()
        {
            InitializeComponent();
            //update data on startup
            UpdateData();
        }

        /// <summary>
        /// Refresh for 10 newest posts, and update the list of clubs and information
        /// </summary>
        private void UpdateData()
        {
            //update clubs, if failed, display a fail message and exit the subprogram
            if (!_client.UpdateClubs())
            {
                MessageBox.Show("Update clubs failed, possibly due to incorrect server location in config.txt\r\n" + DateTime.Now.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //clear the items in the filter checkedlistbox and clublist listbox
            clstFilter.Items.Clear();
            lstClubList.Items.Clear();
            //load the filter and clublist controls with possibly new or updated clubs
            for (int i = 0; i < _client.ClubList.Count; i++)
            {
                clstFilter.Items.Add(_client.ClubList[i].Name);
                lstClubList.Items.Add(_client.ClubList[i].Name);
            }

            //update new posts, if failed, display a fail message, and exit the subprogram
            if (!_client.UpdatePosts(10))
            {
                MessageBox.Show("Update posts failed, possibly due to incorrect server location in config.txt\r\n" + DateTime.Now.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //clear the listbox
            lstThreads.Items.Clear();
            //load the listbox with new, updated posts
            for (int i = 0; i < _client.PostList.Count; i++)
            {
                //add the post to the listbox with the club name for ease of use
                lstThreads.Items.Add("[" + _client.FindClub(_client.PostList[i].ID).Name + "]\r\n" + _client.PostList[i].Content.Replace(@"\r\n", Environment.NewLine));
            }
            //set all the clubs to checked in the filter
            for (int i=0; i<clstFilter.Items.Count; i++)
            {
                clstFilter.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void lstClubList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowClubInfo(lstClubList.SelectedIndex);
        }

        //Shows the club information interface, pass in the index of the club selected
        private void ShowClubInfo(int index)
        {
            //prevent it from accessing negative index
            if(index>=0)
            {
                //show the club information panel
                pnlClubInfo.Visible = true;
                //stores the temporary club to be accessed
                Club club = _client.ClubList[index];
                //change the club information labels to the corresponding club's information
                lblClubName.Text = club.Name;
                lblLocation.Text = "Location: " + club.Location;
                lblSupervisor.Text = "Supervisor: " + club.Supervisor;
                txtDescription.Text = club.Description;
            }
        }

        private void btnReturnToClubList_Click(object sender, EventArgs e)
        {
            pnlClubInfo.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //check if the login is successful
            if(_client.Login(txtUsername.Text, txtPassword.Text))
            {
                //hide the login interface
                pnlLogin.Visible = false;
                //clear the clubmanagelist listbox
                lstClubManageList.Items.Clear();
                //fill the clubmanagelist listbox with clubs that this admin can manage
                foreach(Club manageableClub in _client.Admin.AdminClubList)
                {
                    lstClubManageList.Items.Add(manageableClub.Name);
                }
            }
            else
            {
                //show error
                MessageBox.Show("Request to login failed. Possibly due to incorrect admin credentials or incorrect path of server in config.txt.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstClubManageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPublishPostPanel(lstClubManageList.SelectedIndex);
        }

        //show the publish post interface, pass in the index of the club selected
        private void ShowPublishPostPanel(int index)
        {
            //prevent it from accessing negative index
            if (index >= 0)
            {
                //stores the club currently being managed
                _focusClub = _client.Admin.AdminClubList[index];
                //make the publish post panel visible
                pnlPublishPost.Visible = true;
                //change the name of the title according to the club
                lblPublishClubName.Text = _focusClub.Name;
                //change the text of the club's info's editing textboxes, just in case he decided to edit
                txtEditClubName.Text = _focusClub.Name;
                txtEditLocation.Text = _focusClub.Location;
                txtEditSupervisor.Text = _focusClub.Supervisor;
                txtEditDescription.Text = _focusClub.Description;
            }
        }

        private void btnReturnToAdminClubList_Click(object sender, EventArgs e)
        {
            txtNewPost.Text = "";
            pnlPublishPost.Visible = false;
        }

        private void btnReturnFromEditClubInfo_Click(object sender, EventArgs e)
        {
            pnlEditClubInfo.Visible = false;
            pnlPublishPost.Visible = true;
        }

        private void btnEditClubInfo_Click(object sender, EventArgs e)
        {
            pnlEditClubInfo.Visible = true;
            pnlPublishPost.Visible = false;
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            //check if the post is blank
            if(txtNewPost.Text == "")
            {
                //cannot publish blank posts
                MessageBox.Show("Cannot publish blank post", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //publish the post, but if it's unsuccessful
            if (!_client.PublishPost(_focusClub.ID, txtNewPost.Text))
            {
                //show error
                MessageBox.Show("Request to publish new post failed. Possibly due to incorrect path of server in config.txt.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Request sent successfully");
                //reset the new post textbox
                txtNewPost.Text = "";
            }
        }

        private void btnSubmitChanges_Click(object sender, EventArgs e)
        {
            //check if changes are submitted successfully
            if (_client.SubmitChanges(_focusClub.ID, txtEditClubName.Text, txtEditLocation.Text, txtEditSupervisor.Text, txtEditDescription.Text))
            {
                MessageBox.Show("Request submitted successfully");
            }
            else
            {
                //show error if it failed
                MessageBox.Show("Request to submit changes failed. Possibly due to incorrect path of server in config.txt.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            pnlLogin.Visible = true;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            //stores the list of clubs to filter
            List<Club> filter = new List<Club>();
            //fill the filter up with what the user checked
            for (int i = 0; i < clstFilter.Items.Count; i++)
            {
                //check if the filter for this club is checked
                if (clstFilter.GetItemCheckState(i) == CheckState.Checked)
                {
                    //if it is add it to the filter
                    filter.Add(_client.ClubList[i]);
                }
            }
            //stores the resultant posts from the filter
            List<Post> result = new List<Post>();
            result = _client.Filter(filter);
            //clear the listbox
            lstThreads.Items.Clear();
            //loop through each resultant post
            for (int i = 0; i < result.Count; i++)
            {
                //add the post to the listbox
                lstThreads.Items.Add("[" + _client.FindClub(result[i].ID).Name + "]\r\n" + result[i].Content.Replace(@"\r\n", Environment.NewLine));
            }
        }
    }
}
