using System;
using System.Collections.Generic;
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

namespace TAS.Client.Views
{
    /// <summary>
    /// Interaction logic for EngineState.xaml
    /// </summary>
    public partial class EngineDebugView : Window
    {
        public EngineDebugView()
        {
            InitializeComponent();
        }
#if DEBUG
        ~EngineDebugView()
        {
            Debug.WriteLine(this, "Finalized");
        }
#endif
    }
}
