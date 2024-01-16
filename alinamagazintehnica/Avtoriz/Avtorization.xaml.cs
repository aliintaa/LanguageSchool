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

namespace Avtoriz
{
    /// <summary>
    /// Логика взаимодействия для Avtorization.xaml
    /// </summary>
    public partial class Avtorization : Page
    {
        Client client;
        public Avtorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, object e)
        {
            StringBuilder error = new StringBuilder();
            if (PasswordTb.Password.Length < 6)
            {
                error.AppendLine("Пароль должен содержать больше 6 символов");
            }
            if (!PasswordTb.Password.Any(char.IsUpper))
            {
                error.AppendLine("Пароль должен содержать прописную букву");
            }
            if (!PasswordTb.Password.Any(char.IsDigit))
            {
                error.AppendLine("Пароль должен содержать цифры");
            }
            if (!PasswordTb.Password.Any(c => "! @ # $ % ^.".Contains(c)))
            {
                error.AppendLine("Пароль должен содержать хотябы 1 символ из набора");
            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!CheckVoidBoxes())
            {
                Client client = new Client();
                client.Surname = LastName.Text;
                client.Name = FirstName.Text;
                client.Patronymic = Patronymic.Text;
                client.Phone = PhoneTb.Text;
                client.Mail = MailTb.Text;
                client.Gender = GenderTb.Text;
                client.DayOfBirth = Birthday.Text;
                User user = new User();
                user.ClientId = client.ClientId;
                user.RoleId = 1;
                user.Login = Login.Text;
                user.Password= PasswordTb.Password;
                if(TryAddUser(user))
                {
                    App.db.Client.Add(client);
                    App.db.SaveChanges();
                    MessageBox.Show("Пользователь успешно дабавлен!");
                    Navigation.NextPage(new PageComponent(new AuthPage(), "Авторизация"));
                }

            }
        }
    }
}
