using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_2_Marushchak
{
    public partial class Form1 : Form
    {
        CharacteristicMatrix matrix;
        public Form1()
        {
            InitializeComponent();
            button_Sort.Enabled = false;
            
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            int rows = int.Parse(textBoxRows.Text);
            int cols = int.Parse(textBoxCols.Text);
            matrix = new CharacteristicMatrix(rows, cols);
            int max = int.Parse(textBoxMax.Text);
            int min = int.Parse(textBoxMin.Text);
            matrix.FillElementsRandom(min, max);
            Print(matrix);
            int columnIndex = matrix.IndexOfFirstPositiveColumn() + 1;
            labelIndexPositivColumn.Text = "Номер першого позитивного стовпця: " + columnIndex.ToString();
            button_Sort.Enabled = true;
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
           
                matrix.SortRowsByCharacteristic();
                Print(matrix);

        }

        private void Print(CharacteristicMatrix matrix)
        {
            DataTable dt = new DataTable();
            int columns = matrix.ColCount;
            int rows = matrix.RowCount;
            for (int i = 0; i < columns; i++)
            {
                dt.Columns.Add(i.ToString(), typeof(double));
            }
            for (int row = 0; row < rows; row++)
            {
                DataRow dr = dt.NewRow();
                for (int col = 0; col < columns; col++)
                {
                    dr[col] = matrix[row, col];
                }
                dt.Rows.Add(dr);
            }
            dataGrid.DataSource = dt.DefaultView;
            dataGrid.ColumnHeadersVisible = false;
           
        }
    }
}
