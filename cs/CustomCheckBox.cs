namespace BackupZip;
partial class Form1
{
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
    }//fine CustomCheckBox 
    public void CheckBoxManager(int totali, int StartXpos, int StartYpos, string Name,ref List<CustomCheckBox> List)//creo la lista dei pulsanti LED
    {
        List = new List<CustomCheckBox>();
        for (int i=0; i<totali; i++)
        {
            string nomePulsante= Name+$"{i+2}";
            string labelPulsante= nomePulsante; 
            CustomCheckBox LedCustomCheckSingle = new CustomCheckBox(nomePulsante,100,25, StartXpos,StartYpos+(i*25), indexTab=indexTab+1,labelPulsante,this,nomePulsante);              
            LedCustomCheckSingle.Click += MyButton_Click;   
            List.Add(LedCustomCheckSingle);
        }
    }
}