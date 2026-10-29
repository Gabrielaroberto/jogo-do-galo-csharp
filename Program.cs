using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogo_do_galo
{
    internal class Program
    {
        static string[,] tabuleiro;
        static int tamanho;

        static void Main(string[] args)
        {
            Console.WriteLine("Escolhe a dificuldade:");
            Console.WriteLine("1 - Facil   (3x3)");
            Console.WriteLine("2 - Medio   (5x5)");
            Console.WriteLine("3 - Dificil (7x7)");
            int escolha = int.Parse(Console.ReadLine());

            if (escolha == 1)
            {
                tamanho = 3;
            }
            else if (escolha == 2)
            {
                tamanho = 5;
            }
            else
            {
                tamanho = 7;
            }

            tabuleiro = new string[tamanho, tamanho];
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    tabuleiro[i, j] = " - ";
                }
            }

            int pos_x, pos_y;
            string jogadorAJogar = "x";
            int totalJogadas = 0;

            while (true)
            {
                Console.Clear();
                mostrar_tabuleiro();
                Console.WriteLine("Vez do jogador: " + jogadorAJogar);

                Console.WriteLine("Em que posição de X queres jogar ?");
                pos_x = int.Parse(Console.ReadLine());
                Console.WriteLine("Em que posição de Y queres jogar ?");
                pos_y = int.Parse(Console.ReadLine());

                if (pos_x < 0 || pos_x >= tamanho || pos_y < 0 || pos_y >= tamanho)
                {
                    Console.WriteLine("Posicao invalida! Tenta outra.");
                    Console.ReadKey();
                    continue;
                }

                if (tabuleiro[pos_x, pos_y] != " - ")
                {
                    Console.WriteLine("Posicao ja ocupada! Tenta outra.");
                    Console.ReadKey();
                    continue;
                }

                if (jogadorAJogar == "x")
                {
                    tabuleiro[pos_x, pos_y] = " x ";
                    jogadorAJogar = "o";
                }
                else
                {
                    tabuleiro[pos_x, pos_y] = " o ";
                    jogadorAJogar = "x";
                }

                totalJogadas++;

                string vencedor = verificar_vencedor();
                if (vencedor != "")
                {
                    Console.Clear();
                    mostrar_tabuleiro();
                    Console.WriteLine("Jogador " + vencedor + " ganhou!");
                    break;
                }

                if (totalJogadas == tamanho * tamanho)
                {
                    Console.Clear();
                    mostrar_tabuleiro();
                    Console.WriteLine("Empate!");
                    break;
                }
            }

            Console.ReadKey();
        }

        static void mostrar_tabuleiro()
        {
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    Console.ForegroundColor = tabuleiro[i, j] == " x " ? ConsoleColor.Green : tabuleiro[i, j] == " o " ? ConsoleColor.Red : ConsoleColor.White;
                    Console.Write($"{tabuleiro[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        static string verificar_vencedor()
        {
            string[] jogadores = { " x ", " o " };

            foreach (string peca in jogadores)
            {
                for (int i = 0; i < tamanho; i++)
                {
                    int count = 0;
                    for (int j = 0; j < tamanho; j++)
                    {
                        if (tabuleiro[i, j] == peca) count++;
                        else count = 0;
                        if (count == tamanho) return peca;
                    }
                }

                for (int j = 0; j < tamanho; j++)
                {
                    int count = 0;
                    for (int i = 0; i < tamanho; i++)
                    {
                        if (tabuleiro[i, j] == peca)
                        {
                            count++;
                        }
                        else
                        {
                            count = 0;
                        }
                        if (count == tamanho)
                        {
                            return peca;
                        }
                    }
                }
            }

            return "";
        }
    }
}