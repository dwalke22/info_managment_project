using CS3230RentalSystemProject.Model;
using CS3230RentalSystemProject.view;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CS3230RentalSystemProject.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MemebrInformationViewer : Page
    {

        public Employee Employee { get; set; }

        /// <summary>
        /// Initalize constructor
        /// </summary>
        public MemebrInformationViewer()
        {
            this.InitializeComponent();

        }

        private void setViewer()
        {
            this.firstNameInputBox.Text = this.Employee.Member.FirstName;
            this.lastNameInputBox.Text = this.Employee.Member.LastName;
            this.genderBox.Text = this.Employee.Member.Gender;
            this.address1InputBox.Text = this.Employee.Member.Address1;
            this.address2InputBox.Text = this.Employee.Member.Address2 == null ? "" : this.Employee.Member.Address2;
            this.cityInputBox.Text = this.Employee.Member.City;
            this.stateBox.Text = this.Employee.Member.State;
            this.countryBox.Text = this.Employee.Member.Country;
            this.phoneInputBox.Text = this.Employee.Member.PhoneNumber;
            this.emailInputBox.Text = this.Employee.Member.Email;
            this.birtdayChooser.SelectedDate = this.Employee.Member.Birthday;
            this.zipcodeInputBox.Text = this.Employee.Member.Zipcode;
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EmployeeWindow));
        }

        /// <summary>
        /// Initialize parameter
        /// </summary>
        /// <param name="e">
        ///         The parameter
        /// </param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter == null)
            {
                return;
            }

            this.Employee = (Employee)e.Parameter;

            this.setViewer();
        }
    }
}
