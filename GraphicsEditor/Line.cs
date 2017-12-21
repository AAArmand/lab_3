﻿using DrawablesUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor {
    class Line : IShape, IDescription {
        private Point Beginning { get; set; }

        public DescriptionData Description { get; private set; }

        private Point End{ get; set; }

        public FormatInfo Format { get; set; }

        public Line(Point first, Point second) {
            Beginning = first;
            End = second;
            Description = new DescriptionData("Линия(" + first.Description + ", " + second.Description + ")");
            Format = new FormatInfo();
        }

        public void Draw(IDrawer drawer) {
            drawer.SelectPen(Format.Color, Format.Width);
            drawer.DrawLine(Beginning.Сoordinates, End.Сoordinates);
        }

        public void Transform(Transformation trans) {

        }

    }
}
