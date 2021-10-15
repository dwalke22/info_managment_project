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
        }

        #endregion

        #region Methods

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.userNameBox.Text == null || this.userNameBox.Text == "")
            {
                var message = new MessageDialog("Pleass Entry Your UserName!");
                await message.ShowAsync();
            } 
            else if (this.passwordBox.Password.ToString() == null || this.passwordBox.Password.ToString() == "")
            {
                var message = new MessageDialog("Pleass Entry Your Password!");
                await message.ShowAsync();
            }
            else
            {
                int loginSuccess = LoginDALI.LoginValidation(this.userNameBox.Text, this.passwordBox.Password.ToString());

                if (loginSuccess != -1)
                {
                    Employee emploee = LoginDALI.GetEmployee(loginSuccess);
                    Frame.Navigate(typeof(EmployeeWindow), emploee);
                }
                else
                {
                    var message = new MessageDialog("Incorrect Username or Password! Please Check!");
                    await message.ShowAsync();
                }
            }
        }

        #endregion
    }
}
