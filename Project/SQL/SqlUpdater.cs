using CryptoReg.Libs;
using CryptoReg.Model;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CryptoReg.Controller;

internal static class SqlUpdater{
    public static void UpdateTradeRegistry(Trade trade){
        using(var connection = new SqlConnection(SqlManager.CONNECTION)){
            var affectedLines = connection.Execute(CloseOpenedTrade(), new{
                trade.ID,
                trade.IsOpen,
                trade.DateClosed,
                trade.Final,
                trade.Result,
                trade.ROI
            });
            GeneralLib.Write($"Afected lines: {affectedLines}");
        }
    }

    public static string CloseOpenedTrade(){
        var closeTrade = @"UPDATE [Trade] 
            SET
                [IsOpen]=@IsOpen,
                [DateClosed]=@DateClosed,
                [Final]=@Final,
                [Result]=@Result,
                [ROI]=@ROI
            WHERE [ID]=@ID";
        return closeTrade;
    }
}

// var updateVitorias = $"Update [Shemale] SET [Vitorias]='{shemaleVitoriosa.Vitorias}' Where [Nome]='{shemaleVitoriosa.Nome}'";

// connection.Execute(updateVitorias);
// Console.WriteLine($"\nVitoria atualizada");