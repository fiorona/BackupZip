using System;
using System.CodeDom;
using System.Windows.Forms;
using System.Collections;


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
            //Button button = sender as Button;//setto sender come button
            Control button = sender as Control;//setto sender come Object
            CheckBox CheckBox = sender as CheckBox;//setto sender come CheckBox
            switch(button.Name)
            {
                case "OpenCOM": 
                                    It.SetLabelTextByName(Program.InitSerialPort(),"OpenCOM");
                                    It.ResetButton.Enabled=true;
                                    foreach (Control b in LedCheckBoxList){b.Enabled=true;}
                                    foreach (Control b in LedPwmList){b.Enabled=true;}
                                break;

                case "CloseCOM": 
                                    Program.CloseCom();
                                    It.SetLabelTextByName("Closed","OpenCOM");
                                    It.ResetButton.Enabled=false;
                                    foreach (Control b in LedCheckBoxList){b.Enabled=false;}
                                    foreach (Control b in LedPwmList){b.Enabled=false;}
                                break;

                case "RESET": 
                                    Program.ResetOutputs();                               
                                    Program.DigitalOutputs(0,false);
                                    foreach (CheckBox b in LedCheckBoxList){b.Checked=false;}
                                    foreach (CheckBox b in LedPwmList){b.Checked=false;}
                                break;

                case "LED0": case "LED1": case "LED2": case "LED3": case "LED4": case "LED5": case "LED6": case "LED7": case "LED8": case "LED9":
                case "LED10": case "LED11": case "LED12": case "LED13":
                                    foreach (CheckBox b in LedPwmList){b.Checked=false;}
                                    Program.ResetPwmOutputs();
                                    Program.DigitalOutputs((Int32.Parse(button.Name.Split("LED")[1])-2),CheckBox.Checked);
                                break; 

                case "PWM0": case "PWM1": case "PWM2": case "PWM3": case "PWM4": case "PWM5": case "PWM6": case "PWM7": case "PWM8": case "PWM9":
                case "PWM10": case "PWM11": case "PWM12": case "PWM13":
                                    foreach (CheckBox b in LedCheckBoxList){b.Checked=false;}
                                    int index=(Int32.Parse(button.Name.Split("PWM")[1])-2);
                                    Program.ResetDigitalOutputs();
                                    //if ((CheckBox.Checked==false)||(TXpwm.ElementAt(index).Text==""))
                                    if ((TXpwm.ElementAt(index).Text==""))
                                    {
                                        TXpwm.ElementAt(index).Text="0";
                                    }                                   
                                    byte byteValue = (byte)int.Parse(TXpwm.ElementAt(index).Text); 
                                    Program.PWMOutputs(index,CheckBox.Checked,byteValue);
                                
                                break;            

                case "Exit":        
                                    Program.ExitProgram();
                                break;  

                case "OpenDatabase":    
                                    FormDatabase FormDatabase= new FormDatabase();
                                    FormDatabase.Show(); //lancio la pagina grafica Form1 dichiarata sopra // Apre il form come una finestra separata
                                    //FormDatabase.ShowDialog(); // Apre il form come una finestra modale
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
