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


        // Подписи осей
        private string _axisXName = "X";
        private string _axisYName = "Y";
        private Label _labelXName = new Label();
        private Label _labelYName = new Label();


        // Отступы
        private float _margin = 20;


        // Высота и ширина области рисования
        private float _widthArea;
        private float _heightArea;


        // Начало и конец интервалов 
        private PointF _startValues = new PointF(-1, -1);
        private PointF _endValues = new PointF(1, 1);










        public string AxisXName
        {
            get => _axisXName;
            set => _axisXName = value;
        }

        public string AxisYName
        {
            get => _axisYName;
            set => _axisYName = value;
        }

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

            Controls.Add(_labelXName);
            Controls.Add(_labelYName);

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true
            );
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

            // Вычисление ширины и высоты экрана рисования
            _widthArea = (float)Width - _margin * 2;
            _heightArea = (float)Height - _margin * 2;

            PointF offset = new PointF(0, 0);

            bool intervalChanged = false;

            for (int i = 0; i < _functions.Count; ++i)
            {
                if (!_functions[i].IsEmpty)
                {
                    if (!intervalChanged)
                    {
                        _startValues.X = _functions[i].GetMinX();
                        _startValues.Y = _functions[i].GetMinY();

                        _endValues.X = _functions[i].GetMaxX();
                        _endValues.Y = _functions[i].GetMaxY();

                        intervalChanged = true;
                        continue;
                    }

                    _startValues.X = _startValues.X < _functions[i].GetMinX() ? _startValues.X : _functions[i].GetMinX();
                    _endValues.X = _endValues.X > _functions[i].GetMaxX() ? _endValues.X : _functions[i].GetMaxX();

                    _startValues.Y = _startValues.Y < _functions[i].GetMinY() ? _startValues.Y : _functions[i].GetMinY();
                    _endValues.Y = _endValues.Y > _functions[i].GetMaxY() ? _endValues.Y : _functions[i].GetMaxY();
                }
            }

            float _stepX = Math.Abs(_widthArea / (_endValues.X - _startValues.X));
            float _stepY = Math.Abs(_heightArea / (_endValues.Y - _startValues.Y));

            
            offset.X = _startValues.X < 0 ? Math.Abs(_startValues.X) : -_startValues.X;
            offset.Y = _startValues.Y < 0 ? Math.Abs(_startValues.Y) : _startValues.Y;


            listBox1.Items.Clear();
            listBox1.Items.Add($"min X = {_startValues.X}");
            listBox1.Items.Add($"max X = {_endValues.X}");
            listBox1.Items.Add($"");
            listBox1.Items.Add($"min Y = {_startValues.Y}");
            listBox1.Items.Add($"max Y = {_endValues.Y}");
            listBox1.Items.Add($"");
            listBox1.Items.Add($"step X = {_stepX}");
            listBox1.Items.Add($"step Y = {_stepY}");

            // ось X
            if (_startValues.Y <= 0)
            {
                canvas.DrawLine(
                    _defaultPencil,
                    _margin,
                    Height - _margin - offset.Y * _stepY,
                    Width - _margin,
                    Height - _margin - offset.Y * _stepY
                );
            }

            // ось Y
            if (_startValues.X <= 0)
            {
                canvas.DrawLine(
                    _defaultPencil,
                    _margin + offset.X * _stepX,
                    _margin,
                    _margin + offset.X * _stepX,
                    Height - _margin
                );
            }
            
            // Установка Label-ов
            _labelXName.Location = new Point(
                (int)(Width - _margin - _labelXName.Text.Length * _labelXName.Font.Size),
                (int)(Height - _margin - offset.Y * _stepY - _labelXName.Font.Size * 2)
            );
            _labelXName.Text = _axisXName;

            _labelYName.Location = new Point(
                (int)(_margin + offset.X * _stepX + _labelYName.Font.Size * 2),
                (int)(_margin)
            );
            _labelYName.Text = _axisYName;


            if (_functions.Count != 0 && _functions.Max(x => x.Points.Count) != 0)
            {
                if (_functions.Count > 0)
                {
                    foreach (Fx func in _functions)
                    {
                        for (int i = 0; i < func.Points.Count - 1; ++i)
                        {
                            canvas.DrawLine(
                                func.Pencil,
                                _margin + (func.Points[i].X + offset.X) * _stepX,
                                _margin + _heightArea - (func.Points[i].Y + offset.Y) * _stepY,
                                _margin + (func.Points[i + 1].X + offset.X) * _stepX,
                                _margin + _heightArea - (func.Points[i + 1].Y + offset.Y) * _stepY
                            );
                        }
                    }
                }
            }
        }
    }
}
