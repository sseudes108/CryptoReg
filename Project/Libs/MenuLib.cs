using CryptoReg.Enums;
using CryptoReg.Model;
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

    public static void DrawLine(){
        var hif = 0;
        do{
            Console.Write("-");
            hif++;
        }while(hif < 56);
        Console.WriteLine("");
    }

    public static void MenuItem(string nomeDoItem){
        Console.WriteLine(nomeDoItem);
    }

    public static int GetIntegerEntry(){
        GeneralLib.WaitForSeconds(1.5f);
        GeneralLib.Write("Select an Option, Dave");

        bool valid;
        int option;
        do
        {
            var input = Console.ReadLine();
            valid = int.TryParse(input, out option);
        } while (!valid);

        return option;
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

    public static void BackToLastMenu(EMenus menu){
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