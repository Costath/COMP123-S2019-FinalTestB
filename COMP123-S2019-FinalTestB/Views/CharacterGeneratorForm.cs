using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

/*
 * STUDENT NAME: Thales Costa
 * sTUDENT ID: 301035028
 * DESCRIPTION: This is Character Generator Form - The Main Form of the application
 *              Used for Inventory Management
 */

namespace COMP123_S2019_FinalTestB.Views
{
    public partial class CharacterGeneratorForm : MasterForm
    {
        public static List<string> FirstNameList;
        public static List<string> LastNameList;

        public CharacterGeneratorForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This is the event hadler for the BackButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex != 0)
            {
                MainTabControl.SelectedIndex--;
            }
        }
        /// <summary>
        /// This is the event hadler for the NextButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex < MainTabControl.TabPages.Count - 1)
            {
                MainTabControl.SelectedIndex++;
            }
        }
        /// <summary>
        /// This is the event hadler for the exitToolStripMenuItem Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// This is the event hadler for the GenerateNamebutton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateNamebutton_Click(object sender, EventArgs e)
        {
            GenerateNames();

            Program.character.FirstName = FirstNameDataLabel.Text;
            Program.character.LastName = LastNameDataLabel.Text;

        }

        private void GenerateNames()
        {
            Random rand = new Random();
            string fName, lName;

            fName = FirstNameList[rand.Next(FirstNameList.Count - 1)];
            lName = LastNameList[rand.Next(LastNameList.Count - 1)];
            FirstNameDataLabel.Text = fName;
            LastNameDataLabel.Text = lName;
        }

        private static void LoadNames()
        {
            FirstNameList = new List<string> { };
            LastNameList = new List<string> { };

            using (StreamReader streamReader = new StreamReader("..\\..\\Data\\firstNames.txt"))
            {
                string line;

                while (streamReader.Peek() != -1)
                {
                    line = streamReader.ReadLine();
                    FirstNameList.Add(line);
                }
            }
            using (StreamReader streamReader = new StreamReader("..\\..\\Data\\lastNames.txt"))
            {
                string line;
                List<string> lastNames = new List<string> { };

                while (streamReader.Peek() != -1)
                {
                    line = streamReader.ReadLine();
                    LastNameList.Add(line);
                }
            }
        }

        /// <summary>
        /// This is the event hadler for the GenerateAbilitiesButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateAbilitiesButton_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            string strength;
            string dextery;
            string constitution;
            string intelligence;
            string wisdom;
            string charisma;
        }

        private void CharacterGeneratorForm_Load(object sender, EventArgs e)
        {
            LoadNames();
            GenerateNames();
        }
    }
}
