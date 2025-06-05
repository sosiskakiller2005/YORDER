using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using YORDER.AppData;
using YORDER.Model;

namespace YORDER.Views.Pages
{
    public partial class NewOrderPage : Page
    {
        private byte[] selectedPhotoBytes; // Заполняется в SelectFileBtn_Click
        private static YORDERDbEntities _context = App.GetContext();
        public NewOrderPage()
        {
            InitializeComponent();
            PaymentMethodCmb.ItemsSource = _context.PaymentMethod.ToList();
            PaymentMethodCmb.DisplayMemberPath = "Name";
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // Попытка преобразовать сумму
            decimal amount;
            bool amountParsed = decimal.TryParse(AmountTb.Text, out amount);

            // Проверка всех обязательных полей в одном условии
            if (string.IsNullOrWhiteSpace(NameTb.Text)
                || string.IsNullOrWhiteSpace(PhoneTb.Text)
                || string.IsNullOrWhiteSpace(MaterialsTb.Text)
                || selectedPhotoBytes == null || selectedPhotoBytes.Length == 0
                || !StartDateDp.SelectedDate.HasValue
                || !EndDateDp.SelectedDate.HasValue
                || string.IsNullOrWhiteSpace(DescriptionTb.Text)
                || string.IsNullOrWhiteSpace(AdressTb.Text)
                || PaymentMethodCmb.SelectedItem == null
                || !amountParsed || amount <= 0)
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля и выберите фотографию.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Получение выбранного способа оплаты
            var paymentMethod = PaymentMethodCmb.SelectedItem as PaymentMethod;

            // Создание нового заказа
            var order = new Order
            {
                ClientName = NameTb.Text.Trim(),
                ClientPhone = PhoneTb.Text.Trim(),
                Materials = MaterialsTb.Text.Trim(),
                Photo = selectedPhotoBytes,
                StartDate = StartDateDp.SelectedDate.Value,
                EndDate = EndDateDp.SelectedDate.Value,
                Description = DescriptionTb.Text.Trim(),
                Adress = AdressTb.Text.Trim(),
                PaymentMethodId = paymentMethod.Id,
                Amount = amount,
                User = AuthorisationHelper.selectedUser,
                Status = _context.Status.First()
                // Заполните остальные поля по необходимости
            };


            // Сохранение заказа (пример для EF)
            _context.Order.Add(order);
            _context.SaveChanges();
            MessageBoxHelper.Information("Заказ успешно добавлен!");
            // Очистка формы или переход на другую страницу по необходимости
            FrameHelper.selectedFrame.Navigate(new OrdersPage());   
        }

        // Пример обработчика выбора файла  
        private void SelectFileBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Все файлы (*.*)|*.*"
            };
            if (dialog.ShowDialog() == true)
            {
                selectedPhotoBytes = System.IO.File.ReadAllBytes(dialog.FileName);
                FileNameTb.Text = System.IO.Path.GetFileName(dialog.FileName);
            }
        }
    }
}
