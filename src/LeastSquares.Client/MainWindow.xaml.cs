using System;
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
            }

            if (string.IsNullOrWhiteSpace(yData))
            {
                MessageBox.Show("Incorrect input: Y");
            }

            var xDouble = xData
                .Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(xVal => Convert.ToDouble(xVal.Trim()))
                .ToArray();

            var yDouble = yData
                .Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(yVal => Convert.ToDouble(yVal.Trim()))
                .ToArray();

            var yLine = LeastSquaresAlgorithm.LeastSquaresAlgorithm.Calculate(
                xDouble.Length,
                xDouble,
                yDouble);

            MessageBox.Show(string.Join(
                ";",
                yLine.Select(a => a)));
        }
    }
}
