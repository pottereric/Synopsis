using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SynopsisViews.Tools
{
    class ArcAdder
    {
        private Canvas _root;
        private PathFigureCollection _pathFigureCollection;

        public ArcAdder(Canvas layoutRoot)
        {
            _root = layoutRoot;
            _pathFigureCollection = new PathFigureCollection();
        }

        public void AddCollectionToCanvas()
        {
            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = _pathFigureCollection;

            Path arcPath = new Path();
            arcPath.Stroke = new SolidColorBrush(Colors.Black);
            arcPath.StrokeThickness = 1;
            arcPath.Data = pathGeometry;
            _root.Children.Add(arcPath);
        }

        public PathFigure AddArc(int start, int end)
        {
            int horizontalPostion = 100;


            var startPoint = new Point(horizontalPostion, start);
            var endPoint = new Point(horizontalPostion, end);

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = startPoint;

            ArcSegment arcSeg = new ArcSegment();
            arcSeg.Point = endPoint;
            arcSeg.Size = new Size(25, 25);
            arcSeg.IsLargeArc = true;
            arcSeg.SweepDirection = SweepDirection.Clockwise;
            arcSeg.RotationAngle = 90;

            var arrowhead = new Polygon();
            arrowhead.Stroke = Brushes.Black;
            arrowhead.StrokeThickness = 2;
            arrowhead.Points.Add(new Point(endPoint.X - 4, endPoint.Y));
            arrowhead.Points.Add(new Point(endPoint.X + 4, endPoint.Y + 3));
            arrowhead.Points.Add(new Point(endPoint.X + 4, endPoint.Y - 3));
            arrowhead.Fill = Brushes.Black;

            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
            myPathSegmentCollection.Add(arcSeg);
            pathFigure.Segments = myPathSegmentCollection;

            _pathFigureCollection.Add(pathFigure);

            _root.Children.Add(arrowhead);

            return pathFigure;
        }
    }
}
