namespace CryptoReg.Controller;

using CryptoReg.Libs;
using CryptoReg.Model;

internal static class BalanceController{
    public static void PrintLastRegistry(Balance lastRegistry){
        GeneralLib.ClearScreen();
        GeneralLib.Write($@"Date:{lastRegistry.RegistryDate}");
        GeneralLib.Write($@"Binance:    $  {lastRegistry.Binance}");
        GeneralLib.Write($@"Kucoin:     $  {lastRegistry.Kucoin}");
        GeneralLib.Write($@"Ledger:     $  {lastRegistry.Ledger}");
        GeneralLib.Write($@"TotalUSD:   $  {lastRegistry.TotalUSD}");
        GeneralLib.Write($@"TotalBRL:   R$ {lastRegistry.TotalBRL}");
    }
}