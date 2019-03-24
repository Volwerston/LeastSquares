using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace LeastSquares.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var xData = X.Text;
            var yData = Y.Text;

            if (string.IsNullOrWhiteSpace(xData))
            {
                MessageBox.Show("Incorrect input: X");
                return;
            }

            if (string.IsNullOrWhiteSpace(yData))
            {
                MessageBox.Show("Incorrect input: Y");
                return;
            }

            var xDouble = xData
                .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(xVal => 
                    Convert.ToDouble(
                    xVal.Trim(),
                    CultureInfo.InvariantCulture))
                .ToArray();

            if (xDouble.Length == 1)
            {
                MessageBox.Show("Number of x values must be > 1");
                return;
            }

            var yDouble = yData
                .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(yVal =>
                    Convert.ToDouble(
                        yVal.Trim(),
                        CultureInfo.InvariantCulture))
                .ToArray();

            if (xDouble.Length != yDouble.Length)
            {
                MessageBox.Show("Number of x and y values is different");
                return;
            }

            var yLine = LeastSquaresAlgorithm.LeastSquaresAlgorithm.Calculate(
                xDouble.Length,
                xDouble,
                yDouble);

            var lineChartInfo = xDouble
                    .Zip(yLine, (x, y) => new KeyValuePair<double, double>(x, y))
                    .ToList();

            var pointsInfo = xDouble
                .Zip(yDouble, (x, y) => new KeyValuePair<double, double>(x, y))
                .ToList();

            var dataSourceList = new List<List<KeyValuePair<double, double>>>
            {
                pointsInfo,
                lineChartInfo
            };

            var cr = new CalculationResult
            {
                DataContext = dataSourceList
            };

            cr.Show();
        }
    }
}
