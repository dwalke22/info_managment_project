using CS3230RentalSystemProject.Model;
using CS3230RentalSystemProject.view;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CS3230RentalSystemProject.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FurnitureView : Page
    {

        /// <summary>
        /// The Employee
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// Initialize constructor
        /// </summary>
        public FurnitureView()
        {
            this.InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EmployeeWindow), this.Employee);
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
            this.employeeName.Text = this.Employee.ToString();
            this.name.Text = this.Employee.SelectedFurniture.FurnitureName;
            this.style.Text = this.Employee.SelectedFurniture.Style;
            this.category.Text = this.Employee.SelectedFurniture.Category;
            this.quantity.Text = this.Employee.SelectedFurniture.Quantity.ToString();
            this.price.Text = this.Employee.SelectedFurniture.RentPrice.ToString();
            this.id.Text = this.Employee.SelectedFurniture.FurnitureID.ToString();
            if (this.Employee.SelectedFurniture.Quantity == 0)
            {
                this.availabilty.Text = this.Employee.SelectedFurniture.Availability.Date.ToShortDateString();
            }
            else
            {
                this.availabilty.Text = "Available Now";
            }
        }
    }
}
