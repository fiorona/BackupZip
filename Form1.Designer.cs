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

    public void MyButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;//setto sender come button
            switch(button.Name)
            {
                case "OpenCOM": MessageBox.Show(button.Name + " - " + Program.InitSerialPort());
                                
                    break;

                case "CloseCOM": MessageBox.Show(button.Name + " Clicked!");
                    break;

                case "TX": //MessageBox.Show(button.Name + " - " + Program.TxSerialPort("a"));
                            Program.TxSerialPort("a");
                    break;    

                case "Exit": Application.Exit();
                    break;             

                default:
                    break;    
            }
            
        }

    public class CustomButton : System.Windows.Forms.Button
    {
        private System.Windows.Forms.Label lb = new System.Windows.Forms.Label ();

        public CustomButton (string Name,int Width, int Height, int xLocation, int yLocation, int TabIndex,string LabelText,Form sender)
        {
            this.Width = Width;
            this.Height = Height;
            this.Text= Name;
            this.Name= Name;
            this.Font = new System.Drawing.Font (this.Font.FontFamily, 10);
            this.Location = new System.Drawing.Point(xLocation, yLocation);
            this.TabIndex=TabIndex;
            sender.Controls.Add (this); //this si riferisce al button e la aggiungo al sender che è il Form
            //this.Click += MyButton_Click();
            if (LabelText!="")
            {
                lb = new System.Windows.Forms.Label ();
                lb.Font = new System.Drawing.Font (lb.Font.FontFamily, 10);
                //lb.Location = new System.Drawing.Point (100, 100);
                lb.Text=LabelText;
                lb.AutoSize=true;
                lb.Visible=true;
                lb.Location = new System.Drawing.Point(this.Bounds.Right,this.Bounds.Top + (this.Height - lb.Height) );//centro label sul lato destro
                lb.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                lb.BackColor = System.Drawing.Color.Transparent;            
                sender.Controls.Add (lb);//aggiungo al sender che è il Form
            } 
        }
        
        public System.Windows.Forms.Label getLb ()
        {
            return lb;
        }

        public System.Windows.Forms.Button get_btn ()
        {
            return this;
        }
    }//fine CustomButton
    public class CustomTextBox : System.Windows.Forms.TextBox
    {
        private System.Windows.Forms.Label lb = new System.Windows.Forms.Label ();

        public CustomTextBox (string Name, int Width, int Height, int xLocation, int yLocation, int TabIndex, string LabelText,Form sender)
        {
            this.Width = Width;
            this.Height = Height;
            this.Text= "";
            this.Name= Name;
            this.Font = new System.Drawing.Font (this.Font.FontFamily, 10);
            this.Location = new System.Drawing.Point(xLocation, yLocation);
            this.TabIndex=TabIndex;
            sender.Controls.Add (this); //this si riferisce alla TextBox e la aggiungo al sender che è il Form
            if (LabelText!="")
            {
                lb = new System.Windows.Forms.Label ();
                lb.Font = new System.Drawing.Font (lb.Font.FontFamily, 10);
                //lb.Location = new System.Drawing.Point (100, 100);
                lb.Text=LabelText;
                lb.AutoSize=true;
                lb.Visible=true;
                lb.Location = new System.Drawing.Point(this.Bounds.Right,this.Bounds.Top + (this.Height - lb.Height) );//centro label sul lato destro
                lb.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                lb.BackColor = System.Drawing.Color.Transparent;            
                sender.Controls.Add (lb);//aggiungo al sender che è il Form
            }                 
        }
        
        public System.Windows.Forms.Label getLb ()
        {
            return lb;
        }

        public System.Windows.Forms.TextBox get_txt ()
        {
            return this;
        }
    }//fine CustomTextBox
    #endregion
}
