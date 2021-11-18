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
using K4os.Compression.LZ4.Internal;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Security;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CS3230RentalSystemProject.view
{
    /// <summary>
    /// The EmployeeWindow class
    /// </summary>
    public sealed partial class EmployeeWindow : Page
    {

        private List<string> criteriaListInfo = new List<string>() { "MemberID", "Phone", "Full Name" };

        private List<string> furnitureCriteriaList = new List<string>() { "Style", "Category", "Price" , "ID"};

        private List<Member> list;

        private MemberDAL dAL;

        private FurnitureDAL furnitureDAL;

        private Employee Employee;

        private string searchType;

        private int rentQuantity = 0;

        private List<Furniture> furnitureListData;

        public class SelectedInfo
        {
            public Employee Employee { get; set; }
            public Member Member { get; set; }
        }

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
            List<Member> newlist = dAL.GetAllMemberList();
            newlist.ForEach(x => x.InitializeFurnitureList());
            this.memberList.ItemsSource = newlist;
            
            this.list = this.convertList();
            this.invalidSearch.Visibility = Visibility.Collapsed;
            this.invalidFurnitureSearch.Visibility = Visibility.Collapsed;
            this.furnitureIDSearch.Visibility = Visibility.Collapsed;
            this.criteriaList.ItemsSource = this.criteriaListInfo;
            this.furnitureFilterComboBox.ItemsSource = this.furnitureCriteriaList;

            this.categoryComboBox.ItemsSource = this.furnitureDAL.GetAllFurnitureCategories();
            this.styleComboBox.ItemsSource = this.furnitureDAL.GetAllFurnitureStyles();

        }


        private void registerMemberButton_Click(object sender, RoutedEventArgs e)
        {
            this.Employee.MemberList = this.list;
            Frame.Navigate(typeof(MemberRegistration), this.Employee);
        }

        private void searchBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            this.memberList.ItemsSource = dAL.GetAllMemberList();
            this.invalidSearch.Visibility = Visibility.Collapsed;
            this.serveredMember.Text = "";
        }

        private void employeeList_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            ListBox box = sender as ListBox;
            if (box.SelectedItem != null)
            {
                this.Employee.SelectedMember = (Member)box.SelectedItem;
                Frame.Navigate(typeof(MemebrInformationViewer), this.Employee);
                
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
                else if (this.searchType == "Full Name")
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
            if (this.searchType == "MemberID")
            {
                this.searchBox.PlaceholderText = "eg: 1";
            }
            else if (this.searchType == "Phone")
            {
                this.searchBox.PlaceholderText = "eg: 6782960303";
            }
            else if (this.searchType == "Full Name")
            {
                this.searchBox.PlaceholderText = "eg: John Simith";
            }
        }

        private async void addButtonClick(object sender, RoutedEventArgs e)
        {

            if (this.memberList.SelectedItem == null)
            {
                this.memberErrorLabel.Visibility = Visibility.Visible;
            }
            else
            {
                if (this.Employee.SelectedMember != null)
                {
                    List<Furniture> listFurniture = this.Employee.SelectedMember.FurnitureListData;
                    this.Employee.SelectedMember = (Member)this.memberList.SelectedItem;
                    this.Employee.SelectedMember.FurnitureListData = listFurniture;
                }
                else
                {
                    this.Employee.SelectedMember = (Member)this.memberList.SelectedItem;
                }
                
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

                if (this.Employee.SelectedMember.FurnitureListData.Exists(x=> x.FurnitureID == furniture.FurnitureID))
                {
                    int index = this.Employee.SelectedMember.FurnitureListData.FindIndex(x=> x.FurnitureID == furniture.FurnitureID);
                    this.Employee.SelectedMember.FurnitureListData.ElementAt(index).RentQuantity++;
                    this.Employee.SelectedMember.FurnitureListData.ElementAt(index).setCurentTotalPrice();
                    rentQuantity++;
                    this.bagButton.Content = "Bag(" + rentQuantity + ")";
                }
                else
                {
                    furniture.RentQuantity++;
                    furniture.setCurentTotalPrice();
                    this.Employee.SelectedMember.FurnitureListData.Add(furniture);
                    rentQuantity++;
                    this.bagButton.Content = "Bag(" + rentQuantity + ")";
                }

                this.furnitureList.ItemsSource = list;

            }

            
        }

        private void bagButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.memberList.SelectedItem == null)
            {
                this.memberErrorLabel.Visibility = Visibility.Visible;
            }
            else
            {

                this.memberErrorLabel.Visibility = Visibility.Collapsed;
                //var selectedInfo = new SelectedInfo();
                //selectedInfo.Employee = this.employee;
                //selectedInfo.Member = (Member)this.memberList.SelectedItem;
                //Member member = (Member)this.memberList.SelectedItem;
                if (this.Employee.SelectedMember == null)
                {
                    this.Employee.SelectedMember = (Member)this.memberList.SelectedItem;
                }
                
                Frame.Navigate(typeof(Checkout), this.Employee);
            }
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

            this.Employee = (Employee)e.Parameter;

            this.employeeName.Text = "Welcome, " + this.Employee.ToString();
            if (this.Employee.SelectedMember != null)
            {
                int size =0;
                List<Furniture> list = new List<Furniture>();
                foreach (Furniture item in this.furnitureList.Items)
                {
                    list.Add(item);
                }
                if (this.Employee.SelectedMember.FurnitureListData != null)
                {
                    foreach (var item in this.Employee.SelectedMember.FurnitureListData)
                    {
                        size += item.RentQuantity;
                        if (list.Exists(x => x.FurnitureID == item.FurnitureID))
                        {
                            list.Find(x => x.FurnitureID == item.FurnitureID).Quantity -= item.RentQuantity;
                        }
                    }
                }
               
                this.bagButton.Content = "Bag(" + size + ")";
                this.rentQuantity = size;
                this.serveredMember.Text = "Now Server: " + this.Employee.SelectedMember.ToString();
                
                this.memberList.SelectedIndex = this.list.FindIndex(x=>x.MemberID == this.Employee.SelectedMember.MemberID);
                this.furnitureList.ItemsSource = list;

            }

            if (this.Employee.IsAdmin)
            {
                this.adminQueryButton.Visibility = Visibility.Visible;
            }
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
                this.furnitureIDSearch.Visibility = Visibility.Collapsed;
            }

            if (filter.Equals(this.furnitureCriteriaList[1]))
            {
                this.categoryComboBox.Visibility = Visibility.Visible;
                this.styleComboBox.Visibility = Visibility.Collapsed;
                this.funiturePriceTextbox.Visibility = Visibility.Collapsed;
                this.furnitureIDSearch.Visibility = Visibility.Collapsed;
            }

            if (filter.Equals(this.furnitureCriteriaList[2]))
            {
                this.funiturePriceTextbox.Visibility = Visibility.Visible;
                this.styleComboBox.Visibility = Visibility.Collapsed;
                this.categoryComboBox.Visibility = Visibility.Collapsed;
                this.furnitureIDSearch.Visibility = Visibility.Collapsed;
            }

            if (filter.Equals(this.furnitureCriteriaList[3]))
            {
                this.funiturePriceTextbox.Visibility = Visibility.Collapsed;
                this.styleComboBox.Visibility = Visibility.Collapsed;
                this.categoryComboBox.Visibility = Visibility.Collapsed;
                this.furnitureIDSearch.Visibility = Visibility.Visible;
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
            this.styleComboBox.Visibility = Visibility.Collapsed;
            this.categoryComboBox.Visibility = Visibility.Collapsed;
            this.funiturePriceTextbox.Visibility = Visibility.Collapsed;
            this.furnitureIDSearch.Visibility = Visibility.Collapsed;
            this.furnitureIDSearch.Text = "";
        }

        private void furnitureList_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            ListBox box = sender as ListBox;
            if (box.SelectedItem != null)
            {
                this.Employee.SelectedFurniture = (Furniture)box.SelectedItem;
                if (this.Employee.SelectedFurniture.Quantity == 0)
                {
                    this.Employee.SelectedFurniture.Availability = this.furnitureDAL.GetAllFurnitureMostAvailability(this.Employee.SelectedFurniture.FurnitureID);
                }
                Frame.Navigate(typeof(FurnitureView), this.Employee);
            }
        }

        private void furnitureIDSearch_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            this.invalidFurnitureSearch.Visibility = Visibility.Collapsed;
        }

        private void furnitureIDSearch_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                string text = this.furnitureIDSearch.Text;
               if (text == null || text == "")
                {
                    this.invalidFurnitureSearch.Visibility = Visibility.Visible;
                }
                else
                {
                    int id;
                    if (!int.TryParse(text, out id))
                    {
                        this.invalidFurnitureSearch.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        this.furnitureList.ItemsSource = this.furnitureDAL.GetFurnitureById(id);
                    }
                }
              
            }
        }

        private void memberList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.memberErrorLabel.Visibility = Visibility.Collapsed;
            if (this.memberList.SelectedItem != null)
            {
                this.serveredMember.Text = "Now Server: " + ((Member)this.memberList.SelectedItem).ToString();
                if (this.Employee.SelectedMember != null && this.Employee.SelectedMember.MemberID != ((Member)this.memberList.SelectedItem).MemberID)
                {
                    this.Employee.SelectedMember = (Member)this.memberList.SelectedItem;

                    this.bagButton.Content = "Bag(0)";
                    this.furnitureListData = this.furnitureDAL.GetAllFurnitureList();
                    this.furnitureListData.ForEach(x => x.setQuantityList());
                    this.furnitureList.ItemsSource = this.furnitureListData;

                }
            }
            
        }

        private void transactionButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TransactionView), this.Employee);
        }

        private void Add_Employee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeContentDialog dialog = new AddEmployeeContentDialog();

            dialog.ShowAsync();
        }

        private void Add_Furniture_Click(object sender, RoutedEventArgs e)
        {
            AddFurnitureContentDialog1 dialog = new AddFurnitureContentDialog1();

            dialog.ShowAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AdminInterface), this.Employee);
        }
    }
}
