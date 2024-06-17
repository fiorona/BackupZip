using Microsoft.VisualBasic.ApplicationServices;
using System.Collections;
namespace WinFormsApp;

partial class FormDatabase
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    public DataGridView dataGridView;

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
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.WindowState = FormWindowState.Maximized;
        //this.ClientSize = new System.Drawing.Size(1000, 1000);
        this.Text = "Database";
        
        // dataGridView
        this.dataGridView = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
        this.SuspendLayout();
        this.dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dataGridView.Location = new System.Drawing.Point(12, 12);
        this.dataGridView.Name = "dataGridView";
        this.dataGridView.Size = new System.Drawing.Size(776, 426);
        this.dataGridView.TabIndex = 0;
        this.Controls.Add(this.dataGridView);
        ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
        this.ResumeLayout(false);
    }

    #endregion
}
