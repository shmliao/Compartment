using QuanNetCommon;
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
using System.Windows.Shapes;

namespace QuanNetCompartment
{
    /// <summary>
    /// FastTrade.xaml 的交互逻辑
    /// </summary>
    public partial class FastTrade : Window
    {
        OrderData order;
        public string symbol;
        public FastTrade()
        {
            InitializeComponent();
            order = new OrderData()
            {
                direction=TradeCanstant.DirectLong
            };
        }

        /// <summary>
        /// 快捷键设计，F1快速切换到买入，F2快速切换到卖出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyStates == Keyboard.GetKeyStates(Key.F1))
            {
                btnSendOrder.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                btnSendOrder.Content = "买入";
                order.direction = TradeCanstant.DirectLong;
            }
            else if (e.KeyStates == Keyboard.GetKeyStates(Key.F2))
            {
                btnSendOrder.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                btnSendOrder.Content = "卖出";
                order.direction = TradeCanstant.DirectShort;
            }
        }
    }
}
