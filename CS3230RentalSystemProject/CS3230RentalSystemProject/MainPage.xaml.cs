using CS3230RentalSystemProject.view;
using CS3230RentalSystemProject.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using DBAccess.DAL;
using Windows.UI.Popups;
using System;
using CS3230RentalSystemProject.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CS3230RentalSystemProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region DataMember

        private readonly EmployeeViewModel viewModel;

        #endregion

        #region Contructor

        /// <summary>
        /// Initialize constructor
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            this.viewModel = new EmployeeViewModel();
            this.invalidLogin.Visibility = Visibility.Collapsed;
            this.invalidUsername.Visibility = Visibility.Collapsed;
            this.invalidPassword.Visibility = Visibility.Collapsed;
        }

        #endregion

        #region Methods

        private async void loginButton_Click(object sender, RoutedEventArgs e)
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
                int loginSuccess = LoginDALI.LoginValidation(this.userNameBox.Text, this.passwordBox.Password.ToString());

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

        #endregion

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
    }
}
