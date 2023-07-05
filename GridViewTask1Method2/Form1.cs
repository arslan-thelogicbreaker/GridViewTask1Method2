using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridViewTask1Method2
{

    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

            // Set up the DataGridView
            dataGridView1.Columns.Add("serial_number", "Serial Number");
            dataGridView1.Columns.Add("file_name", "File Name");

            /* DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
             comboBoxColumn.Name = "btn_browse";
             dataGridView1.Columns.Insert(2, comboBoxColumn);
             comboBoxColumn.HeaderText = "Select File/Folder";
             comboBoxColumn.ToolTipText = "File/Folder";
             comboBoxColumn.Items.Add("File");
             comboBoxColumn.Items.Add("Folder");*/

            // Add the DataGridViewComboBoxColumn to the DataGridView
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            dataGridView1.Columns.Insert(2, comboBoxColumn);
            comboBoxColumn.Name = "btn_browse";
            comboBoxColumn.HeaderText = "Select";
            comboBoxColumn.ToolTipText = "Select File or Folder";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)row.Cells["btn_browse"];
                comboBoxCell.Items.Add("File");
                comboBoxCell.Items.Add("Folder");
            }
            dataGridView1.Columns.Add("password_field", "Password");

            dataGridView1.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "btn_save",
                HeaderText = "Save"
            });


            dataGridView1.Columns.Add("progress_col", "Progress");

            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["btn_save"].Index && e.RowIndex >= 0)
            {
                e.Value = "Save";
            }
            if (e.ColumnIndex == dataGridView1.Columns["btn_browse"].Index && e.RowIndex >= 0)
            {
                e.Value = "File/Folder";
            }

            if (e.ColumnIndex == dataGridView1.Columns["btn_browse"].Index && e.RowIndex >= 0)
            {
                string selectedItem = dataGridView1.SelectedCells.ToString();
                if (!string.IsNullOrEmpty(selectedItem))
                {
                    using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
                    {
                        // Set the initial directory, filter, and other properties of the OpenFileDialog
                        openFileDialog1.InitialDirectory = "C:\\";
                        openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                        openFileDialog1.FilterIndex = 1;
                        openFileDialog1.RestoreDirectory = true;
                        if (selectedItem == "File")
                        {
                            OpenFileDialog openFileDialog = new OpenFileDialog();
                            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                string selectedFilePath = openFileDialog1.FileName;
                            }
                        }
                        else if (selectedItem == "Folder")
                        {
                            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                            {
                                string selectedFolderPath = folderBrowserDialog1.SelectedPath;
                            }
                        }
                    }
                }

                /*   private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
                   {
                       string selectedItem = item.SelectedItem.ToString();
                       if (selectedItem == "File")
                       {
                           OpenFileDialog openFileDialog = new OpenFileDialog();
                           if (openFileDialog.ShowDialog() == DialogResult.OK)
                           {
                               // File selection logic
                               string selectedFilePath = openFileDialog.FileName;
                               // Process the selected file
                           }
                       }
                       else if (selectedItem == "Folder")
                       {
                           FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                           if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                           {
                               // Folder selection logic
                               string selectedFolderPath = folderBrowserDialog.SelectedPath;
                               // Process the selected folder
                           }
                       }
                   }*/

            }
        }
    }
}

