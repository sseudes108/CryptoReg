namespace CryptoReg.Model;

internal class Balance{
    public float Binance { get; set; }
    public float Kucoin { get; set; }
    public float Ledger { get; set; }
    public float TotalUSD { get; set; }
    public float TotalBRL { get; set; }
}

// create table Balance(
//     Binance FLOAT,
//     Kucoin FLOAT,
//     Ledger FLOAT,
//     TotalUSD FLOAT,
//     TotalBRL FLOAT
// )