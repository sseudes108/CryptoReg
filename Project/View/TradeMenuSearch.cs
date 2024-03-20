using CryptoReg.Controller;
using CryptoReg.Libs;

namespace CryptoReg.View;

internal static class TradeMenuSearch{
    public static void Show(){
        MenuLib.Header("Trade Search");
        MenuLib.MenuItem("1 - Search for ID");
        MenuLib.MenuItem("2 - Search for ROI (neg. or pos.)");
        
        GeneralLib.Write(" ");
        MenuLib.MenuItem("0 - Back To Trade Menu");

        var option = MenuLib.GetIntegerEntry("Please, selecte one, Dave.");

        switch(option){
            case 1:
                var id = MenuLib.GetIntegerEntry("What is the ID?");
                TradeController.SearchTradeLogID(id);
            break;
            case 2:
                var roi = MenuLib.GetIntegerEntry("(1) Positive ROI Trades (2) Negative ROI Trades");
                TradeController.SearchTradeLogROI(roi);
            break;
            case 3:

            break;
            case 0:
                TradeMenu.Show();
            break;
        }
    }
}