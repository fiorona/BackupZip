using System;
using System.Diagnostics.Tracing;
using System.IO.Ports;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace WinFormsApp;

static class Program
{
    //static SerialPort serialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One); // Adjust COM port as needed
    static SerialPort serialPort = new SerialPort();
    static string TX = "A";
    static string RX = "";
    

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
                serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                        
                CloseCom();
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
        
    }    
}