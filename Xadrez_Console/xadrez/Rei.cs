using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using Xadrez_Console.tabuleiro;

namespace Jogo_de_Xadrez
{
    internal class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linha, tab.Coluna];

            Posicao pos = new Posicao(0, 0);

            //acima 
            pos.definirValores(posicao.Linha -1, posicao.Coluna);
            if (tab.PosicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true; 
            }

            //ne
            pos.definirValores(posicao.Linha - 1, posicao.Coluna+1 );
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //direita 
            pos.definirValores(posicao.Linha, posicao.Coluna+1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //se 
            pos.definirValores(posicao.Linha +1, posicao.Coluna+1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //abaixo
            pos.definirValores(posicao.Linha + 1, posicao.Coluna);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //so
            pos.definirValores(posicao.Linha +1, posicao.Coluna-1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //esquerda
            pos.definirValores(posicao.Linha , posicao.Coluna-1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //no
            pos.definirValores(posicao.Linha - 1, posicao.Coluna -1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;

        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;

        }

        public override string ToString()
        {
            return "R";
        }

    }
}
