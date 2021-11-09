using CS3230RentalSystemProject.DAL;
using CS3230RentalSystemProject.Enums;
using CS3230RentalSystemProject.Model;
using CS3230RentalSystemProject.view;
using DBAccess.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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

        private bool isvalid = true;

        /// <summary>
        /// The Empolyee
        /// </summary>
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

        private void pastDateToEmplyee()
        {

            this.Employee.SelectedMember.FirstName = this.FirstName;
            this.Employee.SelectedMember.LastName = this.LastName;
            this.Employee.SelectedMember.Gender = this.Gender;
            this.Employee.SelectedMember.Address1 = this.Address1;
            this.Employee.SelectedMember.Address2 = this.Address2;
            this.Employee.SelectedMember.City = this.City;
            this.Employee.SelectedMember.State = this.State;
            this.Employee.SelectedMember.Country = this.Country;
            this.Employee.SelectedMember.Zipcode = this.Zipcode;
            this.Employee.SelectedMember.PhoneNumber = this.PhoneNumber;
            this.Employee.SelectedMember.Email = this.Email;
            this.Employee.SelectedMember.Birthday = this.Birthday;
            MemberDAL dAL = new MemberDAL();
            dAL.UpdateMemberInfo(this.Employee.SelectedMember);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.FirstName == null || this.FirstName == "")
            {
                this.invalidFirstname.Visibility = Visibility.Visible;
                isvalid = false;
            }
            if (this.LastName == null || this.LastName == "")
            {
                this.invalidLastname.Visibility = Visibility.Visible;
                isvalid = false;
            }
            if (this.Gender == null)
            {
                this.InvalidGender.Visibility = Visibility.Visible;
                isvalid = false;
            }
            if (this.Address1 == null || this.Address1 == "")
            {
                this.invalidAddress1.Visibility = Visibility.Visible;
                isvalid = false;
            }
            if (this.City == null || this.City == "")
            {
                this.invalidCity.Visibility = Visibility.Visible;
                isvalid = false;
            }
            if (this.State == null)
            {
                this.invalidState.Visibility = Visibility.Visible;
                isvalid = false;
            }
            if (this.Country == null)
            {
                this.invalidCountry.Visibility = Visibility.Visible;
                isvalid = false;
            }
            if (this.Zipcode == null || this.Zipcode == "")
            {
                this.invalidZipcode.Visibility = Visibility.Visible;
                isvalid = false;
            }
            if (this.PhoneNumber == null || this.PhoneNumber == "")
            {
                this.invalidPhone.Visibility = Visibility.Visible;
                isvalid = false;
            }
            if (this.Email == null || this.Email == "")
            {
                this.invalidEmail.Visibility = Visibility.Visible;
                isvalid = false;
            }
            if (this.Birthday == DateTime.MinValue)
            {
                this.invalidBirthday.Visibility = Visibility.Visible;
                isvalid = false;
            }
            if (this.invalidEmail.Visibility == Visibility.Visible)
            {
                isvalid = false;
            }
            if (this.invalidPhone.Visibility == Visibility.Visible)
            {
                isvalid = false;
            }
            if (this.invalidZipcode.Visibility == Visibility.Visible)
            {
                isvalid = false;
            }
            if (isvalid)
            {
                this.saveButton.Visibility = Visibility.Collapsed;
                this.cancelButton.Visibility = Visibility.Collapsed;

                this.okButton.Visibility = Visibility.Visible;
                this.editButon.Visibility = Visibility.Visible;

                this.allowChooser(false);
                this.isReadOnly(true);
                this.pastDateToEmplyee();
            }
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

        private void isReadOnly(bool action)
        {
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
            this.firstNameInputBox.Text = this.Employee.SelectedMember.FirstName;
            this.lastNameInputBox.Text = this.Employee.SelectedMember.LastName;
            this.genderChooser.SelectedItem = this.Employee.SelectedMember.Gender;
            this.address1InputBox.Text = this.Employee.SelectedMember.Address1;
            this.address2InputBox.Text = this.Employee.SelectedMember.Address2 == null ? "" : this.Employee.SelectedMember.Address2;
            this.cityInputBox.Text = this.Employee.SelectedMember.City;
            this.stateChooser.SelectedItem = this.Employee.SelectedMember.State;
            this.CountryChooser.SelectedItem = this.Employee.SelectedMember.Country;
            this.phoneInputBox.Text = this.Employee.SelectedMember.PhoneNumber;
            this.emailInputBox.Text = this.Employee.SelectedMember.Email;
            this.birtdayChooser.SelectedDate = this.Employee.SelectedMember.Birthday;
            this.zipcodeInputBox.Text = this.Employee.SelectedMember.Zipcode;
            this.idInputBox.Text = this.Employee.SelectedMember.MemberID.ToString();

            this.FirstName = this.Employee.SelectedMember.FirstName;
            this.LastName = this.Employee.SelectedMember.LastName;
            this.Gender = this.Employee.SelectedMember.Gender;
            this.Address1 = this.Employee.SelectedMember.Address1;
            this.Address2 = this.Employee.SelectedMember.Address2 == null ? "" : this.Employee.SelectedMember.Address2;
            this.City = this.Employee.SelectedMember.City;
            this.State = this.Employee.SelectedMember.State;
            this.Country = this.Employee.SelectedMember.Country;
            this.PhoneNumber = this.Employee.SelectedMember.PhoneNumber;
            this.Email = this.Employee.SelectedMember.Email;
            this.Birthday = this.Employee.SelectedMember.Birthday;
            this.Zipcode = this.Employee.SelectedMember.Zipcode;


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

        private void phoneInputBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Regex phoneRegex = new Regex(@"[\d]{10}");
            if (this.PhoneNumber != null && !phoneRegex.IsMatch(this.PhoneNumber))
            {
                this.invalidPhone.Visibility = Visibility.Visible;
                isvalid = false;
            }
            else
            {
                isvalid = true;
            }
        }

        private void emailInputBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (this.Email != null && !emailRegex.IsMatch(this.Email))
            {
                this.invalidEmail.Visibility = Visibility.Visible;
                isvalid = false;
            }
            else
            {
                isvalid = true;
            }
        }

        private void zipcodeInputBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Regex zipRegex = new Regex(@"[\d]{5}");

            if (this.Zipcode != null && (!zipRegex.IsMatch(this.Zipcode) || this.Zipcode.Length > 5))
            {
                this.invalidZipcode.Visibility = Visibility.Visible;
                isvalid = false;
            }
            else
            {
                isvalid = true;
            }
        }
    }
}
