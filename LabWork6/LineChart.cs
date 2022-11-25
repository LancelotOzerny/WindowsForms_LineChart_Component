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
    [Serializable]
    public partial class LineChart : UserControl
    {
        // Отрисовка (функции + таймер отрисовки)
        private List<Fx> _functions = new List<Fx>();
        private Timer _timer = new Timer();


        // Средства отрисовки
        private Pen _defaultPencil = new Pen(Color.DarkGray, 2);


        // Отступы
        private float _margin = 20;


        // Высота и ширина области рисования
        private float _widthArea;
        private float _heightArea;


        /// <summary>
        /// Свойство, которое позволяет получить или задать отступы по бокам для графика
        /// </summary>
        public float ChartMargin
        {
            get => _margin;
            set
            {
                if (value > 0)
                {
                    _margin = value;
                }
            }
        }

        /// <summary>
        /// Конструктор по умолчанию, который задает начальные значения и вычисляет область рисования
        /// </summary>
        public LineChart()
        {
            InitializeComponent();

            _timer.Interval = 100;
            _timer.Tick += (delegate { Invalidate(); });
            _timer.Start();
        }

        /// <summary>
        /// Метод, который позволяет добавить к отрисовке какой-либо график
        /// </summary>
        /// <param name="function">функция для отрисовки</param>
        public void AddFunction(Fx function)
        {
            _functions.Add(function);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (_functions.Count == 0 || _functions.Max(x => x.Points.Count) == 0)
            {
                DrawZeroAxis(canvas);
            }
            else
            {
                if (_functions.Count > 0)
                {
                    listBox1.Items.Clear();

                    // Вычисление ширины и высоты экрана рисования
                    _widthArea = (float)Width - _margin * 2;
                    _heightArea = (float)Height - _margin * 2;

                    float offsetX = 0;
                    float offsetY = 0;

                    float minX = _functions.Min(x => x.GetMinX());
                    float maxX = _functions.Max(x => x.GetMaxX());

                    float minY = _functions.Min(y => y.GetMinY());
                    float maxY = _functions.Max(y => y.GetMaxY());

                    listBox1.Items.Add($"Width: {Width}");
                    listBox1.Items.Add($"_widthArea: {_widthArea}");

                    float _stepX = _widthArea / (maxX - minX);
                    float _stepY = _heightArea / (maxY - minY);

                    offsetY = minY < 0 ? Math.Abs(minY) : 0;
                    offsetX = minX < 0 ? Math.Abs(minX) : 0;

                    // ось X
                    canvas.DrawLine(
                        _defaultPencil,
                        _margin,
                        Height - _margin - offsetY * _stepY,
                        Width - _margin,
                        Height - _margin - offsetY * _stepY
                    );

                    // ось Y
                    canvas.DrawLine(
                        _defaultPencil,
                        _margin + offsetX * _stepX,
                        _margin,
                        _margin + offsetX * _stepX,
                        Height - _margin
                    );

                    foreach (Fx func in _functions)
                    {
                        for (int i = 0; i < func.Points.Count - 1; ++i)
                        {
                            canvas.DrawLine(
                                func.Pencil,
                                _margin + (func.Points[i].X + offsetX) * _stepX,
                                _margin + _heightArea - (func.Points[i].Y + offsetY) * _stepY,
                                _margin + (func.Points[i + 1].X + offsetX) * _stepX,
                                _margin + _heightArea - (func.Points[i + 1].Y + offsetY) * _stepY
                            );
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод, который отрисовывает оси при условии, что массив графиков пуст, т.е. оси находятся слева
        /// </summary>
        /// <param name="canvas"></param>
        private void DrawZeroAxis(Graphics canvas)
        {
            // ось X
            canvas.DrawLine(
                _defaultPencil,
                _margin,
                Height - _margin,
                Width - _margin,
                Height - _margin
            );

            // ось Y
            canvas.DrawLine(
                _defaultPencil,
                _margin,
                _margin,
                _margin,
                Height - _margin
            );
        }
    }
}
