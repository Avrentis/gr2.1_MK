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

namespace _6._18
{ //Условие задачи: 18.	Дана строка. Определить, стоят ли в данной строке подряд символы ′а′ и ′б′.
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CheckBtn_Click(object sender, EventArgs e)
        {
            string input = Input.Text;
            ToolsStr str = new ToolsStr(input);
            bool check = str.CheckOn('а', 'б');
            if (check)
                output.Text = "удволетворяет условию";
            else
                output.Text = "не удволетворяет условию";
        }
    }
}
