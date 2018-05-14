using QuanNetCommon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace QuanNetCompartment
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer;
        List<FastTrade> listFastTrade;
        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            // 当间隔时间过去时发生的事件
            dispatcherTimer.Tick += new EventHandler(ShowCurrentTime);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            dispatcherTimer.Start();


            ///绑定数据源
            this.lvAllPosition.ItemsSource = MainData.AllPositionData;
            /////更新线程用
            BindingOperations.EnableCollectionSynchronization(MainData.AllPositionData, new object());

            this.lvAllOrder.ItemsSource = MainData.AllOrderData;
            BindingOperations.EnableCollectionSynchronization(MainData.AllOrderData, new object());


            this.lvCanCancelOrder.ItemsSource = MainData.CanCancelOrderData;
            BindingOperations.EnableCollectionSynchronization(MainData.CanCancelOrderData, new object());


            this.lvTrade.ItemsSource = MainData.AllTradeData;
            BindingOperations.EnableCollectionSynchronization(MainData.AllTradeData, new object());
            listFastTrade = new List<FastTrade>();


        }

        public void ShowCurrentTime(object sender, EventArgs e)
        {
            //获得星期
            //this.tBlockTime.Text = DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("zh-cn"));
            //this.tBlockTime.Text += "\n";

            //获得年月日
            //this.tBlockTime.Text = DateTime.Now.ToString("yyyy:MM:dd");   //yyyy年MM月dd日
            //this.tBlockTime.Text += "\n";

            //获得时分秒
            this.txtTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss dddd");
        }

        private void btnSelectAllOrder_Click(object sender, RoutedEventArgs e)
        {
            foreach (var order in MainData.CanCancelOrderData)
            {
                order.isSelected = true;
            }
        }

        private void btnSelectNoOrder_Click(object sender, RoutedEventArgs e)
        {
            foreach (var order in MainData.CanCancelOrderData)
            {
                order.isSelected = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddFastTrade_Click(object sender, RoutedEventArgs e)
        {
            FastTrade newPage = new FastTrade();
            listFastTrade.Add(newPage);
            newPage.ShowActivated = true;
            newPage.Show();
        }

        protected override void OnClosed(EventArgs e)
        {
            var collections = Application.Current.Windows;

            foreach (Window window in collections)
            {
                if (window != this)
                    window.Close();
            }
            base.OnClosed(e);
        }
    }

    public class test : BindableBase
    {
        public test()
        {
        }
        ///<summary>
        /// 原始数据
        ///<summary>
        private bool _isSelected = false;

        /// <summary>
        /// 原始数据
        /// </summary>
        public bool isSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                SetProperty(ref _isSelected, value);
            }
        }

    }


    /// <summary>
    /// 实现INotifyPropertyChanged，数据改变，ui自动改变
    /// </summary>
    public abstract class BindableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storage"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T storage, T value, [System.Runtime.CompilerServices.CallerMemberName] String propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName)) return false;
            if (object.Equals(storage, value)) return false;
            try
            {
                storage = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        protected void NotifyPropertyChanged(object propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs((string)propertyName));
            }
        }
    }

}
