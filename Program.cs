using System;
using System.Diagnostics.Tracing;
using System.IO.Ports;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace WinFormsApp;

static class Program
{
    //static SerialPort serialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One); // Adjust COM port as needed
    static SerialPort serialPort = new SerialPort();
    static string TX = "A";
    static string RX = "";
    static Form1 mainForm = new Form1();
        
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        Application.Run(mainForm); //lancio la pagina grafica Form1 dichiarata in linea 16
    }
    internal static string InitSerialPort(string COMport)
    {
        string status="";
        string MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        try
            {
                serialPort.PortName = COMport;
                serialPort.BaudRate = 9600;
                serialPort.Parity = Parity.None;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.DtrEnable = true;
                serialPort.RtsEnable = true;
                serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                        
                serialPort.Close();
                serialPort.Open();
                Thread.Sleep(1000);
                status = $"{MethodName} ok: {serialPort.PortName}";
                
            }
            catch (ArgumentException e)
            {
                status = $"{MethodName} failed: {serialPort.PortName}";
            }
            catch (OperationCanceledException)
            {
                serialPort.Close();
                status = $"{MethodName} cancelled: {serialPort.PortName}";
            }

        return  status;
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
                serialPort.Close();
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
        mainForm.SetTextBoxText(RX);

    }    
}