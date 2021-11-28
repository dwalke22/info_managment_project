using CS3230RentalSystemProject.DAL;
using CS3230RentalSystemProject.Enums;
using CS3230RentalSystemProject.Model;
using System;
using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CS3230RentalSystemProject.view
{

    /// <summary>
    /// The MemberRegistration class
    /// </summary>
    public sealed partial class MemberRegistration : Page
    {
        private bool isvalid = true;

        /// <summary>
        /// The Employee
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
        /// Initialize constructor
        /// </summary>
        public MemberRegistration()
        {
            this.InitializeComponent();
            this.stateChooser.ItemsSource = Enum.GetNames(typeof(State));
            this.countryChooser.ItemsSource = Enum.GetNames(typeof(Country));
            this.genderChooser.ItemsSource = Enum.GetNames(typeof(Gender));

            this.disableInvalidlable();
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

            this.employeeName.Text = this.Employee.ToString();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            this.checkInput();
           
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EmployeeWindow), this.Employee);
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
            this.usernameExist.Visibility = Visibility.Collapsed;
        }

        private void checkInput()
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
                this.pastDateToEmplyee();
            }
        }

        private void pastDateToEmplyee()
        {
            Member member = new Member
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Gender = this.Gender,
                Address1 = this.Address1,
                Address2 = this.Address2,
                City = this.City,
                State = this.State,
                Country = this.Country,
                Zipcode = this.Zipcode,
                PhoneNumber = this.PhoneNumber,
                Email = this.Email,
                Birthday = this.Birthday
            };
            MemberDAL dAL = new MemberDAL();
            dAL.RegisterMember(member);
            Frame.Navigate(typeof(EmployeeWindow), this.Employee);
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

        private void countryChooser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Country = this.countryChooser.SelectedItem.ToString();
            this.invalidCountry.Visibility = Visibility.Collapsed;
        }

        private void zipcodeInputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Zipcode = this.zipcodeInputBox.Text;
        }

        private void firstNameInputBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            this.invalidFirstname.Visibility = Visibility.Collapsed;
            this.usernameExist.Visibility = Visibility.Collapsed;
        }

        private void lastNameInputBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            this.invalidLastname.Visibility = Visibility.Collapsed;
            this.usernameExist.Visibility = Visibility.Collapsed;
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
