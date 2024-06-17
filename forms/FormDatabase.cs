using System;
using System.CodeDom;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using Microsoft.VisualBasic.FileIO;

namespace WinFormsApp
{
    public partial class FormDatabase : Form
    {    
        public static FormDatabase ThisForm;   // Singleton.
        //DatabaseCsv.SaveCsv($"C:\\Collaudi\\VisualStudioCode\\WindowsForms\\WinFormsApp\\Prova.csv",";",myMatrix);
        
        public FormDatabase()
        {
            InitializeComponent();
            
            //DatabaseCsv.LoadCsvFileToDataGridView($"C:\\Collaudi\\VisualStudioCode\\WindowsForms\\WinFormsApp\\Prova.csv",";",ref dataGridView);//carico i dati direttamente nel dataGridView by reference
            dataGridView.DataSource=DatabaseCsv.ReadCsvFileToDataTable($"C:\\Collaudi\\VisualStudioCode\\WindowsForms\\WinFormsApp\\Database\\csv\\Prova.csv",";");//carico i dati in un datatable e poi li copio nel dataGridView

            ThisForm=this;            
        }
        
    }
    
}
