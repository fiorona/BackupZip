using System;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Button myButton1 = new CustomButton("A","CIAO",300,400, 50, 50);
            myButton1.Click += MyButton_Click;
            this.Controls.Add(myButton1);

        }

        private void MyButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            MessageBox.Show(button.Name + " Clicked!");
        }
    }
}
