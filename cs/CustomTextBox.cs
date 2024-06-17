namespace BackupZip;
partial class Form1
{
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
    }//fine CustomTextBox

    public void TexBoxManager(int totali, int StartXpos, int StartYpos, string Name,ref List<CustomTextBox> List)//creo la lista dei pulsanti LED
    {
        List = new List<CustomTextBox>();
        for (int i=0; i<totali; i++)
        {
            string nome= Name+$"{i}";
            string label= nome; 
            CustomTextBox RXAmpereTextBox = new CustomTextBox(nome,100,50, StartXpos,StartYpos+(i*25), indexTab=indexTab+1,label,this);          
            List.Add(RXAmpereTextBox);
        }
    }
}