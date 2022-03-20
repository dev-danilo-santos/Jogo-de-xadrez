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
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.Terminada)
                {
                    
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab);
                    
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.executaMovimento(origem, destino);
                }
                
                Tela.ImprimirTabuleiro(partida.Tab);
           
            }

            catch (TabuleiroException e) { Console.WriteLine("Error! "+e.Message); }

            //PosicaoXadrez pos = new PosicaoXadrez('c', 7);
            //Console.WriteLine(pos.toPosicao());

            













        }
    }
}