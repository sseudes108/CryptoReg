using System.Data.SqlTypes;
using System.Globalization;
using CryptoReg.Controller;
using CryptoReg.Libs;
using CryptoReg.Model;

namespace CryptoReg.View;

internal static class TradeMenu{
    public static void Show(){
        GeneralLib.ClearScreen();
        MenuLib.Header("Trade");

        MenuLib.MenuItem("1 - Make a Trade Log Registry");
        MenuLib.MenuItem("2 - Search for a Trade");
        MenuLib.MenuItem("9 - DEBUG");

        GeneralLib.Write(" ");
        MenuLib.MenuItem("0 - Main Menu");

        GeneralLib.DrawLine();

        var option = MenuLib.GetIntegerEntry("What do you want to do, Dave?");

        switch(option){
            case 1:
                CreateTradeLog();
            break;
            case 9:  
                var invested = 108.5f;
                var final = 112.3f;
                var result = Math.Round(final - invested, 2);
                var roi = final/invested * 100 - 100;
                var roundedRoi = Math.Round(roi, 2);

                // Trade newTradeLog = new(){
                //     DateOpened = new DateTime(1800, 12, 08),
                //     DateClosed = new DateTime(1900, 12, 08),
                //     Coin = "locus",
                //     Lavarage = 9,
                //     Invested = invested,
                //     Final = final,
                //     Result = (float)result,
                //     ROI = (float)roundedRoi
                // };
                // TradeController.PrintTradeLog(newTradeLog);

            break;
            case 0:
                MainMenu.Show();
            break;
        }
    }

    private static void CreateTradeLog(){
        GeneralLib.ClearScreen();
        MenuLib.Header("Create a New Finished Trade Log");
        GeneralLib.WaitForSeconds(1.5f);

        Trade newTradeLog = new();
        bool isCorrect = false;

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

            var coin = MenuLib.GetTextEntry();

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
            TradeController.PrintTradeLog(newTradeLog);

            isCorrect = MenuLib.GetYesOrNoEntry("The Log is Correct, Dave? (Yes or No)");
            if(!isCorrect){
                GeneralLib.Loading("OK. Apagando dados");
            }

        }while(!isCorrect);

        SqlInserter.InsertNewTradeLog(newTradeLog);
    }
}