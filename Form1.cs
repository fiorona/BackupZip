using System;
using System.CodeDom;
using System.Windows.Forms;
using System.Collections;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public static Form1 It;   // Singleton.
        public static BitArray ArduinoDigitalOutputs= new BitArray (16, false);
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
                                    //It.RXvalue.Text=Program.InitSerialPort();
                                    It.SetLabelTextByName(Program.InitSerialPort(),"OpenCOM");
                                    It.ResetButton.Enabled=true;
                                    //foreach (Button b in LedButtonList){b.Enabled=true;}
                                    //foreach (CheckBox b in LedCheckBoxList){b.Enabled=true;}
                                    foreach (Control b in LedCheckBoxList){b.Enabled=true;}
                    break;

                case "CloseCOM": 
                                    Program.CloseCom();
                                    It.SetLabelTextByName("Closed","OpenCOM");
                                    It.ResetButton.Enabled=false;
                                    //foreach (Button b in LedButtonList){b.Enabled=false;}
                                    //foreach (CheckBox b in LedCheckBoxList){b.Enabled=false;}
                                    foreach (Control b in LedCheckBoxList){b.Enabled=false;}
                    break;

                case "RESET": 
                                    //MessageBox.Show(button.Name + " - " + Program.TxSerialPort("a"));
                                    //Program.TxSerialPort("aaaa"); 
                                    ArduinoDigitalOutputs =  new BitArray (16, false);                                
                                    Program.BitArrayTxSerialPort(ArduinoDigitalOutputs,0,false);
                                    foreach (CheckBox b in LedCheckBoxList){b.Checked=false;}
                    break;

                case "LED0": case "LED1": case "LED2": case "LED3": case "LED4": case "LED5": case "LED6": case "LED7": case "LED8": case "LED9":
                case "LED10": case "LED11": case "LED12": case "LED13":
                                    int position= Int32.Parse(button.Name.Split("LED")[1])-2;//split restituisce un array e leggo il 2 byte
                                                                       
                                    Program.BitArrayTxSerialPort(ArduinoDigitalOutputs,position,CheckBox.Checked);
                    break;        

                case "Exit":        
                                    Program.ExitProgram();
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
        public void SetLabelTextByRef(string text, CustomTextBox TextBoxName)
        {           
            TextBoxName.Text= text;                               
        }
    }
    
}
