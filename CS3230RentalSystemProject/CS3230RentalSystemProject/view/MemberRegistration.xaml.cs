using CS3230RentalSystemProject.Enums;
using CS3230RentalSystemProject.Model;
using DBAccess.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CS3230RentalSystemProject.view
{

    /// <summary>
    /// The MemberRegistration class
    /// </summary>
    public sealed partial class MemberRegistration : Page
    {

        #region DataMember

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

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize constructor
        /// </summary>
        public MemberRegistration()
        {
            this.InitializeComponent();
            this.stateChooser.ItemsSource = Enum.GetNames(typeof(State));
            this.countryChooser.ItemsSource = Enum.GetNames(typeof(Country));
            this.genderChooser.ItemsSource = Enum.GetNames(typeof(Gender));
        }
        #endregion

        #region Methods

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            this.checkInput();
           
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
            EmployeeDAL dAL = new EmployeeDAL();
            dAL.RegisterMember(member);
            Frame.Navigate(typeof(EmployeeWindow));
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EmployeeWindow));
        }

        private async void checkInput()
        {

            Regex phoneRegex = new Regex(@"[\d]{10}");
            Regex zipRegex = new Regex(@"[\d]{5}");
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            var message = new MessageDialog("");
            message.Title = "Alert Message";
            if (this.FirstName != null && this.LastName != null)
            {
                string fullName = this.FirstName + " " + this.LastName;
                if (this.checkFirstAndLastName(fullName))
                {
                    message.Content = "The memebr (" + fullName + ") exists! Please try a different First Name or Last Name!";
                    await message.ShowAsync();
                }
            }
            else if (this.FirstName == null || this.FirstName == "")
            {
                message.Content = "Please Entry Your First Name!";
                await message.ShowAsync();
            } 
            else if (this.LastName == null || this.LastName == "")
            {
                message.Content = "Please Entry Your Last Name!";
                await message.ShowAsync();
            }
            else if (this.Gender == null)
            {
                message.Content = "Please Choose Your Gender!";
                await message.ShowAsync();
            }
            else if (this.Address1 == null || this.Address1 == "")
            {
                message.Content = "Please Entry Your Address1!";
                await message.ShowAsync();
            }
            else if (this.City == null || this.City == "")
            {
                message.Content = "Please Entry Your City!";
                await message.ShowAsync();
            }
            else if (this.State == null)
            {
                message.Content = "Please Choose Your State!";
                await message.ShowAsync();
            }
            else if (this.Country == null)
            {
                message.Content = "Please Choose Your Country!";
                await message.ShowAsync();
            }
            else if (this.Zipcode == null || this.Zipcode == "")
            {
                message.Content = "Please Entry Your Zipcode!";
                await message.ShowAsync();
            }
            else if (this.PhoneNumber == null || this.PhoneNumber == "")
            {
                message.Content = "Please Entry Your Phone Number!";
                await message.ShowAsync();
            }
            else if (this.Email == null || this.Email == "")
            {
                message.Content = "Please Entry Your Email!";
                await message.ShowAsync();
            }
            else if (this.Birthday == null)
            {
                message.Content = "Please Choose Your Birthday!";
                await message.ShowAsync();
            }
            else if (this.PhoneNumber != null && !phoneRegex.IsMatch(this.PhoneNumber))
            {
                message.Content = "Please Entry 9 digits for phone number!";
                await message.ShowAsync();
            }
            else if (this.Zipcode != null && !zipRegex.IsMatch(this.Zipcode))
            {
                message.Content = "Please Entry 5 digits for zipcode!";
                await message.ShowAsync();
            }
            else if (this.Email != null && !emailRegex.IsMatch(this.Email))
            {
                message.Content = "Email format is incorrect! Please try again!";
                await message.ShowAsync();
            }
            else
            {
                this.pastDateToEmplyee();
            }
            

        }

        private bool checkFirstAndLastName(string fullName)
        {
            foreach(Member member in this.Employee.MemberList)
            {
                if (fullName.Equals(member.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
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
        }

        private void countryChooser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Country = this.countryChooser.SelectedItem.ToString();
        }

        private void zipcodeInputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Zipcode = this.zipcodeInputBox.Text;
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
        }

        #endregion
    }
}
