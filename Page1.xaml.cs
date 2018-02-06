using Project.ViewModels;
using Project.Models;
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
    /// Interaction logic for Page1.xaml
    /// </summary>
    
    public partial class Page1 : Page
    {
        MainWindowViewModel vm;
        public Page1()
        {
            InitializeComponent();
            vm = new MainWindowViewModel();
            this.DataContext = vm;
          
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           MainWindow mainWindow = new MainWindow();
           Application.Current.Windows[0].Close();
           mainWindow.Show();
        }

        private void CustomerGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Player p = CustomerGrid.SelectedItem as Player;
            String val = p.PlayerName;
            string id = p.id;
            
            Window win2 = new Window();
            win2.Height = 500;
            win2.Width = 900;
            win2.Activate();
            win2.Topmost = true;
            win2.Show();
           
            
            win2.Content = new myPage(id);
        }
    }
}
