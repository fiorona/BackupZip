using System;
using System.Diagnostics.Tracing;
using System.IO.Ports;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using System.Collections;
using Microsoft.VisualBasic;

namespace WinFormsApp;

static class Program
{
    const int ArduinoOutputs=12;
    public static byte[] SendArray = new byte[64];
    static SerialPort serialPort = new SerialPort();
    static string TX = "A";
    static string RX = "";
    static SerialDataReceivedEventHandler myHandle=null; //dichiaro metodo evento interrupt seriale
    static Form1 mainForm = new Form1();//creo reference del Form1.cs 
    public static BitArray ArduinoDigitalOutputs= new BitArray (16, false);
    public static byte[] ArduinoDigitalOutputs2 = new byte[2];
    public static byte[] ArduinoPwmOutputs = new byte[ArduinoOutputs]; // Array di 12 byte, inizializzati a 0

    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        string[,] myMatrix=null;
        FindComPort.GetComName();
        Application.Run(mainForm); //lancio la pagina grafica Form1 dichiarata sopra
        
    }

    internal static string InitSerialPort()
    {   
        if (serialPort.PortName!=""){CloseCom();}       
        string COMport="";
        string status="";
        string MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        try
            {
                COMport=FindComPort.GetComName();
                serialPort.PortName = COMport;
                serialPort.BaudRate = 9600;
                serialPort.Parity = Parity.None;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.DtrEnable = true;
                serialPort.RtsEnable = true;
                serialPort.ReceivedBytesThreshold=64;
                myHandle= new SerialDataReceivedEventHandler(sp_DataReceived); //inizializzo metodo evento interrupt seriale
                //serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                serialPort.DataReceived += myHandle; //ogni volta che ricevo dati su seriale "DataReceived" eseguo metodo configurato in myHandle
                        
                
                serialPort.Open();
                Thread.Sleep(1000);
                //status = $"{MethodName} ok: {serialPort.PortName}";
                status =$"{serialPort.PortName} OK";
            }
            catch (ArgumentException e)
            {
                //status = $"{MethodName} failed: {serialPort.PortName}";
                status =$"{serialPort.PortName} failed";
            }
            catch (OperationCanceledException)
            {
                CloseCom();
                //status = $"{MethodName} cancelled: {serialPort.PortName}";
                status =$"{serialPort.PortName} cancelled";
            }

        return  status;
    }
    internal static void ExitProgram()
    {   
                        
            CloseCom();
            Application.Exit();

    }   
    internal static void CloseCom()
    {   
                        
            serialPort.Close();
            serialPort.DataReceived -= myHandle; //rimuovo metodo altrimenti non funziona dopo open com

    }
    public static string TxSerialPort()//invio byte array su seriale
    {
        string status="";      
        SendArray[0] = 0x0B;//header in Arduino firmware        
        SendArray[63] = 0x0A;//ender in Arduino firmware
        SendArray[2]=ArduinoDigitalOutputs2[0];//digitali da 2 a 9
        SendArray[3]=ArduinoDigitalOutputs2[1];//digitali da 10 a 13
        for (int i=0;i<12;i++)
            {
                SendArray[i+4]=ArduinoPwmOutputs[i];//PWM 0=0% - 255=100%  
                //byte da 4 a 15
            }    
        try
            {
                serialPort.Write(SendArray,0,SendArray.Length);    
                status = $"Ok: {serialPort.PortName}";
            }
            catch (ArgumentException e)
            {
                status = $"Failed: {serialPort.PortName}";
            }
            catch (OperationCanceledException)
            {
                CloseCom();
                status = $"Cancelled: {serialPort.PortName}";
            }

        return  status;
    }
    public static void DigitalOutputs(int position, bool bit)
    {   
        SendArray[1] = 0x0D;//case Digital in Arduino firmware 
        ArduinoDigitalOutputs.Set (position, bit);                           
        ArduinoDigitalOutputs.CopyTo(ArduinoDigitalOutputs2, 0);
        TxSerialPort();//invio byte array su seriale
    }
    public static void PWMOutputs(int position, bool bit, byte value)
    {   
        SendArray[1] = 0x0A;//case Digital in Arduino firmware 
        if (bit==false){value=0;}
        ArduinoPwmOutputs[position]=value;                
        TxSerialPort();//invio byte array su seriale
    }
    public static void ResetOutputs()
    {
        ResetDigitalOutputs();
        ResetPwmOutputs();        
        TxSerialPort();//invio byte array su seriale
    }
    public static void ResetPwmOutputs()
    {
        ArduinoPwmOutputs = new byte[ArduinoOutputs]; 
    }
    public static void ResetDigitalOutputs()
    {
        ArduinoDigitalOutputs =  new BitArray (16, false); 
    }
    public static void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        int bit=serialPort.BytesToRead;//The number of bytes of data in the receive buffer.
        mainForm.SetLabelTextByRef(bit.ToString(),mainForm.RXbytes);//aggiorno valore TextBox nel form in base al nome della TextBox da aggiornare
        var RXArray = new byte[64];
        serialPort.Read(RXArray,0,RXArray.Length);//Reads a number of bytes from the SerialPort input buffer and writes those bytes into a byte array at the specified offset.
        if ((RXArray[0]==0x0A)&&(RXArray[63]==0x0B))
        {
            var MillisArray = new byte[4];
                MillisArray[0]=RXArray[2];
                MillisArray[1]=RXArray[3];
                MillisArray[2]=RXArray[4];
                MillisArray[3]=RXArray[5];
            int millis=BitConverter.ToInt32(MillisArray,0);
            mainForm.SetLabelTextByRef(millis.ToString(),mainForm.RXmillis);//aggiorno valore TextBox nel form in base al nome della TextBox da aggiornare 

            
                for (int i=0; i<6;i++)//lettura contatore Arduino firware
                {
                    var AnalogsArray = new byte[2];
                    AnalogsArray[0]=RXArray[8+(i*2)];
                    AnalogsArray[1]=RXArray[9+(i*2)];
                    int Analog=BitConverter.ToInt16(AnalogsArray,0);
                    mainForm.SetLabelTextByRef(Analog.ToString(),mainForm.RXAnalogs.ElementAt(i));//aggiorno valore TextBox nel form in base al nome della TextBox da aggiornare
                    
                    double Volt=(Analog*5)/1023.00;//1023:5=bit:Volt
                    double Ampere=Volt/1.00;//K=Volt/Ampere --> K=1  
                    string AmpereString= String.Format("{0:0.##}", Ampere);//setto 2 numeri dopo la virgola                   
                    mainForm.SetLabelTextByRef(AmpereString,mainForm.RXAmperes.ElementAt(i));             
                }
                 
            switch (RXArray[1])
            {
                case 0:
                    break;

                case 0x0A://gestione analogiche
                            
                    break;

                case 0x0D://gestione digitali
              
                    break;      

                default:
                    break;
            }                                
        }
        serialPort.DiscardInBuffer();//se tengo premuto pulsante leggo non si impalla il buffer    
    }    
}