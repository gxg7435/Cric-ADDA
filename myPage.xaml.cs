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
using Project.ViewModels;

namespace Project
{
    /// <summary>
    /// Interaction logic for myPage.xaml
    /// </summary>
    public partial class myPage : Page
    {
        private String p;
        myPageViewModel mpVM;

        public myPage()
        {
            InitializeComponent();
            
        }

        public myPage(String id)
        {
            // TODO: Complete member initialization
            this.p = id;
            InitializeComponent();
            
            mpVM = new myPageViewModel();
            this.DataContext = mpVM;

            mpVM.GetData(id);
            txtOutput.Text = mpVM.ItemData;
            
            if (null == mpVM.IconUri)
            {
                return;
            }
            else
            {
                ItemImg.Source = new BitmapImage(mpVM.IconUri);
            }
            
        }

       

       
    }
}
