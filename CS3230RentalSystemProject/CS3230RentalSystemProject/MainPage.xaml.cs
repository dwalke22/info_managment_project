using CS3230RentalSystemProject.view;
using CS3230RentalSystemProject.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CS3230RentalSystemProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region DataMember

        private readonly EmployeeViewModel viewModel;

        #endregion

        #region Contructor

        /// <summary>
        /// Initialize constructor
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            this.viewModel = new EmployeeViewModel();
        }

        #endregion

        #region Methods

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EmployeeWindow));
        }

        #endregion
    }
}
