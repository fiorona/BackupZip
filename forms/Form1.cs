using System;
using System.CodeDom;
using System.Windows.Forms;
using System.Collections;

namespace BackupZip
{
    public partial class Form1 : Form
    {    
        public static Form1 It;   // Singleton.
        public static string folder=@"C:\Collaudi\LEONARDO\AW129";
        public static string file=@"C:\Collaudi\LEONARDO\AW129\TestStand";
        public static string server=@"F:\SERVICE\PROGETTI\LEONARDO\AW129";
        
        public Form1()
        {
            InitializeComponent();      //aggiungo tutti i campi grafici    
            It=this;
        }

        //private void button1_Click(object sender, EventArgs e)

        public static void MyButton_Click(object sender, EventArgs e)
        {
            //Button button = sender as Button;//setto sender come button
            Control button = sender as Control;//setto sender come Object
            CheckBox CheckBox = sender as CheckBox;//setto sender come CheckBox
            switch(button.Name)
            {
                case "BackupFolder": 
                                    folder=FileZip.SelectPath();
                                    It.SetLabelTextByName(folder,"BackupFolder");
                                break;

                case "BackupFile": 
                                    file=FileZip.SelectPath();
                                    It.SetLabelTextByName(file,"BackupFile");
                                break;

                case "BackupSave": 
                                    string status=FileZip.BackupSave(file,folder,server);
                                    It.SetLabelTextByName(status,"BackupSave");
                                break;
                case "Exit":        
                                    Program.ExitProgram();
                                break;  
                default:
                    break;    
            }
            
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
        public void SetLabelTextByRef(string text, ref CustomTextBox TextBoxName)
        {           
            TextBoxName.Text= text;                               
        }
        public void SetLabelTextByRef2(string text, ref List<CustomTextBox> TextBoxName, int index)
        {           
            TextBoxName[index].Text= text;                               
        }
    }
    
}
