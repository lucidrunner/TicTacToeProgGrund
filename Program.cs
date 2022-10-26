namespace TicTacToeProgGrund;


internal class Program
{
    static void Main(string[] args)
    {
        char[,] gameBoard = new char[3,3];
        

        for (int indexX = 0; indexX < 3; indexX++)
        {
            for (int indexY = 0; indexY < 3; indexY++)
            {
                gameBoard[indexX, indexY] = ' ';
            }
        }

        //Spelare 1 - X
        //Spelare 2 - O (inte 0)

        //Två sätt att kolla nuvarande spelare
        int currentPlayer = 1;
        bool firstPlayer = true;

        while (true)
        {
            PrintBoard(gameBoard);
            Console.WriteLine("Skriv in kordinater som X,Y (1-3): ");

            //?? = null-coalescing operator, om värdet till vänster om den inte är null används det, annars det till höger om den
            string input = Console.ReadLine() ?? "";

            //Splitta inputet i sina x / y-delar
            string[] inputParts = input.Split(',');

            Console.WriteLine(inputParts[0]);
            Console.WriteLine(inputParts[1]);


            bool xOkay = int.TryParse(inputParts[0], out int x);
            bool yOkay = int.TryParse(inputParts[1], out int y);
            if (!xOkay)
                x = -1;
            if (!yOkay)
                y = -1;

            //Reducera båda eftersom arrays börjar med index 0
            x--;
            y--;

            if (x >= 0 && y >= 0 && x < 3 && y < 3)
            {
                //Kolla vad som är på platsen
                //Är den valid osv osv, annars, gör inget

                if (currentPlayer == 1)
                {
                    gameBoard[x, y] = 'X';
                    currentPlayer = 2;
                }
                else
                {
                    gameBoard[x, y] = 'O';
                    currentPlayer = 1;
                }

                //Kolla om spelet är slut
            }
        }


    }

    static void PrintBoard(char[,] gameBoard)
    {
        /*
         * [ ] [ ] [ ]
         * [ ] [O] [ ]
         * [X] [ ] [ ]
         */

        Console.WriteLine("-----------");

        for (int indexX = 0; indexX < 3; indexX++)
        {
            for (int indexY = 0; indexY < 3; indexY++)
            {
                Console.Write($"[{gameBoard[indexX, indexY]}]");
            }
            Console.Write('\n');
        }


        Console.WriteLine("-----------");


        
    }

    
}