using CS3230RentalSystemProject.DAL;
using CS3230RentalSystemProject.Model;
using CS3230RentalSystemProject.view;
using System;
using System.Collections.Generic;
using System.Data;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
                    int maxLenght = 0;
                    for (int i = 0; i <coumnCount; i++)
                    {
                        if (data.Columns[i].ColumnName.Length > maxLenght)
                        {
                            maxLenght = data.Columns[i].ColumnName.Length;
                        }
                    }
                    int columnWidth = maxLenght + 2;

                    text += this.formattTableHeaders(data, columnWidth);

                    text += Environment.NewLine;

                    int rowsCount = data.Rows.Count;
                    for (int i = 0; i < rowsCount; i++)
                    {
                        DataRow row = data.Rows[i];
                        text += this.formatRow(row, columnWidth);
                    }

                    this.resultBox.Text = text;
                }
            }
           
        }

        private string formattTableHeaders(DataTable data, int columnWidth)
        {
            string text = "";
            for (int i = 0; i < data.Columns.Count; i++)
            {
                if (i == data.Columns.Count - 1)
                {
                    text += data.Columns[i].ColumnName;
                }
                else
                {
                    string rowData = data.Columns[i].ColumnName;
                    int width = data.Columns[i].ColumnName.Length;
                    while (width < columnWidth)
                    {
                        rowData += " ";
                        width++;
                    }

                    text += rowData;
                }
            }

            return text;
        }

        private string formatRow(DataRow row, int columnWidth)
        {
            string text = "";
            int count = row.ItemArray.Length;
            for (int k = 0; k < count; k++)
            {
                string rowData = "";
                if (k == count - 1)
                {
                    rowData = row[k].ToString();
                    if (row[k].GetType() == typeof(DateTime))
                    {
                        rowData = ((DateTime)row[k]).ToString("yyyy-MM-dd");
                    }
                }
                else
                {
                    rowData = row[k].ToString();
                    if (row[k].GetType() == typeof(DateTime))
                    {
                        rowData = ((DateTime)row[k]).ToString("yyyy-MM-dd");
                    }

                    if (rowData.Length > columnWidth)
                    {
                        string tempString = rowData.Substring(0, columnWidth - 4);
                        tempString = tempString + "...";
                        rowData = tempString;
                    }
                    else
                    {
                        int width = rowData.Length;
                        while (width < columnWidth)
                        {
                            rowData += " ";
                            width++;
                        }
                    }
                }
                text += rowData;
            }
            text += Environment.NewLine;
            return text;
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

        private void mainPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EmployeeWindow), this.Employee);
        }

        private void report_Click(object sender, RoutedEventArgs e)
        {
            this.queryPage.Visibility = Visibility.Visible;
            this.firstDate.Visibility = Visibility.Visible;
            this.secondDate.Visibility = Visibility.Visible;
            this.firstDateLabel.Visibility = Visibility.Visible;
            this.secondDateLabel.Visibility = Visibility.Visible;
            this.executeReportButton.Visibility = Visibility.Visible;
            this.reportList.Visibility = Visibility.Visible;

            this.entryQueryLabel.Visibility = Visibility.Collapsed;
            this.queryBox.Visibility = Visibility.Collapsed;
            this.excuteButton.Visibility = Visibility.Collapsed;
            this.resultBox.Visibility = Visibility.Collapsed;
            this.mainpage.Visibility = Visibility.Collapsed;
            this.report.Visibility = Visibility.Collapsed;

            this.queryBox.Text = "";
            this.resultBox.Text = "";
        }

        private void queryPage_Click(object sender, RoutedEventArgs e)
        {
            this.queryPage.Visibility = Visibility.Collapsed;
            this.firstDate.Visibility = Visibility.Collapsed;
            this.secondDate.Visibility = Visibility.Collapsed;
            this.firstDateLabel.Visibility = Visibility.Collapsed;
            this.secondDateLabel.Visibility = Visibility.Collapsed;
            this.executeReportButton.Visibility = Visibility.Collapsed;
            this.reportList.Visibility = Visibility.Collapsed;

            this.entryQueryLabel.Visibility = Visibility.Visible;
            this.queryBox.Visibility = Visibility.Visible;
            this.excuteButton.Visibility = Visibility.Visible;
            this.resultBox.Visibility = Visibility.Visible;
            this.mainpage.Visibility = Visibility.Visible;
            this.report.Visibility = Visibility.Visible;

            this.firstDate.Date = null;
            this.secondDate.Date = null;
            this.reportList.ItemsSource = new List<Report>();

        }

        private async void executeReportButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.firstDate.Date == null || this.secondDate.Date == null)
            {
                var message = new MessageDialog("Please select your first date and second date!");
                await message.ShowAsync();
            } else if (this.firstDate.Date >= this.secondDate.Date)
            {
                var message = new MessageDialog("Please make sure your first date is before your second date!");
                await message.ShowAsync();
            } else
            {
                this.reportList.ItemsSource = AdminQueryDAL.getReportByDates(DateTimeOffset.Parse(this.firstDate.Date.ToString()).Date, DateTimeOffset.Parse(this.secondDate.Date.ToString()).Date);
            }
        }

        private void queryBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.resultBox.Text = "";
        }
    }
}
