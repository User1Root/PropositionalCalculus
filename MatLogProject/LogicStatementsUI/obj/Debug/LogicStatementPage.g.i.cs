﻿#pragma checksum "..\..\LogicStatementPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "41C7AE5D760D7BD4E0726EB71D9FB1172DC442F83F2432B59B0605EAC24ECC50"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using LogicStatementsUI;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace LogicStatementsUI {
    
    
    /// <summary>
    /// LogicStatementPage
    /// </summary>
    public partial class LogicStatementPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 119 "..\..\LogicStatementPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox axiomsTextBox;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\LogicStatementPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox hypothesesTextBox;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\LogicStatementPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button axiomsGetter;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\LogicStatementPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button hypothesesGetter;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\LogicStatementPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox outPutTextBox;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\LogicStatementPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button outputGetter;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\LogicStatementPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LogicStatementsUI;component/logicstatementpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LogicStatementPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.axiomsTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.hypothesesTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.axiomsGetter = ((System.Windows.Controls.Button)(target));
            
            #line 121 "..\..\LogicStatementPage.xaml"
            this.axiomsGetter.Click += new System.Windows.RoutedEventHandler(this.GetAxioms);
            
            #line default
            #line hidden
            return;
            case 4:
            this.hypothesesGetter = ((System.Windows.Controls.Button)(target));
            
            #line 122 "..\..\LogicStatementPage.xaml"
            this.hypothesesGetter.Click += new System.Windows.RoutedEventHandler(this.GetHypotheses);
            
            #line default
            #line hidden
            return;
            case 5:
            this.outPutTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.outputGetter = ((System.Windows.Controls.Button)(target));
            
            #line 124 "..\..\LogicStatementPage.xaml"
            this.outputGetter.Click += new System.Windows.RoutedEventHandler(this.GetProof);
            
            #line default
            #line hidden
            return;
            case 7:
            this.saveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 125 "..\..\LogicStatementPage.xaml"
            this.saveBtn.Click += new System.Windows.RoutedEventHandler(this.Save);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

