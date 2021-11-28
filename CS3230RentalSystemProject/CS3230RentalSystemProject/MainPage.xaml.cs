using CS3230RentalSystemProject.view;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using DBAccess.DAL;
using Windows.UI.Popups;
using System;
using CS3230RentalSystemProject.Model;
using CS3230RentalSystemProject.Utils;
using CS3230RentalSystemProject.View;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CS3230RentalSystemProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    { 

        /// <summary>
        /// Initialize constructor
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            this.invalidLogin.Visibility = Visibility.Collapsed;
            this.invalidUsername.Visibility = Visibility.Collapsed;
            this.invalidPassword.Visibility = Visibility.Collapsed;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            bool isvalid = true;
            if (this.userNameBox.Text == null || this.userNameBox.Text == "")
            {
                this.invalidUsername.Visibility = Visibility.Visible;
                isvalid = false;
            }
            if (this.passwordBox.Password.ToString() == null || this.passwordBox.Password.ToString() == "")
            {
                this.invalidPassword.Visibility = Visibility.Visible;
                isvalid = false;
            }
            if (isvalid)
            {
                string hashedpassword = PasswordHash.CreateMD5(this.passwordBox.Password.ToString());
                int loginSuccess = LoginDALI.LoginValidation(this.userNameBox.Text, hashedpassword);

                if (loginSuccess != -1)
                {
                    Employee emploee = EmployeeDAL.GetEmployee(loginSuccess);
                    Frame.Navigate(typeof(EmployeeWindow), emploee);

                }
                else
                {
                    this.invalidLogin.Visibility = Visibility.Visible;
                }
            }
        }

        private void userNameBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            this.invalidLogin.Visibility = Visibility.Collapsed;
            this.invalidUsername.Visibility = Visibility.Collapsed;
        }

        private void passwordBox_PasswordChanging(PasswordBox sender, PasswordBoxPasswordChangingEventArgs args)
        {
            this.invalidLogin.Visibility = Visibility.Collapsed;
            this.invalidPassword.Visibility = Visibility.Collapsed;
        }

        private void passwordBox_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                this.loginButton_Click(sender, e);
            }
        }
    }
}
