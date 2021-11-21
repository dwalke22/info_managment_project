using CS3230RentalSystemProject.DAL;
using CS3230RentalSystemProject.Model;
using CS3230RentalSystemProject.view;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization.DateTimeFormatting;
using Windows.UI.Popups;
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
    public sealed partial class TransactionView : Page
    {
        private List<string> criteriaListInfo = new List<string>() { "MemberID", "Phone", "Full Name" };

        private MemberDAL dAL;

        private FurnitureDAL furnitureDAL;

        private Employee Employee;

        private List<RentalItem> RentalItemList { get; set; }

        private List<RentalItem> RentalItemsWithSameID { get; set; }

        private List<ReturnItem> ReturnItemList { get; set; }

        private List<RentalItem> CheckedReturnItemList { get; set; }

        private List<RentalItem> PreReturnItemList { get; set; }

        private string searchType;

        private TransanctionDAL TransanctionDAL;

        private const double LATE_FEE_RATE = 50.00;

        /// <summary>
        /// Initialize constructor
        /// </summary>
        public TransactionView()
        {
            this.InitializeComponent();
            this.dAL = new MemberDAL();
            this.furnitureDAL = new FurnitureDAL();
            this.TransanctionDAL = new TransanctionDAL();
            this.memberList.ItemsSource = dAL.GetAllMemberList();
            this.RentalItemsWithSameID = new List<RentalItem>();
            this.invalidSearch.Visibility = Visibility.Collapsed;
            this.criteriaList.ItemsSource = this.criteriaListInfo;
            this.returnALl.Visibility = Visibility.Collapsed;
        }

        private void searchBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            this.memberList.ItemsSource = dAL.GetAllMemberList();
            this.invalidSearch.Visibility = Visibility.Collapsed;
            this.membername.Text = "";
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
            this.employeeName.Text = "Employee: " + this.Employee.ToString();
        }

        private async void  returnChecked(object sender, RoutedEventArgs e)
        {
            string tag = (string)((CheckBox)sender).Tag;
            if (tag != null)
            {
                string[] list = tag.Split(",");
                int rentalID = Int32.Parse(list[0]);
                int furnitureID = Int32.Parse(list[1]);
                this.CheckedReturnItemList.Add(this.PreReturnItemList.Find(x=> x.RentalID == rentalID && x.FurnitureID == furnitureID));
            }
            
        }

        private async void returnUnchecked(object sender, RoutedEventArgs e)
        {
            string tag = (string)((CheckBox)sender).Tag;
            if (tag != null)
            {
                string[] list = tag.Split(",");
                int rentalID = Int32.Parse(list[0]);
                int furnitureID = Int32.Parse(list[1]);
                this.CheckedReturnItemList.RemoveAt(this.CheckedReturnItemList.FindIndex(y => y.RentalID == rentalID && y.FurnitureID == furnitureID));
            }
           
        }

        private void memberList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.memberList.SelectedItem != null)
            {
                this.CheckedReturnItemList = new List<RentalItem>();
                this.PreReturnItemList = new List<RentalItem>();
                Member member = (Member)this.memberList.SelectedItem;
                List<RentalItem> list = this.TransanctionDAL.getAllCurrentRentaledItems((int)member.MemberID);
                list.ForEach(x => x.setRentalIDInfor());
                list.ForEach(x => x.setQuantityList());
                this.rentalItemList.ItemsSource = list;
                this.PreReturnItemList = list;
                this.rentalItemHistoryList.ItemsSource = this.TransanctionDAL.getAllRentalItems((int)member.MemberID);
                this.returnItemList.ItemsSource = this.TransanctionDAL.getAllReturnItems((int)member.MemberID);
                this.transactionIDBox.ItemsSource = this.TransanctionDAL.getMemberTansactionsNumber((int)member.MemberID);
                this.membername.Text = "Member: " + member.ToString();
            }
            
        }

        private void transactionIDBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.returnALl.Visibility = Visibility.Collapsed;
            if (this.transactionIDBox.SelectedItem != null)
            {
                int id = (int)this.transactionIDBox.SelectedItem;

                List<RentalItem> list = this.TransanctionDAL.getAllRentalItemsByRentalID(id);
                list.ForEach(x => x.setRentalIDInfor());
                this.rentalItemList.ItemsSource = list;
                this.RentalItemsWithSameID = list;
                if (list.Count != 0)
                {
                    this.returnALl.Visibility = Visibility.Visible;
                } 
                else
                {
                    this.returnALl.Visibility = Visibility.Collapsed;
                }
            }
            
            
        }

        private void returnToMainPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EmployeeWindow), this.Employee);
        }

        private async void returnALl_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog showDialog = new MessageDialog("Are you sure want to return all items? \n fine: $" + this.calculateFine());
            showDialog.Title = "Comfirmation";
            showDialog.Commands.Add(new UICommand("Yes")
            {
                Id = 0
            });
            showDialog.Commands.Add(new UICommand("No")
            {
                Id = 1
            });
            showDialog.DefaultCommandIndex = 0;
            showDialog.CancelCommandIndex = 1;
            var result = await showDialog.ShowAsync();
            Member member = (Member)this.memberList.SelectedItem;
            if ((int)result.Id == 0)
            {
               

                this.TransanctionDAL.returnItems(this.RentalItemsWithSameID, this.Employee, member, 0);
                List<RentalItem> list = this.TransanctionDAL.getAllCurrentRentaledItems((int)member.MemberID);
                list.ForEach(x => x.setRentalIDInfor());
                list.ForEach(x => x.setQuantityList());
                this.rentalItemList.ItemsSource = list;
                this.PreReturnItemList = list;
                this.rentalItemHistoryList.ItemsSource = this.TransanctionDAL.getAllRentalItems((int)member.MemberID);
                this.returnItemList.ItemsSource = this.TransanctionDAL.getAllReturnItems((int)member.MemberID);

                int transactionID = this.TransanctionDAL.GetReturnTransactionID();
                string reciept = "";
                reciept += "Transaction ID: " + transactionID + "\n";
                reciept += "Employee:" + this.Employee.FirstName + " " + this.Employee.LastName + "\n";
                reciept += "Customer:" + member.FirstName + " " + member.LastName + "\n";
                reciept += "Return Items: " + "                       " + "Return Quantity: " + "\n";
                foreach(var returnItem in this.RentalItemsWithSameID)
                {
                    reciept += "" + returnItem.FurnitureName + "               " + returnItem.Quantity + "\n";
                }
                reciept += "\n";
                reciept += "Thanks for your business! Have A Nice Day!";
                
                MessageDialog recieptDialog = new MessageDialog(reciept);
                recieptDialog.Title = "Reciept";
                recieptDialog.Commands.Add(new UICommand("Print")
                {
                    Id = 0
                });
                recieptDialog.Commands.Add(new UICommand("Exist")
                {
                    Id = 1
                });
                recieptDialog.DefaultCommandIndex = 0;
                recieptDialog.CancelCommandIndex = 1;
                await recieptDialog.ShowAsync();
            }
            this.transactionIDBox.ItemsSource = this.TransanctionDAL.getMemberTansactionsNumber((int)member.MemberID);
        }

        private void _switch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;

            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    this.returnItemList.Visibility = Visibility.Visible;

                    this.rentalItemList.Visibility = Visibility.Collapsed;
                    this.filterTransactionLabel.Visibility = Visibility.Collapsed;
                    this.transactionIDBox.Visibility = Visibility.Collapsed;
                    this.returnALl.Visibility = Visibility.Collapsed;

                    this.rentalItemHistoryList.Visibility = Visibility.Visible;
                    this.returnLabel.Visibility = Visibility.Visible;

                    this.returnButton.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.returnItemList.Visibility = Visibility.Collapsed;

                    this.rentalItemList.Visibility = Visibility.Visible;
                    this.filterTransactionLabel.Visibility = Visibility.Visible;
                    this.transactionIDBox.Visibility = Visibility.Visible;
                    this.returnALl.Visibility = Visibility.Collapsed;
                    this.rentalItemHistoryList.Visibility = Visibility.Collapsed;
                    this.returnLabel.Visibility = Visibility.Collapsed;
                    this.returnButton.Visibility = Visibility.Visible;
                }
            }
        }

        private async void returnButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.CheckedReturnItemList.Count == 0)
            {
                MessageDialog dialog = new MessageDialog("Please check at least one return item!");
                await dialog.ShowAsync();
            }
            else
            {
                MessageDialog showDialog = new MessageDialog("Are you sure want to return all items?" + "\n" + "\n" + "Total Fine: $" + this.calculateFine());
                showDialog.Title = "Comfirmation";
                showDialog.Commands.Add(new UICommand("Yes")
                {
                    Id = 0
                });
                showDialog.Commands.Add(new UICommand("No")
                {
                    Id = 1
                });
                showDialog.DefaultCommandIndex = 0;
                showDialog.CancelCommandIndex = 1;
                var result = await showDialog.ShowAsync();
                if ((int)result.Id == 0)
                {
                    Member member = (Member)this.memberList.SelectedItem;

                    if (this.TransanctionDAL.returnItems(this.CheckedReturnItemList, this.Employee, member, (decimal)this.calculateFine()))
                    {
                        List<RentalItem> list = this.TransanctionDAL.getAllCurrentRentaledItems((int)member.MemberID);
                        list.ForEach(x => x.setRentalIDInfor());
                        list.ForEach(x => x.setQuantityList());
                        this.rentalItemList.ItemsSource = list;
                        this.PreReturnItemList = list;
                        this.rentalItemHistoryList.ItemsSource = this.TransanctionDAL.getAllRentalItems((int)member.MemberID);
                        this.returnItemList.ItemsSource = this.TransanctionDAL.getAllReturnItems((int)member.MemberID);
                        this.transactionIDBox.ItemsSource = this.TransanctionDAL.getMemberTansactionsNumber((int)member.MemberID);

                        int transactionID = this.TransanctionDAL.GetReturnTransactionID();
                        string reciept = "";
                        reciept += "Transaction ID: " + transactionID + "\n" + "\n";
                        reciept += "Employee:       " + this.Employee.FirstName + " " + this.Employee.LastName + "\n" + "\n";
                        reciept += "Customer:       " + member.FirstName + " " + member.LastName + "\n" + "\n";
                        reciept += "Return Date:    " + DateTime.Now.ToString("yyyy-MM-dd") + "\n" + "\n";
                        reciept += "Return Items".PadRight(50) + "Return Quantity" + "\n";
                        foreach (var returnItem in this.CheckedReturnItemList)
                        {
                            reciept += returnItem.FurnitureName.PadRight(70, '.');
                            reciept += returnItem.Quantity + "\n";
                        }

                        this.CheckedReturnItemList = new List<RentalItem>();
                        reciept += "\n" + "\n";
                        reciept += "Total fine: $" + this.calculateFine();
                        reciept += "\n" + "\n";
                        reciept += "Thanks for your business! Have A Nice Day!";
                        MessageDialog recieptDialog = new MessageDialog(reciept);
                        recieptDialog.Title = "Reciept";
                        recieptDialog.Commands.Add(new UICommand("Print")
                        {
                            Id = 0
                        });
                        recieptDialog.Commands.Add(new UICommand("Exist")
                        {
                            Id = 1
                        });
                        recieptDialog.DefaultCommandIndex = 0;
                        recieptDialog.CancelCommandIndex = 1;
                        await recieptDialog.ShowAsync();
                    }
                    else
                    {
                        MessageDialog dialog = new MessageDialog("An exception of type was encountered while inserting the data! Neither record was written to database!");
                        await dialog.ShowAsync();
                    }


                }
            }
        }

        private double calculateFine()
        {
            double fines = 0.0;
            foreach (var furniture in this.CheckedReturnItemList)
            {
                double daysPast = (DateTime.Parse(furniture.DueDate) - DateTime.Today).TotalDays;

                if (daysPast < 0)
                {
                    double fee = daysPast * -1 * LATE_FEE_RATE;
                    fines += fee;
                }
            }
            return fines;
        }

        private void quantity_changed(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ((ComboBox)sender).SelectedItem;
            if (selectedItem != null)
            {
                int quantity = (int)selectedItem;
                string tag = (string)((ComboBox)sender).Tag;
                if (tag != null)
                {
                    string[] list = tag.Split(",");
                    int rentalID = Int32.Parse(list[0]);
                    int furnitureID = Int32.Parse(list[1]);
                    this.PreReturnItemList.Find(y => y.RentalID == rentalID && y.FurnitureID == furnitureID).Quantity = quantity;
                    if (this.CheckedReturnItemList.Exists(x=> x.FurnitureID == furnitureID && x.RentalID == rentalID))
                    {
                        this.CheckedReturnItemList.Find(y => y.RentalID == rentalID && y.FurnitureID == furnitureID).Quantity = quantity;
                    }
                }
            }
        }
    }
    
}
