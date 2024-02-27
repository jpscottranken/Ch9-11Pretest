using System;
using System.Drawing;
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
    public partial class frmMatch : Form
    {
        //  Declare and initialize class variables
        string[] firstNames =
        {
            "Franklin",
            "Harry",
            "Dwight",
            "John F.",
            "Lyndon",
            "Richard",
            "Gerald",
            "Jimmy",
            "Ronald",
            "George H.W.",
            "Bill",
            "George W.",
            "Barack",
            "Donald",
            "Joe"
        };

        string[] lastNames =
        {
            "Roosevelt",
            "Truman",
            "Eisenhower",
            "Kennedy",
            "Johnson",
            "Nixon",
            "Ford",
            "Carter",
            "Reagan",
            "Bush",
            "Clinton",
            "Bush",
            "Obama",
            "Trump",
            "Biden"
        };

        string[] party =
        {
            "Democrat",
            "Democrat",
            "Republican",
            "Democrat",
            "Democrat",
            "Republican",
            "Republican",
            "Democrat",
            "Republican",
            "Republican",
            "Democrat",
            "Republican",
            "Democrat",
            "Republican",
            "Democrat"
        };

        //	NOTE: 	You will have to change the path on all of
        //			these image files to reflect your location
        //			of said images!
        string[] images =
        {
            @"C:\Users\jpscott\Desktop\Ch9-11Pretest\Ch9-11Pretest\Ch9-11Pretest\images\32-franklinroosevelt.jpg",
            @"C:\Users\jpscott\Desktop\Ch9-11Pretest\Ch9-11Pretest\Ch9-11Pretest\images\33-harrytruman.jpg",
            @"C:\Users\jpscott\Desktop\Ch9-11Pretest\Ch9-11Pretest\Ch9-11Pretest\images\34-dwighteisenhower.jpg",
            @"C:\Users\jpscott\Desktop\Ch9-11Pretest\Ch9-11Pretest\Ch9-11Pretest\images\35-johnkennedy.jpg",
            @"C:\Users\jpscott\Desktop\Ch9-11Pretest\Ch9-11Pretest\Ch9-11Pretest\images\36-lyndonjohnson.jpg",
            @"C:\Users\jpscott\Desktop\Ch9-11Pretest\Ch9-11Pretest\Ch9-11Pretest\images\37-richardnixon.jpg",
            @"C:\Users\jpscott\Desktop\Ch9-11Pretest\Ch9-11Pretest\Ch9-11Pretest\images\38-geraldford.jpg",
            @"C:\Users\jpscott\Desktop\Ch9-11Pretest\Ch9-11Pretest\Ch9-11Pretest\images\39-jimmycarter.jpg",
            @"C:\Users\jpscott\Desktop\Ch9-11Pretest\Ch9-11Pretest\Ch9-11Pretest\images\40-ronaldreagan.jpg",
            @"C:\Users\jpscott\Desktop\Ch9-11Pretest\Ch9-11Pretest\Ch9-11Pretest\images\41-georgehwbush.jpg",
            @"C:\Users\jpscott\Desktop\Ch9-11Pretest\Ch9-11Pretest\Ch9-11Pretest\images\42-billclinton.jpg",
            @"C:\Users\jpscott\Desktop\Ch9-11Pretest\Ch9-11Pretest\Ch9-11Pretest\images\43-georgewwbush.jpg",
            @"C:\Users\jpscott\Desktop\Ch9-11Pretest\Ch9-11Pretest\Ch9-11Pretest\images\44-barackobama.jpg",
            @"C:\Users\jpscott\Desktop\Ch9-11Pretest\Ch9-11Pretest\Ch9-11Pretest\images\45-donaldtrump.jpg",
            @"C:\Users\jpscott\Desktop\Ch9-11Pretest\Ch9-11Pretest\Ch9-11Pretest\images\46-joebiden.jpg"
        };

        //	NOTE: 	Same with this image file.
        string noImageAvailable = @"C:\Users\jpscott\Desktop\Ch9-11Pretest\Ch9-11Pretest\Ch9-11Pretest\images\00-nia.jpg";

        public frmMatch()
        {
            InitializeComponent();
        }

        private void frmMatch_Load(object sender, EventArgs e)
        {
            //  Populate first name dropdown list
            for (int lcv = 0; lcv < firstNames.Length; ++lcv)
            {
                ddlFirstName.Items.Add(firstNames[lcv]);
            }

            //  Populate last name dropdown list
            for (int lcv = 0; lcv < lastNames.Length; ++lcv)
            {
                ddlLastName.Items.Add(lastNames[lcv]);
            }
        }

        private void btnMatch_Click(object sender, EventArgs e)
        {
            bool keepGoing = CheckForNoFirstNameChosen();

            //  If keepGoing is true, there WAS a value
            //  chosen in the firstName dropdown list.
            //  So, check to see if there WAS a value
            //  chosen in the lastName dropdown list.
            if (keepGoing)
            {
                CheckForNoLastNameChosen();
            }
            else
            {
                return;
            }

            //  If we get here, there was BOTH a first
            //  name selected AND a last name selected.
            //  So, check for a first name/last name
            //  match.
            if (keepGoing)
            {
                CheckForMatch();
            }
        }

        private bool CheckForNoFirstNameChosen()
        {
            bool retVal = true;

            if (ddlFirstName.SelectedIndex < 0)
            {
                ShowMessage("No First Name Selected!",
                            "NO FIRST NAME");
                retVal = false;
            }

            return retVal;
        }

        private bool CheckForNoLastNameChosen()
        {
            bool retVal = true;

            if (ddlLastName.SelectedIndex < 0)
            {
                ShowMessage("No Last Name Selected!",
                            "NO LAST NAME");
                retVal = false;
            }

            return retVal;
        }

        private void CheckForMatch()
        {
            //  If both dropdown lists are referencing
            //  the same array element location, there
            //  was a match.
            if (ddlFirstName.SelectedIndex == ddlLastName.SelectedIndex)
            {
                //  If this is the case, fill the Picture
                //  with the correct image.
                pbPresidentImage.Image = Image.FromFile
                    (images[ddlFirstName.SelectedIndex]);

                //  Set the appropriate politcal party for
                //  the selected President.
                string polParty = party[ddlLastName.SelectedIndex];
                switch(polParty)
                {
                    case "Democrat":
                        rbDemocrat.Checked = true;
                        break;

                    case "Republican":
                        rbRepublican.Checked = true;
                        break;

                    case "Independent":
                        rbIndependent.Checked = true;
                        break;

                    default:
                        break;
                }
            }
            //  There was NOT a match.
            else
            {
                pbPresidentImage.Image = Image.FromFile
                    (noImageAvailable);

                //  Clear out all radio buttons
                ClearRadioButtons();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            ClearDropDownLists();
            ClearImage();
            ClearRadioButtons();
        }

        private void ClearDropDownLists()
        {
            ddlFirstName.SelectedIndex = -1;
            ddlLastName.SelectedIndex = -1;
        }

        private void ClearImage()
        {
            pbPresidentImage.Image = null;
        }

        private void ClearRadioButtons()
        {
            rbDemocrat.Checked = false;
            rbRepublican.Checked = false;
            rbIndependent.Checked = false;
        }

        private void btnMainForm_Click(object sender, EventArgs e)
        {
            //  Hide the current form (frmMatch).
            this.Hide();

            //  Instantiate (create) a new Main form
            frmMain main = new frmMain();

            //  Show the Play The Game Form
            main.ShowDialog();
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
