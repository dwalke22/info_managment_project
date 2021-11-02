using CS3230RentalSystemProject.Model;
using CS3230RentalSystemProject.view;
using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using CS3230RentalSystemProject.DAL;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CS3230RentalSystemProject.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Checkout : Page
    {
        /// <summary>
        /// The Employee
        /// </summary>
        public Employee Employee { get; set; }

        public Member Member { get; set; }

        private IList<Furniture> furnitureListData;
        private CheckoutDAL checkoutDal;

        /// <summary>
        /// Initialize constructor
        /// </summary>
        public Checkout()
        {
            this.InitializeComponent();
            this.checkoutDal = new CheckoutDAL();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Employee.FurnitureListData.Clear();
            Frame.Navigate(typeof(EmployeeWindow), this.Employee);
        }

        private async void Checkout_Click(object sender, RoutedEventArgs e)
        {
            foreach (var furniture in this.Employee.FurnitureListData)
            {
                if (furniture.ReturnDate == DateTime.MinValue)
                {
                    var datemessageDialog = new MessageDialog("Please select return date for all items!");

                    await datemessageDialog.ShowAsync();
                    return;
                }
            }
            decimal total = Convert.ToDecimal(this.totalTextBlock.Text.Split("$")[1]);
            this.checkoutDal.CreateTransaction(this.Employee, total, this.Member);
            int transactionID = this.checkoutDal.GetTransactionID();
            this.checkoutDal.CheckoutCart(this.Employee.FurnitureListData, this.Employee, transactionID);

            var messageDialog = new MessageDialog("Order Complete.");

            await messageDialog.ShowAsync();

            Frame.Navigate(typeof(EmployeeWindow));
        }

        private void removeButtonClick(object sender, RoutedEventArgs e)
        {
            int tag = (int)((Button)sender).Tag;
            

            Furniture furniture = this.Employee.FurnitureListData.Find(x => x.FurnitureID == tag);

            this.Employee.FurnitureListData.Remove(furniture);
            List <Furniture> list = new List<Furniture>();
            foreach(Furniture item in this.Employee.FurnitureListData)
            {
                list.Add(item);
            }
            this.furnitureList.ItemsSource = list;
            this.resetTotalText();
        }

        private void quantity_changed(object sender, SelectionChangedEventArgs e)
        {
            int tag = (int)((ComboBox)sender).Tag;
            this.Employee.FurnitureListData.Find(x => x.FurnitureID == tag).RentQuantity = (int)((ComboBox)sender).SelectedItem;
            this.resetTotalText();
        }

        private void date_changed(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            int tag = (int)((CalendarDatePicker)sender).Tag;
            this.Employee.FurnitureListData.Find(x => x.FurnitureID == tag).ReturnDate = DateTimeOffset.Parse(((CalendarDatePicker)sender).Date.ToString()).DateTime;
            this.resetTotalText();
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
            this.furnitureListData = new List<Furniture>();
            var info = (EmployeeWindow.SelectedInfo)e.Parameter;
            this.Employee = info.Employee;
            this.Member = info.Member;
            this.furnitureList.ItemsSource = this.Employee.FurnitureListData;
            this.furnitureListData = this.Employee.FurnitureListData;
            this.employeeName.Text = "Employee: " + this.Employee.ToString();
            this.membername.Text = "Member: " + this.Member.ToString();
            this.resetTotalText();
        }

        private void resetTotalText()
        {
            if (this.furnitureListData.Count == 0)
            {
                this.totalTextBlock.Text = "Not Items In The Cart.";
            }
            else
            {
                decimal total = 0;
                foreach (var furniture in this.Employee.FurnitureListData)
                {
                    total += furniture.RentPrice * furniture.RentQuantity;
                }
                this.totalTextBlock.Text = "Total: $" + total;
            }
        }

    }
}
