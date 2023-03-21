using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] matriz = new string[3, 3];
            List<string> indexNum = new List<string>();

            int index = 1, attempts = 1;
            string shifts = "X";
            /*--------------------------------------------*/


            Welcome();

            index = AddtoMatriz(matriz, indexNum, index);

            PrintMatriz(matriz);
            MovePosition(shifts);
            string round = Console.ReadLine();

            Console.Clear();



            while (attempts < 9)
            {
                Welcome();
                toReplace(matriz, shifts, indexNum, round);
                PrintMatriz(matriz);

                //Diagonals
                if (matriz[0, 0] == matriz[1, 1] && matriz[1, 1] == matriz[2, 2] ||
                    matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0])
                {
                    Wins(shifts);
                    break;
                }

                //Lines
                if (matriz[0, 0] == matriz[0, 1] && matriz[0, 1] == matriz[0, 2] ||
                    matriz[1, 0] == matriz[1, 1] && matriz[1, 1] == matriz[1, 2] ||
                    matriz[2, 0] == matriz[2, 1] && matriz[2, 1] == matriz[2, 2])
                {
                    Wins(shifts);
                    break;
                }

                //Columns
                if (matriz[0, 0] == matriz[1, 0] && matriz[1, 0] == matriz[2, 0] ||
                    matriz[0, 1] == matriz[1, 1] && matriz[1, 1] == matriz[2, 1] ||
                    matriz[0, 2] == matriz[1, 2] && matriz[1, 2] == matriz[2, 2])
                {
                    Wins(shifts);
                    break;
                }

                //Check shift
                if (shifts == "X") { shifts = "O"; }
                else { shifts = "X"; }


                
                MovePosition(shifts);
                round = Console.ReadLine();


                while (!indexNum.Contains(round))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nJogada inválida. Tenve novamente: ");
                    Console.ResetColor();
                    round = Console.ReadLine();
                }

                attempts++;
                Console.Clear();
            }


            if (attempts == 9)
            {
                Welcome();
                PrintMatriz(matriz);
                Draw();
            }
            Console.ReadLine();
        }

        private static void Welcome()
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---------------");
            Console.WriteLine(" JOGO DA VELHA");
            Console.WriteLine("---------------");
            Console.ResetColor();
        }

        private static int AddtoMatriz(string[,] matriz, List<string> indexNum, int index)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = index.ToString();
                    indexNum.Add(index.ToString());
                    index++;
                }
            }

            return index;
        }

        private static void PrintMatriz(string[,] matriz)
        {

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($" [{matriz[i, j]}]");
                }
                Console.WriteLine();
            }

        }

        private static void Wins(string shifts)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n-------------");
            Console.WriteLine(" FIM DE JOGO!");
            Console.WriteLine("-------------");
            Console.Write($"Parabens! O ganhador é [{shifts}].");
            Console.ResetColor();
        }

        private static void MovePosition(string shifts)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\nDeseja jogar [{shifts}] em qual posição?: ");
            Console.ResetColor();
        }

        private static void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n------------");
            Console.WriteLine(" FIM DE JOGO!");
            Console.WriteLine("--------------");
            Console.Write($"\nQue tristeza. Ninguem ganhou.");
            Console.ResetColor();
        }

        private static void toReplace(string[,] matriz, string shifts, List<string> indexNum, string round)
        {
            //Validation
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[i, j] == round && indexNum.Contains(round))
                    {
                        matriz[i, j] = shifts;
                        indexNum.Remove(round);
                    }
                }
            }
        }
    }
}



