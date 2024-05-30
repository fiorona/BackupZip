using System;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        TextBox field1=null;
        public Form1()
        {
            InitializeComponent();

            Button myButton1 = new CustomButton("OpenCOM","Open COM",100,50, 0, 0, 0);
            myButton1.Click += MyButton_Click;
            this.Controls.Add(myButton1);

            Button myButton2 = new CustomButton("CloseCOM","Close COM",100,50, 100, 0, 1);
            myButton2.Click += MyButton_Click;
            this.Controls.Add(myButton2);

            Button myButton3 = new CustomButton("Exit","Exit",100,50, 200, 0, 2);
            myButton3.Click += MyButton_Click;
            this.Controls.Add(myButton3);

            Button myButton4 = new CustomButton("TX","TX",100,50, 300, 0, 3);
            myButton4.Click += MyButton_Click;
            this.Controls.Add(myButton4);

            Label label1 = new Label()
            {
                Text = "&RX value",
                Location = new Point(0, 200),
                TabIndex = 4
            };
            field1 = new TextBox()
            {
                Location = new Point(label1.Location.X, label1.Bounds.Bottom + Padding.Top),
                TabIndex = 5
            };
            this.Controls.Add(label1);
            this.Controls.Add(field1);

        }

        private void MyButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            switch(button.Name)
            {
                case "OpenCOM": MessageBox.Show(button.Name + " - " + Program.InitSerialPort("COM6"));
                                
                    break;

                case "CloseCOM": MessageBox.Show(button.Name + " Clicked!");
                    break;

                case "TX": //MessageBox.Show(button.Name + " - " + Program.TxSerialPort("a"));
                            Program.TxSerialPort("a");
                    break;    

                case "Exit": Application.Exit();
                    break;             

                default:
                    break;    
            }
            
        }
        
         // Public property to access the TextBox
        public TextBox MainTextBox
        {
            get { return field1; }
        }
        // Optional: Public method to access the TextBox
        public string GetTextBoxText()
        {
            return field1.Text;
        }
        public void SetTextBoxText(string text)
        {
             field1.Text= text;
        }
        
    }
}
