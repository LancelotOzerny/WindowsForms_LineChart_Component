using System;
using System.Windows.Forms;

namespace LabWork6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Создаем функции
            Fx sin = new Fx();
            Fx cos = new Fx();
            Fx giperbola = new Fx();

            // Добавляем значения в графики
            for (float x = -5; x < 5; x += 0.2f)
            {
                sin.AddPoint(x, (float)Math.Sin(x));
                cos.AddPoint(x, (float)Math.Cos(x));
                giperbola.AddPoint(x, (float)(x * x / 50));
            }

            // Меняем толщину линий
            sin.LineWidth = 2;
            cos.LineWidth = 2;
            giperbola.LineWidth = 2;

            // Меняем цвет линий
            sin.LineColor = System.Drawing.Color.Red;
            cos.LineColor = System.Drawing.Color.Green;
            giperbola.LineColor = System.Drawing.Color.Blue;

            // Добавляем графики на отрисовку в компонент
            grapher.AddFunction(sin);
            grapher.AddFunction(cos);
            grapher.AddFunction(giperbola);
        }
    }
}
