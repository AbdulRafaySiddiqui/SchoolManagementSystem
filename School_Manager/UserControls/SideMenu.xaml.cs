using System.Windows.Controls;

namespace School_Manager
{
    /// <summary>
    /// Interaction logic for SideMenu.xaml
    /// </summary>
    public partial class SideMenu : UserControl
    {
        public SideMenu()
        {
            InitializeComponent();

            //set the datacontext
            DataContext = new SideMenuViewModel();
        }
    }
}
