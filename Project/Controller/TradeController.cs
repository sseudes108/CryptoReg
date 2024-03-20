namespace CryptoReg.Controller;

using CryptoReg.Libs;
using CryptoReg.Model;
using Microsoft.Data.SqlClient;

internal static class TradeController{

#region TradeLog
    public static void CreateTradeLog(){
        GeneralLib.ClearScreen();
        MenuLib.Header("Create a New Finished Trade Log");
        GeneralLib.WaitForSeconds(1.5f);

        Trade newTradeLog = new();
        bool isCorrect;
        do{
            GeneralLib.Write("Enter when you Opened the Trade: ");
            var dayOpen = MenuLib.GetIntegerEntry("Enter the day (dd)");
            var monthOpen = MenuLib.GetIntegerEntry("Enter the month (mm)");
            var yearOpen = MenuLib.GetIntegerEntry("Enter the year (yyyy)");
            GeneralLib.Write($"Opened Date: {dayOpen}/{monthOpen}/{yearOpen}");

            GeneralLib.Write("Enter when you Closed the Trade: ");
            var dayClose = MenuLib.GetIntegerEntry("Enter the day (dd)");
            var monthClose = MenuLib.GetIntegerEntry("Enter the month (mm)");
            var yearClose = MenuLib.GetIntegerEntry("Enter the year (yyyy)");
            GeneralLib.Write($"Closed Date: {dayClose}/{monthClose}/{yearClose}");

            var coin = MenuLib.GetTextEntry("What was the Coin this time?");

            var lavarage = MenuLib.GetIntegerEntry("What was the lavarage?, Dave");

            var invested = MenuLib.GetFloatEntry("How much was the investment?");

            var final = MenuLib.GetFloatEntry("The final value was?");

            var result = Math.Round(final - invested, 2);

            var roi = final/invested * 100 - 100;
            var roundedRoi = Math.Round(roi, 2);

            newTradeLog.DateOpened = new DateTime(yearOpen, monthOpen, dayOpen);
            newTradeLog.DateClosed = new DateTime(yearClose, monthClose, dayClose);
            newTradeLog.Coin = coin;
            newTradeLog.Lavarage = lavarage;
            newTradeLog.Invested = invested;
            newTradeLog.Final = final;
            newTradeLog.Result = (float)result;
            newTradeLog.ROI = (float)roundedRoi;
            
            GeneralLib.Loading("Organizing informations");
            PrintTradeLog(newTradeLog);

            isCorrect = MenuLib.GetYesOrNoEntry("The Log is Correct, Dave? (Yes or No)");
            if(!isCorrect){
                GeneralLib.Loading("OK. Apagando dados");
            }

        }while(!isCorrect);

        SqlInserter.InsertNewTradeLog(newTradeLog);
    }

    public static void PrintTradeLog(Trade tradeLog){
        GeneralLib.Loading("Searching logs");

        if(tradeLog.ID != 0){               //IDs used internally
            MenuLib.Header($"Trade {tradeLog.ID - 1}");
        }else{
            GeneralLib.DrawLine();
        }

        var formatedDateOpened = tradeLog.DateOpened.ToString("dd/MM/yyyy");
        var formatedDateClosed = tradeLog.DateClosed.ToString("dd/MM/yyyy");
        GeneralLib.Write($@"Opened Date:    {formatedDateOpened}");
        GeneralLib.Write($@"Closed Date:    {formatedDateClosed}");
        GeneralLib.Write($@"Lavarage:       {tradeLog.Lavarage}x");
        GeneralLib.Write($@"Invested:       {GeneralLib.USCurrencyValue(tradeLog.Invested)}");
        GeneralLib.Write($@"Final:          {GeneralLib.USCurrencyValue(tradeLog.Final)}");
        GeneralLib.Write($@"Result:         {GeneralLib.USCurrencyValue(tradeLog.Result)}");
        GeneralLib.Write($@"ROI:            {tradeLog.ROI}%");    
        
        GeneralLib.DrawLine();
    }
#endregion

