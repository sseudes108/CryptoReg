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
}