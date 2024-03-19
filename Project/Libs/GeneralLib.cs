namespace CryptoReg.Libs;

internal static class GeneralLib{
    public static void Write(string text){
        Console.WriteLine(text);
    }

    public static void Write(float value){
        Console.WriteLine("{0:F2}", value);
    }

    public static void ClearScreen(){
        Console.Clear();
    }

    public static void WaitForSeconds(float seconds){
        int miliseconds = (int)(seconds * 1000);
        Thread.Sleep(miliseconds);
    }
}