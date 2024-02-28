namespace TicTacToe
{
    class Program
    {
        // The board is represented by a char array
        // Доска представлена массивом символов
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        static int position;

        // The current player is represented by a char
        // Текущий игрок представлен символом
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            // The game ends when the game is won
            // Игра заканчивается, когда игра выиграна
            bool gameWon = false;

            // Loop until the game is won
            // Цикл до выигрыша игры
            while (!gameWon)
            {
                // Draw the board, get a position, and make a move 
                // Нарисовать доску, получить позицию и сделать ход
                DrawBoard();
                position = GetPosition();
                if (IsValidMove())
                {
                    MakeMove();

                    // Check if the game is won and switch the player
                    // Проверить, выиграл ли игрок и переключить игрока
                    gameWon = CheckWin();
                    if (!gameWon)
                        SwitchPlayer();
                    
                }
                else
                {
                    // The move was invalid, so ask again
                    // Ход был недействителен, поэтому спросите еще раз
                    Console.WriteLine("Not correct move");
                    
                }
            }

            // Draw the board one last time and print the winner
            // Нарисуйте доску еще раз и напечатайте победителя
            DrawBoard();
            Console.WriteLine($"Congratulation: Player {currentPlayer} won");

            // Print the winner
            // Напечатать победителя
        }

        static void DrawBoard()
        {
            // Clear the console and draw the board
            // Очистить консоль и нарисовать доску
            Console.Clear();
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
            
        }

        static int GetPosition()
        {
            // Ask the current player for a position
            // Спросить текущего игрока о позиции
            while (true)
            {
            
                Console.WriteLine($"\nThe player {currentPlayer} get a position");
                string getPosition = Console.ReadLine();
                bool isgetPosition = int.TryParse(getPosition, out position);

                if (isgetPosition == true)
                {
                    if (position > 0 && position < 10)
                    {
                        return position;
                    }
                    else
                    {
                        Console.WriteLine("\nPlease choose correct number from 1 to 9");
                    }
                }

                else
                {
                    Console.WriteLine("\nPlease choose correct number from 1 to 9, not a letter");
                }
            }
            
        }

        static bool IsValidMove()
        {
            // Check if the position is valid
            // Проверить, действительна ли позиция
           
            //if (Array.Exists(board, x => x == 'X' && x == 'O'))
            //{
            //    return false;
            //}
           
            if (board[position-1] != 'X'
                && board[position-1] != 'O')
            {
                return true;
            }
            return false;

        }

        static void MakeMove()
        {
            // Make the move
            // Сделать ход
                       
            board[position-1] = currentPlayer;
        }

        static bool CheckWin()
        {
            // Check if the current player has won
            // Проверить, выиграл ли текущий игрок
            if (board[0] == currentPlayer && board[1] == currentPlayer && board[2] == currentPlayer) { return true; }
            if (board[3] == currentPlayer && board[4] == currentPlayer && board[5] == currentPlayer) { return true; }
            if (board[6] == currentPlayer && board[7] == currentPlayer && board[8] == currentPlayer) { return true; }
            if (board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer) { return true; }
            if (board[0] == currentPlayer && board[3] == currentPlayer && board[6] == currentPlayer) { return true; }
            if (board[1] == currentPlayer && board[4] == currentPlayer && board[7] == currentPlayer) { return true; }
            if (board[2] == currentPlayer && board[5] == currentPlayer && board[8] == currentPlayer) { return true; }
            if (board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer) { return true; }

            else { return false; }

        }

        static void SwitchPlayer()
        {
            // Switch the current player
            // Переключить текущего игрока
            if (currentPlayer == 'X')
            {
                currentPlayer = 'O';
            }
            else
            {
                currentPlayer = 'X';
            }
        }
    }
}