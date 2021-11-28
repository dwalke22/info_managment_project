using Windows.UI.Xaml.Controls;
using CS3230RentalSystemProject.Model;
using CS3230RentalSystemProject.Utils;
using DBAccess.DAL;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CS3230RentalSystemProject.View
{
    /// <summary>
    /// The class AddEmployeeContentDialog
    /// </summary>
    public sealed partial class AddEmployeeContentDialog : ContentDialog
    {

        private EmployeeDAL employeeDal;

        /// <summary>
        /// Initialize constructor
        /// </summary>
        public AddEmployeeContentDialog()
        {
            this.InitializeComponent();
            this.employeeDal = new EmployeeDAL();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Employee employee = new Employee
            {
                FirstName = this.employeeFirstNameBox.Text,
                LastName = this.employeeLastNameBox.Text,
                PhoneNumber = this.phoneNumberBox.Text,
                Email = this.emailBox.Text
            };

            int isAdmin = 0;
            var isChecked = this.isAdminCheckBox.IsChecked;
            if (isChecked != null && (bool)isChecked)
            {
                isAdmin = 1;
            }

            this.employeeDal.AddEmployee(employee, isAdmin);

            var hashedPassword = PasswordHash.CreateMD5(this.passwordBox.Text);
            var employeeID = this.employeeDal.GetNewestEmployeeID();

            this.employeeDal.AddEmployeeUsernamePassword(employeeID, this.usernameBox.Text, hashedPassword);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //Close dialog, no need to implement
        }
    }
}
