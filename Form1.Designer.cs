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

    public CustomTextBox RXvalue=null;
    public CustomButton OpenComButton=null;
    public CustomButton CloseComButton=null;
    public CustomButton ExitButton=null;
    public CustomButton ResetButton=null;
    public static List <CustomButton> LedButtonList=null;
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
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Ciao";
        //aggiungo Pulsanti al form
        OpenComButton = new CustomButton("OpenCOM",100,50, 0, 0, 0,"closed",this,"bottom");//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
        CloseComButton = new CustomButton("CloseCOM",100,50, 100, 0, 1,"a",this,"bottom");//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
        ExitButton = new CustomButton("Exit",100,50, 200, 0, 2,"b",this,"bottom");//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
        ResetButton = new CustomButton("RESET",100,50, 300, 0, 3,"c",this,"bottom");//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
        ResetButton.Enabled=false;
        //ButtonManager(); 
        CheckBoxManager();
        //aggiungo TestBox al form
        RXvalue = new CustomTextBox("RXvalue",100,50, 400, 0, 4,"RXvalue",this);//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
        //TextBox txtCOM = new CustomTextBox("txtCOM",100,50, 500, 100, 6,"txtCOM",this);//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
        //aggiungo controlli al form

    }
    public void ButtonManager()//creo la lista dei pulsanti LED
    {
        LedButtonList = new List<CustomButton>();
        for (int i=0; i<12; i++)
        {
            string nomePulsante= $"LED{i+2}";
            string labelPulsante= nomePulsante; 
            CustomButton LedButtonSingle = new CustomButton(nomePulsante,100,25, 300,50+(i*25), 5+i,labelPulsante,this,nomePulsante);          
            LedButtonSingle.Enabled=false;    
               
            LedButtonList.Add(LedButtonSingle);
        }
    }
    public void CheckBoxManager()//creo la lista dei pulsanti LED
    {
        LedCheckBoxList = new List<CustomCheckBox>();
        for (int i=0; i<12; i++)
        {
            string nomePulsante= $"LED{i+2}";
            string labelPulsante= nomePulsante; 
            CustomCheckBox LedCustomCheckSingle = new CustomCheckBox(nomePulsante,100,25, 300,50+(i*25), 5+i,labelPulsante,this,nomePulsante);              
               
            LedCheckBoxList.Add(LedCustomCheckSingle);
        }
    }
    public class CustomButton : System.Windows.Forms.Button
    {
        private System.Windows.Forms.Label lb = new System.Windows.Forms.Label ();
        
        public CustomButton (string Name,int Width, int Height, int xLocation, int yLocation, int TabIndex,string LabelText,Form sender, string lbLocation)
        {
            this.Width = Width;
            this.Height = Height;
            this.Text= Name;
            this.Name= Name;
            this.Enabled=true;
            //this.AccessibleName=LabelText;
            this.Font = new System.Drawing.Font (this.Font.FontFamily, 10);
            this.Location = new System.Drawing.Point(xLocation, yLocation);
            this.TabIndex=TabIndex;
            sender.Controls.Add (this); //this si riferisce al button e la aggiungo al sender che è il Form
            this.Click += MyButton_Click;

            if (LabelText!="")
            {
                lb = new System.Windows.Forms.Label ();
                lb.Font = new System.Drawing.Font (lb.Font.FontFamily, 10);
                //lb.Location = new System.Drawing.Point (100, 100);
                lb.Text=LabelText;
                lb.AutoSize=true;
                lb.Visible=true;
                lb.Name=Name;
                int lbX=0;
                int lbY=0;
                switch(lbLocation)
                {
                    case "left":    
                                    lbX=(this.Bounds.Left-lb.Width);
                                    lbY=this.Top + ((this.Height - lb.Height)/2);
                                    lb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        break;
                    case "right":
                                    lbX=(this.Bounds.Right);
                                    lbY=this.Top + ((this.Height - lb.Height)/2);
                                    lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        break;
                    case "top":    
                                    lbX=this.Bounds.Left;
                                    lbY=this.Bounds.Top;
                                    lb.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                        break;
                    case "bottom":    
                                    lbX=this.Bounds.Left;
                                    lbY=this.Bounds.Bottom;
                                    lb.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                        break;

                    default:
                        break;
                }
                lb.Location = new System.Drawing.Point(lbX ,lbY);//centro label sul lato destro               
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
    public class CustomCheckBox : System.Windows.Forms.CheckBox
    {
        private System.Windows.Forms.Label lb = new System.Windows.Forms.Label ();
        
        public CustomCheckBox (string Name,int Width, int Height, int xLocation, int yLocation, int TabIndex,string LabelText,Form sender, string lbLocation)
        {
            this.Appearance=System.Windows.Forms.Appearance.Button;
            this.Width = Width;
            this.Height = Height;
            this.Text= Name;
            this.Name= Name;
            //this.AccessibleName=LabelText;
            this.Font = new System.Drawing.Font (this.Font.FontFamily, 10);
            this.TextAlign=ContentAlignment.MiddleCenter;
            this.Location = new System.Drawing.Point(xLocation, yLocation);
            this.TabIndex=TabIndex;
            this.Enabled=false;
            sender.Controls.Add (this); //this si riferisce al button e la aggiungo al sender che è il Form
            this.Click += MyButton_Click;

            if (LabelText!="")
            {
                lb = new System.Windows.Forms.Label ();
                lb.Font = new System.Drawing.Font (lb.Font.FontFamily, 10);
                //lb.Location = new System.Drawing.Point (100, 100);
                lb.Text=LabelText;
                lb.AutoSize=true;
                lb.Visible=true;
                lb.Name=Name;
                int lbX=0;
                int lbY=0;
                switch(lbLocation)
                {
                    case "left":    
                                    lbX=(this.Bounds.Left-lb.Width);
                                    lbY=this.Top + ((this.Height - lb.Height)/2);
                                    lb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        break;
                    case "right":
                                    lbX=(this.Bounds.Right);
                                    lbY=this.Top + ((this.Height - lb.Height)/2);
                                    lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        break;
                    case "top":    
                                    lbX=this.Bounds.Left;
                                    lbY=this.Bounds.Top;
                                    lb.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                        break;
                    case "bottom":    
                                    lbX=this.Bounds.Left;
                                    lbY=this.Bounds.Bottom;
                                    lb.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                        break;

                    default:
                        break;
                }
                lb.Location = new System.Drawing.Point(lbX ,lbY);//centro label sul lato destro               
                lb.BackColor = System.Drawing.Color.Transparent;            
                sender.Controls.Add (lb);//aggiungo al sender che è il Form
            } 
        }
        public System.Windows.Forms.Label getLb ()
        {
            return lb;
        }
        public System.Windows.Forms.CheckBox get_btn ()
        {
            return this;
        }
    }//fine CustomCheckBox
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
