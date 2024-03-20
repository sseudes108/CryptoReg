using CryptoReg.Libs;
using CryptoReg.Model;

namespace CryptoReg.Controller;

internal static class BalanceController{
    public static void PrintLastRegistry(Balance lastRegistry){
        GeneralLib.ClearScreen();

        var formatedDate = lastRegistry.RegistryDate.ToString("dd/MM/yyyy");
        GeneralLib.Write($@"Date:       {formatedDate}");
        GeneralLib.Write($@"Binance:    {GeneralLib.UsCurrencyValue(lastRegistry.Binance)}");
        GeneralLib.Write($@"Kucoin:     {GeneralLib.UsCurrencyValue(lastRegistry.Kucoin)}");
        GeneralLib.Write($@"Ledger:     {GeneralLib.UsCurrencyValue(lastRegistry.Ledger)}");
        GeneralLib.Write($@"TotalUSD:   {GeneralLib.UsCurrencyValue(lastRegistry.TotalUSD)}");
        GeneralLib.Write($@"TotalBRL:   {GeneralLib.BRCurrencyValue(lastRegistry.TotalBRL)}");
    }

    public static void CheckLastRegistry(){
        var lastRegistry = SqlReader.GetLastBalanceRegistry();
        GeneralLib.Loading("Searching");

        PrintLastRegistry(lastRegistry);
        GeneralLib.DrawLine();

        MenuLib.BackToMenu(Enums.EMenus.Balance);
    }

    public static void NewBalanceRegistry(){
        GeneralLib.ClearScreen();
        MenuLib.Header("Create the Monthly Balance Registry");
        
        GeneralLib.WaitForSeconds(1f);

        Balance newBalance = new(){
            RegistryDate = DateTime.Today,
            // RegistryDate = new DateTime(1999,02,33),
            Binance = MenuLib.GetFloatEntry("Binance balance value"),
            Kucoin = MenuLib.GetFloatEntry("Kucoin balance value"),
            Ledger = MenuLib.GetFloatEntry("Ledger balance value"),
            TotalUSD = MenuLib.GetFloatEntry("TotalUSD balance value"),
            TotalBRL = MenuLib.GetFloatEntry("TotalBRL balance value")
        };

        GeneralLib.Loading("Making the Registry");
        SqlInserter.InsertBalanceMonthyRegistry(newBalance);

        MenuLib.BackToMenu(Enums.EMenus.Main);
    }
}