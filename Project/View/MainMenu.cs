namespace CryptoReg.View;

using CryptoReg.Libs;

internal static class MainMenu{
    public static void Show(){
        GeneralLib.ClearScreen();
        MenuLib.Header("Main");

        GeneralLib.Write(" ");
        MenuLib.MenuItem("1 - Balance");
        MenuLib.MenuItem("2 - Trades");

        GeneralLib.Write(" ");
        MenuLib.MenuItem("0 - Exit");
        GeneralLib.DrawLine();
        
        var option = MenuLib.GetIntegerEntry();

        switch(option){
            case 1:
                BalanceMenu.Show();
            break;
            case 2:
                TradeMenu.Show();
            break;
            case 0:
                MenuLib.ExitProgram();
            break;
        }
    }
}