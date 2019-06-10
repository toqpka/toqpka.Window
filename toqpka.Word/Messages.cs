using System.Windows;

namespace toqpka.Word
{
    public interface IMessageService
    {
        void ShowMessage(string message);
        void ShowExclamation(string exclamation);
        void ShowError(string error);

    }   

    public class Messages : IMessageService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Сообщение");
        }

        public void ShowExclamation(string exclamation)
        {
            MessageBox.Show(exclamation, "Предупреждение");
        }

        public void ShowError(string error)
        {
            MessageBox.Show(error, "Ошибка");
        }
    }
}
