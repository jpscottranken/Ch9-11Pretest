using System;
using System.Windows.Forms;

/*
 *		For this pretest, you will create a new
 *		(contrived) project.
 *
 *		Create a new C# windows form app (call the
 *		solution PretestCh10-11 and call the project
 *		Presidents) to create a very simplistic
 *		2-form US Presidents matching game.
 *
 *		For this main screen, the first name and last
 *		name are each in a ComboBox (dropDownList).
 *		These are to be populated programmatically from
 *		the arrays you have been given.
 *
 *		•	If the first name and last name match, you
 *			should show the associated image and party.
 *
 *		•	If they do not match, you should show the
 *			No Image Available image. 
 *
 *		•	In addition, if you find a match, also make
 *			sure that the right radio button is checked.
 *
 *		When the Help button is clicked, the (Help) 
 *		screen appears.
 *
 *		All buttons, radioButtons, dropDownLists, etc.
 *		should be operational. Tab Order, Cancel Button,
 *		Accept Button, and Start Position should be set
 *		also.
 *
 *		For this help screen, all buttons and checkboxes
 *		should be operational.
 *
 *		When the Home button is clicked, the first (Home)
 *		screen should appear.
 *
 *		If the Exit button is clicked and the user chooses
 *		Yes to exit the program, the program should first
 *		print out any/all Follow Us On checkboxes that are
 *		checked.
 *
 *		Again, all buttons should be operational. The Tab 
 *		Order, CancelButton, AcceptButton, and StartPosition
 *		should be set, as on the Home page.
 *
 *		Try to modularize as much as possible. Have your 
 *		buttons, etc. act like drivers. Use good function,
 *		variable, and constant names.
 *
 *		Note that there is not much to this game, as the
 *		President's first and last names are already in 
 *		the correct order. That's OK.
 *
 *		Please try to set your form to look as much like 
 *		this one as possible. Remember to create an images
 *		folder and change the image paths I have set (for
 *		my machine) to your machine.
 */

namespace Ch9_11Pretest
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string outputStr = "";
            outputStr += "Choose a first name and a last name from each of the ComboBoxes.\r\n";
            outputStr += "Then click the Match button to see whether or not you are correct.\r\n\r\n";
            outputStr += "To keep the game simple, only the last 15 US Presidents are shown.";

            txtInstructions.Text = outputStr;
        }

        private void btnPlayTheGame_Click(object sender, EventArgs e)
        {
            //  Hide the current form (frmMain).
            this.Hide();

            //  Instantiate (create) a new Play The Game form
            frmMatch presidentMatch = new frmMatch();

            //  Show the Play The Game Form
            presidentMatch.ShowDialog();
        }

        private void ShowCheckBoxesSelected()
        {
            string selected = "";

            if (cbFacebook.Checked)
            {
                selected += cbFacebook.Text + " ";
            }

            if (cbInstagram.Checked)
            {
                selected += cbInstagram.Text + " ";
            }

            if (cbTwitter.Checked)
            {
                selected += cbTwitter.Text + " ";
            }

            if (selected.Trim() != "")
            {
                ShowMessage("You Current Folow Us On:\n" +
                            selected, "SOCIAL MEDIA PRSENCE");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitProgramOrNot();
        }

        private void ExitProgramOrNot()
        {
            DialogResult dialog = MessageBox.Show(
                        "Do You Really Want To Exit The Program?",
                        "EXIT NOW?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                ShowCheckBoxesSelected();
                Application.Exit();
            }
        }

        private void ShowMessage(string msg, string title)
        {
            MessageBox.Show(msg, title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }
}
