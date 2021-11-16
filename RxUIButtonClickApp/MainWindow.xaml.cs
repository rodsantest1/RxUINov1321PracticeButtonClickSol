using ClassLibrary1;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace RxUIButtonClickApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<AppViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new AppViewModel();

            this.WhenActivated(disposableRegistration =>
            {
                Observable
                    .FromEventPattern(this.TestButton, nameof(this.TestButton.Click))
                    .Select(_ => Unit.Default)
                    .InvokeCommand(ViewModel.MyCommand);

                this
                    .TestButton2
                    .Events()
                    .MouseEnter
                    .Select(_ => Unit.Default)
                    .InvokeCommand(ViewModel.MyCommand);

                this.BindCommand(ViewModel, vm => vm.MyCommand, v => v.TestButton3);

                this.WhenAnyObservable(x => x.ViewModel.MyCommand).Subscribe(x => MessageBox.Show(x));

            });
        }

    }
}
