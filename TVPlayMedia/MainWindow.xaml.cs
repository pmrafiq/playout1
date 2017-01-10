﻿//#undef DEBUG
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TAS.Client.ViewModels;
using TAS.Remoting.Client;
using TAS.Server.Interfaces;

namespace TAS.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly RemoteClient _client;
        public MainWindow()
        {
#if DEBUG
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            Infralution.Localization.Wpf.CultureManager.UICulture = new System.Globalization.CultureInfo("en");
            System.Threading.Thread.Sleep(2000); // wait for server to spin up
#endif
            InitializeComponent();
            try
            {
                _client = new RemoteClient(ConfigurationManager.AppSettings["Host"]);
                _client.Binder = new Remoting.ClientTypeNameBinder();
                _client.Initialize();
                IEngine engine = _client.GetInitalObject<IEngine>();
                //IMediaManager mm = engine.MediaManager;
                //MediaManagerViewmodel vm = new MediaManagerViewmodel(mm, engine);
                EngineViewmodel vm = new EngineViewmodel(engine, engine);
                _windowContent.Content = vm.View;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
#if DEBUG
            if (e.Key == Key.G && e.KeyboardDevice.Modifiers == (ModifierKeys.Alt | ModifierKeys.Control))
            {
                GC.Collect(GC.MaxGeneration);
                Debug.WriteLine("CG enforced");
                e.Handled = true;
            }
#endif
        }
    }
}
