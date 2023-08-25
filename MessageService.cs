using System.Windows;

namespace form_409_check
{
    public static class MessageService
    {
        public static void ShowMessage(string message)
        {
            MessageBox.Show(message, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static void ShowExclmation(string exclamation)
        {
            MessageBox.Show(exclamation, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        public static void ShowError(string error)
        {
            MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}