#pragma checksum "C:\Users\jzeng1\Source\Repos\info_managment_project\CS3230RentalSystemProject\CS3230RentalSystemProject\View\AddFurnitureContentDialog1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BB56E834BF3672F5032FDEE723BF7421E52D7279E56142AC1EC7E3AB607BA370"
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
    partial class AddFurnitureContentDialog1 : 
        global::Windows.UI.Xaml.Controls.ContentDialog, 
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
            case 1: // View\AddFurnitureContentDialog1.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.ContentDialog element1 = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).PrimaryButtonClick += this.ContentDialog_PrimaryButtonClick;
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).SecondaryButtonClick += this.ContentDialog_SecondaryButtonClick;
                }
                break;
            case 2: // View\AddFurnitureContentDialog1.xaml line 17
                {
                    this.furnitureTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // View\AddFurnitureContentDialog1.xaml line 19
                {
                    this.styleComboBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 4: // View\AddFurnitureContentDialog1.xaml line 21
                {
                    this.categoryComboBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 5: // View\AddFurnitureContentDialog1.xaml line 23
                {
                    this.priceTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // View\AddFurnitureContentDialog1.xaml line 25
                {
                    this.quantityTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
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

