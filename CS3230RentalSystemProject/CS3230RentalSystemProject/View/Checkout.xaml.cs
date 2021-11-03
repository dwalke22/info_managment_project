﻿using CS3230RentalSystemProject.Model;
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
            this.Employee.Member = null;
            this.Employee.SelectedFurniture = null;
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
            this.Employee.FurnitureListData.Clear();
            this.Employee.Member = null;
            this.Employee.SelectedFurniture = null;
            Frame.Navigate(typeof(EmployeeWindow), this.Employee);
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
            var selectedItem = ((ComboBox)sender).SelectedItem;
            if (selectedItem != null)
            {
                int quantity = (int)selectedItem;
                int tag = (int)((ComboBox)sender).Tag;
                if (this.Employee.FurnitureListData.Find(x => x.FurnitureID == tag).RentQuantity != quantity)
                {
                    this.Employee.FurnitureListData.Find(x => x.FurnitureID == tag).RentQuantity = (int)selectedItem;
                    this.Employee.FurnitureListData.Find(x => x.FurnitureID == tag).setCurentTotalPrice();
                    List<Furniture> list = new List<Furniture>();
                    foreach (Furniture item in this.Employee.FurnitureListData)
                    {
                        list.Add(item);
                    }
                    this.furnitureList.ItemsSource = list;
                    this.resetTotalText();
                }
            }
        }

        private void date_changed(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            if (((CalendarDatePicker)sender).Tag != null)
            {
                int tag = (int)((CalendarDatePicker)sender).Tag;
                this.Employee.FurnitureListData.Find(x => x.FurnitureID == tag).ReturnDate =
                    DateTimeOffset.Parse(((CalendarDatePicker)sender).Date.ToString()).DateTime;
                this.Employee.FurnitureListData.Find(x => x.FurnitureID == tag).setCurentTotalPrice();
                if (this.Employee.FurnitureListData.Find(x => x.FurnitureID == tag).RentalDays != 1)
                {
                   
                    
                }

                this.resetTotalText();

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
            this.furnitureListData = new List<Furniture>();
            this.Employee = (Employee)e.Parameter;
            //var info = (EmployeeWindow.SelectedInfo)e.Parameter;
            //this.Employee = info.Employee;
            this.Member = Employee.Member;
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
                    total += furniture.CurrentToalPrice;
                }
                this.totalTextBlock.Text = "Total: $" + total;
            }
        }

        private void TextBox_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            var selectedItem = ((TextBox)sender).Text;
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                int days = Int32.Parse(selectedItem);
                int tag = (int)((TextBox)sender).Tag;
                this.Employee.FurnitureListData.Find(x => x.FurnitureID == tag).RentalDays = days;
                DateTime date = DateTime.Now.AddDays(days);
                this.Employee.FurnitureListData.Find(x => x.FurnitureID == tag).ReturnDate = DateTimeOffset.Now.AddDays(days);
                this.Employee.FurnitureListData.Find(x => x.FurnitureID == tag).setCurentTotalPrice();
                List<Furniture> list = new List<Furniture>();
                foreach (Furniture item in this.Employee.FurnitureListData)
                {
                    list.Add(item);
                }
                this.furnitureList.ItemsSource = list;
                this.resetTotalText();
            }
        }
    }
}
