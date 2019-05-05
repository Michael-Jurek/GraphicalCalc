using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using SimpleCalc.Model;

namespace SimpleCalc.ViewModel
{
    public class FunctionsViewModel
    {
        private double minX, maxX, minY, maxY;
        private Matrix WtoDMatrix, DtoWMatrix;

        #region Matrix Transformation - from left upper to right down
        
        // Transform a point from world to device coordinates
        private Point WtoD(Point point)
        {
            return WtoDMatrix.Transform(point);
        }

        // Transform a point from device to world coordinates
        private Point DtoW(Point point)
        {
            return DtoWMatrix.Transform(point);
        }

        private void PrepareTransformations(double minWx, double maxWx, double minWy, double maxWy, double minDx,
            double maxDx, double maxDy, double minDy)
        {
            // Make WtoD matrix
            WtoDMatrix = Matrix.Identity;
            WtoDMatrix.Translate(-minWx, -minWy);

            double scaleX = (maxDx - minDx) / (maxWx - minWx);
            double scaleY = (maxDy - minDy) / (maxWy - minWy);
            WtoDMatrix.Scale(scaleX, scaleY);

            WtoDMatrix.Translate(minDx, minDy);

            // Make DtoW matrix
            DtoWMatrix = WtoDMatrix;
            DtoWMatrix.Invert();
        }

        #endregion

        #region Basic Cross Axis Loaded

        public void Loaded(Canvas graphPlate, double minX, double maxX, double minY, double maxY)
        {
            // initializing ranges
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;

            // WORLD Boundaries - x, y ranges
            double minWx = minX; // world boundaries of x Axis below 0
            double maxWx = maxX; // world boundaries of x Axis
            double minWy = minY; // y Axis
            double maxWy = maxY; // y Axis
            double STEPX = (maxX - minX)/20; // step on X axis
            double STEPY = (maxY-minY)/20;  // step on Y axis

            // Device Boundaries - canvas boundaries - margin
            const double DMARGIN = 10;
            double minDx = DMARGIN;
            double maxDx = graphPlate.Width - DMARGIN;
            double minDy = DMARGIN;
            double maxDy = graphPlate.Height - DMARGIN;

            // prepare the transoframtion matrices
            PrepareTransformations(
                minWx, maxWx, minWy, maxWy,
                minDx, maxDx, maxDy, minDy
            );

            // Get the tic mark length
            Point p0 = DtoW(new Point(0, 0));
            Point p1 = DtoW(new Point(5, 5));
            double xtic = p1.X - p0.X;
            double ytic = p1.Y - p0.Y;

            // Make the X Axis
            GeometryGroup xaxisGeom = new GeometryGroup();
            p0 = new Point(minWx, 0);
            p1 = new Point(maxWx, 0);
            xaxisGeom.Children.Add(new LineGeometry(WtoD(p0), WtoD(p1)));

            for (double x = STEPX; x <= maxWx - STEPX; x += STEPX)
            {
                // Add the tic mark
                Point tic0 = WtoD(new Point(x, -ytic));
                Point tic1 = WtoD(new Point(x, ytic));
                xaxisGeom.Children.Add(new LineGeometry(tic0, tic1));

                // Label the tic mark's X coordinates
                DrawText(graphPlate, x.ToString(),
                    new Point(tic0.X, tic0.Y + 5), 0, 12,
                    HorizontalAlignment.Center,
                    VerticalAlignment.Top);
            }

            // Draws line
            Path xaxisPath = new Path();
            xaxisPath.StrokeThickness = 1;
            xaxisPath.Stroke = Brushes.Black;
            xaxisPath.Data = xaxisGeom;

            graphPlate.Children.Add(xaxisPath);


            // Make the Y axis
            GeometryGroup yaxisGeom = new GeometryGroup();
            p0 = new Point(0, minWy);
            p1 = new Point(0, maxWy);
            yaxisGeom.Children.Add(new LineGeometry(WtoD(p0), WtoD(p1)));

            for (double y = STEPY; y <= maxWy - STEPY; y += STEPY)
            {
                // Add the tic mark
                Point tic0 = WtoD(new Point(-xtic, y));
                Point tic1 = WtoD(new Point(xtic, y));
                yaxisGeom.Children.Add(new LineGeometry(tic0, tic1));

                DrawText(graphPlate, y.ToString(),
                    new Point(tic0.X - 10, tic0.Y), -90, 12,
                    HorizontalAlignment.Center,
                    VerticalAlignment.Center);
            }

            Path yaxisPath = new Path();
            yaxisPath.StrokeThickness = 1;
            yaxisPath.Stroke = Brushes.Black;
            yaxisPath.Data = yaxisGeom;

            graphPlate.Children.Add(yaxisPath);

        }

