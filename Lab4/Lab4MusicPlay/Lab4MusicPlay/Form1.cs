using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4MusicPlay
{
    public partial class Form1 : Form
    {
        // Declare our mp3Player.
        private Mp3Player ourmp3Player;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlgOpen = new OpenFileDialog())
            {
                // We set a filter for files.
                dlgOpen.Filter = "Mp3 File|*.mp3";
                // Set a beginning folder.
                dlgOpen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                
                if (dlgOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Creating mp3Player if user open the file.
                    ourmp3Player = new Mp3Player(dlgOpen.FileName);
                    ourmp3Player.Repeat = true;
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (ourmp3Player != null)
            {
                ourmp3Player.Play();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (ourmp3Player != null)
            {
                ourmp3Player.Stop();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (ourmp3Player != null)
            {
                ourmp3Player.Close();
            }
        }
    }
}
