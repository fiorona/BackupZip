using Microsoft.VisualBasic.ApplicationServices;
using System.Collections;
namespace WinFormsApp;
partial class Form1
{
    ///  Required designer variable.
    private System.ComponentModel.IContainer components = null;

    public CustomTextBox RXmillis=null;
    public CustomTextBox RXbytes=null;
    public List <CustomTextBox> RXAnalogs=null;
    public List <CustomTextBox> RXAmperes=null;
    public static List <CustomTextBox> TXpwm=null;
    public CustomButton OpenComButton=null;
    public CustomButton OpenDatabaseForm=null;
    public CustomButton CloseComButton=null;
    public CustomButton ExitButton=null;
    public CustomButton ResetButton=null;
    public int indexTab=0;
    public static List <CustomCheckBox> LedCheckBoxList=null;
    public static List <CustomCheckBox> LedPwmList=null;
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.WindowState = FormWindowState.Maximized;
        //this.ClientSize = new System.Drawing.Size(1000, 1000);
        this.Text = "Ciao";
        //aggiungo Pulsanti al form
        OpenComButton = new CustomButton("OpenCOM",100,50, 0, 0, indexTab,"closed",this,"bottom");//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
        OpenDatabaseForm = new CustomButton("OpenDatabase",100,50, 0, 100, indexTab,"",this,"bottom");//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
        CloseComButton = new CustomButton("CloseCOM",100,50, 100, 0, indexTab=indexTab+1,"",this,"bottom");//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
        ExitButton = new CustomButton("Exit",100,50, 200, 0, indexTab=indexTab+1,"",this,"bottom");//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
        ResetButton = new CustomButton("RESET",200,50, 300, 0, indexTab=indexTab+1,"",this,"bottom");//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
        ResetButton.Enabled=false;

        CheckBoxManager(12,300,50,"PWM",ref LedPwmList);
        CheckBoxManager(12,400,50,"LED",ref LedCheckBoxList);
        //aggiungo TestBox al form
        RXmillis = new CustomTextBox("RXmillis",100,50, 500, 0, indexTab=indexTab+1,"RXmillis",this);//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
        RXbytes = new CustomTextBox("RXbytes",100,50, 500, 25, indexTab=indexTab+1,"RXbytes",this);
        TexBoxManager(6,500,75,"RXAnalogs",ref RXAnalogs);//passo lista come riferimento a quella già esistente
        TexBoxManager(6,700,75,"RXAmpere",ref RXAmperes);//passo lista come riferimento a quella già esistente
        TexBoxManager(12,200,50,"TXpwm",ref TXpwm);//passo lista come riferimento a quella già esistente

    }
      
    #endregion
}
