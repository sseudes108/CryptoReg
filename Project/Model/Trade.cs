namespace CryptoReg.Model;

internal class Trade{
    public int ID { get; set; }
    public string? TradeType { get; set; }
    public int IsOpen { get; set; }
    public DateTime DateOpened { get; set; }
    public DateTime DateClosed { get; set; }
    public string? Coin { get; set; }
    public int Lavarage { get; set; }
    public float Invested { get; set; }
    public float Final { get; set; }
    public float Result { get; set; }
    public float ROI { get; set; }
}

/*
create table Trade(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TradeType VARCHAR(8),
    IsOpen INT,
    DateOpened DATE,
    DateClosed DATE,
    Coin NVARCHAR (12),
    Lavarage INT,
    Invested FLOAT,
    Final FLOAT,
    Result FLOAT,
    ROI FLOAT
)
*/