using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TAS.Client.Views
{
    /// <summary>
    /// Interaction logic for SplashScreenView.xaml
    /// </summary>
    public partial class SplashScreenView : Window
    {
        public SplashScreenView()
        {
            InitializeComponent();
            Product.Text = Assembly.GetEntryAssembly().GetName().Name;
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Version.Text = $"{version.Major}.{version.Minor}.{version.Build}";
            Current = this;
        }

        public void Notify(string message)
        {
            if (Thread.CurrentThread == Dispatcher.Thread)
                LoadStage.Text = message;
            else
                Dispatcher.BeginInvoke(new Action(() => LoadStage.Text = message));
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Current = null;
        }

        public static SplashScreenView Current { get; private set; }
        
    }
}
