using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanNetCommon
{
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








    /// <summary>
    ///  """回调函数推送数据的基础类，其他数据类继承于此"""
    /// </summary>
    public class BaseData : BindableBase
    {
        public BaseData()
        {
        }
        ///<summary>
        /// 是否选中
        ///<summary>
        private bool _isSelected = false;

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool isSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (value != null)
                    SetProperty(ref _isSelected, value);
            }
        }

        private string _gatewayName = string.Empty;

        /// <summary>
        /// Gateway名称
        /// </summary>
        public string gatewayName
        {
            get
            {
                return _gatewayName;
            }
            set
            {
                if (value != null)
                    SetProperty(ref _gatewayName, value);
            }
        }


        ///<summary>
        /// 原始数据
        ///<summary>
        private string _rawData = string.Empty;

        /// <summary>
        /// 原始数据
        /// </summary>
        public string rawData
        {
            get
            {
                return _rawData;
            }
            set
            {
                if (value != null)
                    SetProperty(ref _rawData, value);
            }
        }


        /// <summary>
        ///  账户ID,支持多账户
        /// </summary>
        public string accountID
        {
            get
            {
                return _accountID;
            }
            set
            {
                if (value != null)
                    SetProperty(ref _accountID, value);
            }
        }

        private string _accountID = string.Empty;


    }

    /// <summary>
    /// 行情tick数据
    /// </summary>
    public class TickData : BaseData
    {
        public TickData()
        {
        }
        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol { get { return _symbol; } set { if (value != null) SetProperty(ref _symbol, value); } }
        private string _symbol = string.Empty;
        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange { get { return _exchange; } set { if (value != null) SetProperty(ref _exchange, value); } }
        private string _exchange = string.Empty;
        /// <summary>
        /// 合约在本系统中的唯一代码，通常是 合约代码.交易所代码
        /// </summary>
        public string qnSymbol { get { return _qnSymbol; } set { if (value != null) SetProperty(ref _qnSymbol, value); } }
        private string _qnSymbol = string.Empty;


        /// <summary>
        /// 最新成交价
        /// </summary>
        public double lastPrice { get { return _lastPrice; } set { SetProperty(ref _lastPrice, value); } }
        private double _lastPrice = 0;
        /// <summary>
        /// 最新成交量
        /// </summary>
        public int lastVolume { get { return _lastVolume; } set { SetProperty(ref _lastVolume, value); } }
        private int _lastVolume = 0;
        /// <summary>
        /// 今天总成交量
        /// </summary>
        public int volume { get { return _volume; } set { SetProperty(ref _volume, value); } }
        private int _volume = 0;

        /// <summary>
        /// 持仓量
        /// </summary>
        public int openInterest { get { return _openInterest; } set { SetProperty(ref _openInterest, value); } }
        private int _openInterest = 0;
        /// <summary>
        /// 时间 11:20:56.5
        /// </summary>
        public string time { get { return _time; } set { SetProperty(ref _time, value); } }
        private string _time = string.Empty;
        /// <summary>
        /// 日期 20151009
        /// </summary>
        public string date { get { return _date; } set { SetProperty(ref _date, value); } }
        private string _date = string.Empty;
        /// <summary>
        /// python的datetime时间对象
        /// </summary>
        public DateTime datetime { get { return _datetime; } set { if (value != null) SetProperty(ref _datetime, value); } }
        private DateTime _datetime = DateTime.Now;

        // 常规行情
        /// <summary>
        /// 今日开盘价
        /// </summary>
        public double openPrice { get { return _openPrice; } set { SetProperty(ref _openPrice, value); } }
        private double _openPrice = 0;
        /// <summary>
        /// 今日最高价
        /// </summary>
        public double highPrice { get { return _highPrice; } set { SetProperty(ref _highPrice, value); } }
        private double _highPrice = 0;
        /// <summary>
        /// 今日最低价
        /// </summary>
        public double lowPrice { get { return _lowPrice; } set { SetProperty(ref _lowPrice, value); } }
        private double _lowPrice = 0;
        /// <summary>
        ///昨收盘价
        /// </summary>
        public double preClosePrice { get { return _preClosePrice; } set { SetProperty(ref _preClosePrice, value); } }
        private double _preClosePrice = 0;

        /// <summary>
        /// 涨停价
        /// </summary>
        public double upperLimit { get { return _upperLimit; } set { SetProperty(ref _upperLimit, value); } }
        private double _upperLimit = 0;
        /// <summary>
        /// 跌停价
        /// </summary>
        public double lowerLimit { get { return _lowerLimit; } set { SetProperty(ref _lowerLimit, value); } }
        private double _lowerLimit = 0;

        // 五档行情
        public double bidPrice1 { get { return _bidPrice1; } set { SetProperty(ref _bidPrice1, value); } }
        private double _bidPrice1 = 0;

        public double bidPrice2 { get { return _bidPrice2; } set { SetProperty(ref _bidPrice2, value); } }
        private double _bidPrice2 = 0;

        public double bidPrice3 { get { return _bidPrice3; } set { SetProperty(ref _bidPrice3, value); } }
        private double _bidPrice3 = 0;

        public double bidPrice4 { get { return _bidPrice4; } set { SetProperty(ref _bidPrice4, value); } }
        private double _bidPrice4 = 0;

        public double bidPrice5 { get { return _bidPrice5; } set { SetProperty(ref _bidPrice5, value); } }
        private double _bidPrice5 = 0;

        public double askPrice1 { get { return _askPrice1; } set { SetProperty(ref _askPrice1, value); } }
        private double _askPrice1 = 0;

        public double askPrice2 { get { return _askPrice2; } set { SetProperty(ref _askPrice2, value); } }
        private double _askPrice2 = 0;

        public double askPrice3 { get { return _askPrice3; } set { SetProperty(ref _askPrice3, value); } }
        private double _askPrice3 = 0;

        public double askPrice4 { get { return _askPrice4; } set { SetProperty(ref _askPrice4, value); } }
        private double _askPrice4 = 0;

        public double askPrice5 { get { return _askPrice5; } set { SetProperty(ref _askPrice5, value); } }
        private double _askPrice5 = 0;

        public int bidVolume1 { get { return _bidVolume1; } set { SetProperty(ref _bidVolume1, value); } }
        private int _bidVolume1 = 0;

        public int bidVolume2 { get { return _bidVolume2; } set { SetProperty(ref _bidVolume2, value); } }
        private int _bidVolume2 = 0;

        public int bidVolume3 { get { return _bidVolume3; } set { SetProperty(ref _bidVolume3, value); } }
        private int _bidVolume3 = 0;

        public int bidVolume4 { get { return _bidVolume4; } set { SetProperty(ref _bidVolume4, value); } }
        private int _bidVolume4 = 0;

        public int bidVolume5 { get { return _bidVolume5; } set { SetProperty(ref _bidVolume5, value); } }
        private int _bidVolume5 = 0;

        public int askVolume1 { get { return _askVolume1; } set { SetProperty(ref _askVolume1, value); } }
        private int _askVolume1 = 0;

        public int askVolume2 { get { return _askVolume2; } set { SetProperty(ref _askVolume2, value); } }
        private int _askVolume2 = 0;

        public int askVolume3 { get { return _askVolume3; } set { SetProperty(ref _askVolume3, value); } }
        private int _askVolume3 = 0;

        public int askVolume4 { get { return _askVolume4; } set { SetProperty(ref _askVolume4, value); } }
        private int _askVolume4 = 0;

        public int askVolume5 { get { return _askVolume5; } set { SetProperty(ref _askVolume5, value); } }
        private int _askVolume5 = 0;

    }

    /// <summary>
    /// """K线数据"""
    /// </summary>
    public class BarData : BaseData
    {
        public BarData()
        {
        }


        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol { get { return _symbol; } set { if (value != null) SetProperty(ref _symbol, value); } }
        private string _symbol = string.Empty;
        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange { get { return _exchange; } set { if (value != null) SetProperty(ref _exchange, value); } }
        private string _exchange = string.Empty;
        /// <summary>
        /// 合约在本系统中的唯一代码，通常是 合约代码.交易所代码
        /// </summary>
        public string qnSymbol { get { return _qnSymbol; } set { if (value != null) SetProperty(ref _qnSymbol, value); } }
        private string _qnSymbol = string.Empty;



        public double open { get { return _open; } set { if (value != null) SetProperty(ref _open, value); } }
        private double _open = 0;

        public double high { get { return _high; } set { if (value != null) SetProperty(ref _high, value); } }
        private double _high = 0;

        public double low { get { return _low; } set { if (value != null) SetProperty(ref _low, value); } }
        private double _low = 0;

        public double close { get { return _close; } set { if (value != null) SetProperty(ref _close, value); } }
        private double _close = 0;

        /// <summary>
        /// // bar开始的时间，日期
        /// </summary>
        public string date { get { return _date; } set { if (value != null) SetProperty(ref _date, value); } }
        private string _date = string.Empty;

        /// <summary>
        /// // bar开始的时间，日期
        /// </summary>
        public string time { get { return _time; } set { if (value != null) SetProperty(ref _time, value); } }
        private string _time = string.Empty;

        /// <summary>
        /// // bar开始的时间，日期
        /// </summary>
        public DateTime datetime { get { return _datetime; } set { if (value != null) SetProperty(ref _datetime, value); } }
        private DateTime _datetime;

        /// <summary>
        /// 成交量
        /// </summary>
        public int volume { get { return _volume; } set { SetProperty(ref _volume, value); } }
        private int _volume = 0;

        /// <summary>
        /// 持仓量
        /// </summary>
        public int openInterest { get { return _openInterest; } set { SetProperty(ref _openInterest, value); } }
        private int _openInterest = 0;
    }

    /// <summary>
    ///  """成交数据类"""
    /// </summary>
    public class TradeData : BaseData
    {
        public TradeData(string qtradeid)
        {
            qnTradeID = qtradeid;
        }

        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol { get { return _symbol; } set { if (value != null) SetProperty(ref _symbol, value); } }
        private string _symbol = string.Empty;
        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange { get { return _exchange; } set { if (value != null) SetProperty(ref _exchange, value); } }
        private string _exchange = string.Empty;

        /// <summary>
        /// 成交编号
        /// </summary>
        public string tradeID { get { return _tradeID; } set { if (value != null) SetProperty(ref _tradeID, value); } }
        private string _tradeID = string.Empty;

        /// <summary>
        /// 成交在qn系统中的唯一编号"CTP" + "_" + this.UserID+"_" + pTrade.TradeID格式
        /// </summary>
        public string qnTradeID { get { return _qnTradeID; } set { if (value != null) SetProperty(ref _qnTradeID, value); } }
        private string _qnTradeID = string.Empty;

        /// <summary>
        ///  // 订单编号
        /// </summary>
        public string orderID { get { return _orderID; } set { if (value != null) SetProperty(ref _orderID, value); } }
        private string _orderID = string.Empty;

        /// <summary>
        ///  // 订单在qn系统中的唯一编号
        /// </summary>
        public string qnOrderID { get { return _qnOrderID; } set { if (value != null) SetProperty(ref _qnOrderID, value); } }
        private string _qnOrderID = string.Empty;

        /// <summary>
        /// // 成交方向
        /// </summary>
        public string direction { get { return _direction; } set { if (value != null) SetProperty(ref _direction, value); } }
        private string _direction = string.Empty;
        /// <summary>
        ///  // 成交开平仓
        /// </summary>
        public string offset { get { return _offset; } set { if (value != null) SetProperty(ref _offset, value); } }
        private string _offset = string.Empty;

        /// <summary>
        ///  // 投机，套保
        /// </summary>
        public string hedge { get { return _hedge; } set { if (value != null) SetProperty(ref _hedge, value); } }
        private string _hedge = string.Empty;
        /// <summary>
        ///  // 成交价格
        /// </summary>
        public double price { get { return _price; } set { SetProperty(ref _price, value); } }
        private double _price = 0;
        /// <summary>
        /// // 成交数量
        /// </summary>
        public int volume { get { return _volume; } set { SetProperty(ref _volume, value); } }
        private int _volume = 0;
        /// <summary>
        ///  // 成交时间
        /// </summary>
        public string tradeTime { get { return _tradeTime; } set { if (value != null) SetProperty(ref _tradeTime, value); } }
        private string _tradeTime = string.Empty;
    }

    /// <summary>
    /// ""订单数据类"""
    /// </summary>
    public class OrderData : BaseData
    {
        public OrderData()
        {
        }
        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol { get { return _symbol; } set { if (value != null) SetProperty(ref _symbol, value); } }
        private string _symbol = string.Empty;
        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange { get { return _exchange; } set { if (value != null) SetProperty(ref _exchange, value); } }
        private string _exchange = string.Empty;


        ///
        /// <summary>
        /// 柜台委托号,撤单的时候尽量传这个参数(ctp接口传orderID)
        /// </summary>
        public int spdOrderID { get { return _spdOrderID; } set { SetProperty(ref _spdOrderID, value); } }
        private int _spdOrderID = 0;

        /// <summary>
        /// 订单编号
        /// </summary>
        public string orderID { get { return _orderID; } set { if (value != null) SetProperty(ref _orderID, value); } }
        private string _orderID = string.Empty;
        /// <summary>
        /// 订单QN系统中的唯一编号 "CTP"+Convert.ToString(frontID) + "_" + Convert.ToString(sessionID) + "_" + orderID;
        /// </summary>
        public string qnOrderID { get { return _qnOrderID; } set { if (value != null) SetProperty(ref _qnOrderID, value); } }
        private string _qnOrderID = string.Empty;

        // 报单相关
        /// <summary>
        /// 报单方向
        /// </summary>
        public string direction { get { return _direction; } set { if (value != null) SetProperty(ref _direction, value); } }
        private string _direction = string.Empty;
        /// <summary>
        /// 报单开平仓
        /// </summary>
        public string offset { get { return _offset; } set { if (value != null) SetProperty(ref _offset, value); } }
        private string _offset = string.Empty;
        /// <summary>
        /// 报单价格
        /// </summary>
        public double price { get { return _price; } set { SetProperty(ref _price, value); } }
        private double _price = 0;
        /// <summary>
        /// 报单总数量
        /// </summary>
        public int totalVolume { get { return _totalVolume; } set { SetProperty(ref _totalVolume, value); } }
        private int _totalVolume = 0;
        /// <summary>
        /// 报单成交数量
        /// </summary>
        public int tradedVolume { get { return _tradedVolume; } set { SetProperty(ref _tradedVolume, value); } }
        private int _tradedVolume = 0;
        /// <summary>
        /// 报单状态
        /// </summary>
        public string status { get { return _status; } set { if (value != null) SetProperty(ref _status, value); } }
        private string _status = string.Empty;

        /// <summary>
        /// 发单时间
        /// </summar
        public string orderTime { get { return _orderTime; } set { if (value != null) SetProperty(ref _orderTime, value); } }
        private string _orderTime = string.Empty;
        /// <summary>
        /// 撤单时间
        /// </summary>
        public string cancelTime { get { return _cancelTime; } set { if (value != null) SetProperty(ref _cancelTime, value); } }
        private string _cancelTime = string.Empty;

        /// <summary>
        /// 前置机编号
        /// </summary>
        public int frontID { get { return _frontID; } set { SetProperty(ref _frontID, value); } }
        private int _frontID = 0;
        /// <summary>
        /// 连接编号
        /// </summary>
        public int sessionID { get { return _sessionID; } set { SetProperty(ref _sessionID, value); } }
        private int _sessionID = 0;
    }

    /// <summary>
    /// """持仓数据类"""
    /// </summary>
    public class PositionData : BaseData
    {

        //positionName= this.UserID+"_"+symbol + "_" + direction +"_" + hedge;
        public PositionData()
        {
       
        }

        /// <summary>
        ///  订单QN系统中qnPositionName = "CTP" + "_" + this.UserID + "_" + td.symbol + "_" + td.direction;唯一字段
        /// </summary>
        public string qnPositionName { get { return _qnPositionName; } set { if (value != null) SetProperty(ref _qnPositionName, value); } }
        private string _qnPositionName = string.Empty;

        public string hedge { get { return _hedge; } set { if (value != null) SetProperty(ref _hedge, value); } }
        private string _hedge = string.Empty;

        public int tdPosition { get { return _tdPosition; } set {  SetProperty(ref _tdPosition, value); } }
        private int _tdPosition = 0;

        public int totalPosition { get { return _totalPosition; } set { SetProperty(ref _totalPosition, value); } }
        private int _totalPosition = 0;

        public int ydPosition { get { return _ydPosition; } set { SetProperty(ref _ydPosition, value); } }
        private int _ydPosition = 0;

        public string positionDate { get { return _positionDate; } set { if (value != null) SetProperty(ref _positionDate, value); } }
        private string _positionDate = string.Empty;

        public int longFrozen { get { return _longFrozen; } set { SetProperty(ref _longFrozen, value); } }
        private int _longFrozen = 0;

        public int shortFrozen { get { return _shortFrozen; } set { SetProperty(ref _shortFrozen, value); } }
        private int _shortFrozen = 0;

        public double longFrozenAmount { get { return _longFrozenAmount; } set { SetProperty(ref _longFrozenAmount, value); } }
        private double _longFrozenAmount = 0;

        public double shortFrozenAmount { get { return _shortFrozenAmount; } set { SetProperty(ref _shortFrozenAmount, value); } }
        private double _shortFrozenAmount = 0;

        public int openVolume { get { return _openVolume; } set { SetProperty(ref _openVolume, value); } }
        private int _openVolume = 0;

        public int closeVolume { get { return _closeVolume; } set { SetProperty(ref _closeVolume, value); } }
        private int _closeVolume = 0;


        public double openAmount { get { return _openAmount; } set { SetProperty(ref _openAmount, value); } }
        private double _openAmount = 0;


        public double closeAmount { get { return _closeAmount; } set { SetProperty(ref _closeAmount, value); } }
        private double _closeAmount = 0;

        public double positionCost { get { return _positionCost; } set { SetProperty(ref _positionCost, value); } }
        private double _positionCost = 0;

        public double preMargin { get { return _preMargin; } set { SetProperty(ref _preMargin, value); } }
        private double _preMargin = 0;


        public double useMargin { get { return _useMargin; } set { SetProperty(ref _useMargin, value); } }
        private double _useMargin = 0;

        public double frozenMargin { get { return _frozenMargin; } set { SetProperty(ref _frozenMargin, value); } }
        private double _frozenMargin = 0;

        public double frozenCash { get { return _frozenCash; } set { SetProperty(ref _frozenCash, value); } }
        private double _frozenCash = 0;

        public double frozenCommission { get { return _frozenCommission; } set { SetProperty(ref _frozenCommission, value); } }
        private double _frozenCommission = 0;

        public double cashIn { get { return _cashIn; } set { SetProperty(ref _cashIn, value); } }
        private double _cashIn = 0;


        public double commission { get { return _commission; } set { SetProperty(ref _commission, value); } }
        private double _commission = 0;


        public double closeProfit { get { return _closeProfit; } set { SetProperty(ref _closeProfit, value); } }
        private double _closeProfit = 0;


        public double positionProfit { get { return _positionProfit; } set { SetProperty(ref _positionProfit, value); } }
        private double _positionProfit = 0;

        public double preSettlementPrice { get { return _preSettlementPrice; } set { SetProperty(ref _preSettlementPrice, value); } }
        private double _preSettlementPrice = 0;

        public double settlementPrice { get { return _settlementPrice; } set { SetProperty(ref _settlementPrice, value); } }
        private double _settlementPrice = 0;

        public string tradingDay { get { return _tradingDay; } set { SetProperty(ref _tradingDay, value); } }
        private string _tradingDay = string.Empty;

        public double openCost { get { return _openCost; } set { SetProperty(ref _openCost, value); } }
        private double _openCost = 0;


        public double avgOpenPrice { get { return _avgOpenPrice; } set { SetProperty(ref _avgOpenPrice, value); } }
        private double _avgOpenPrice = 0;


        public double openProfit { get { return _openProfit; } set { SetProperty(ref _openProfit, value); } }
        private double _openProfit = 0;


        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol { get { return _symbol; } set { if (value != null) SetProperty(ref _symbol, value); } }
        private string _symbol = string.Empty;
        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange { get { return _exchange; } set { if (value != null) SetProperty(ref _exchange, value); } }
        private string _exchange = string.Empty;


        // 持仓相关
        /// <summary>
        /// 持仓方向
        /// </summary>
        public string direction { get { return _direction; } set { if (value != null) SetProperty(ref _direction, value); } }
        private string _direction = string.Empty;
    }

    /// <summary>
    /// """账户数据类"""
    /// </summary>
    public class AccountData : BaseData
    {
        public AccountData()
        {
        }

        /// <summary>
        /// 账户在qn中的唯一代码，格式："CTP" +"_"+ UserID
        /// </summary>
        public string qnAccountID { get { return _qnAccountID; } set { if (value != null) SetProperty(ref _qnAccountID, value); } }
        private string _qnAccountID = string.Empty;

        // 数值相关
        /// <summary>
        /// 昨日账户结算净值
        /// </summary>
        public double preBalance { get { return _preBalance; } set { SetProperty(ref _preBalance, value); } }
        private double _preBalance = 0;
        /// <summary>
        /// 账户净值
        /// </summary>
        public double balance { get { return _balance; } set { SetProperty(ref _balance, value); } }
        private double _balance = 0;
        /// <summary>
        /// 可用资金
        /// </summary>
        public double available { get { return _available; } set { SetProperty(ref _available, value); } }
        private double _available = 0;
        /// <summary>
        /// 今日手续费
        /// </summary>
        public double commission { get { return _commission; } set { SetProperty(ref _commission, value); } }
        private double _commission = 0;
        /// <summary>
        /// 保证金占用
        /// </summary>
        public double margin { get { return _margin; } set { SetProperty(ref _margin, value); } }
        private double _margin = 0;
        /// <summary>
        /// 平仓盈亏
        /// </summary>
        public double closeProfit { get { return _closeProfit; } set { SetProperty(ref _closeProfit, value); } }
        private double _closeProfit = 0;
        /// <summary>
        /// 持仓盈亏
        /// </summary>
        public double positionProfit { get { return _positionProfit; } set { SetProperty(ref _positionProfit, value); } }
        private double _positionProfit = 0;
        /// <summary>
        /// 风险度
        /// </summary>
        public double risk { get { return _risk; } set { SetProperty(ref _risk, value); } }
        private double _risk = 0;
    }


    /// <summary>
    /// """错误数据类"""
    /// </summary>
    public class ErrorData : BaseData
    {
        public ErrorData()
        {
        }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string errorID { get { return _errorID; } set { if (value != null) SetProperty(ref _errorID, value); } }
        private string _errorID = string.Empty;
        /// <summary>
        /// 错误信息
        /// </summary>
        public string errorMsg { get { return _errorMsg; } set { if (value != null) SetProperty(ref _errorMsg, value); } }
        private string _errorMsg = string.Empty;
        /// <summary>
        /// 补充信息
        /// </summary>
        public string additionalInfo { get { return _additionalInfo; } set { if (value != null) SetProperty(ref _additionalInfo, value); } }
        private string _additionalInfo = string.Empty;
        /// <summary>
        /// 错误生成时间
        /// </summary>
        public DateTime errorTime { get { return _errorTime; } set { if (value != null) SetProperty(ref _errorTime, value); } }
        private DateTime _errorTime;
    }

    /// <summary>
    /// """日志数据类"""
    /// </summary>
    public class LogData : BaseData
    {
        public LogData()
        {
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        public int logLevel { get { return _logLevel; } set { if (value != null) SetProperty(ref _logLevel, value); } }
        private int _logLevel = 0;
        /// <summary>
        /// 补充信息
        /// </summary>
        public string logContent { get { return _logContent; } set { if (value != null) SetProperty(ref _logContent, value); } }
        private string _logContent = string.Empty;
        /// <summary>
        /// /错误生成时间
        /// </summary
        public DateTime logTime { get { return _logTime; } set { if (value != null) SetProperty(ref _logTime, value); } }
        private DateTime _logTime;
    }

    /// <summary>
    /// """合约详细信息类"""
    /// </summary>
    public class ContractData : BaseData
    {
        public ContractData()
        {
        }
        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol { get { return _symbol; } set { if (value != null) SetProperty(ref _symbol, value); } }
        private string _symbol = string.Empty;
        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange { get { return _exchange; } set { if (value != null) SetProperty(ref _exchange, value); } }
        private string _exchange = string.Empty;
        /// <summary>
        /// 合约在本系统中的唯一代码，通常是 合约代码_交易所代码
        /// </summary>
        public string qnSymbol { get { return _qnSymbol; } set { if (value != null) SetProperty(ref _qnSymbol, value); } }
        private string _qnSymbol = string.Empty;

        /// <summary>
        /// 合约中文名
        /// </summary>
        public string name { get { return _name; } set { if (value != null) SetProperty(ref _name, value); } }
        private string _name = string.Empty;

        /// <summary>
        /// 合约类型
        /// </summary>
        public string productClass { get { return _productClass; } set { if (value != null) SetProperty(ref _productClass, value); } }
        private string _productClass = string.Empty;
        /// <summary>
        /// 合约大小
        /// </summary>
        public int size { get { return _size; } set { SetProperty(ref _size, value); } }
        private int _size = 0;
        /// <summary>
        /// 合约最小价格
        /// </summary>
        public double priceTick { get { return _priceTick; } set { SetProperty(ref _priceTick, value); } }
        private double _priceTick = 0;

        // 期权相关
        /// <summary>
        /// 期权行权价
        /// </summary>
        public double strikePrice { get { return _strikePrice; } set { SetProperty(ref _strikePrice, value); } }
        private double _strikePrice = 0;
        /// <summary>
        /// 标的物合约代码
        /// </summary>
        public string underlyingSymbol { get { return _underlyingSymbol; } set { if (value != null) SetProperty(ref _underlyingSymbol, value); } }
        private string _underlyingSymbol = string.Empty;
        /// <summary>
        /// 期权类型
        /// </summary>
        public string optionType { get { return _optionType; } set { if (value != null) SetProperty(ref _optionType, value); } }
        private string _optionType = string.Empty;
        /// <summary>
        /// 到期日
        /// </summary>
        public string expiryDate { get { return _expiryDate; } set { if (value != null) SetProperty(ref _expiryDate, value); } }
        private string _expiryDate = string.Empty;
    }


    /// <summary>
    /// """订阅行情时传入的对象类"""
    /// </summary>
    public class SubscribeReq : BaseData
    {
        public SubscribeReq()
        {
        }
        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol { get { return _symbol; } set { if (value != null) SetProperty(ref _symbol, value); } }
        private string _symbol = string.Empty;
        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange { get { return _exchange; } set { if (value != null) SetProperty(ref _exchange, value); } }
        private string _exchange = string.Empty;
        /// <summary>
        /// 合约在本系统中的唯一代码，通常是 合约代码.交易所代码
        /// </summary>
        public string qnSymbol { get { return _qnSymbol; } set { if (value != null) SetProperty(ref _qnSymbol, value); } }
        private string _qnSymbol = string.Empty;


        // 以下为IB相关
        /// <summary>
        /// 合约类型
        /// </summary>
        public string productClass { get { return _productClass; } set { if (value != null) SetProperty(ref _productClass, value); } }
        private string _productClass = string.Empty;
        /// <summary>
        /// 合约货币
        /// </summary>
        public string currency { get { return _currency; } set { if (value != null) SetProperty(ref _currency, value); } }
        private string _currency = string.Empty;
        /// <summary>
        /// 到期日
        /// </summary>
        public string expiry { get { return _expiry; } set { if (value != null) SetProperty(ref _expiry, value); } }
        private string _expiry = string.Empty;
        /// <summary>
        /// 行权价
        /// </summary>
        public double strikePrice { get { return _strikePrice; } set { if (value != null) SetProperty(ref _strikePrice, value); } }
        private double _strikePrice = 0;
        /// <summary>
        /// 期权类型
        /// </summary>
        public string optionType { get { return _optionType; } set { if (value != null) SetProperty(ref _optionType, value); } }
        private string _optionType = string.Empty;

    }

    /// <summary>
    /// """发单时传入的对象类"""
    /// </summary>
    public class OrderReq : BaseData
    {
        public OrderReq()
        {
        }
        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol { get { return _symbol; } set { if (value != null) SetProperty(ref _symbol, value); } }
        private string _symbol = string.Empty;

        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange { get { return _exchange; } set { if (value != null) SetProperty(ref _exchange, value); } }
        private string _exchange = string.Empty;

        /// <summary>
        /// 合约在本系统中的唯一代码，通常是 合约代码.交易所代码
        /// </summary>
        public string qnSymbol { get { return _qnSymbol; } set { if (value != null) SetProperty(ref _qnSymbol, value); } }
        private string _qnSymbol = string.Empty;


        /// <summary>
        /// 价格
        /// </summary>
        public double price { get { return _price; } set { SetProperty(ref _price, value); } }
        private double _price = 0;

        /// <summary>
        /// 数量
        /// </summary>
        public int volume { get { return _volume; } set { SetProperty(ref _volume, value); } }
        private int _volume = 0;

        /// <summary>
        /// 价格类型
        /// </summary>
        public string priceType { get { return _priceType; } set { SetProperty(ref _priceType, value); } }
        private string _priceType = string.Empty;

        /// <summary>
        /// 买卖
        /// </summary>
        public string direction { get { return _direction; } set { if (value != null) SetProperty(ref _direction, value); } }
        private string _direction = string.Empty;

        /// <summary>
        /// 开平
        /// </summary>
        public string offset { get { return _offset; } set { if (value != null) SetProperty(ref _offset, value); } }
        private string _offset = string.Empty;


        // 以下为IB相关
        /// <summary>
        /// 合约类型
        /// </summary>
        public string productClass { get { return _productClass; } set { if (value != null) SetProperty(ref _productClass, value); } }
        private string _productClass = string.Empty;

        /// <summary>
        /// 合约货币
        /// </summary>
        public string currency { get { return _currency; } set { if (value != null) SetProperty(ref _currency, value); } }
        private string _currency = string.Empty;

        /// <summary>
        /// 到期日
        /// </summary>
        public string expiry { get { return _expiry; } set { if (value != null) SetProperty(ref _expiry, value); } }
        private string _expiry = string.Empty;

        /// <summary>
        /// 行权价
        /// </summary>
        public double strikePrice { get { return _strikePrice; } set { SetProperty(ref _strikePrice, value); } }
        private double _strikePrice = 0;
        /// <summary>
        /// 期权类型
        /// </summary>
        public string optionType { get { return _optionType; } set { if (value != null) SetProperty(ref _optionType, value); } }
        private string _optionType = string.Empty;

        /// <summary>
        /// 合约月,IB专用
        /// </summary>
        public string lastTradeDateOrContractMonth { get { return _lastTradeDateOrContractMonth; } set { if (value != null) SetProperty(ref _lastTradeDateOrContractMonth, value); } }
        private string _lastTradeDateOrContractMonth = string.Empty;

        /// <summary>
        /// 乘数,IB专用
        /// </summary>
        public string multiplier { get { return _multiplier; } set { if (value != null) SetProperty(ref _multiplier, value); } }
        private string _multiplier = string.Empty;

    }

    /// <summary>
    /// """撤单时传入的对象类"""
    /// </summary>
    public class CancelOrderReq : BaseData
    {
        public CancelOrderReq()
        {
        }
        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol { get { return _symbol; } set { if (value != null) SetProperty(ref _symbol, value); } }
        private string _symbol = string.Empty;
        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange { get { return _exchange; } set { if (value != null) SetProperty(ref _exchange, value); } }
        private string _exchange = string.Empty;
        /// <summary>
        /// 合约在本系统中的唯一代码，通常是 合约代码.交易所代码
        /// </summary>
        public string qnSymbol { get { return _qnSymbol; } set { if (value != null) SetProperty(ref _qnSymbol, value); } }
        private string _qnSymbol = string.Empty;


        /// <summary>
        /// 报单号
        /// </summary>
        public string orderID { get { return _orderID; } set { if (value != null) SetProperty(ref _orderID, value); } }
        private string _orderID = string.Empty;

        /// <summary>
        /// 前置机号
        /// </summary>
        public int frontID { get { return _frontID; } set { if (value != null) SetProperty(ref _frontID, value); } }
        private int _frontID = 0;

        /// <summary>
        /// 会话号
        /// </summary>
        public int sessionID { get { return _sessionID; } set { if (value != null) SetProperty(ref _sessionID, value); } }
        private int _sessionID = 0;

    }


    /// <summary>
    /// 持仓详细数据
    /// </summary>
    public class PositionDetail : BindableBase
    {
        public PositionDetail(string instrumentID, string userID="") 
        {
            this.symbol = instrumentID;
            this.accountID = userID;
            if (string.IsNullOrEmpty(this.accountID))
            {
                vtPositionID = this.symbol;
            }
            else 
            {
                vtPositionID=this.accountID+"_"+this.symbol;
            }
        }

        private string _vtPositionID = string.Empty;
        public string vtPositionID { get { return _vtPositionID; } set { if (value != null) SetProperty(ref _vtPositionID, value); } } 

        private string _symbol = string.Empty;
        public string symbol { get { return _symbol; } set { if (value != null) SetProperty(ref _symbol, value); } }

        /// <summary>
        /// 账户，如果账户为空，则统计了所有的账户
        /// </summary>
        private string _accountID = string.Empty;
        public string accountID { get { return _accountID; } set { if (value != null) SetProperty(ref _accountID, value); } }

        public int longPos { get { return _longPos; } set { SetProperty(ref _longPos, value); } }
        private int _longPos = 0;


        public int longYd { get { return _longYd; } set { SetProperty(ref _longYd, value); } }
        private int _longYd = 0;


        public int longTd { get { return _longTd; } set { SetProperty(ref _longTd, value); } }
        private int _longTd = 0;

        public int longPosFrozen { get { return _longPosFrozen; } set { SetProperty(ref _longPosFrozen, value); } }
        private int _longPosFrozen = 0;


        public int longTdFrozen { get { return _longTdFrozen; } set { SetProperty(ref _longTdFrozen, value); } }
        private int _longTdFrozen = 0;

        public int longYdFrozen { get { return _longYdFrozen; } set { SetProperty(ref _longYdFrozen, value); } }
        private int _longYdFrozen = 0;

        public int longTradedVolumn { get { return _longTradedVolumn; } set { SetProperty(ref _longTradedVolumn, value); } }
        private int _longTradedVolumn = 0;

        public int shortTradedVolumn { get { return _shortTradedVolumn; } set { SetProperty(ref _shortTradedVolumn, value); } }
        private int _shortTradedVolumn = 0;

        public int shortPos { get { return _shortPos; } set { SetProperty(ref _shortPos, value); } }
        private int _shortPos = 0;

        public int shortYd { get { return _shortYd; } set { SetProperty(ref _shortYd, value); } }
        private int _shortYd = 0;

        public int shortTd { get { return _shortTd; } set { SetProperty(ref _shortTd, value); } }
        private int _shortTd = 0;

        public int shortPosFrozen { get { return _shortPosFrozen; } set { SetProperty(ref _shortPosFrozen, value); } }
        private int _shortPosFrozen = 0;

        public int shortTdFrozen { get { return _shortTdFrozen; } set { SetProperty(ref _shortTdFrozen, value); } }
        private int _shortTdFrozen = 0;

        public int shortYdFrozen { get { return _shortYdFrozen; } set { SetProperty(ref _shortYdFrozen, value); } }
        private int _shortYdFrozen = 0;

        public string exchange { get { return _exchange; } set { SetProperty(ref _exchange, value); } }
        private string _exchange = string.Empty;

        public enumMode mode { get { return _mode; } set { SetProperty(ref _mode, value); } }
        private enumMode _mode = enumMode.normal;


        public enum enumMode
        {
            /// <summary>
            /// 普通模式
            /// </summary>
            normal,
            /// <summary>
            /// 上期所今昨分别平仓
            /// </summary>
            shfe,
            tdpenalty
        }

        /// <summary>
        /// 成交更新
        /// </summary>
        /// <param name="trade"></param>
        public void UpdateTrade(TradeData trade)
        {

            if (trade.direction == TradeCanstant.DirectLong)
            {
                if (trade.offset == TradeCanstant.offsetOpen)
                    this.longTd += trade.volume;
                else if (trade.offset == TradeCanstant.offsetCloseToday)
                    this.shortTd -= trade.volume;
                else if (trade.offset == TradeCanstant.offsetCloseYesterday)
                    this.shortYd -= trade.volume;
                else if (trade.offset == TradeCanstant.offsetClose)
                {
                    //上期所等同于平昨
                    if (trade.exchange == TradeCanstant.exchangeSHFE)
                    {
                        this.shortYd -= trade.volume;
                    }
                    else  //非上期所，优先平今
                    {
                        this.shortTd -= trade.volume;
                        if (this.shortTd < 0)
                        {
                            this.shortYd += this.shortTd;
                            this.shortTd = 0;
                        }
                    }
                }
            }

            else if (trade.direction == TradeCanstant.DirectShort)
            {
                if (trade.offset == TradeCanstant.offsetOpen)
                    this.shortTd += trade.volume;
                else if (trade.offset == TradeCanstant.offsetCloseToday)
                    this.longTd -= trade.volume;
                else if (trade.offset == TradeCanstant.offsetCloseYesterday)
                    this.longYd -= trade.volume;
                else if (trade.offset == TradeCanstant.offsetClose)
                {
                    //上期所等同于平昨
                    if (trade.exchange == TradeCanstant.exchangeSHFE)
                    {
                        this.longYd -= trade.volume;
                    }
                    else  //非上期所，优先平今
                    {
                        this.longTd -= trade.volume;
                        if (this.longTd < 0)
                        {
                            this.longYd += this.longTd;
                            this.longTd = 0;
                        }
                    }
                }
            }
            this.CalculatePosition();
        }

        /// <summary>
        /// 委托更新
        /// </summary>
        /// <param name="order"></param>
        public void UpdateOrder(OrderData order)
        {
            // 将可撤委托委托缓存下来

            if (order.status == TradeCanstant.statusAllTraded || order.status == TradeCanstant.statusReject)
            {
                return;
            }
            this.CalculateFrozen(order);
        }


        /// <summary>
        /// 持仓更新
        /// </summary>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public void UpdatePosition(PositionData pos)
        {
            if (pos.direction == TradeCanstant.DirectLong)
            {
                this.longPos = pos.totalPosition;
                this.longYd = pos.ydPosition;
                this.longTd = this.longPos - this.longYd;
            }
            else if (pos.direction == TradeCanstant.DirectShort)
            {
                this.shortPos = pos.totalPosition;
                this.shortYd = pos.ydPosition;
                this.shortTd = this.shortPos - this.shortYd;
            }
        }

        public void UpdateOrderReq(OrderReq req, string qnOrderID)
        {

            var order = new OrderData();
            order.symbol = req.symbol;
            order.exchange = req.exchange;
            order.offset = req.offset;
            order.direction = req.direction;
            order.totalVolume = req.volume;
            order.status = TradeCanstant.DirectUnkown;
            order.accountID = req.accountID;


            // 计算冻结量
            this.CalculateFrozen(order);
        }

        /// <summary>
        /// 计算持仓情况
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public void CalculatePosition()
        {
            this.longPos = this.longTd + this.longYd;
            this.shortPos = this.shortTd + this.shortYd;
        }


        /// <summary>
        /// 计算冻结情况
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public void CalculateFrozen(OrderData order)
        {


      
                    //计算剩余冻结量
                    int frozenVolume = order.totalVolume - order.tradedVolume;

                    //多头委托
                    if (order.direction == TradeCanstant.DirectLong)
                    {
                        // 平今
                        if (order.offset == TradeCanstant.offsetCloseToday)
                            this.shortTdFrozen += frozenVolume;
                        // 平昨
                        else if (order.offset == TradeCanstant.offsetCloseYesterday)
                            this.shortYdFrozen += frozenVolume;
                        //平仓
                        else if (order.offset == TradeCanstant.offsetClose)
                        {
                            this.shortTdFrozen += frozenVolume;

                            if (this.shortTdFrozen > this.shortTd)
                            {
                                this.shortYdFrozen += (this.shortTdFrozen - this.shortTd);
                                this.shortTdFrozen = this.shortTd;
                            }
                        }
                    }
                    // 空头委托
                    else if (order.direction == TradeCanstant.DirectShort)
                    {
                        // 平今
                        if (order.offset == TradeCanstant.offsetCloseToday)
                            this.longTdFrozen += frozenVolume;
                        // 平昨
                        else if (order.offset == TradeCanstant.offsetCloseYesterday)
                            this.longYdFrozen += frozenVolume;
                        // 平仓
                        else if (order.offset == TradeCanstant.offsetClose)
                        {
                            this.longTdFrozen += frozenVolume;

                            if (this.longTdFrozen > this.longTd)
                            {
                                this.longYdFrozen += (this.longTdFrozen - this.longTd);
                                this.longTdFrozen = this.longTd;
                            }
                        }
                    }
    

            //汇总今昨冻结
            this.longPosFrozen = this.longYdFrozen + this.longTdFrozen;
            this.shortPosFrozen = this.shortYdFrozen + this.shortTdFrozen;
        }

    }

}
