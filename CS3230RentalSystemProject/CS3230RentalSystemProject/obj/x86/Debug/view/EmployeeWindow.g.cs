﻿#pragma checksum "C:\Users\jzeng1\Documents\GitHub\info_managment_project\CS3230RentalSystemProject\CS3230RentalSystemProject\View\EmployeeWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7BA03D4B4F5E05AA15A2B39F175616EC3CA30A31A017E90E3E93A75D005A05E5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CS3230RentalSystemProject.view
{
    partial class EmployeeWindow : 
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
            case 2: // View\EmployeeWindow.xaml line 12
                {
                    this.employeeName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3: // View\EmployeeWindow.xaml line 13
                {
                    this.registerMemberButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.registerMemberButton).Click += this.registerMemberButton_Click;
                }
                break;
            case 4: // View\EmployeeWindow.xaml line 14
                {
                    this.bagButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.bagButton).Click += this.bagButton_Click;
                }
                break;
            case 5: // View\EmployeeWindow.xaml line 16
                {
                    this.criteriaList = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.criteriaList).SelectionChanged += this.criteriaList_SelectionChanged;
                }
                break;
            case 6: // View\EmployeeWindow.xaml line 17
                {
                    this.searchBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.searchBox).TextChanging += this.searchBox_TextChanging;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.searchBox).KeyDown += this.searchBox_KeyDown;
                }
                break;
            case 7: // View\EmployeeWindow.xaml line 18
                {
                    this.invalidSearch = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // View\EmployeeWindow.xaml line 19
                {
                    this.memberList = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.memberList).DoubleTapped += this.employeeList_DoubleTapped;
                }
                break;
            case 9: // View\EmployeeWindow.xaml line 21
                {
                    this.furnitureFilterComboBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.furnitureFilterComboBox).SelectionChanged += this.furnitureComboBox_SelectionChanged;
                }
                break;
            case 10: // View\EmployeeWindow.xaml line 22
                {
                    this.resetFilterButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.resetFilterButton).Click += this.resetFilterButton_Click;
                }
                break;
            case 11: // View\EmployeeWindow.xaml line 23
                {
                    this.styleComboBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.styleComboBox).SelectionChanged += this.styleComboBox_SelectionChanged;
                }
                break;
            case 12: // View\EmployeeWindow.xaml line 24
                {
                    this.categoryComboBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.categoryComboBox).SelectionChanged += this.categoryComboBox_SelectionChanged;
                }
                break;
            case 13: // View\EmployeeWindow.xaml line 25
                {
                    this.funiturePriceTextbox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.funiturePriceTextbox).TextChanged += this.funiturePriceTextbox_TextChanged;
                }
                break;
            case 14: // View\EmployeeWindow.xaml line 26
                {
                    this.priceErrorTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15: // View\EmployeeWindow.xaml line 27
                {
                    this.applyPriceFilter = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.applyPriceFilter).Click += this.applyPriceFilter_Click;
                }
                break;
            case 16: // View\EmployeeWindow.xaml line 28
                {
                    this.furnitureList = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.furnitureList).DoubleTapped += this.furnitureList_DoubleTapped;
                }
                break;
            case 17: // View\EmployeeWindow.xaml line 87
                {
                    this.logout = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.logout).Click += this.logout_Click;
                }
                break;
            case 18: // View\EmployeeWindow.xaml line 92
                {
                    this.memberErrorLabel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 19: // View\EmployeeWindow.xaml line 93
                {
                    this.furnitureIDSearch = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.furnitureIDSearch).TextChanging += this.furnitureIDSearch_TextChanging;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.furnitureIDSearch).KeyDown += this.furnitureIDSearch_KeyDown;
                }
                break;
            case 20: // View\EmployeeWindow.xaml line 94
                {
                    this.invalidFurnitureSearch = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 22: // View\EmployeeWindow.xaml line 44
                {
                    global::Windows.UI.Xaml.Controls.Button element22 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element22).Click += this.addButtonClick;
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

