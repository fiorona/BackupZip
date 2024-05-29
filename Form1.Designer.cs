namespace WinFormsApp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Ciao";
    }

    public class CustomButton : System.Windows.Forms.Button
{
    private System.Windows.Forms.Label lb = new System.Windows.Forms.Label ();

    public CustomButton (string Name ,string Text,int Width, int Height, int xLocation, int yLocation)
    {
        this.Width = Width;
        this.Height = Height;
        this.Text= Text;
        this.Name= Name;
        this.Font = new System.Drawing.Font (this.Font.FontFamily, 10);
        this.Location = new System.Drawing.Point(xLocation, yLocation);
        //lb = new System.Windows.Forms.Label ();
        //lb.Font = new System.Drawing.Font (lb.Font.FontFamily, 10);
        //lb.Location = new System.Drawing.Point (0, 0);
        //lb.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
        //lb.BackColor = System.Drawing.Color.Transparent;
        //lb.Text=LabelText;
        //lb.Width = 70;
        //lb.AutoSize=true;
        //lb.Click += (sender, args) => InvokeOnClick (this, args); //Add this line
        //this.Controls.Add (lb);
    }

    public System.Windows.Forms.Label getLb ()
    {
        return lb;
    }

    public System.Windows.Forms.Button get_btn ()
    {
        return this;
    }
}

    #endregion
}
