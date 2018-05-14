using QuanNetCommon;
using QuanNetCommon.Event;
using QuanNetCommon.Gateway;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanNetCommon
{
    public static class MainData
    {
        //系统变量
        public static int nOrders = 1; //维护下单OrderRef
        //public static List<FutureBroker> ListFutureBroker;
        //public static List<Investor> ListInvestor;
        //public static ConcurrentDictionary<string, List<Tuple<string, TThostFtdcPosiDirectionType, TThostFtdcHedgeFlagType>>> Dic_InstrumentID_PositionKeys
        //    = new ConcurrentDictionary<string, List<Tuple<string, TThostFtdcPosiDirectionType, TThostFtdcHedgeFlagType>>>();

        public static EventDefine MainEvent = new EventDefine();

        /// <summary>
        /// 多账户操作
        /// </summary>
        public static Dictionary<string,Tuple<IMdApi, ITdApi>> DicGateway = new Dictionary<string,Tuple<IMdApi, ITdApi>>();

        /// <summary>
        /// 本地委托号，不放在每个接口里面，是为了满足多账户要求
        /// </summary>
        public static int maxOrderLocalID = 10000;

        /// <summary>
        /// 多账户操作，用来存储已登录的账号信息
        /// </summary>

        //主页面数据
        /// <summary>
        /// 行情数据
        /// </summary>
        public static ObservableCollection<TickData> AllMarketData = new ObservableCollection<TickData>();

        /// <summary>
        /// 已订阅行情合约列表,防止多账户，重复订阅相同的合约
        /// </summary>
        public static  ConcurrentDictionary<string,TickData> DicMarketData = new ConcurrentDictionary<string,TickData>();
        /// <summary>
        /// 成交数据
        /// </summary>
        public static ObservableCollection<TradeData> AllTradeData = new ObservableCollection<TradeData>();
        /// <summary>
        /// 持仓数据
        /// </summary>
        public static ObservableCollection<PositionData> AllPositionData = new ObservableCollection<PositionData>();
        /// <summary>
        /// 持仓详细
        /// </summary>
        public static ObservableCollection<PositionDetail> AllPositionDetailData = new ObservableCollection<PositionDetail>();
        /// <summary>
        /// 委托数据
        /// </summary>
        public static ObservableCollection<OrderData> AllOrderData = new ObservableCollection<OrderData>();
        /// <summary>
        /// 账户数据
        /// </summary>
        public static ObservableCollection<AccountData> AllAccountData = new ObservableCollection<AccountData>();
        /// <summary>
        /// 可撤委托
        /// </summary>
        public static ObservableCollection<OrderData> CanCancelOrderData = new ObservableCollection<OrderData>();


        /// <summary>
        /// 所有合约
        /// </summary>
        public static ObservableCollection<ContractData> AllContract = new ObservableCollection<ContractData>();

        /// <summary>
        /// 合约字典
        /// </summary>
        public static ConcurrentDictionary<string, ContractData> DicContract = new ConcurrentDictionary<string, ContractData>();

        /// <summary>
        /// 全部委托字典
        /// </summary>
        public static ConcurrentDictionary<string, OrderData> DicOrder = new ConcurrentDictionary<string, OrderData>();

        /// <summary>
        /// 持仓字典
        /// </summary>
        public static ConcurrentDictionary<string, PositionData> DicPosition = new ConcurrentDictionary<string, PositionData>();
        /// <summary>
        /// 账户字典
        /// </summary>
        public static ConcurrentDictionary<string, AccountData> DicAccount = new ConcurrentDictionary<string, AccountData>();
        /// <summary>
        /// 交易字典
        /// </summary>
        public static ConcurrentDictionary<string, TradeData> DicTrade = new ConcurrentDictionary<string, TradeData>();

   
        
        private static readonly ConcurrentDictionary<string, PositionDetail> dicPositionDetail = new ConcurrentDictionary<string, PositionDetail>();

        /// <summary>
        /// 持仓字典
        /// </summary>
        public static ConcurrentDictionary<string, PositionDetail> DicPositionDetail
        {
            get
            {
                return dicPositionDetail;
            }
        }

       private static readonly ConcurrentDictionary<string, OrderData> dicCanCancelOrder = new ConcurrentDictionary<string, OrderData>();

        /// <summary>
        /// 可撤委托字典
        /// </summary>
        public static ConcurrentDictionary<string, OrderData> DicCanCancelOrder
        {
            get
            {
                return dicCanCancelOrder;
            }
        }

        /// <summary>
        /// 合约回调函数
        /// </summary>
        /// <param name="contract"></param>
        public static void ContractDelegate(ContractData contract) 
        {
            //DicContract.TryAdd(contract.symbol, contract);
        }

        /// <summary>
        /// 成交回调
        /// </summary>
        /// <param name="trade"></param>
        public static void TradeDelegate(TradeData trade) 
        {
            lock (AllPositionDetailData)
            {
                var detail = GetPositionDetail(trade.symbol, trade.accountID);
                if (trade.direction == TradeCanstant.DirectLong)
                {
                    detail.longTradedVolumn += trade.volume;
                    //longTradedVolumn+= trade.volume;
                }
                else
                {
                    detail.shortTradedVolumn += trade.volume;
                    //shortTradedVolumn += trade.volume
                }
                ///这个有待商榷测试
                detail.UpdateTrade(trade);


                var detail2 = GetPositionDetail(trade.symbol);
                if (trade.direction == TradeCanstant.DirectLong)
                {
                    detail2.longTradedVolumn += trade.volume;
                    //longTradedVolumn+= trade.volume;
                }
                else
                {
                    detail2.shortTradedVolumn += trade.volume;
                    //shortTradedVolumn += trade.volume
                }
                detail2.UpdateTrade(trade);
            }
        }

        /// <summary>
        /// 委托回调
        /// </summary>
        /// <param name="trade"></param>
        public static void OrderDelegate(OrderData order)
        {
            lock (AllPositionDetailData)
            {
                if (order.status == TradeCanstant.statusAllTraded || order.status == TradeCanstant.statusReject)
                {
                    return;
                }
                var detail = GetPositionDetail(order.symbol);
                detail.UpdateOrder(order);
            }
        }

        /// <summary>
        /// 持仓回调
        /// </summary>
        /// <param name="trade"></param>
        public static void PositionDelegate(PositionData position)
        {
            lock (AllPositionDetailData)
            {
                var detail = GetPositionDetail(position.symbol, position.accountID);
                detail.UpdatePosition(position);

                var detail2 = GetPositionDetail(position.symbol);
                detail2.UpdatePosition(position);
            }
        }

        /// <summary>
        /// 查询持仓细节，为了区分多账户 dicPositionDetail的key分为account+"_"+symbol（方便账户快速平仓）和symbol（主要是为了统计展示）
        /// </summary>
        /// 
        /// <returns></returns>
        public static PositionDetail GetPositionDetail(string symbol,string accountID="")
        {
            string vtPositionID;
            if (string.IsNullOrEmpty(accountID))
            {
                vtPositionID = symbol;
            }
            else
            {
                vtPositionID = accountID + "_" + symbol;
            }
            if (dicPositionDetail.Keys.Contains(vtPositionID))
            {
                var detail = dicPositionDetail[vtPositionID];
                try
                {
                    var contract = DicContract[symbol];
                    detail.exchange = contract.exchange;
                    // 上期所合约
                    if (contract.exchange == TradeCanstant.exchangeSHFE)
                        detail.mode = QuanNetCommon.PositionDetail.enumMode.shfe;

                    //   # 检查是否有平今惩罚
                    //for productID in self.tdPenaltyList:
                    //    if str(productID) in contract.symbol:
                    //        detail.mode = detail.MODE_TDPENALTY
                }
                catch (Exception e)
                {
                }
                return dicPositionDetail[vtPositionID];
            }
            else
            {
                var detail = new PositionDetail(symbol, accountID);
                dicPositionDetail.TryAdd(vtPositionID, detail);
                AllPositionDetailData.Add(detail);
                try
                {
                    var contract = DicContract[symbol];
                    detail.exchange = contract.exchange;
                    // 上期所合约
                    if (contract.exchange == TradeCanstant.exchangeSHFE)
                        detail.mode = QuanNetCommon.PositionDetail.enumMode.shfe;

                    //   # 检查是否有平今惩罚
                    //for productID in self.tdPenaltyList:
                    //    if str(productID) in contract.symbol:
                    //        detail.mode = detail.MODE_TDPENALTY
                }
                catch (Exception e)
                {
                }
                return detail;
            }
        }

        public static void UpdateOrderReq(OrderReq req, string vtOrderID)
        {
            var detail = GetPositionDetail(req.symbol);
            detail.UpdateOrderReq(req, vtOrderID);
        }

        
        public static void SendOrder(OrderReq req)
        {
            foreach (var gateway in DicGateway.Values) 
            {
                var vtOrderID = gateway.Item2.SendOrder(req);
                UpdateOrderReq(req, vtOrderID);
            }
        }

        /// <summary>
        /// 全撤
        /// </summary>
        public static void CancelAll() 
        {
            foreach (var order in CanCancelOrderData)
            {
                var req = new CancelOrderReq();
                req.symbol = order.symbol;
                req.sessionID = order.sessionID;
                req.frontID = order.frontID;
                req.orderID = order.orderID;
                DicGateway[order.accountID].Item2.CancelOrder(req);
            }
        }

        /// <summary>
        /// 通过qnOrderID找到Order
        /// </summary>
        /// <param name="qnOrderID"></param>
        /// <returns></returns>
        public static OrderData GetOrder(string qnOrderID) 
        {
            if (DicOrder.Keys.Contains(qnOrderID))
            {
                return  DicOrder[qnOrderID];
            }
            else
            {
                var order = new OrderData();
                DicOrder.TryAdd(qnOrderID, order);
                MainData.AllOrderData.Insert(0,order);
                return order;
            }
        }

        /// <summary>
        /// 通过qnTradeID找到Trade
        /// </summary>
        /// <param name="qnOrderID"></param>
        /// <returns></returns>
        public static TradeData GetTrade(string qnTradeID)
        {
            if (DicTrade.Keys.Contains(qnTradeID))
            {
                return DicTrade[qnTradeID];
            }
            else
            {
                var trade = new TradeData(qnTradeID);
                DicTrade.TryAdd(qnTradeID, trade);
                MainData.AllTradeData.Insert(0,trade);
                return trade;
            }
        }


        /// <summary>
        /// 通过qnPositionName找到Position
        /// </summary>
        /// <param name="qnOrderID"></param>
        /// <returns></returns>
        public static PositionData GetPosition(string qnPositionName)
        {
            if (DicPosition.Keys.Contains(qnPositionName))
            {
                return DicPosition[qnPositionName];
            }
            else
            {
                var position = new PositionData();
                DicPosition.TryAdd(qnPositionName, position);
                MainData.AllPositionData.Insert(0,position);
                return position;
            }
        }

        /// <summary>
        /// 通过qnAccountID找到Account
        /// </summary>
        /// <param name="qnOrderID"></param>
        /// <returns></returns>
        public static AccountData GetAccount(string qnAccountID)
        {
            if (DicPosition.Keys.Contains(qnAccountID))
            {
                return DicAccount[qnAccountID];
            }
            else
            {
                var account = new AccountData();
                DicAccount.TryAdd(qnAccountID, account);
                MainData.AllAccountData.Insert(0,account);
                return account;
            }
        }
    }
}
