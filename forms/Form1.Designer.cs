using Microsoft.VisualBasic.ApplicationServices;
using System.Collections;
namespace BackupZip;
partial class Form1
{
    ///  Required designer variable.
    private System.ComponentModel.IContainer components = null;
    public List <CustomTextBox> RXAnalogs=null;
    public CustomButton BackupFolder=null;
    public CustomButton BackupFile=null;
    public CustomButton BackupSave=null;
    public CustomButton ExitButton=null;
    public int indexTab=0;
    public static List <CustomCheckBox> LedCheckBoxList=null;
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
        this.Text = "Backup zip";
        //aggiungo Pulsanti al form
        BackupFolder = new CustomButton("BackupFolder",100,50, 0, 50, indexTab,folder,this,"right");//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
        BackupFile = new CustomButton("BackupFile",100,50, 0, 100, indexTab,file,this,"right");
        BackupSave = new CustomButton("BackupSave",100,50, 0, 150, indexTab,"-",this,"right");//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo = new CustomButton("OpenCOM",100,50, 0, 0, indexTab,"closed",this,"bottom");//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
        ExitButton = new CustomButton("Exit",100,50, 0, 200, indexTab=indexTab+1,"",this,"right");//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo

        //CheckBoxManager(12,400,50,"LED",ref LedCheckBoxList);
        //aggiungo TestBox al form
        //TexBoxManager(6,500,75,"RXAnalogs",ref RXAnalogs);//passo lista come riferimento a quella già esistente

    }
      
    #endregion
}
