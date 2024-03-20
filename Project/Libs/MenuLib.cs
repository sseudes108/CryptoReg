using CryptoReg.Enums;
using CryptoReg.View;

namespace CryptoReg.Libs;

internal static class MenuLib{
    public static void Header(string headerText){
        var textLength = headerText.Length;

        var maxHifens = 54;
        var maxHifensLessTextLenght = maxHifens - textLength;
        var maxEachSide = maxHifensLessTextLenght / 2;

        var hif = 0;

        //Começo da linha
        do{
            Console.Write("-");
            hif++;
        }while(hif < maxEachSide);

        //Nome do header
        Console.Write(" ");
        Console.Write(headerText);
        Console.Write(" ");

        //Garante o mesmo tamanho caso a matematica resulte em um numero ímpar
        if(maxHifensLessTextLenght %2 != 0){
            hif--;
        }
        //completa a linha até o caracter designado
        do{
            Console.Write("-");
            hif++;
        }while(hif < maxEachSide * 2);
        Console.WriteLine();
    }

    public static void MenuItem(string nomeDoItem){
        Console.WriteLine(nomeDoItem);
    }

    public static int GetIntegerEntry(string text){
        GeneralLib.WaitForSeconds(1.5f);
        GeneralLib.Write(text);

        return GetInteger();
    }
    public static int GetIntegerEntry(){
        GeneralLib.WaitForSeconds(1.5f);
        GeneralLib.Write("Select an Option, Dave");

        return GetInteger();
    }
    private static int GetInteger(){
        bool valid;
        int option;
        do{
            var input = Console.ReadLine();
            valid = int.TryParse(input, out option);
        } while (!valid);

        return option;
    }

    public static float GetFloatEntry(string text){
        GeneralLib.WaitForSeconds(1.5f);
        GeneralLib.Write(text);

        bool valid;
        float option;
        do{
            var input = Console.ReadLine();
            valid = float.TryParse(input, out option);
        } while (!valid);

        return option;
    }

    public static string GetTextEntry(){
        GeneralLib.Write("What was the Coin this time?");
        var input = Console.ReadLine();
        return input.ToUpper();
    }

    public static bool GetYesOrNoEntry(string text){
        GeneralLib.Write(text);
        var input = Console.ReadLine();
        var formatedInput = input.ToUpper();

        bool returnValue = false;
        bool valid;
        do{
            valid = true;

            if (formatedInput.Contains('Y')){
                returnValue = true;
            }
            else if (formatedInput.Contains('N')){
                returnValue = false;
            }
            else{
                valid = false;
            }
        } while (!valid);

        return returnValue;
    }

    public static void ExitProgram(){
        GeneralLib.Write("Good bye, Dave. See you soon.");
        GeneralLib.WaitForSeconds(1.5f);
        Environment.Exit(0);
    }

    public static void PressAnyKey(){
        GeneralLib.Write("Press any key...");
        Console.ReadKey();
    }

    public static void BackToMenu(EMenus menu){
        PressAnyKey();
        
        string? menuName;
        if (menu == EMenus.Balance){
            menuName = "Balance Menu";
        }else if(menu == EMenus.Trade){
            menuName = "Trade Menu";
        }else{
            menuName = "Main Menu";
        }

        GeneralLib.Write($"Backing to {menuName}...");
        GeneralLib.WaitForSeconds(1.5f);

        if(menu == EMenus.Balance){
            BalanceMenu.Show();
        }else if(menu == EMenus.Trade){
            TradeMenu.Show();
        }else{
            MainMenu.Show();
        }
    }
}