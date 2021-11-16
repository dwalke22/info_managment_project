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
using CS3230RentalSystemProject.Model;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CS3230RentalSystemProject.View
{
    public sealed partial class RecieptDialog : ContentDialog
    {
        /// <summary>
        /// The furniture list data
        /// </summary>
        public IList<Furniture> furnitureListData;

        public RecieptDialog(List<Furniture> furnitureList)
        {
            this.InitializeComponent();
            this.itemListBox.ItemsSource = furnitureList;
            this.Width = 400;
            this.Height = 400;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

    }
}
