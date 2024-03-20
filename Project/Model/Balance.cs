namespace CryptoReg.Model;

internal class Balance{
    public DateTime RegistryDate { get; set; }
    public float Binance { get; set; }
    public float Kucoin { get; set; }
    public float Ledger { get; set; }
    public float TotalUSD { get; set; }
    public float TotalBRL { get; set; }
}

/*
create table Balance(
    RegistryDate DATE,
    Binance FLOAT,
    Kucoin FLOAT,
    Ledger FLOAT,
    TotalUSD FLOAT,
    TotalBRL FLOAT
)
*/