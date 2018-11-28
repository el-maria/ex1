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

namespace ex1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(textBoxSource.Text))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    // Console.WriteLine(line);

                    //find the size of the source file
                    long fileSize = sr.Length;
                    Console.WriteLine("The size of the source file is " + fileSize);


                    string fileDestination = textBoxDestination.Text;
                    if (File.Exists(fileDestination))
                    {
                    // This text is always added, making the file longer over time
                    
                        string appendText = line + Environment.NewLine;
                        File.AppendAllText(textBoxDestination.Text, appendText);
                    }
                    else
                    {
                        //the file doesn't exist
                        Console.WriteLine("The file does not exist");
                        //we need to create first the file and then write 
                        // Create a file to write to.
                        string createText = line + Environment.NewLine;
                        File.WriteAllText(textBoxDestination.Text, createText);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
