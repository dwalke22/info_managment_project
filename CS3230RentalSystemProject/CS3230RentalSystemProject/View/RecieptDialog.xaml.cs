using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using CS3230RentalSystemProject.Model;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CS3230RentalSystemProject.View
{
    /// <summary>
    /// The class RecieptDialog
    /// </summary>
    public sealed partial class RecieptDialog : ContentDialog
    {
        /// <summary>
        /// The furniture list data
        /// </summary>
        public IList<Furniture> furnitureListData;

        /// <summary>
        /// Initalize constructor
        /// </summary>
        /// <param name="furnitureList"> The rentaled furniture List</param>
        public RecieptDialog(List<Furniture> furnitureList)
        {
            this.InitializeComponent();
            this.itemListBox.ItemsSource = furnitureList;
            this.Width = 400;
            this.Height = 400;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //Close dialog
        }
    }
}
