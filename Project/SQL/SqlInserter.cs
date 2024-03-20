namespace CryptoReg.Controller;

using CryptoReg.Libs;
using CryptoReg.Model;
using Dapper;
using Microsoft.Data.SqlClient;

internal static class SqlInserter{

#region Trade
    public static void InsertNewTradeLog(Trade newTradeLog){
        using(var connection = new SqlConnection(SqlManager.CONNECTION)){
            var affectedLines = connection.Execute(InsertTradeLog(),
            new{
                newTradeLog.DateOpened,
                newTradeLog.DateClosed,
                newTradeLog.Coin,
                newTradeLog.Lavarage,
                newTradeLog.Invested,
                newTradeLog.Final,
                newTradeLog.Result,
                newTradeLog.ROI,
            });
            GeneralLib.Write($"Afected lines: {affectedLines}");
        }
    }

    private static string InsertTradeLog(){
        var tradeRegistry = @"INSERT INTO
            [Trade] (DateOpened, DateClosed, Coin, Lavarage, Invested, Final, Result, ROI)
        VALUES(
            @DateOpened,
            @DateClosed,
            @Coin,
            (ROUND(@Lavarage, 2)),
            (ROUND(@Invested, 2)),
            (ROUND(@Final, 2)),
            (ROUND(@Result, 2)),
            (ROUND(@ROI, 2))
        )";
        return tradeRegistry;
    }

#endregion

#region Balance
    public static void InsertBalanceMonthyRegistry(Balance newBalanceRegistry){
        using(var connection = new SqlConnection(SqlManager.CONNECTION)){
            var affectedLines = connection.Execute(InsertBalance(), new {
                newBalanceRegistry.RegistryDate,
                newBalanceRegistry.Binance,
                newBalanceRegistry.Kucoin,
                newBalanceRegistry.Ledger,
                newBalanceRegistry.TotalUSD,
                newBalanceRegistry.TotalBRL
            });
            GeneralLib.Write($"Afected lines: {affectedLines}");
        }
    }

    private static string InsertBalance(){
        var registry = @"INSERT INTO
            [Balance]
        VALUES(
            @RegistryDate,
            (ROUND(@Binance, 2)),
            (ROUND(@Kucoin, 2)),
            (ROUND(@Ledger, 2)),
            (ROUND(@TotalUSD, 2)),
            (ROUND(@TotalBRL, 2))
        )";
        return registry;
    }
    
#endregion

}