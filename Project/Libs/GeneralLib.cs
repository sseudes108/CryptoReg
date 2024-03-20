namespace CryptoReg.Libs;

using System.Globalization;

internal static class GeneralLib{
    public static void Write(string text){
        Console.WriteLine(text);
    }

    public static void ClearScreen(){
        Console.Clear();
    }

    public static void WaitForSeconds(float seconds){
        int miliseconds = (int)(seconds * 1000);
        Thread.Sleep(miliseconds);
    }

    public static void DrawLine(){
        var hif = 0;
        do{
            Console.Write("*");
            hif++;
        }while(hif < 56);
        Console.WriteLine("");
    }

    public static void Loading(string text){
        ClearScreen();
        var index = 0;
        do{
            Write($"{text}.");
            WaitForSeconds(0.15f);
            ClearScreen();

            Write($"{text}..");
            WaitForSeconds(0.15f);
            ClearScreen();

            Write($"{text}...");
            WaitForSeconds(0.15f);
            ClearScreen();
            
            index++;

            // 0.15s * 3 * 5 = 2.25s
        }while(index < 5);
    }

    public static string BRCurrencyValue(float value){
        return value.ToString("C", CultureInfo.CurrentCulture);
    }  

    public static string USCurrencyValue(float value){
        var cultureInfo = CultureInfo.CreateSpecificCulture("en-US");
        return value.ToString("C", cultureInfo);
    }
}