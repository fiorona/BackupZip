using System;
using System.IO;
using System.Data;
public static class DatabaseCsv
{
    public static void SaveCsv(string filePath, string delimiter,string[,] matrice)
    {
        try
        {
            if (filePath!="")
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Scrivi l'intestazione del CSV
                    writer.WriteLine($"Nome{delimiter}Cognome{delimiter}Età");
                    // Scrivi alcune righe di dati
                    writer.WriteLine($"Mario{delimiter}Rossi{delimiter}30");
                    writer.WriteLine($"Luca{delimiter}Bianchi{delimiter}25");
                    writer.WriteLine($"Giulia{delimiter}Verdi{delimiter}28");
                }
            }    
    
        }
        catch{}      
    }

    public static DataTable ReadCsvFileToDataTable(string filePath, string delimiter)
    {
        var dataTable = new DataTable();

        using (var reader = new StreamReader(filePath))
        {
            // Legge la prima riga per ottenere i nomi delle colonne
            string[] headers = reader.ReadLine().Split(delimiter);
            foreach (var header in headers)
            {
                dataTable.Columns.Add(header);
            }

            // Legge il resto del file riga per riga
            while (!reader.EndOfStream)
            {
                string[] fields = reader.ReadLine().Split(delimiter);
                var dataRow = dataTable.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dataRow[i] = fields[i];
                }
                dataTable.Rows.Add(dataRow);
            }
        }

        return dataTable;
    }
    public static void LoadCsvFileToDataGridView(string filePath, string delimiter, ref DataGridView dataGridView)
    {
        using (var reader = new StreamReader(filePath))
        {
            // Leggi la prima riga per ottenere i nomi delle colonne
            string[] headers = reader.ReadLine().Split(delimiter);
            foreach (var header in headers)
            {
                dataGridView.Columns.Add(header, header);
            }

            // Leggi il resto del file riga per riga
            while (!reader.EndOfStream)
            {
                string[] fields = reader.ReadLine().Split(delimiter);
                dataGridView.Rows.Add(fields);
            }
        }
    }
}
