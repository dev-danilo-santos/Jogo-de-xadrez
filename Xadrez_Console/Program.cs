using tabuleiro;
using Xadrez_Console.tabuleiro;
using Jogo_de_Xadrez;
using xadrez;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{

            //    Tabuleiro tab = new Tabuleiro(8, 8);
            //    tab.ColocarPeca(new Torre(tab, Cor.preta), new Posicao(0, 9));
            //    tab.ColocarPeca(new Torre(tab, Cor.preta), new Posicao(0, 0));
            //    tab.ColocarPeca(new Rei(tab, Cor.preta), new Posicao(2, 4));

            //    Tela.ImprimirTabuleiro(tab);

            //    Console.ReadLine();
            //}

            //catch (TabuleiroException e) { Console.WriteLine("Error! "+e.Message); }

            PosicaoXadrez pos = new PosicaoXadrez('c', 7);
            Console.WriteLine(pos.toPosicao());













        }
    }
}