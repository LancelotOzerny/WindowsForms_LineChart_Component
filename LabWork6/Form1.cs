using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabWork6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Инициализация графиков
            Fx sin = new Fx();
            Fx cos = new Fx();
            Fx myGrap = new Fx();

            // Меняем их цвет
            sin.LineColor = Color.Blue;
            cos.LineColor = Color.Red;
            myGrap.LineColor = Color.Green;

            // Меняем их ширину
            sin.LineWidth = 1;
            cos.LineWidth = 2;
            myGrap.LineWidth = 3;

            // График синуса
            for (float x = -10; x <= 10; x += 0.2f)
            {
                sin.AddPoint(x, (float)Math.Sin(x));
            }

            // График косинуса
            for (float x = -10; x <= 10; x += 0.2f)
            {
                cos.AddPoint(x, (float)Math.Cos(x));
            }

            // График параболы
            for (float x = -4; x <= 4; x += 0.1f)
            {
                myGrap.AddPoint(x, (float)(x * x));
            }

            // Добавляем графики на экран
            grapher.AddFunction(sin);
            grapher.AddFunction(cos);
            grapher.AddFunction(myGrap);
        }
    }
}
