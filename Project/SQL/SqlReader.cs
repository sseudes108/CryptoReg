using System.Collections;
using CryptoReg.Model;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CryptoReg.Controller;

internal static class SqlReader{


#region Balance

    public static IEnumerable<Balance> GetAllBalanceRegistries(){
        IEnumerable<Balance> registries;
        using(var connection = new SqlConnection(SqlManager.CONNECTION)){
            registries = connection.Query<Balance>(@"SELECT [RegistryDate], [Binance], [Kucoin], [Ledger], [TotalUSD], [TotalBRL] FROM Balance");
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

}