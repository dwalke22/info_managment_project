#pragma checksum "C:\Users\jzeng1\Source\Repos\info_managment_project\CS3230RentalSystemProject\CS3230RentalSystemProject\View\Checkout.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BF6E8A4C9775C6F1AB68A74B2D498CC3E1630C58CAD39984703BEA2AA533B65D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CS3230RentalSystemProject.View
{
    partial class Checkout : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // View\Checkout.xaml line 12
                {
                    this.furnitureList = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                }
                break;
            case 3: // View\Checkout.xaml line 81
                {
                    this.employeeName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // View\Checkout.xaml line 82
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.Checkout_Click;
                }
                break;
            case 5: // View\Checkout.xaml line 83
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.Cancel_Click;
                }
                break;
            case 6: // View\Checkout.xaml line 84
                {
                    this.totalTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // View\Checkout.xaml line 85
                {
                    this.membername = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // View\Checkout.xaml line 87
                {
                    this.rentalDaysForAll = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.rentalDaysForAll).TextChanged += this.rentalDaysForAll_TextChanged;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.rentalDaysForAll).TextChanging += this.rentalDaysForAll_TextChanging;
                }
                break;
            case 9: // View\Checkout.xaml line 90
                {
                    this.returndate = (global::Windows.UI.Xaml.Controls.CalendarDatePicker)(target);
                    ((global::Windows.UI.Xaml.Controls.CalendarDatePicker)this.returndate).DateChanged += this.CalendarDatePicker_DateChanged;
                }
                break;
            case 10: // View\Checkout.xaml line 91
                {
                    global::Windows.UI.Xaml.Controls.Button element10 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element10).Click += this.Button_Click;
                }
                break;
            case 11: // View\Checkout.xaml line 92
                {
                    this.invalidForRentalDays = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13: // View\Checkout.xaml line 27
                {
                    global::Windows.UI.Xaml.Controls.ComboBox element13 = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)element13).SelectionChanged += this.quantity_changed;
                }
                break;
            case 14: // View\Checkout.xaml line 28
                {
                    global::Windows.UI.Xaml.Controls.TextBox element14 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)element14).LostFocus += this.TextBox_LostFocus;
                }
                break;
            case 15: // View\Checkout.xaml line 30
                {
                    global::Windows.UI.Xaml.Controls.CalendarDatePicker element15 = (global::Windows.UI.Xaml.Controls.CalendarDatePicker)(target);
                    ((global::Windows.UI.Xaml.Controls.CalendarDatePicker)element15).DateChanged += this.date_changed;
                }
                break;
            case 16: // View\Checkout.xaml line 31
                {
                    global::Windows.UI.Xaml.Controls.Button element16 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element16).Click += this.removeButtonClick;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

