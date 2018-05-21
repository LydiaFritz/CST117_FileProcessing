using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileProcessingStatistics
{
    public partial class Form1 : Form
    {
        private System.IO.StreamReader sr;

        public Form1( )
        {
            InitializeComponent( );
        }

        private void button1_Click( object sender, EventArgs e )
        {
            this.richTextBox1.Text = "";
            if (openFileDialog1.ShowDialog( ) == System.Windows.Forms.DialogResult.OK)
            {
                sr = new System.IO.StreamReader( openFileDialog1.FileName );
                processFile( );
                sr.Close( );
            }
        }

        private void processFile( )
        {
            /*
             Converts all the words to lower-case
             Finds the first and last word alphabetically
             Finds the longest word
             Finds the word with the most vowels */
            string firstAlpha = "", lastAlpha = "", longestWord = "";
            while (!sr.EndOfStream)
            {

                string str = sr.ReadLine( );
                string[] words = str.Split( );

                foreach (string s in words)
                {
                    if (s.Length > 0)
                    {
                        ///this.richTextBox1.Text += s.ToLower( ) + "\n";
                        string sCopy = s.ToLower( );
                        if (firstAlpha == "")
                            firstAlpha = sCopy;
                        if (lastAlpha == "")
                            lastAlpha = sCopy;
                        if (longestWord == "")
                            longestWord = sCopy;

                        if (s.CompareTo( firstAlpha ) < 0)
                            firstAlpha = sCopy;
                        if (s.CompareTo( lastAlpha ) > 0)
                            lastAlpha = sCopy;
                        if (s.Length > longestWord.Length)
                            longestWord = sCopy;


                    }
                }
            }

            //write this info to a file as well

            this.richTextBox1.Text += "First alphabetic: " + firstAlpha +
                  "\nLast alphabetic: " + lastAlpha +
                  "\nLongest word: " + longestWord + "\n";

           
            System.IO.File.WriteAllText( "outFile.out", richTextBox1.Text );
        }

        private void button2_Click( object sender, EventArgs e )
        {
            this.Close( );
        }
    }
}
