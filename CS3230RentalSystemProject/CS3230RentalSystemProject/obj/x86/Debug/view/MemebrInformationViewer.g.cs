﻿#pragma checksum "C:\Users\jason\source\repos\info_managment_project\CS3230RentalSystemProject\CS3230RentalSystemProject\View\MemebrInformationViewer.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3E2953A3363E87DF79ED0F0047CB840514714F5218C234B9608017AF42ABE989"
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
    partial class MemebrInformationViewer : 
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
            case 2: // View\MemebrInformationViewer.xaml line 18
                {
                    this.employeeName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3: // View\MemebrInformationViewer.xaml line 32
                {
                    this.birtdayChooser = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                    ((global::Windows.UI.Xaml.Controls.DatePicker)this.birtdayChooser).DateChanged += this.birtdayChooser_DateChanged;
                }
                break;
            case 4: // View\MemebrInformationViewer.xaml line 33
                {
                    this.firstNameInputBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.firstNameInputBox).TextChanged += this.firstNameInputBox_TextChanged;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.firstNameInputBox).TextChanging += this.firstNameInputBox_TextChanging;
                }
                break;
            case 5: // View\MemebrInformationViewer.xaml line 34
                {
                    this.lastNameInputBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.lastNameInputBox).TextChanged += this.lastNameInputBox_TextChanged;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.lastNameInputBox).TextChanging += this.lastNameInputBox_TextChanging;
                }
                break;
            case 6: // View\MemebrInformationViewer.xaml line 35
                {
                    this.phoneInputBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.phoneInputBox).TextChanged += this.phoneInputBox_TextChanged;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.phoneInputBox).TextChanging += this.phoneInputBox_TextChanging;
                }
                break;
            case 7: // View\MemebrInformationViewer.xaml line 36
                {
                    this.emailInputBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.emailInputBox).TextChanged += this.emailInputBox_TextChanged;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.emailInputBox).TextChanging += this.emailInputBox_TextChanging;
                }
                break;
            case 8: // View\MemebrInformationViewer.xaml line 37
                {
                    this.address1InputBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.address1InputBox).TextChanged += this.address1InputBox_TextChanged;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.address1InputBox).TextChanging += this.address1InputBox_TextChanging;
                }
                break;
            case 9: // View\MemebrInformationViewer.xaml line 38
                {
                    this.address2InputBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.address2InputBox).TextChanged += this.address2InputBox_TextChanged;
                }
                break;
            case 10: // View\MemebrInformationViewer.xaml line 39
                {
                    this.cityInputBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.cityInputBox).TextChanged += this.cityInputBox_TextChanged;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.cityInputBox).TextChanging += this.cityInputBox_TextChanging;
                }
                break;
            case 11: // View\MemebrInformationViewer.xaml line 40
                {
                    this.zipcodeInputBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.zipcodeInputBox).TextChanged += this.zipcodeInputBox_TextChanged;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.zipcodeInputBox).TextChanging += this.zipcodeInputBox_TextChanging;
                }
                break;
            case 12: // View\MemebrInformationViewer.xaml line 41
                {
                    this.okButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.okButton).Click += this.okButton_Click;
                }
                break;
            case 13: // View\MemebrInformationViewer.xaml line 42
                {
                    this.stateChooser = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.stateChooser).SelectionChanged += this.stateChooser_SelectionChanged;
                }
                break;
            case 14: // View\MemebrInformationViewer.xaml line 43
                {
                    this.genderChooser = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.genderChooser).SelectionChanged += this.genderChooser_SelectionChanged;
                }
                break;
            case 15: // View\MemebrInformationViewer.xaml line 44
                {
                    this.CountryChooser = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.CountryChooser).SelectionChanged += this.CountryChooser_SelectionChanged;
                }
                break;
            case 16: // View\MemebrInformationViewer.xaml line 45
                {
                    this.editButon = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.editButon).Click += this.editButon_Click;
                }
                break;
            case 17: // View\MemebrInformationViewer.xaml line 46
                {
                    this.cancelButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.cancelButton).Click += this.cancelButton_Click;
                }
                break;
            case 18: // View\MemebrInformationViewer.xaml line 47
                {
                    this.saveButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.saveButton).Click += this.saveButton_Click;
                }
                break;
            case 19: // View\MemebrInformationViewer.xaml line 48
                {
                    this.invalidFirstname = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 20: // View\MemebrInformationViewer.xaml line 49
                {
                    this.invalidLastname = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 21: // View\MemebrInformationViewer.xaml line 50
                {
                    this.invalidBirthday = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 22: // View\MemebrInformationViewer.xaml line 51
                {
                    this.invalidPhone = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 23: // View\MemebrInformationViewer.xaml line 52
                {
                    this.invalidAddress1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 24: // View\MemebrInformationViewer.xaml line 53
                {
                    this.invalidState = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 25: // View\MemebrInformationViewer.xaml line 54
                {
                    this.invalidEmail = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 26: // View\MemebrInformationViewer.xaml line 55
                {
                    this.InvalidGender = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 27: // View\MemebrInformationViewer.xaml line 56
                {
                    this.invalidCity = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 28: // View\MemebrInformationViewer.xaml line 57
                {
                    this.invalidCountry = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 29: // View\MemebrInformationViewer.xaml line 58
                {
                    this.invalidZipcode = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

