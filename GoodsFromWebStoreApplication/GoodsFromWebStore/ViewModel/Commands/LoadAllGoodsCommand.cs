using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoodsFromWebStore.ViewModel.Commands
{
    public class LoadAllGoodsCommand :ICommand
    {
        private readonly GoodsViewModel _goodsViewModel;

        public LoadAllGoodsCommand(GoodsViewModel goodsViewModel)
        {
            _goodsViewModel = goodsViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public  void Execute(object parameter)
        {
            new Thread(_goodsViewModel.LoadAllGoods).Start(); 
        }

        public event EventHandler CanExecuteChanged;
    }
}
