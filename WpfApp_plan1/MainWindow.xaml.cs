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
using System.Data;

namespace WpfApp_plan1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
            foreach (UIElement el in MainRoot.Children)
            {
                if (el is Button) //Проверяем является ли объект классом (кнопка), ели да то добавляем обработчик события
                {
                    ((Button)el).Click += Button_Click; //преобразование обьекта в класса Button
                }
            }           
            textBox.MaxLength = 10; // Максимальное количество ввода символов с клавиатуры 
            
        }

        private void Button_Click(object sender, RoutedEventArgs e) // метод Button_Click
        {
            string srt_val = (string)((Button)e.OriginalSource).Content;

            /// <summary>
            /// Берём обьект на основе класса (RoutedEventArgs) > преобразуем к классу Button 
            /// Далее берём(OriginalSource) сам обьект > получаем контент т.е.получаем ту надпись которая находится на самом объекте >
            /// > и это всё преобразуем к строке(string)
            /// </summary>
            switch (srt_val)
            {
                case "Del":
                    textBox.Clear();
                    break;

                case "BS":
                    if (textBox.Text.Length == 0)
                    {
                        textBox.Clear(); // и возвращает пустую строку (решение временное!)
                        break;
                    }
                    else
                    {
                        textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1); // удоляем предыдущий индекс масива
                    }
                    break;

                case "=":
                    /// <summary>
                    /// Внутри локальной переменной создаём объект класса (DataTable) >
                    ///  > обращаемся к методу (Compute), он позволят высчитать математическую операцию и в качестве 
                    ///  .. пораметра может принимать строчный тип данных > обращаемся к (textLabel.Text) null это значение фильтра >
                    ///  всё это приобразуем в строку с помощью (ToString()) > значение (value) устанавливаем в ..
                    ///  .. качестве нового значения  (textLabel.Text) 
                    /// </summary>
                    string value = new DataTable().Compute(textBox.Text, null).ToString();
                    textBox.Text = value;
                    break;

                case ".":
                    if (textBox.Text.Length == 0 && srt_val == ".")
                        textBox.Text = textBox.Text.Insert(textBox.Text.Length, "0.");
                    break;
                default:
                    textBox.Text += srt_val;// Обращаемся к полю (окно заполнения) и с каждым новым нажатием на цифру или символ добавляем его в поле 
                    break;

            }
           
        }

    }
}
