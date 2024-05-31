using System;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        TextBox field1=null;
        public Form1()
        {
            InitializeComponent();

            Button myButton1 = new CustomButton("OpenCOM",100,50, 0, 0, 0,"",this);//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
            myButton1.Click += MyButton_Click;

            Button myButton2 = new CustomButton("CloseCOM",100,50, 100, 0, 1,"",this);//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
            myButton2.Click += MyButton_Click;

            Button myButton3 = new CustomButton("Exit",100,50, 200, 0, 2,"",this);//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
            myButton3.Click += MyButton_Click;

            Button myButton4 = new CustomButton("TX",100,50, 300, 0, 3,"",this);//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
            myButton4.Click += MyButton_Click;

            Label label1 = new Label()
            {
                Text = "&RX value",
                Location = new Point(0, 200),
                TabIndex = 4
            };
            field1 = new TextBox()
            {
                Location = new Point(label1.Location.X, label1.Bounds.Bottom + Padding.Top),
                TabIndex = 5
            };
            this.Controls.Add(label1);
            this.Controls.Add(field1);

            TextBox txtCOM = new CustomTextBox("txtCOM",100,50, 500, 100, 6,"txtCOM",this);//this fa riferimento a WinFormsApp.Form1 e lo passo al metodo
            //this.Controls.Add(txtCOM);

        }
        
         // Public property to access the TextBox
        public TextBox MainTextBox
        {
            get { return field1; }
        }
        // Optional: Public method to access the TextBox
        public string GetTextBoxText()
        {
            return field1.Text;
        }
        public void SetTextBoxText(string text)
        {
             field1.Text= text;
        }
        
    }
}
