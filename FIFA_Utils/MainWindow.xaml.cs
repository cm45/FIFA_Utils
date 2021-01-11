using FIFA_Utils_Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace FIFA_Utils
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Patcher patcher = new Patcher();

        public MainWindow()
        {
            InitializeComponent();
            InitUI();
        }

        private void InitUI()
        {
            AppConfig cfg = ConfigManager.AppConfig;

            tboxPath.Text = cfg.path;
            checkBoxSkipLauncher.IsChecked = cfg.skipGameLauncher;
            checkBoxSkipLanguageSelection.IsChecked = cfg.skipLanguageSelection;
            checkBoxForceMetric.IsChecked = cfg.forceMetricUnits;
        }

        #region Events

        private void TboxPath_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tboxPath.Text = patcher.OpenGameFolderDialog() ?? tboxPath.Text;
        }

        private void BtnSelectFolder_Click(object sender, RoutedEventArgs e)
        {
            tboxPath.Text = patcher.OpenGameFolderDialog() ?? tboxPath.Text;
        }

        private void BtnPatch_Click(object sender, RoutedEventArgs e)
        {
            AppConfig config = new AppConfig()
            {
                path = tboxPath.Text,
                skipGameLauncher = (bool)checkBoxSkipLauncher.IsChecked,
                skipLanguageSelection = (bool)checkBoxSkipLanguageSelection.IsChecked,
                forceMetricUnits = (bool)checkBoxForceMetric.IsChecked
            };

            patcher.Patch(config, Patcher.MessageType.MESSAGEBOX);
        }

        #endregion
    }
}
