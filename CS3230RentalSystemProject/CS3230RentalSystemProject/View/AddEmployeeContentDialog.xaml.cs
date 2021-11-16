using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CS3230RentalSystemProject.Model;
using CS3230RentalSystemProject.Utils;
using DBAccess.DAL;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CS3230RentalSystemProject.View
{
    public sealed partial class AddEmployeeContentDialog : ContentDialog
    {
        private EmployeeDAL employeeDal;

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
        }
    }
}
