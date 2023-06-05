using System;
using System.Drawing;
using System.Windows.Forms;

namespace CGLab
{
    public partial class Form1 : Form
    {
        private Point _startPoint;
        private Pen _pen;
        private bool _mouseButton;

        public Form1()
        {
            InitializeComponent();
            MouseDown += Mouse_Down;
            MouseUp += Mouse_Up;
            MouseMove+= DrawStraight;
        }

        private void Color_Click(object sender, EventArgs e)
        {

            ColorDialog MyDialog = new ColorDialog();

            MyDialog.AllowFullOpen = false;

            MyDialog.ShowHelp = true;

            MyDialog.Color = Width.ForeColor;


            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                Color.BackColor = MyDialog.Color;
                Color.ForeColor = MyDialog.Color;
            }
        }


        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            _pen = new Pen(Color.BackColor, (int)Width.Value);
            _startPoint = e.Location;
            _mouseButton = true;
        }

        private void Mouse_Up(object sender, MouseEventArgs e)
        {
            _startPoint = MousePosition;
            _mouseButton = false;
        }

        private void DrawStraight(object sender, MouseEventArgs e)
        {
            if (!_mouseButton) return;
            var graph = this.CreateGraphics();
            graph.Clear(System.Drawing.Color.FromArgb(255, 227, 227, 227));
            Point startPoint = new Point(_startPoint.X, _startPoint.Y);
            Point endPoint = new Point(e.Location.X, e.Location.Y);
            int x = startPoint.X;
            int y = startPoint.Y;
            int Dx = endPoint.X - startPoint.X;
            int Dy = endPoint.Y - startPoint.Y;
            int er = 2 * Dy - Dx;
            for (int i = 1; i < Dx; i++)
            {
                graph.FillRectangle(_pen.Brush, x, y, 1, 1);

                if (er >= 0)
                {
                    y++;
                    er -= 2 * Dx;
                }
                x++;
                er += 2 * Dy;
            }
        }
    }
}
