using Jogo_de_Xadrez;
using System;
using tabuleiro;
using Xadrez_Console.tabuleiro;

namespace xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set;  }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }


        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.branca;
            Terminada = false;
            ColocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino ) 
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQtdeMovimento();
            Peca pecaCapturada =  Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);

        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            Turno++;
            mudaJogador();
        } 

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (Tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida.");

            }
            if (JogadorAtual != Tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peca de origem escolhida nao é sua!");
            }
            if (!Tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }

        }

        private void mudaJogador()
        {
            if (JogadorAtual == Cor.branca)
            {
                JogadorAtual = Cor.preta;
            }
            else JogadorAtual = Cor.branca;
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida! ");
            }
        }


        private void ColocarPecas()
        {
            Tab.ColocarPeca(new Torre(Tab,Cor.branca),new PosicaoXadrez('c',1).toPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.branca), new PosicaoXadrez('c', 2).toPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.branca), new PosicaoXadrez('d', 2).toPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.branca), new PosicaoXadrez('e', 2).toPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.branca), new PosicaoXadrez('e', 1).toPosicao());
            Tab.ColocarPeca(new Rei (Tab, Cor.branca), new PosicaoXadrez('d', 1).toPosicao());

            Tab.ColocarPeca(new Torre(Tab, Cor.preta), new PosicaoXadrez('c', 7).toPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.preta), new PosicaoXadrez('c', 8).toPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.preta), new PosicaoXadrez('d', 7).toPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.preta), new PosicaoXadrez('e', 7).toPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.preta), new PosicaoXadrez('e', 8).toPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.preta), new PosicaoXadrez('d', 8).toPosicao());
        }

    }
}
