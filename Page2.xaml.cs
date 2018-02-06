using Project.Models;
using Project.ViewModels;
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

namespace Project
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        MatchViewModel mvm;
        public Page2()
        {
            InitializeComponent();
            mvm = new MatchViewModel();
            this.DataContext = mvm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Application.Current.Windows[0].Close();
            mainWindow.Show();
        }

        private void CustomerGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Match m = CustomerGrid.SelectedItem as Match;
            string id = m.unique_id;
            
            Window win2 = new Window();
            win2.Height = 500;
            win2.Width = 900;
            win2.Activate();
            win2.Topmost = true;
            win2.Show();


            win2.Content = new TeamPlayers(id);
        }
    }
}
