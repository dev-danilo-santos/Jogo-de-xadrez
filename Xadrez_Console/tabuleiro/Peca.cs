using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez_Console.tabuleiro;

namespace tabuleiro
{
    internal abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int QtdeMovimentos { get; protected set; }
        public Tabuleiro tab { get; private set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.cor = cor;
            this.tab = tab;
            this.QtdeMovimentos = 0;
        }

        public void IncrementarQtdeMovimento()
        {
            this.QtdeMovimentos++;
        }

        public void DecrementarQtdeMovimento()
        {
            this.QtdeMovimentos--;
        }

        public bool podeMoverPara(Posicao pos)
        {
            return movimentosPossiveis()[pos.Linha,pos.Coluna];
        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tab.Linha ; i++)
            {

                for (int j = 0; j < tab.Coluna; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public abstract bool[,] movimentosPossiveis();
    }
}
