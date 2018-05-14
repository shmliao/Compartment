using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanNetCommon
{
    /// <summary>
    /// 交易常量定义
    /// </summary>
    public class TradeCanstant
    {
       /// <summary>
       /// 交易,持仓方向
       /// </summary>
       public const string DirectNone="无";
       /// <summary>
       /// 交易,持仓方向
       /// </summary>
       public const string DirectUnkown="未知";
       /// <summary>
       /// 交易,持仓方向
       /// </summary>
       public const string DirectLong="多";
       /// <summary>
       /// 交易,持仓方向
       /// </summary>
       public const string DirectShort="空";
       /// <summary>
       /// 交易,持仓方向
       /// </summary>
       public const string DirectNet="净";

       /// <summary>
       ///  交易,持仓方向，证券期权
       /// </summary>
       public const string DirectCoveredShort="directCoveredShort";

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

   
        /// <summary>
       ///  开仓，
       /// </summary>
       public const string offsetOpen = "开仓";
        /// <summary>
       ///  平仓，
       /// </summary>
       public const string offsetClose = "平仓";
       /// <summary>
       ///  强仓，
       /// </summary>
       public const string offsetForceClose = "强仓";
        /// <summary>
       ///  平今，
       /// </summary>
       public const string offsetCloseToday = "平今";
        /// <summary>
       ///  平昨，
       /// </summary>
       public const string offsetCloseYesterday = "平昨";


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

         /// <summary>
       ///  未成交，
       /// </summary>
       public const string statusNotTraded="未成交";
        /// <summary>
       ///  部分成交，
       /// </summary>
       public const string statusPartTraded="部分成交";
        /// <summary>
       ///  全部成交，
       /// </summary>
       public const string statusAllTraded="全部成交";
        /// <summary>
       ///  撤单，
       /// </summary>
       public const string statusCanceled="撤单";
        /// <summary>
       ///  拒单，
       /// </summary>
       public const string statusReject="拒单";
        /// <summary>
       ///  未知，
       /// </summary>
       public const string statusUnKown="未知";

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

       /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productEquity="productEquity";

        /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productFutures="productFutures";

           /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productOption="productOption";

         /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productIndex="productIndex";

         /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productCombination="productCombination";

             /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productForex="productForex";

           /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productUnknown="productUnknown";

           /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productSpot="productSpot";

        
           /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productDefer="productDefer";

         /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productNone="productNone";


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          /// <summary>
       ///  价格类型常量Limit，
       /// </summary>
       public const string priceTypeLimit="限价";

        /// <summary>
       ///  价格类型常量Market，
       /// </summary>
       public const string priceTypeMarket="市价";

         /// <summary>
       ///  价格类型常量Fak，
       /// </summary>
       public const string priceTypeFak="Fak";

         /// <summary>
       ///  价格类型常量Fok，
       /// </summary>
       public const string priceTypeFok="Fok";

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

         /// <summary>
       ///  期权类型，
       /// </summary>
       public const string optionCall="Call";

         /// <summary>
       ///  期权类型，
       /// </summary>
       public const string optionPut="Put";

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

          /// <summary>
       ///  交易所类型:上交所，
       /// </summary>
       public const string exchangeSSE = "上交所";

        /// <summary>
       ///  交易所类型:深交所，
       /// </summary>
       public const string exchangeSZSE = "深交所";


          /// <summary>
       ///  交易所类型:中金所，
       /// </summary>
       public const string exchangeCFFEX = "中金所";

            /// <summary>
       ///  交易所类型:郑商所，
       /// </summary>
       public const string exchangeCZCE = "郑商所";

              /// <summary>
       ///  交易所类型:上期所，
       /// </summary>
       public const string exchangeSHFE = "上期所";

         /// <summary>
       ///  交易所类型:大商所，
       /// </summary>
       public const string exchangeDCE = "大商所";


            /// <summary>
       ///  交易所类型:上金所，
       /// </summary>
       public const string exchangeSGE = "上金所";


           /// <summary>
       ///  交易所类型:国际能源交易中心，
       /// </summary>
       public const string exchangeINE = "国际能源交易中心";

        
           /// <summary>
       ///  交易所类型:未知交易所，
       /// </summary>
       public const string exchangeUNKNOWN = "未知交易所";

        
           /// <summary>
       ///  交易所类型:空交易所，
       /// </summary>
       public const string exchange="exchange";

        /// <summary>
       ///  交易所类型:港交所，
       /// </summary>
       public const string exchangeHKEX = "港交所";

           /// <summary>
       ///  交易所类型:香港期货交易所，
       /// </summary>
       public const string exchangeHKFE = "香港期货交易所";

              /// <summary>
       ///  交易所类型:IB智能路由（股票、期权），
       /// </summary>
       public const string exchangeSMART="exchangeSMART";

         /// <summary>
       ///  交易所类型:IB 期货，
       /// </summary>
       public const string exchangeNYMEX="exchangeNYMEX";

         /// <summary>
       ///  交易所类型:CME电子交易平台，
       /// </summary>
       public const string exchangeGLOBEX="exchangeGLOBEX";

           /// <summary>
       ///  交易所类型:IB外汇ECN，
       /// </summary>
       public const string exchangeIDEALPRO="exchangeIDEALPRO";

               /// <summary>
       ///  交易所类型:CME交易所，
       /// </summary>
       public const string exchangeCME = "CME交易所";

             /// <summary>
       ///  交易所类型:ICE交易所，
       /// </summary>
       public const string exchangeICE = "ICE交易所";

         /// <summary>
       ///  交易所类型:LME交易所，
       /// </summary>
       public const string exchangeLME = "LME交易所";

          /// <summary>
       ///  交易所类型:OANDA外汇做市商，
       /// </summary>
       public const string exchangeOANDA = "OANDA外汇做市商";

           /// <summary>
       ///  交易所类型:OKCOIN比特币交易所，
       /// </summary>
       public const string exchangeOKCOIN = "OKCOIN比特币交易所";

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /// <summary>
       ///  货币类型:美元，
       /// </summary>
       public const string currencyUSD = "美元";

        /// <summary>
       ///  货币类型:CNY，
       /// </summary>
       public const string currencyCNY="人民币";

       /// <summary>
       ///  货币类型:HKD，
       /// </summary>
       public const string currencyHKD="港币";

              /// <summary>
        /// 投机
        ///</summary>
        public const string hedgeFlagSpeculation="投机";
        /// <summary>
        /// 套利
        ///</summary>
        public const string hedgeFlagArbitrage="套利";
        /// <summary>
        /// 套保
        ///</summary>
        public const string hedgeFlagHedge="套保";
        /// <summary>
        /// 做市商
        ///</summary>
        public const string hedgeFlagMarketMaker="做市商";

       /// <summary>
       /// 今日持仓
       /// </summary>
        public const string psdToday="今日持仓";

        /// <summary>
        /// 昨日持仓
        /// </summary>
        public const string psdYesterday = "昨日持仓";
    }
}
