using System;
using System.Diagnostics.Tracing;
using System.IO.Ports;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using System.Collections;

namespace WinFormsApp;

static class Program
{
    //static SerialPort serialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One); // Adjust COM port as needed
    static SerialPort serialPort = new SerialPort();
    static string TX = "A";
    static string RX = "";
    static SerialDataReceivedEventHandler myHandle=null; //dichiaro metodo evento interrupt seriale
    static Form1 mainForm = new Form1();//creo reference del Form1.cs 

    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
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
    internal static string TxSerialPort(string messageTx)
    {
        string status="";
        string MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        try
            {
                serialPort.WriteLine(messageTx);    
                status = $"{MethodName} ok: {serialPort.PortName}";
            }
            catch (ArgumentException e)
            {
                status = $"{MethodName} failed: {serialPort.PortName}";
            }
            catch (OperationCanceledException)
            {
                CloseCom();
                status = $"{MethodName} cancelled: {serialPort.PortName}";
            }

        return  status;
    }
    internal static string ArrayTxSerialPort(bool led)
    {
        string status="";
        string MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        var SendArray = new byte[] { 0x0B, 0x00, 0x00, 0x0A };
        
        try
            {
                SendArray[2]=insertIntoPosition(SendArray[2],3,led);
                serialPort.Write(SendArray,0,SendArray.Length);    
                //serialPort.WriteLine("a"); 
                status = $"{MethodName} ok: {serialPort.PortName}";
            }
            catch (ArgumentException e)
            {
                status = $"{MethodName} failed: {serialPort.PortName}";
            }
            catch (OperationCanceledException)
            {
                CloseCom();
                status = $"{MethodName} cancelled: {serialPort.PortName}";
            }

        return  status;
    }
    public static byte insertIntoPosition(byte number, int position, bool bit)
    {
        // converting the number to BitArray
        //BitArray a = new BitArray (new byte[]{number});
        BitArray a = new BitArray (8, false);
        // setting the position bit
        a.Set (position, bit);

        // converting BitArray to byte again
        byte[] array = new byte[1];
        a.CopyTo(array, 0);
        return array[0];
    }
    public static void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        //Write the serial port data to the console.
        RX = serialPort.ReadExisting();
        //Console.WriteLine("RX: " + RX);
       
        // Access the TextBox after the form is running
        string textBoxContent = mainForm.MainTextBox.Text; // Access using property
        // or
        string textBoxContentAlt = mainForm.GetTextBoxText(); // Access using method
        // Optionally, modify the TextBox content
        //mainForm.SetTextBoxText(RX); //aggiorno valore TextBox nel form
        mainForm.SetTextBoxTextByName(RX,"RXvalue");//aggiorno valore TextBox nel form in base al nome della TextBox da aggiornare
        //mainForm.SetLabelTextByRef(RX,mainForm.RXvalue);//aggiorno valore TextBox nel form in base al nome della TextBox da aggiornare
    }    
}