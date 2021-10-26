using CS3230RentalSystemProject.DAL;
using CS3230RentalSystemProject.Model;
using CS3230RentalSystemProject.View;
using CS3230RentalSystemProject.ViewModel;
using DBAccess.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CS3230RentalSystemProject.view
{
    /// <summary>
    /// The EmployeeWindow class
    /// </summary>
    public sealed partial class EmployeeWindow : Page
    {
        #region DataMember

        private List<string> criteriaListInfo = new List<string>() { "MemberID", "Phone", "FullName" };

        private EmployeeViewModel viewModel;

        private List<Member> list;

        private MemberDAL dAL;

        private FurnitureDAL furnitureDAL;

        private Employee employee;

        private string searchType;

        private int rentQuantity = 0;

        

        #endregion

        #region Constructor


        /// <summary>
        /// Initialize constructor
        /// </summary>
        public EmployeeWindow()
        {
            this.InitializeComponent();
            this.dAL = new MemberDAL();
            this.furnitureDAL = new FurnitureDAL();
            this.furnitureList.ItemsSource = this.furnitureDAL.GetAllFurnitureList();
            this.viewModel = new EmployeeViewModel();
            
            this.memberList.ItemsSource = dAL.GetAllMemberList();
            
            this.list = this.convertList();
            this.invalidSearch.Visibility = Visibility.Collapsed;
            this.criteriaList.ItemsSource = this.criteriaListInfo;
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
            this.memberList.ItemsSource = dAL.GetAllMemberList();
            this.invalidSearch.Visibility = Visibility.Collapsed;
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

        private void searchBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                string text = this.searchBox.Text;
                if (this.searchType == null)
                {
                    this.invalidSearch.Text = "Please Select Your Criteria";
                    this.invalidSearch.Visibility = Visibility.Visible;
                }
                else if (text == null || text == "")
                {
                    this.invalidSearch.Text = "Invalid Input!";
                    this.invalidSearch.Visibility = Visibility.Visible;
                }
                else if (this.searchType == "MemberID")
                {
                    int id;
                    if (!int.TryParse(text, out id))
                    {
                        this.invalidSearch.Text = "Invalid Input!";
                        this.invalidSearch.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        this.memberList.ItemsSource = this.dAL.GetMemberById(id);
                    }
                }
                else if (this.searchType == "Phone")
                {
                    Regex phoneRegex = new Regex(@"[\d]{10}");
                    if (text != null && !phoneRegex.IsMatch(text))
                    {
                        this.invalidSearch.Text = "Invalid Input!";
                        this.invalidSearch.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        this.memberList.ItemsSource = this.dAL.GetMemberByPhone(text);
                    }
                }
                else if (this.searchType == "FullName")
                {
                    Regex nameRegex = new Regex(@"^[\w]+\s[\w]");
                    if (text != null && !nameRegex.IsMatch(text))
                    {
                        this.invalidSearch.Text = "Invalid Input!";
                        this.invalidSearch.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        this.memberList.ItemsSource = this.dAL.GetMemberByFullName(text);
                    }
                }
            }
        }

        private void criteriaList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.searchType = this.criteriaList.SelectedItem.ToString();
            this.invalidSearch.Visibility = Visibility.Collapsed;
        }

        private void warningButtonClick(object sender, RoutedEventArgs e)
        {
            ListBox box = sender as ListBox;
            if (this.furnitureList.SelectedItem != null)
            {
                Furniture funiture = (Furniture)this.furnitureList.SelectedItem;
                if (this.employee.FurnitureListData.Contains(funiture))
                {
                    int index = this.employee.FurnitureListData.IndexOf(funiture);
                    this.employee.FurnitureListData.ElementAt(index).rentQuantity++;
                    rentQuantity++;
                    this.bagButton.Content = "Bag(" + rentQuantity + ")";
                }
                else
                {
                    funiture.rentQuantity++;
                    this.employee.FurnitureListData.Add(funiture);
                    rentQuantity++;
                    this.bagButton.Content = "Bag(" + rentQuantity + ")";
                }
                
            }
            
        }

        private void bagButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Checkout), this.employee);
        }
    }
}
