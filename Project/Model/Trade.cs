namespace CryptoReg.Model;

internal class Trade{
    public DateTime DateOpened { get; set; }
    public DateTime DateClosed { get; set; }
    public string? Coin { get; set; }
    public int Lavarage { get; set; }
    public float Investido { get; set; }
    public float Final { get; set; }
    public float Resultado { get; set; }
    public int ROI { get; set; }
}
