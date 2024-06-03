using System;
using System.CodeDom;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public static Form1 It;   // Singleton.
        public Form1()
        {
            InitializeComponent();      //aggiungo tutti i campi grafici    
            It=this;
        }


        public static void MyButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;//setto sender come button
            switch(button.Name)
            {
                case "OpenCOM": RXvalue.Text=Program.InitSerialPort();
                                It.SetLabelTextByName("ciao","TX");
                    break;

                case "CloseCOM": Program.CloseCom();
                    break;

                case "TX": //MessageBox.Show(button.Name + " - " + Program.TxSerialPort("a"));
                            Program.TxSerialPort("a");
                    break;    

                case "Exit": Program.ExitProgram();
                    break;             

                default:
                    break;    
            }
            
        }
         // Public property to access the TextBox
        public TextBox MainTextBox
        {
            get { return RXvalue; }
        }
        // Optional: Public method to access the TextBox
        public string GetTextBoxText()
        {
            return RXvalue.Text;
        }
        public void SetTextBoxText(string text)
        {
             RXvalue.Text= text;
        }
        public void SetTextBoxTextByName(string text, string TextBoxName)
        {
             int i=0;
             
             foreach (object  s in this.Controls)
                {
                        //Type tipo=s.GetType();
                        if (s.GetType().Equals(typeof(CustomTextBox)))//{WinFormsApp.Form1+CustomTextBox}
                        {
                            CustomTextBox valore = s as CustomTextBox;//setto sender come button
                            if (valore.Name==TextBoxName)
                            {
                                valore.Text= text;  
                                //RXvalue.Text= text;  
                                break; // get out of the loop
                            }
                        }    
                    i++;
                }
        } 
        public void SetLabelTextByName(string text, string labelName)
        {
             int i=0;
             
             foreach (object  s in this.Controls)
                {
                        //Type tipo=s.GetType();
                        if (s.GetType().Equals(typeof(Label)))//{WinFormsApp.Form1+CustomTextBox}
                        {
                            Label valore = s as Label;//setto sender come button
                            if (valore.Name==labelName)
                            {
                                valore.Text= text;  
                                break; // get out of the loop
                            }
                        }    
                    i++;
                }
        }  
        
    }
    
}
