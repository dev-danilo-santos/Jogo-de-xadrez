using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez_Console.tabuleiro;

namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        private Peca[,] pecas;

        public Tabuleiro(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
            pecas = new Peca[linha,coluna];
        }

        public Peca peca (int linha, int coluna)
        {
            return pecas[linha,coluna];
        }

        public Peca peca (Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("A posição já contem uma peça! ");
            }
            pecas[pos.Linha, pos.Coluna] = p;
            p.posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }
        
        public bool PosicaoValida (Posicao pos)
        {
            if (pos.Linha<0 || pos.Linha>=Linha || pos.Coluna < 0 || pos.Coluna>=Coluna)
            {
                return false;
            }
            return true;
        } 

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;

        }

        public void validarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos)) 
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }


    }
}
