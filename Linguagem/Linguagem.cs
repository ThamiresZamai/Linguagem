using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BancoDadosDB;

namespace Linguagem
{
    public partial class Linguagem : Form
    {
        public Linguagem()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Entidade.Linguagem linguagem = new Entidade.Linguagem();
            linguagem.pontuacao = Convert.ToInt32(txtPontuacao.Text);
            linguagem.nome = txtNome.Text;

            if (new LinguagemDB().Insert(linguagem))
            {
                MessageBox.Show("Registo Inserido");
                CarregaGrid();
            }
            else
            {
                MessageBox.Show("Erro ao inserir Registro");
            }
        
        }

        private void CarregaGrid()
        {
            GridLinguagem.DataSource = new LinguagemDB().ListarTipo();
        }

        private void Linguagem_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }
    }
}
