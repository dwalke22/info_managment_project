using CS3230RentalSystemProject.Model;
using CS3230RentalSystemProject.View;
using CS3230RentalSystemProject.ViewModel;
using DBAccess.DAL;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CS3230RentalSystemProject.view
{
    /// <summary>
    /// The EmployeeWindow class
    /// </summary>
    public sealed partial class EmployeeWindow : Page
    {
        #region DataMember

        private EmployeeViewModel viewModel;

        private List<Member> list;

        private Employee employee;

        #endregion

        #region Constructor


        /// <summary>
        /// Initialize constructor
        /// </summary>
        public EmployeeWindow()
        {
            this.InitializeComponent();
            this.viewModel = new EmployeeViewModel();
            EmployeeDAL dAL = new EmployeeDAL();
            this.memberList.ItemsSource = dAL.GetAllMemberList();
            this.list = this.convertList();
        }

        #endregion

        #region Methods

        private void registerMemberButton_Click(object sender, RoutedEventArgs e)
        {
            this.employee.MemberList = this.list;
            Frame.Navigate(typeof(MemberRegistration), this.employee);
        }

        private void searchBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            string name = sender.Text;
            this.memberList.ItemsSource = this.list.Where(x => x.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase) || x.LastName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        private List<Member> convertList()
        {
            List<Member> list = new List<Member>();
            foreach(Member member in this.memberList.Items)
            {
                list.Add(member);
            }
            return list;
        }

        private void employeeList_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            ListBox box = sender as ListBox;
            if (box.SelectedItem != null)
            {
                this.employee.Member = (Member)box.SelectedItem;
                Frame.Navigate(typeof(MemebrInformationViewer), this.employee);
            }
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

            this.employee = (Employee)e.Parameter;

            this.employeeName.Text = "Welcome, " +  this.employee.ToString();
        }
        #endregion

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
