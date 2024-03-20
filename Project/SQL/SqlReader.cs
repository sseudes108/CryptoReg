namespace CryptoReg.Controller;

using CryptoReg.Libs;
using CryptoReg.Model;
using Dapper;
using Microsoft.Data.SqlClient;

internal static class SqlReader{
#region Balance

    public static IEnumerable<Balance> GetAllBalanceRegistries(){
        IEnumerable<Balance> registries;
        using(var connection = new SqlConnection(SqlManager.CONNECTION)){
            registries = connection.Query<Balance>(@"SELECT 
                [RegistryDate], [Binance], [Kucoin], [Ledger], [TotalUSD], [TotalBRL] 
            FROM 
                Balance");
        }
        return registries;
    }

    public static Balance GetLastBalanceRegistry(){
        var registries = GetAllBalanceRegistries();

        Balance lastRegistry = new();
        Balance? lastBalance = new();

        foreach(var item in registries){
            if(lastBalance == null){
                lastBalance.RegistryDate = item.RegistryDate;
            }else{
                if(lastBalance.RegistryDate < item.RegistryDate){
                    lastBalance.RegistryDate = item.RegistryDate;
                    lastBalance.Binance = item.Binance;
                    lastBalance.Kucoin = item.Kucoin;
                    lastBalance.Ledger = item.Ledger;
                    lastBalance.TotalUSD = item.TotalUSD;
                    lastBalance.TotalBRL = item.TotalBRL;
                }
            }
            lastRegistry = lastBalance;
        }
        
        return lastRegistry;
    }
#endregion

#region Trade
    public static IEnumerable<Trade> GetAllTradeLogs(){
        IEnumerable<Trade> registries;
        using(var connection = new SqlConnection(SqlManager.CONNECTION)){
            registries = connection.Query<Trade>(@"SELECT 
                [ID], [DateOpened], [DateClosed], [Coin], [Lavarage], [Invested],
                [Final], [Result], [ROI] 
            FROM 
                Trade");
        }
        return registries;
    }

    public static void SearchTradeLogID(int id){
        var tradeLogs = GetAllTradeLogs();
        var selectedLog = new Trade();
        foreach(var tradeLog in tradeLogs){
            if(id == tradeLog.ID){
                selectedLog = tradeLog;
            }
        }
       
        TradeController.PrintTradeLog(selectedLog);
    }

    public static void SearchTradeLogROI(int key){
        var tradeLogs = GetAllTradeLogs();
        var selectedLogs = new List<Trade>();

        //Positive ROI
        if(key == 1){
            foreach(var tradeLog in tradeLogs){
                if(tradeLog.ROI > 0.0f){
                    selectedLogs.Add(tradeLog);
                }
            }
        }else{
            foreach(var tradeLog in tradeLogs){
                if(tradeLog.ROI < 0.0f){
                    selectedLogs.Add(tradeLog);
                }
            }
        }

        foreach(var tradeLog in selectedLogs){
            TradeController.PrintTradeLog(tradeLog);
        }
    }
#endregion
}