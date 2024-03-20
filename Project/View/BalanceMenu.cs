namespace CryptoReg.View;

using CryptoReg.Libs;
using CryptoReg.Controller;

internal static class BalanceMenu{
    public static void Show(){       
        GeneralLib.ClearScreen();
        MenuLib.Header("Balance");
        GeneralLib.Write(" ");

        MenuLib.MenuItem("1 - See Last Registry");
        MenuLib.MenuItem("2 - Create a New Registry (Monthly)");

        MenuLib.MenuItem("0 - Back to Main");
        GeneralLib.DrawLine();
        
        var option = MenuLib.GetIntegerEntry();

        switch(option){
            case 1:
                BalanceController.CheckLastRegistry();
            break;
            case 2:
                BalanceController.NewBalanceRegistry();
            break;
            case 0:
                MainMenu.Show();
            break;
        }
    }
}