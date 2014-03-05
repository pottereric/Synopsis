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
        private PathFigureCollection pathFigureCollection;

        public ArcAdder(Canvas layoutRoot)
        {
            _root = layoutRoot;
            pathFigureCollection = new PathFigureCollection();
        }

        public void AddCollectionToCanvas()
        {
            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pathFigureCollection;

            Path arcPath = new Path();
            arcPath.Stroke = new SolidColorBrush(Colors.Black);
            arcPath.StrokeThickness = 1;
            arcPath.Data = pathGeometry;
            _root.Children.Add(arcPath);
        }

        public PathFigure AddArc(int start, int end)
        {
            int horizontalPostion = 100;

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(horizontalPostion, start);

            ArcSegment arcSeg = new ArcSegment();
            arcSeg.Point = new Point(horizontalPostion, end);
            arcSeg.Size = new Size(25, 25);
            arcSeg.IsLargeArc = true;
            arcSeg.SweepDirection = SweepDirection.Clockwise;
            arcSeg.RotationAngle = 90;

            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
            myPathSegmentCollection.Add(arcSeg);
            pathFigure.Segments = myPathSegmentCollection;

            pathFigureCollection.Add(pathFigure);

            return pathFigure;
        }
    }
}
