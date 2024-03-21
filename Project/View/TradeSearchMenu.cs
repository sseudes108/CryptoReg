using CryptoReg.Controller;
using CryptoReg.Libs;

namespace CryptoReg.View;

internal static class TradeSearchMenu{
    public static void Show(){
        MenuLib.Header("Trade Search");
        MenuLib.MenuItem("1 - Search for ID");
        MenuLib.MenuItem("2 - Search for ROI (neg. or pos.)");
        MenuLib.MenuItem("3 - Close Opened Trade");
        
        GeneralLib.Write(" ");
        MenuLib.MenuItem("0 - Back To Trade Menu");

        var option = MenuLib.GetIntegerEntry("Please, selecte one, Dave.");
        int id;
        switch (option){
            case 1:
                id = MenuLib.GetIntegerEntry("What is the ID?");
                var trade = TradeController.SearchTradeLogID(id);
                TradeController.PrintTradeLog(trade);

                MenuLib.BackToMenu(EMenus.TradeSearch);
            break;
            case 2:
                var roi = MenuLib.GetIntegerEntry("(1) Positive ROI Trades (2) Negative ROI Trades");
                TradeController.SearchTradeLogROI(roi);
            break;
            case 3:
                id = MenuLib.GetIntegerEntry("What is the ID?");
                TradeController.CloseTrade(id);

                MenuLib.BackToMenu(EMenus.TradeSearch);
            break;
            case 0:
                TradeMenu.Show();
            break;
        }
    }
}