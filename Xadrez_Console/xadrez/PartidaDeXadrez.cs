using Jogo_de_Xadrez;
using System.Collections.Generic;
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
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.branca;
            Terminada = false;
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        private Peca rei(Cor cor)
        {
            foreach (Peca  x     in pecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }

            }
            return null;
        }

        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            if (R == null)
            {
                throw new TabuleiroException($"Ñão tem rei da cor " + cor + " no tabuleiro!");
            }

            foreach (Peca x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis(); 
                if (mat[R.posicao.Linha,R.posicao.Coluna]) 
                {
                    return true;
                }
            }
            return false;
        }

        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.branca)
            {
                return Cor.preta;
            }
            else { return Cor.branca; }
        }

        public Peca executaMovimento(Posicao origem, Posicao destino ) 
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQtdeMovimento();
            Peca pecaCapturada =  Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada =  executaMovimento(origem, destino);

            if (estaEmXeque(JogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque. "); 
            }

            if (estaEmXeque(adversaria(JogadorAtual)))
            {
                xeque = true;
            }
            else xeque = false; 

            Turno++;
            mudaJogador();
        } 

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tab.RetirarPeca(destino);
            p.DecrementarQtdeMovimento();
            if ( pecaCapturada != null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
                capturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(p,origem);
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

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        private void ColocarPecas()
        {

            colocarNovaPeca('c', 1, new Torre(Tab, Cor.branca));
            colocarNovaPeca('c', 2, new Torre(Tab, Cor.branca));
            colocarNovaPeca('d', 2, new Torre(Tab, Cor.branca));
            colocarNovaPeca('e', 2, new Torre(Tab, Cor.branca));
            colocarNovaPeca('e', 1, new Torre(Tab, Cor.branca));
            colocarNovaPeca('d', 1, new Rei(Tab, Cor.branca));

            colocarNovaPeca('c', 7,new Torre(Tab, Cor.preta));
            colocarNovaPeca('c', 8,new Torre(Tab, Cor.preta));
            colocarNovaPeca('d', 7,new Torre(Tab, Cor.preta));
            colocarNovaPeca('e', 7,new Torre(Tab, Cor.preta));
            colocarNovaPeca('e', 8,new Torre(Tab, Cor.preta));
            colocarNovaPeca('d', 8, new Rei(Tab, Cor.preta));
        }

    }
}
