using tabuleiro;
using Xadrez_Console.tabuleiro;
using Jogo_de_Xadrez;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8,8);
            tab.ColocarPeca(new Torre(tab,Cor.preta), new Posicao(0,0));
            tab.ColocarPeca(new Torre(tab, Cor.preta), new Posicao(1,3));
            tab.ColocarPeca(new Rei(tab, Cor.preta), new Posicao(2,4));

            Tela.ImprimirTabuleiro(tab);

            Console.ReadLine();

        }
    }
}