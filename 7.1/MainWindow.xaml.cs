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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> resources = new List<string>
        {
            "Организация рогатых и копытных спортивных соревнований (козы, овцы, коровы, быки)",
            "Организация рогатых вечеринок (олени, лоси, бараны)",
            "Организация копытных вечеринок (лошади, зебры, ослы)",
            "Обучение рогатым и копытным танцам (козы, овцы, коровы, быки, олени, лоси, бараны)",
            "Курсы верховой езды на свинье",
            "Курсы по рогатой йоге (козы, овцы, коровы)",
            "Продажа рогатых и копытных сувениров"
        };

        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();

            // Заполняем список ресурсов
            foreach (string resource in resources)
            {
                ListBoxItem item = new ListBoxItem { Content = resource };// Создаем новый элемент ListBoxItem         
                item.MouseEnter += ListBoxItem_MouseEnter;// Добавляем обработчик события для изменения цвета текста
                item.MouseLeave += ListBoxItem_MouseLeave; // Добавлен обработчик для возврата к исходному цвету               
                userList.Items.Add(item);// Добавляем элемент в ListBox
            }
        }
        // Обработчик события MouseEnter для изменения цвета текста
        private void ListBoxItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)sender;
            Color color = Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));// Генерируем случайный цвет
            item.Foreground = new SolidColorBrush(color);// Изменяем цвет текста
        }
        // Обработчик события MouseLeave для возврата к исходному цвету
        private void ListBoxItem_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)sender;
            item.Foreground = new SolidColorBrush(Colors.Black);//Возвращаем исходный цвет
        }
        //Метод, который будет вызываться при выборе элемента в ListBox
        private void userList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (userList.SelectedItem != null)
            {
                string selectedItemText = ((ListBoxItem)userList.SelectedItem).Content.ToString();// Получаем текст выбранного элемента
                MessageBox.Show($"Вы выбрали: {selectedItemText}", "Информация");// Выводим сообщение с информацией о выбранной услуге 
            }
        }
    }
}
