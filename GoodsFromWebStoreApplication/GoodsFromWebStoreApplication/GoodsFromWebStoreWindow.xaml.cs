using System.Threading;
using System.Windows;
using GoodsFromWebStore.GoodsUtils;
using GoodsFromWebStore.ViewModel;

namespace GoodsFromWebStoreApplication
{
    /// <summary>
    /// Логика взаимодействия для GoodsFromWebStoreWindow.xaml
    /// </summary>
    public partial class GoodsFromWebStoreWindow : Window
    {
        private readonly GoodsViewModel _viewModel;

        public GoodsFromWebStoreWindow()
        {
            InitializeComponent();
            ViewModel.ListGoods.CollectionChanged += ListGoods_CollectionChanged;
        }

        private void ListGoods_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           
        }

        public GoodsViewModel ViewModel => DataContext as GoodsViewModel;
     }
}
