using CS3230RentalSystemProject.Model;
using CS3230RentalSystemProject.view;
using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using CS3230RentalSystemProject.DAL;
using System.Text.RegularExpressions;

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

        /// <summary>
        /// The Member
        /// </summary>
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
            this.invalidForRentalDays.Visibility = Visibility.Collapsed;
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
            this.Employee = (Employee)e.Parameter;
            this.Member = Employee.SelectedMember;
            this.furnitureList.ItemsSource = this.Employee.SelectedMember.FurnitureListData;
            this.furnitureListData = this.Employee.SelectedMember.FurnitureListData;
            this.employeeName.Text = "Employee: " + this.Employee.ToString();
            this.membername.Text = "Member: " + this.Member.ToString();
            this.returndate.Date = DateTime.Now.AddDays(1);
            this.resetTotalText();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Employee.SelectedFurniture = null;
            Frame.Navigate(typeof(EmployeeWindow), this.Employee);
        }

        private async void Checkout_Click(object sender, RoutedEventArgs e)
        {
            decimal total = Convert.ToDecimal(this.totalTextBlock.Text.Split("$")[1]);
            if (this.checkoutDal.CheckoutCart(this.Employee.SelectedMember.FurnitureListData, this.Employee, total, this.Member))
            {
                var messageDialog = new MessageDialog("Order Complete.");

                await messageDialog.ShowAsync();

                var reciept = new RecieptDialog(this.Employee.SelectedMember.FurnitureListData);
                reciept.Width = 400;
                reciept.Height = 400;

                await reciept.ShowAsync();

                this.Employee.SelectedMember.FurnitureListData.Clear();
                this.Employee.SelectedMember = null;
                this.Employee.SelectedFurniture = null;
                Frame.Navigate(typeof(EmployeeWindow), this.Employee);
            }
            else
            {
                MessageDialog dialog = new MessageDialog("An exception of type was encountered while inserting the data! Neither record was written to database!");
                await dialog.ShowAsync();
            }
        }

        private void removeButtonClick(object sender, RoutedEventArgs e)
        {
            int tag = (int)((Button)sender).Tag;
            

            Furniture furniture = this.Employee.SelectedMember.FurnitureListData.Find(x => x.FurnitureID == tag);

            this.Employee.SelectedMember.FurnitureListData.Remove(furniture);
            List <Furniture> list = new List<Furniture>();
            foreach(Furniture item in this.Employee.SelectedMember.FurnitureListData)
            {
                list.Add(item);
            }
            this.furnitureList.ItemsSource = list;
            this.resetTotalText();
        }

        private void quantity_changed(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ((ComboBox)sender).SelectedItem;
            if (selectedItem != null)
            {
                int quantity = (int)selectedItem;
                int tag = (int)((ComboBox)sender).Tag;
                if (this.Employee.SelectedMember.FurnitureListData.Find(x => x.FurnitureID == tag).RentQuantity != quantity)
                {
                    this.Employee.SelectedMember.FurnitureListData.Find(x => x.FurnitureID == tag).RentQuantity = (int)selectedItem;
                    this.Employee.SelectedMember.FurnitureListData.Find(x => x.FurnitureID == tag).setCurentTotalPrice();
                    List<Furniture> list = new List<Furniture>();
                    foreach (Furniture item in this.Employee.SelectedMember.FurnitureListData)
                    {
                        list.Add(item);
                    }
                    this.furnitureList.ItemsSource = list;
                    this.resetTotalText();
                }
            }
        }

        private async void date_changed(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            if (((CalendarDatePicker)sender).Tag != null)
            {
                try
                {
                    DateTime date = DateTimeOffset.Parse(((CalendarDatePicker)sender).Date.ToString()).Date;
                    if (date.AddDays(1) < DateTime.Now.AddDays(1))
                    {
                        var message = new MessageDialog(" Cannot select past date! Please try again!");

                        sender.Date = args.OldDate;
                        await message.ShowAsync();
                    }
                    else
                    {
                        int tag = (int)((CalendarDatePicker)sender).Tag;
                        int days = (((CalendarDatePicker)sender).Date.Value.DateTime.Date - DateTime.Now).Days + 1;
                        this.Employee.SelectedMember.FurnitureListData.Find(x => x.FurnitureID == tag).RentalDays = days;
                        this.Employee.SelectedMember.FurnitureListData.Find(x => x.FurnitureID == tag).ReturnDate = DateTime.Now.AddDays(days);
                        this.Employee.SelectedMember.FurnitureListData.Find(x => x.FurnitureID == tag).setCurentTotalPrice();
                        List<Furniture> list = new List<Furniture>();
                        foreach (Furniture item in this.Employee.SelectedMember.FurnitureListData)
                        {
                            list.Add(item);
                        }
                        this.furnitureList.ItemsSource = list;
                        this.resetTotalText();
                    }
                }
                catch (Exception)
                {
                }

            }

        }

        private async void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var inputdays = ((TextBox)sender).Text;
            int tag = (int)((TextBox)sender).Tag;
            Regex regex = new Regex(@"[\d]");
            if (!regex.IsMatch(inputdays))
            {
                var message = new MessageDialog(" " + inputdays + " is not valid. Please type agian!");
                await message.ShowAsync();
                ((TextBox)sender).Text = "" + this.Employee.SelectedMember.FurnitureListData.Find(x => x.FurnitureID == tag).RentalDays;
                return;

            }
            if (regex.IsMatch(inputdays))
            {
                int day = Int32.Parse(inputdays);
                if (day < 1)
                {
                    var message = new MessageDialog(" " + inputdays + " is not valid. Please type agian!");
                    await message.ShowAsync();
                    ((TextBox)sender).Text = "" + this.Employee.SelectedMember.FurnitureListData.Find(x => x.FurnitureID == tag).RentalDays;
                    return;
                }

            }
            int days = Int32.Parse(inputdays);
            
            this.Employee.SelectedMember.FurnitureListData.Find(x => x.FurnitureID == tag).RentalDays = days;
            this.Employee.SelectedMember.FurnitureListData.Find(x => x.FurnitureID == tag).ReturnDate = DateTime.Now.AddDays(days);
            this.Employee.SelectedMember.FurnitureListData.Find(x => x.FurnitureID == tag).setCurentTotalPrice();
            List<Furniture> list = new List<Furniture>();
            foreach (Furniture item in this.Employee.SelectedMember.FurnitureListData)
            {
                list.Add(item);
            }
            this.furnitureList.ItemsSource = list;
            this.resetTotalText();

        }

        private void rentalDaysForAll_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = this.rentalDaysForAll.Text;
            if (text != "")
            {
                Regex regex = new Regex(@"[\d]");
                if (!regex.IsMatch(text))
                {
                    this.invalidForRentalDays.Visibility = Visibility.Visible;
                }
                if (regex.IsMatch(text))
                {
                    int days = Int32.Parse(text);
                    if (days < 1)
                    {
                        this.invalidForRentalDays.Visibility = Visibility.Visible;
                    }

                }
            }
        }

        private void rentalDaysForAll_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            this.invalidForRentalDays.Visibility = Visibility.Collapsed;
        }

        private async void CalendarDatePicker_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            try
            {
                DateTime date = DateTimeOffset.Parse(((CalendarDatePicker)sender).Date.ToString()).Date;
                if (date.AddDays(1) < DateTime.Now.AddDays(1))
                {
                    var message = new MessageDialog(" Cannot select past date! Please try again!");
                    await message.ShowAsync();
                    this.returndate.Date = DateTime.Now.AddDays(1);
                }
                else
                {
                    int days = (this.returndate.Date.Value.DateTime.Date - DateTime.Now).Days + 1;
                    this.rentalDaysForAll.Text = days.ToString();
                }
            }
            catch(Exception)
            {
                this.returndate.Date = DateTime.Now.AddDays(1);
            }
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.rentalDaysForAll.Text != null || this.rentalDaysForAll.Text != "")
            {
                if (this.invalidForRentalDays.Visibility != Visibility.Visible)
                {
                    this.returndate.Date = DateTimeOffset.Now.Date.AddDays(Int32.Parse(this.rentalDaysForAll.Text));
                    List<Furniture> list = new List<Furniture>();
                    foreach (Furniture item in this.Employee.SelectedMember.FurnitureListData)
                    {
                        item.RentalDays = Int32.Parse(this.rentalDaysForAll.Text);
                        item.ReturnDate = DateTimeOffset.Now.Date.AddDays(Int32.Parse(this.rentalDaysForAll.Text));
                        item.setCurentTotalPrice();
                        list.Add(item);
                    }
                    this.furnitureList.ItemsSource = list;
                    this.resetTotalText();
                }
                
            } 
            else
            {
                var message = new MessageDialog("Please input your rental days or select your return day!");
                await message.ShowAsync();
            }
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
                foreach (var furniture in this.Employee.SelectedMember.FurnitureListData)
                {
                    total += furniture.CurrentToalPrice;
                }
                this.totalTextBlock.Text = "Total: $" + total;
            }
        }
    }
}
