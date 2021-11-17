using CS3230RentalSystemProject.DAL;
using CS3230RentalSystemProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CS3230RentalSystemProject.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminInterface : Page
    {

        /// <summary>
        /// The Empolyee
        /// </summary>
        public Employee Employee { get; set; }

        public AdminInterface()
        {
            this.InitializeComponent();
        }

        private async void excuteButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.queryBox.Text == "" || this.queryBox.Text == null)
            {
                MessageDialog dialog = new MessageDialog("Please Input your Query Statement!");
                await dialog.ShowAsync();
            }
            else
            {
                DataTable data = AdminQueryDAL.AdminQuery(this.queryBox.Text);
                if (data == null)
                {
                    MessageDialog dialog = new MessageDialog("Invalid Query Statement!");
                    await dialog.ShowAsync();
                }
                else
                {
                    string text = string.Empty;

                    int coumnCount = data.Columns.Count;
                    for (int i = 0; i < coumnCount; i++)
                    {
                        text += data.Columns[i].ColumnName.ToString().PadRight(15);
                    }
                    text += Environment.NewLine;
                    int rowsCount = data.Rows.Count;
                    for (int i = 0; i < rowsCount; i++)
                    {
                        DataRow row = data.Rows[i];
                        int count = row.ItemArray.Length;
                        for (int k = 0; k < count; k++)
                        {
                            string rowData = row[k].ToString();
                            if (row[k].GetType() == typeof(DateTime))
                            {
                                rowData = ((DateTime)row[k]).ToString("yyyy-MM-dd");
                            }
                            text += rowData.PadRight(15);
                        }
                        text += Environment.NewLine;
                    }
                    this.resultBox.Text = text;
                }
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
            this.adminName.Text = "Admin: " + this.Employee.ToString();
        }
    }
}
