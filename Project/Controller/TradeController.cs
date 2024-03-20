namespace CryptoReg.Controller;

using CryptoReg.Libs;
using CryptoReg.Model;

internal static class TradeController{
    public static void PrintTradeLog(Trade tradeLog){
        GeneralLib.ClearScreen();

        if(tradeLog.ID != 0){
            MenuLib.Header($"Trade {tradeLog.ID}");
        }else{
            GeneralLib.DrawLine();
        }

        var formatedDateOpened = tradeLog.DateOpened.ToString("dd/MM/yyyy");
        var formatedDateClosed = tradeLog.DateClosed.ToString("dd/MM/yyyy");
        GeneralLib.Write($@"Opened Date:    {formatedDateOpened}");
        GeneralLib.Write($@"Closed Date:    {formatedDateClosed}");
        GeneralLib.Write($@"Lavarage:       {tradeLog.Lavarage}x");
        GeneralLib.Write($@"Invested:       {GeneralLib.UsCurrencyValue(tradeLog.Invested)}");
        GeneralLib.Write($@"Final:          {GeneralLib.UsCurrencyValue(tradeLog.Final)}");
        GeneralLib.Write($@"Result:         {GeneralLib.UsCurrencyValue(tradeLog.Result)}");
        GeneralLib.Write($@"ROI:            {tradeLog.ROI}%");    
        
        GeneralLib.DrawLine();
    }
}