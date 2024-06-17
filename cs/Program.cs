using System;
using System.Diagnostics.Tracing;
using System.IO.Ports;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using System.Collections;
using Microsoft.VisualBasic;
using System.IO.Compression;

namespace BackupZip;

static class Program
{
    static Form1 mainForm = new Form1();//creo reference del Form1.cs 

    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(mainForm); //lancio la pagina grafica Form1 dichiarata sopra
        
    }
    internal static void ExitProgram()
    {   
                        
            Application.Exit();

    }              
}