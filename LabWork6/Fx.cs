using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork6
{
    public class Fx
    {
        /// <summary>
        /// Коллекция точек [X;Y] графика
        /// </summary>
        private List<PointF> _points = new List<PointF>();
        private Color _lineColor = Color.DarkGray;
        private float _lineWidth = 1;
        private Pen _pencil;

        /// <summary>
        /// Свойство, которое позволяе получить или установить массив точек графика
        /// </summary>
        public List<PointF> Points { get => _points; set => _points = value; }

        /// <summary>
        /// Свойство, которое позволяет проверить пустой ли массив точек в графике
        /// </summary>
        public bool IsEmpty { get => _points.Count == 0; }

        /// <summary>
        /// Свойство, которое позволяет получить или установить значение ширины линии графика
        /// </summary>
        public float LineWidth
        {
            get => _lineWidth;
            set
            {
                _lineWidth = (value > 0 ? value : _lineWidth = 0);
                SetPencil(_lineColor, _lineWidth);
            }
        }

        /// <summary>
        /// Свойство, которое позволяет установить или получить значение цвета линии графика
        /// </summary>
        public Color LineColor
        {
            get => _lineColor;
            set
            {
                _lineColor = value;
                SetPencil(_lineColor, _lineWidth);
            }
        }

        /// <summary>
        /// Свойство, которое возвращает текущий "карандаш" графика
        /// </summary>
        public Pen Pencil { get => _pencil; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Fx()
        {
            _pencil = new Pen(_lineColor, _lineWidth);
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Fx(Color color)
        {
            _lineColor = color;
            SetPencil(_lineColor, _lineWidth);
        }

        /// <summary>
        /// Метод, который позволяет установить значения цвета и ширины "карандаша" для графика
        /// </summary>
        /// <param name="color">цвет "карандаша"</param>
        /// <param name="width">ширина "карандаша"</param>
        public void SetPencil(Color color, float width)
        {
            _pencil = new Pen(_lineColor, _lineWidth);
        }

        /// <summary>
        /// Метод, которй позволяет добавить новую точку в график
        /// </summary>
        /// <param name="x">значение точки по оси X</param>
        /// <param name="y">значение точки по оси Y</param>
        public void AddPoint(float x, float y)
        {
            _points.Add(new PointF(x, y));
        }

        /// <summary>
        /// Метод, позволяющий получить максимальное значение X в графике
        /// </summary>
        /// <returns>максимальное X значение в графике</returns>
        public float GetMaxX()
        {
            return _points.Max(x => x.X);
        }
        /// <summary>
        /// Метод, позволяющий получить максимальное значение Y в графике
        /// </summary>
        /// <returns>максимальное Y значение в графике</returns>
        public float GetMaxY()
        {
            return _points.Max(y => y.Y);
        }
        /// <summary>
        /// Метод, позволяющий получить минимальное значение X в графике
        /// </summary>
        /// <returns>минимальное значение X в графике</returns>
        public float GetMinX()
        {
            return _points.Min(x => x.X);
        }
        /// <summary>
        /// Метод, позволяющий получить минимальное значение Y в графике
        /// </summary>
        /// <returns>минимальное значение Y в графике</returns>
        public float GetMinY()
        {
            return _points.Min(y => y.Y);
        }
    }
}
