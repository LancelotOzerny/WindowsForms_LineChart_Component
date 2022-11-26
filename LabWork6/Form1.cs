using System;
using System.Drawing;
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

            // Меняем цвет графиков
            sin.LineColor = Color.Blue;
            cos.LineColor = Color.Red;
            myGrap.LineColor = Color.Green;

            // Меняем ширину графиков
            sin.LineWidth = 1;
            cos.LineWidth = 2;
            myGrap.LineWidth = 3;

            // Добавляем точки синуса
            for (float x = -5f; x <= 5; x += 0.02f)
            {
                sin.AddPoint(x, Math.Abs((float)Math.Sin(x)));
            }

            // Добавляем точки косинуса
            for (float x = -5; x <= 10; x += 0.02f)
            {
                cos.AddPoint(x, Math.Abs((float)Math.Cos(x)));
            }

            // Добавляем точки параболы
            for (float x = -5; x <= 1.2f; x += 0.01f)
            {
                myGrap.AddPoint(x, (float)(x * x));
            }

            // Добавляем графики на экран
            grapher.AddFunction(sin);
            grapher.AddFunction(cos);
            grapher.AddFunction(myGrap);
            grapher.AddFunction(new Fx()); // Пустой график
        }
    }
}
