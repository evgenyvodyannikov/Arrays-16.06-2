using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Массивы_16._06__2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,] matrix;
        int n;
        Random r = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                n = int.Parse(textBox1.Text);
                for (int k = 1; k <= n; k++)
                {
                    dataGridView1.Columns.Add("Участник №" + k, "Участник №" + k);
                }
                dataGridView1.Rows.Add(n);
                matrix = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == j)
                            matrix[i, j] = 0;
                        else
                            matrix[i, j] = r.Next(0, 3);
                        dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];
                    }
                }
                button3.Enabled = true;
            }
            catch { }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Турнирная таблица. В матрице К(n, n) представлена турнирная таблица соревнований по футболу среди n участников (каждый элемент аi матрицы есть число голов, забитых i-м участником j-му участнику); все элементы главной диагонали равны нулю. Присвоить каждому диагональному элементу разницу забитых и пропущенных голов соответствующего участника, то есть разность между суммами элементов соответствующих строки и столбца\nВ строках под участником записано сколько ему забили, а в столбцах сколько и кому он забил", "Задание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        for(int k = 0; k < n; k++)
                        {
                            matrix[i, j] += matrix[i, k] - matrix[k, j];
                        }
                        dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];
                        if (matrix[i, j] >= 0) dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Lime;
                        else dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;
                    }
                }
            }
            button3.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                if (textBox1.Text.Length == 6 && textBox1.Text.Length <= 6)
                {
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }
            e.Handled = true;
        }
    }
}
