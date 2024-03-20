namespace CryptoReg.Controller;

using CryptoReg.Libs;
using CryptoReg.Model;

internal static class BalanceController{
    public static void PrintLastRegistry(Balance lastRegistry){
        GeneralLib.ClearScreen();

        var formatedDate = lastRegistry.RegistryDate.ToString("dd/MM/yyyy");
        GeneralLib.Write($@"Date:       {formatedDate}");
        GeneralLib.Write($@"Binance:    {GeneralLib.USCurrencyValue(lastRegistry.Binance)}");
        GeneralLib.Write($@"Kucoin:     {GeneralLib.USCurrencyValue(lastRegistry.Kucoin)}");
        GeneralLib.Write($@"Ledger:     {GeneralLib.USCurrencyValue(lastRegistry.Ledger)}");
        GeneralLib.Write($@"TotalUSD:   {GeneralLib.USCurrencyValue(lastRegistry.TotalUSD)}");
        GeneralLib.Write($@"TotalBRL:   {GeneralLib.BRCurrencyValue(lastRegistry.TotalBRL)}");
    }

    public static void CheckLastRegistry(){
        var lastRegistry = SqlReader.GetLastBalanceRegistry();
        GeneralLib.Loading("Searching");

        PrintLastRegistry(lastRegistry);
        GeneralLib.DrawLine();

        MenuLib.BackToMenu(EMenus.Balance);
    }

    public static void NewBalanceRegistry(){
        GeneralLib.ClearScreen();
        MenuLib.Header("Create the Monthly Balance Registry");
        
        GeneralLib.WaitForSeconds(1f);

        Balance newBalance = new(){
            RegistryDate = DateTime.Today,
            // RegistryDate = new DateTime(1999,02,33),
            Binance = MenuLib.GetFloatEntry("Binance account value"),
            Kucoin = MenuLib.GetFloatEntry("Kucoin account value"),
            Ledger = MenuLib.GetFloatEntry("Ledger account value"),
            TotalUSD = MenuLib.GetFloatEntry("TotalUSD value"),
            TotalBRL = MenuLib.GetFloatEntry("TotalBRL value")
        };

        GeneralLib.Loading("Making the Registry");
        SqlInserter.InsertBalanceMonthyRegistry(newBalance);

        MenuLib.BackToMenu(EMenus.Main);
    }
}