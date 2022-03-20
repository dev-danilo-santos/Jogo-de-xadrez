using System;
using tabuleiro;
using xadrez;

namespace Xadrez_Console
{
    internal class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linha; i++)
            {
                Console.Write(8-i+" ");
                for (int j = 0; j < tabuleiro.Coluna; j++)
                {
                        Tela.imprimirPeca(tabuleiro.peca(i, j));
                }
                Console.WriteLine();

            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterad = ConsoleColor.DarkGray;

            for (int i = 0; i < tabuleiro.Linha; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.Coluna; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterad;
                    }
                    else { Console.BackgroundColor = fundoOriginal; }
                    Tela.imprimirPeca(tabuleiro.peca(i, j));
                    Console.BackgroundColor = fundoOriginal; 
                }
                Console.WriteLine();

            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor=fundoOriginal;
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha); 
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }

        }

    }
}
