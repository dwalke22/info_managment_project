using CS3230RentalSystemProject.DAL;
using CS3230RentalSystemProject.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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

        private string searchType;

        private TransanctionDAL TransanctionDAL;

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
            
        }

        private void searchBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            this.memberList.ItemsSource = dAL.GetAllMemberList();
            this.invalidSearch.Visibility = Visibility.Collapsed;
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
            if (this.searchType == "MemberID")
            {
                this.searchBox.PlaceholderText = "eg: 1";
            }
            else if (this.searchType == "Phone")
            {
                this.searchBox.PlaceholderText = "eg: 6782960303";
            }
            else if (this.searchType == "FullName")
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

        private async void returnButtonClick(object sender, RoutedEventArgs e)
        {
            

            MessageDialog showDialog = new MessageDialog("Are you sure want to return all items? \n fine: 0.00");
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
                string tag = (string)((Button)sender).Tag;
                string[] list = tag.Split(",");
                int rentalID = Int32.Parse(list[0]);
                int furnitureID = Int32.Parse(list[1]);
                List<RentalItem> rentalItems = this.TransanctionDAL.getRentalItem(rentalID, furnitureID);

                this.TransanctionDAL.returnItems(rentalItems, this.Employee, member, 0);

                this.rentalItemList.ItemsSource = this.TransanctionDAL.getAllRentalItems((int)member.MemberID);
                this.returnItemList.ItemsSource = this.TransanctionDAL.getAllReturnItems((int)member.MemberID);
                this.transactionIDBox.ItemsSource = this.TransanctionDAL.getMemberTansactionsNumber((int)member.MemberID);

                int transactionID = this.TransanctionDAL.GetReturnTransactionID();
                string reciept = "";
                reciept += "Transaction ID: " + transactionID + "\n";
                reciept += "Employee:" + this.Employee.FirstName + " " + this.Employee.LastName + "\n";
                reciept += "Customer:" + member.FirstName + " " + member.LastName + "\n";
                reciept += "Return Items: " + "                   " + "Return Quantity: " + "\n";
                foreach (var returnItem in rentalItems)
                {
                    reciept += "" + returnItem.FurnitureName + "           " + returnItem.Quantity + "\n";
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


        }


        private void memberList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Member member = (Member)this.memberList.SelectedItem;
            this.rentalItemList.ItemsSource = this.TransanctionDAL.getAllRentalItems((int)member.MemberID);
            this.returnItemList.ItemsSource = this.TransanctionDAL.getAllReturnItems((int)member.MemberID);
            this.transactionIDBox.ItemsSource = this.TransanctionDAL.getMemberTansactionsNumber((int)member.MemberID);
            this.membername.Text = "Member: " + member.ToString();
        }

        private void transactionIDBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (string)this.transactionIDBox.SelectedItem;
            int id = Int32.Parse(text);
            List<RentalItem> list = this.TransanctionDAL.getAllRentalItemsByRentalID(id);
            this.rentalItemList.ItemsSource = list;
            this.RentalItemsWithSameID = list;
        }

        private void returnToMainPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void returnALl_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog showDialog = new MessageDialog("Are you sure want to return all items? \n fine: 0.00");
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

                this.TransanctionDAL.returnItems(this.RentalItemsWithSameID, this.Employee, member, 0);

                this.rentalItemList.ItemsSource = this.TransanctionDAL.getAllRentalItems((int)member.MemberID);
                this.returnItemList.ItemsSource = this.TransanctionDAL.getAllReturnItems((int)member.MemberID);
                this.transactionIDBox.ItemsSource = this.TransanctionDAL.getMemberTansactionsNumber((int)member.MemberID);

                int transactionID = this.TransanctionDAL.GetReturnTransactionID();
                string reciept = "";
                reciept += "Transaction ID: " + transactionID + "\n";
                reciept += "Employee:" + this.Employee.FirstName + " " + this.Employee.LastName + "\n";
                reciept += "Customer:" + member.FirstName + " " + member.LastName + "\n";
                reciept += "Return Items: " + "                   " + "Return Quantity: " + "\n";
                foreach(var returnItem in this.RentalItemsWithSameID)
                {
                    reciept += "" + returnItem.FurnitureName + "           " + returnItem.Quantity + "\n";
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
            
        }
    }
    
}
