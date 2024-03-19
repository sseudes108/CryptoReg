using CryptoReg.Libs;
using CryptoReg.Controller;
using CryptoReg.Model;

namespace CryptoReg.View;

internal static class BalanceMenu{
    public static void Show(){
        GeneralLib.ClearScreen();
        MenuLib.Header("Balance Menu");
        GeneralLib.Write(" ");

        MenuLib.MenuItem("1 - See Last Registry");
        MenuLib.MenuItem("2 - Creat a New Registry (Monthly)");

        MenuLib.MenuItem("0 - Back to Main");
        MenuLib.DrawLine();
        
        var option = MenuLib.GetIntegerEntry();

        switch(option){
            case 1:
                Balance balanceHolder = new(){
                    RegistryDate = new DateTime(2024,03,19),
                    Binance = 935.12f,
                    Kucoin = 409.04f,
                    Ledger = 659.63f,
                    TotalUSD = 2023.79f,
                    TotalBRL = 10096.96f
                };
                BalanceController.PrintLastRegistry(balanceHolder);
                MenuLib.DrawLine();

                GeneralLib.WaitForSeconds(1.5f);
                
                MenuLib.BackToLastMenu(Enums.EMenus.Balance);
            break;
            case 2:
                GeneralLib.Write("New Registry ");
            break;
            case 0:
                MainMenu.Show();
            break;
        }
    }
}