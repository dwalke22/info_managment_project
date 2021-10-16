using CS3230RentalSystemProject.Enums;
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

        private string FirstName;

        private string LastName;

        private string Gender;

        private string Address1;

        private string Address2;

        private string City;

        private string State;

        private string Country;

        private string Zipcode;

        private string PhoneNumber;

        private string Email;

        private DateTime Birthday;

        /// <summary>
        /// Initalize constructor
        /// </summary>
        public MemebrInformationViewer()
        {
            this.InitializeComponent();
            this.saveButton.Visibility = Visibility.Collapsed;
            this.cancelButton.Visibility = Visibility.Collapsed;

            this.stateChooser.ItemsSource = Enum.GetNames(typeof(State));
            this.CountryChooser.ItemsSource = Enum.GetNames(typeof(Country));
            this.genderChooser.ItemsSource = Enum.GetNames(typeof(Gender));
            this.allowChooser(false);
            this.isReadOnly(true);
            this.disableInvalidlable();
        }
        private void isReadOnly(bool action)
        {
            this.firstNameInputBox.IsReadOnly = action;
            this.lastNameInputBox.IsReadOnly = action;
            
            this.address1InputBox.IsReadOnly = action;
            this.address2InputBox.IsReadOnly = action;
            this.cityInputBox.IsReadOnly = action;
            
            this.phoneInputBox.IsReadOnly = action;
            this.emailInputBox.IsReadOnly = action;
            
            this.zipcodeInputBox.IsReadOnly = action;
        }

        private void disableInvalidlable()
        {
            this.invalidFirstname.Visibility = Visibility.Collapsed;
            this.invalidLastname.Visibility = Visibility.Collapsed;
            this.invalidBirthday.Visibility = Visibility.Collapsed;
            this.invalidPhone.Visibility = Visibility.Collapsed;
            this.invalidEmail.Visibility = Visibility.Collapsed;
            this.InvalidGender.Visibility = Visibility.Collapsed;
            this.invalidAddress1.Visibility = Visibility.Collapsed;
            this.invalidCountry.Visibility = Visibility.Collapsed;
            this.invalidState.Visibility = Visibility.Collapsed;
            this.invalidZipcode.Visibility = Visibility.Collapsed;
            this.invalidCity.Visibility = Visibility.Collapsed;
            
        }

        private void allowChooser(bool action)
        {
            this.genderChooser.IsEnabled = action;
            this.stateChooser.IsEnabled = action;
            this.CountryChooser.IsEnabled = action;
            this.birtdayChooser.IsEnabled = action;
        }

        private void setViewer()
        {
            this.firstNameInputBox.Text = this.Employee.Member.FirstName;
            this.lastNameInputBox.Text = this.Employee.Member.LastName;
            this.genderChooser.SelectedItem = this.Employee.Member.Gender;
            this.address1InputBox.Text = this.Employee.Member.Address1;
            this.address2InputBox.Text = this.Employee.Member.Address2 == null ? "" : this.Employee.Member.Address2;
            this.cityInputBox.Text = this.Employee.Member.City;
            this.stateChooser.SelectedItem = this.Employee.Member.State;
            this.CountryChooser.SelectedItem = this.Employee.Member.Country;
            this.phoneInputBox.Text = this.Employee.Member.PhoneNumber;
            this.emailInputBox.Text = this.Employee.Member.Email;
            this.birtdayChooser.SelectedDate = this.Employee.Member.Birthday;
            this.zipcodeInputBox.Text = this.Employee.Member.Zipcode;

            
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EmployeeWindow), this.Employee);
        }

        private void editButon_Click(object sender, RoutedEventArgs e)
        {
            this.saveButton.Visibility = Visibility.Visible;
            this.cancelButton.Visibility = Visibility.Visible;

            this.okButton.Visibility = Visibility.Collapsed;
            this.editButon.Visibility = Visibility.Collapsed;

            this.allowChooser(true);
            this.isReadOnly(false);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            this.saveButton.Visibility = Visibility.Collapsed;
            this.cancelButton.Visibility = Visibility.Collapsed;

            this.okButton.Visibility = Visibility.Visible;
            this.editButon.Visibility = Visibility.Visible;

            this.allowChooser(false);
            this.isReadOnly(true);
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.saveButton.Visibility = Visibility.Collapsed;
            this.cancelButton.Visibility = Visibility.Collapsed;

            this.okButton.Visibility = Visibility.Visible;
            this.editButon.Visibility = Visibility.Visible;

            this.allowChooser(false);
            this.isReadOnly(true);

            this.setViewer();
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
            this.employeeName.Text = this.Employee.ToString();
        }

        private void firstNameInputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.FirstName = this.firstNameInputBox.Text;
        }

        private void lastNameInputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.LastName = this.lastNameInputBox.Text;
        }

        private void birtdayChooser_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            this.Birthday = this.birtdayChooser.Date.DateTime;
            this.invalidBirthday.Visibility = Visibility.Collapsed;
        }

        private void phoneInputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.PhoneNumber = this.phoneInputBox.Text;
        }

        private void emailInputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Email = this.emailInputBox.Text;
        }

        private void genderChooser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Gender = this.genderChooser.SelectedItem.ToString();
            this.InvalidGender.Visibility = Visibility.Collapsed;
        }

        private void address1InputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Address1 = this.address1InputBox.Text;
        }

        private void address2InputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Address2 = this.address2InputBox.Text;
        }

        private void cityInputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.City = this.cityInputBox.Text;
        }

        private void stateChooser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.State = this.stateChooser.SelectedItem.ToString();
            this.invalidState.Visibility = Visibility.Collapsed;
        }

        private void CountryChooser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Country = this.CountryChooser.SelectedItem.ToString();
            this.invalidCountry.Visibility = Visibility.Collapsed;
        }

        private void zipcodeInputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Zipcode = this.zipcodeInputBox.Text;
        }

        private void firstNameInputBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            this.invalidFirstname.Visibility = Visibility.Collapsed;
        }

        private void lastNameInputBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            this.invalidLastname.Visibility = Visibility.Collapsed;
        }

        private void phoneInputBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            this.invalidPhone.Visibility = Visibility.Collapsed;
        }

        private void emailInputBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            this.invalidEmail.Visibility = Visibility.Collapsed;
        }

        private void address1InputBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            this.invalidAddress1.Visibility = Visibility.Collapsed;
        }

        private void cityInputBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            this.invalidCity.Visibility = Visibility.Collapsed;
        }

        private void zipcodeInputBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            this.invalidZipcode.Visibility = Visibility.Collapsed;
        }
    }
}
