using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO.Ports;

/// <summary>
/// Compile an array of COM port names associated with given VID and PID
/// </summary>
/// <param name="VID"></param>
/// <param name="PID"></param>
/// <returns></returns>

public static class FindComPort
{
    static SerialPort serialPort = new SerialPort();
    static string VID = "VID_2341&PID_8041&MI_00";
    static string PID = "8&394899FE&1&0000";//non lo uso

    public static List<string> ComPortNames(String VID)
    {
        List<string> comports = new List<string>();
        RegistryKey rk1 = Registry.LocalMachine;//Computer\HKEY_LOCAL_MACHINE\
        RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\USB\\"+VID);//Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Enum\USB\VID_2341&PID_8041&MI_00
        foreach (String s3 in rk2.GetSubKeyNames())
        {
            RegistryKey rk3 = rk2.OpenSubKey(s3);//Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Enum\USB\VID_2341&PID_8041&MI_00\8&394899fe&1&0000
            RegistryKey rk4 = rk3.OpenSubKey($"Device Parameters");//Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Enum\USB\VID_2341&PID_8041&MI_00\8&394899fe&1&0000\Device Parameters
            comports.Add((string)rk4.GetValue("PortName"));//leggo parametro "PortName"
        }
        return comports;
    }

    public static string GetComName()
    {
        string ComTrovata="";
        List<string> ComNames = ComPortNames(VID);
        if (ComNames.Count > 0)
        {
            foreach (String s in SerialPort.GetPortNames())
            {
                if (ComNames.Contains(s))
                {
                    //Console.WriteLine("My Arduino port is " + s);
                        ComTrovata=s;
                     break; // get out of the loop
                }
                    
            }
        }
        else {}

        return ComTrovata;
    }
}