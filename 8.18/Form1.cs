using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tools;

namespace _8._18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CalcBtn_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> list = ConvertList.StrToList(ListInput.Text);
                ToolsList toolsList = new ToolsList(list);
                List<int> listNew = toolsList.Process(out bool success);
                Output.Text = ConvertList.ListToStr(listNew) + "\n" + (success ? "успешно" : "не успешно");
            }
            catch (Exception)
            {
                MessageBox.Show("ошибка ввода", "ошибка");
            }
        }
    }
}
