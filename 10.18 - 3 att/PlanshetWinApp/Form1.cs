using PlanshetModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanshetWinApp
{
    /*17. Прайс-лист содержит следующую информацию о планшетах: название модели, 
      объем памяти, рейтинг модели среди пользователей (цифра от 1 до 5), стоимость. 
      У вас есть N денег, вам необходимо купить самый хороший планшет, на который вам 
      хватит денег. Для вас приоритетным является объем памяти, в случае одинакового 
      объема – рейтинг модели. Если подходящих моделей будет несколько, вы выберете 
      Samsung или Asus (присутствует в названии модели), а затем все остальные. 
      Если по этим критериям вам подходят несколько моделей – выбирайте любой.

    18. Входные данные соответствуют предыдущей задачи, однако теперь вам надо купить 
    K самых дешевых планшетов с объемом памяти не ниже M и рейтингом не 
    ниже R (призы победителям олимпиады). Какие планшет вы выберете и сколько денег вы потратите?*/

    public partial class Form1 : Form
    {
        private List<Tablet> _tablets = new List<Tablet>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            int k = int.Parse(txtBxK.Text); //кол-во планшетов
            int m = int.Parse(txtBxM.Text); //объем памяти
            int r = int.Parse(txtBxR.Text); //рейтинг

            decimal sum = 0;

            var chipTablets = ChoiceManager.GetChipsTablet(_tablets, k, m, r, out sum);

            dataGridView2.DataSource = chipTablets;
            txtBxTotal.Text = sum.ToString("C2");
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = dialog.FileName;

                _tablets.AddRange(FileManager.ReadFromFile(filename));

                UpdateGrid();
            }
        }

        private void Save(List<Tablet> tablets)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileManager.SaveInFile(dialog.FileName, tablets);
            }
        }

        private void исходныеДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save(dataGridView1.DataSource as List<Tablet>);
        }

        private void результатОтбораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save(dataGridView2.DataSource as List<Tablet>);
        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _tablets;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Tablet t = new Tablet();
            t.Model = txtBxModel.Text;
            t.Cost = decimal.Parse(txtBxCost.Text);
            t.Rating = int.Parse(txtBxRating.Text);
            t.VolumeMemory = int.Parse(txtBxMemory.Text);

            _tablets.Add(t);

            UpdateGrid();

            txtBxCost.Clear();
            txtBxMemory.Clear();
            txtBxModel.Clear();
            txtBxRating.Clear();
        }
    }
}
