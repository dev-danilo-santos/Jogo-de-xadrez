using tabuleiro;
using Xadrez_Console.tabuleiro;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {

            Posicao p = new Posicao(4, 8);
            

            Tabuleiro tab = new Tabuleiro(8,8);

            Tela.ImprimirTabuleiro(tab);

            Console.ReadLine();

        }
    }
}