using System;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            Button myButton = new Button();
            myButton.Text = "Click Me!";
            myButton.Location = new System.Drawing.Point(50, 50);
            myButton.Click += MyButton_Click;
            this.Controls.Add(myButton);
        }

        private void MyButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button Clicked!");
        }
    }
}