        #endregion

        #region Draw Labels

        // Position a Label at the indicated point
        private void DrawText(Canvas graphPlate, string text,
            Point location, double angle, double fontSize,
            HorizontalAlignment hAlign, VerticalAlignment vAlign)
        {
            // Make the label
            Label label = new Label();
            label.Content = text;
            label.FontSize = fontSize;

            // Rotate if desired
            if (angle != 0) label.LayoutTransform = new RotateTransform(angle);

            // Position the label
            label.Measure(new Size(double.MaxValue, double.MaxValue));

            // x position of label
            double x = location.X;
            if (hAlign == HorizontalAlignment.Center)
                x -= label.DesiredSize.Width / 2;
            else if (hAlign == HorizontalAlignment.Right)
                x -= label.DesiredSize.Width;
            Canvas.SetLeft(label, x);

            // y position of label
            double y = location.Y;
            if (vAlign == VerticalAlignment.Center)
                y -= label.DesiredSize.Height / 2;
            else if (vAlign == VerticalAlignment.Bottom)
                y -= label.DesiredSize.Height;
            Canvas.SetTop(label, y);
        }

        #endregion


        public void Refresh(Canvas graphFunctions,ListBox list,TextBox minx, TextBox miny, TextBox maxx, TextBox maxy)
        {
           
           this.minX = Convert.ToDouble(minx.Text);
           this.maxX = Convert.ToDouble(maxx.Text);
           this.minY = Convert.ToDouble(miny.Text);
           this.maxY = Convert.ToDouble(maxy.Text);

           Loaded(graphFunctions, minX, maxX, minY, maxY);

            for (int i = 0; i < list.Items.Count; i++)
           {
               FunctionColor fc = list.Items[i] as FunctionColor;
               DrawFunction(graphFunctions, fc.Function, fc.Color);
           }

        }

        #region DrawFunction 
        // Draw function
        public void DrawFunction(Canvas graphFunctions, string function, Color functionColor)
        {
            // creates syntax tree
            SyntaxTree calculator = new SyntaxTree(function);

            GeometryGroup g = new GeometryGroup();

            Point currentPoint = new Point();
            Point previousPoint = new Point();
            bool isCurrentPoint = false;
            bool isPreviousPoint = false;

            Brush brush = new SolidColorBrush(functionColor);


            // for each x point calclulates y with step of range x divided by canvas width => x+=step of each point
            for (double x = minX; x < maxX; x += (maxX - minX) / graphFunctions.Width)
            {
                // calculates y value for each x point
                double y = calculator.Calculate(x, out isCurrentPoint);
                
                    if (Math.Abs(y) > maxY * 2) isCurrentPoint = false;
                    if (isCurrentPoint)
                    {
                        currentPoint.X = (x / ((maxY - minX) / graphFunctions.Width) -
                                          minX / ((maxX - minX) / graphFunctions.Width));
                        currentPoint.Y = (graphFunctions.Height -
                                          (y / ((maxY - minY) / graphFunctions.Height) -
                                           minY / ((maxY - minY) / graphFunctions.Height)));
                        if (isPreviousPoint)
                        {
                            // connect prev and current point with line
                            g.Children.Add(new LineGeometry(
                                previousPoint,
                                currentPoint));

                            Path functionPath = new Path();
                            functionPath.StrokeThickness = 1;
                            functionPath.Stroke = brush;
                            functionPath.Data = g;

                            graphFunctions.Children.Add(functionPath);
                        }
                    }
                
                // set current point to previous till the end of canvas
                previousPoint = currentPoint;
                isPreviousPoint = isCurrentPoint;
            }
        }


        #endregion
    }
}
