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
    public sealed partial class Checkout : Page
    {
        public Employee Employee { get; set; }

        private IList<Furniture> furnitureListData;

        public Checkout()
        {
            this.InitializeComponent();
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
            this.furnitureList.ItemsSource = this.Employee.FurnitureListData;
            this.furnitureListData = this.Employee.FurnitureListData;
            this.employeeName.Text = this.Employee.ToString();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EmployeeWindow), this.Employee);
        }

        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
        }

        private void warningButtonClick(object sender, RoutedEventArgs e)
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


        }
    }
}
