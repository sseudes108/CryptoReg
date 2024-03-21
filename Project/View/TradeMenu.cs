namespace CryptoReg.View;

using CryptoReg.Controller;
using CryptoReg.Libs;

internal static class TradeMenu{
    public static void Show(){
        GeneralLib.ClearScreen();
        MenuLib.Header("Trade");

        MenuLib.MenuItem("1 - Make a Trade Log Registry");
        MenuLib.MenuItem("2 - Search for a Trade");
        MenuLib.MenuItem("3 - Calculate trade");
        MenuLib.MenuItem("9 - DEBUG");

        GeneralLib.Write(" ");
        MenuLib.MenuItem("0 - Main Menu");

        GeneralLib.DrawLine();

        var option = MenuLib.GetIntegerEntry("What do you want to do, Dave?");

        switch(option){
            case 1:
                TradeController.CreateTradeLog();
            break;
            case 2:
                TradeSearchMenu.Show();
            break;
            case 3:
                TradeController.CalculateTrade();
            break;
            case 0:
                MainMenu.Show();
            break;
        }
    }
}