    public static void CalculateTrade(){
        ETradeType tradeType;
        var tradeTypeInput = MenuLib.GetIntegerEntry("(1) Long or (2) Short?");

        if (tradeTypeInput == 1){
            tradeType = ETradeType.Long;
        }
        else{
            tradeType = ETradeType.Short;
        }

        var coin = MenuLib.GetTextEntry("What is the Coin?");
        var price = MenuLib.GetFloatEntry("What is the price?");
        var amount = MenuLib.GetFloatEntry($"What is the amount of {coin}?");
        var lavarage = MenuLib.GetFloatEntry("Whats is the Lavarage?");

        var amountToSell = amount * 0.25f;

        //50%, 100%, 150% Roi
        float target501 = 50 / lavarage / 100;
        float target502 = 100 / lavarage / 100;
        float target503 = 150 / lavarage / 100;

        float sellPoint501 = 0.0f;
        float sellPoint502 = 0.0f;
        float sellPoint503 = 0.0f;

        //75%, 125%, 200% Roi
        float target751 = 75 / lavarage / 100;
        float target752 = 125 / lavarage / 100;
        float target753 = 200 / lavarage / 100;

        float sellPoint751 = 0.0f;
        float sellPoint752 = 0.0f;
        float sellPoint753 = 0.0f;


        //SHORT
        if (tradeType == ETradeType.Long){
            sellPoint751 = price + (price * target751);
            sellPoint752 = price + (price * target752);
            sellPoint753 = price + (price * target753);

            sellPoint501 = price + (price * target501);
            sellPoint502 = price + (price * target502);
            sellPoint503 = price + (price * target503);
        }

        if (tradeType == ETradeType.Short){
            sellPoint751 = price - (price * target751);
            sellPoint752 = price - (price * target752);
            sellPoint753 = price - (price * target753);

            sellPoint501 = price - (price * target501);
            sellPoint502 = price - (price * target502);
            sellPoint503 = price - (price * target503);
        }

        List<float> sellPoints50 = new(){
            sellPoint501,
            sellPoint502,
            sellPoint503
        };

        List<float> sellPoints75 = new(){
            sellPoint751,
            sellPoint752,
            sellPoint753
        };

        PrintSellPoints(tradeType, sellPoints50, 50, amountToSell, price);
        PrintSellPoints(tradeType, sellPoints75, 75, amountToSell, price);

        RegistryNewTrade(coin, price, amount, lavarage);
        MenuLib.BackToMenu(EMenus.Trade);
    }

    private static void RegistryNewTrade(string coin, float price, float amount, float lavarage){

        var makeRegistry = MenuLib.GetYesOrNoEntry("Do you want to registry this trade, Dave? (Yes or No)");

        if (makeRegistry){

            Trade newTrade = new(){
                DateOpened = DateTime.Today,
                Coin = coin,
                Lavarage = (int)lavarage,
                Invested = price * amount,
            };

            GeneralLib.Loading("Organizing informations");
            PrintTradeLog(newTrade);

            makeRegistry = MenuLib.GetYesOrNoEntry("The Log is Correct, Dave? (Yes or No)");

            if (!makeRegistry){
                GeneralLib.Loading("OK. Apagando dados");
            }
            else{
                SqlInserter.InsertNewTradeLog(newTrade);
            }
        }
    }

    private static void PrintSellPoints(ETradeType tradeType, List<float> sellPoints, int target, float amount, float price){
        var index = 1;
        var profits = 0.0f;
        var cost = amount * price;

        MenuLib.Header($"{tradeType} | Sell Targets for {target}s");
        GeneralLib.Write(" ");

        GeneralLib.Write($"Amount to sell {amount}");
        GeneralLib.Write($"Cost {cost}.");

        foreach(var point in sellPoints){
            var faturado = amount * point;
            var profit = faturado - cost;

            if(tradeType == ETradeType.Short){
                profit *= -1;
            }

            profits += profit;
            GeneralLib.Write(" ");
            GeneralLib.Write($"Target {target}{index}: {point}");
            GeneralLib.Write($"Faturado {faturado}. Profit {GeneralLib.USCurrencyValue((float)Math.Round(profit, 2))}.");
            GeneralLib.Write($"Faturado til this moment {(float)Math.Round(profits, 2)}");

            index++;
        }
        GeneralLib.Write(" ");
    }

    public static void SearchTradeLogID(int id){
        SqlReader.SearchTradeLogID(id);
    }
    public static void SearchTradeLogROI(int key){
        SqlReader.SearchTradeLogROI(key);
    }
}