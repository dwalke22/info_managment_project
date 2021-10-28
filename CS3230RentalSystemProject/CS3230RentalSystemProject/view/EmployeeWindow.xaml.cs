using CS3230RentalSystemProject.DAL;
using CS3230RentalSystemProject.Model;
using CS3230RentalSystemProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CS3230RentalSystemProject.view
{
    /// <summary>
    /// The EmployeeWindow class
    /// </summary>
    public sealed partial class EmployeeWindow : Page
    {

        private List<string> criteriaListInfo = new List<string>() { "MemberID", "Phone", "Full Name" };

        private List<string> furnitureCriteriaList = new List<string>() { "Style", "Category", "Price" };

        private List<Member> list;

        private MemberDAL dAL;

        private FurnitureDAL furnitureDAL;

        private Employee employee;

        private string searchType;

        private int rentQuantity = 0;

        private List<Furniture> furnitureListData;


        /// <summary>
        /// Initialize constructor
        /// </summary>
        public EmployeeWindow()
        {
            this.InitializeComponent();
            this.furnitureListData = new List<Furniture>();
            this.dAL = new MemberDAL();
            this.furnitureDAL = new FurnitureDAL();
            this.furnitureListData = this.furnitureDAL.GetAllFurnitureList();
            this.furnitureListData.ForEach(x => x.setQuantityList());
            this.furnitureList.ItemsSource = this.furnitureListData;
            
            this.memberList.ItemsSource = dAL.GetAllMemberList();
            
            this.list = this.convertList();
            this.invalidSearch.Visibility = Visibility.Collapsed;
            this.criteriaList.ItemsSource = this.criteriaListInfo;
            this.furnitureFilterComboBox.ItemsSource = this.furnitureCriteriaList;

            this.categoryComboBox.ItemsSource = this.furnitureDAL.GetAllFurnitureCategories();
            this.styleComboBox.ItemsSource = this.furnitureDAL.GetAllFurnitureStyles();
        }


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

        private void employeeList_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            ListBox box = sender as ListBox;
            if (box.SelectedItem != null)
            {
                this.employee.Member = (Member)box.SelectedItem;
                Frame.Navigate(typeof(MemebrInformationViewer), this.employee);
            }
        }

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

        private async void addButtonClick(object sender, RoutedEventArgs e)
        {
            int tag = (int)((Button)sender).Tag;

            List<Furniture> list = new List<Furniture>();
            foreach (Furniture item in this.furnitureList.Items)
            {
                if (item.FurnitureID == tag)
                {
                    if (item.Quantity == 0)
                    {
                        var message = new MessageDialog(" " + item.FurnitureName + " is not available now!");
                        await message.ShowAsync();
                        return;
                    }
                    item.Quantity--;
                }
                list.Add(item);
            }
            
            Furniture furniture = this.furnitureListData.Find(x => x.FurnitureID == tag);
            
            if (this.employee.FurnitureListData.Contains(furniture))
            {
                int index = this.employee.FurnitureListData.IndexOf(furniture);
                this.employee.FurnitureListData.ElementAt(index).RentQuantity++;
                rentQuantity++;
                this.bagButton.Content = "Bag(" + rentQuantity + ")";
            }
            else
            {
                furniture.RentQuantity++;
                this.employee.FurnitureListData.Add(furniture);
                rentQuantity++;
                this.bagButton.Content = "Bag(" + rentQuantity + ")";
            }

            this.furnitureList.ItemsSource = list;
        }

        private void bagButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Checkout), this.employee);
        }

        private List<Member> convertList()
        {
            List<Member> list = new List<Member>();
            foreach (Member member in this.memberList.Items)
            {
                list.Add(member);
            }
            return list;
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

            this.employeeName.Text = "Welcome, " + this.employee.ToString();
        }

        private void furnitureComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.applyPriceFilter.Visibility = Visibility.Collapsed;
            this.priceErrorTextBlock.Visibility = Visibility.Collapsed;
            string filter = this.furnitureFilterComboBox.SelectedItem.ToString();
            if (filter.Equals(this.furnitureCriteriaList[0]))
            {
                this.styleComboBox.Visibility = Visibility.Visible;
                this.categoryComboBox.Visibility = Visibility.Collapsed;
                this.funiturePriceTextbox.Visibility = Visibility.Collapsed;
            }

            if (filter.Equals(this.furnitureCriteriaList[1]))
            {
                this.categoryComboBox.Visibility = Visibility.Visible;
                this.styleComboBox.Visibility = Visibility.Collapsed;
                this.funiturePriceTextbox.Visibility = Visibility.Collapsed;
            }

            if (filter.Equals(this.furnitureCriteriaList[2]))
            {
                this.funiturePriceTextbox.Visibility = Visibility.Visible;
                this.styleComboBox.Visibility = Visibility.Collapsed;
                this.categoryComboBox.Visibility = Visibility.Collapsed;
            }
        }

        private void styleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string style = this.styleComboBox.SelectedItem.ToString();
            this.furnitureListData = this.furnitureDAL.GetAllFunitureBySelectedStyle(style);
            this.furnitureListData.ForEach(x => x.setQuantityList());
            this.furnitureList.ItemsSource = this.furnitureListData;
        }

        private void categoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string category = this.categoryComboBox.SelectedItem.ToString();
            this.furnitureListData = this.furnitureDAL.GetAllFurnitureBySelectedCategory(category);
            this.furnitureListData.ForEach(x => x.setQuantityList());
            this.furnitureList.ItemsSource = this.furnitureListData;
        }

        private void funiturePriceTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex priceRegex = new Regex(@"^\d+.\d{2}$");
            this.applyPriceFilter.Visibility = Visibility.Visible;
            if (!priceRegex.IsMatch(this.funiturePriceTextbox.Text))
            {
                this.priceErrorTextBlock.Visibility = Visibility.Visible;
                this.applyPriceFilter.IsEnabled = false;
            }
            else
            {
                this.priceErrorTextBlock.Visibility = Visibility.Collapsed;
                this.applyPriceFilter.IsEnabled = true;
            }
        }

        private void applyPriceFilter_Click(object sender, RoutedEventArgs e)
        {
            decimal price = Convert.ToDecimal(this.funiturePriceTextbox.Text);
            this.furnitureListData = this.furnitureDAL.GetAllFurnitureLessThanSpecifiedPrice(price);
            this.furnitureListData.ForEach(x => x.setQuantityList());
            this.furnitureList.ItemsSource = this.furnitureListData;
        }

        private void resetFilterButton_Click(object sender, RoutedEventArgs e)
        {
            this.furnitureListData = this.furnitureDAL.GetAllFurnitureList();
            this.furnitureListData.ForEach(x => x.setQuantityList());
            this.furnitureList.ItemsSource = this.furnitureListData;
        }
    }
}
