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

        public Member member { get; set; }

        public MemebrInformationViewer()
        {
            this.InitializeComponent();

        }

        private void setViewer()
        {
            this.firstNameInputBox.Text = this.member.FirstName;
            this.lastNameInputBox.Text = this.member.LastName;
            this.genderBox.Text = this.member.Gender;
            this.address1InputBox.Text = this.member.Address1;
            this.address2InputBox.Text = this.member.Address2 == null ? "" : this.member.Address2;
            this.cityInputBox.Text = this.member.City;
            this.stateBox.Text = this.member.State;
            this.countryBox.Text = this.member.Country;
            this.phoneInputBox.Text = this.member.PhoneNumber;
            this.emailInputBox.Text = this.member.Email;
            this.birtdayChooser.SelectedDate = this.member.Birthday;
            this.zipcodeInputBox.Text = this.member.Zipcode;
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EmployeeWindow));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter == null)
            {
                return;
            }

            this.member = (Member)e.Parameter;;

            this.setViewer();
        }
    }
}
