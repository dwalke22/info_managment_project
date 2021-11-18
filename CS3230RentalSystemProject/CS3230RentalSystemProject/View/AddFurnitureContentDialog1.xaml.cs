using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using CS3230RentalSystemProject.DAL;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CS3230RentalSystemProject.View
{
    public sealed partial class AddFurnitureContentDialog1 : ContentDialog
    {
        private FurnitureDAL funitureDal;

        public AddFurnitureContentDialog1()
        {
            this.InitializeComponent();
            this.funitureDal = new FurnitureDAL();
            this.styleComboBox.ItemsSource = this.funitureDal.GetAllFurnitureStyles();
            this.categoryComboBox.ItemsSource = this.funitureDal.GetAllFurnitureCategories();
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var quantity = Int32.Parse(this.quantityTextBox.Text);
            var price = Decimal.Parse(this.priceTextBox.Text);
            var style = this.styleComboBox.SelectedItem.ToString();
            var category = this.categoryComboBox.SelectedItem.ToString();


            this.funitureDal.AddFurnitureToInventory(this.furnitureTextBox.Text, style, category, price, quantity);

            var message = new MessageDialog("Furniture added to inventory.");

            await message.ShowAsync();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
