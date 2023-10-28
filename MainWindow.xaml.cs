using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _22107_Ochapova
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void GenerateAndSortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int size = int.Parse(sizeTextBox.Text);
                int minValue = int.Parse(minValueTextBox.Text);
                int maxValue = int.Parse(maxValueTextBox.Text);

                int[] array = GenerateArray(size, minValue, maxValue);
                SortArray(array);

                string result = string.Join(", ", array);
                resultLabel.Content = result;

            }
            catch (Exception ex)
            {
                resultLabel.Content = "Ошибка: " + ex.Message;
            }

        }

        private int[] GenerateArray(int size, int minValue, int maxValue)
        {
            Random random = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(minValue, maxValue + 1);
            }

            return array;
        }

        private void SortArray(int[] array)
        {
            Array.Sort(array, (x, y) => // => определяет порядок сортировки элементов в массиве. массив сортируется так, что четные числа идут перед нечетными.
            {
                if (x % 2 == 0 && y % 2 != 0)
                    return -1;
                if (x % 2 != 0 && y % 2 == 0)
                    return 1;
                return 0;
            });
        }
    }
}
