using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeuCompilador
{
    public partial class MeuCompiladorIHM : Form
    {
        public MeuCompiladorIHM()
        {
            InitializeComponent();
        }

        private void abrirProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            compilarProgramaToolStripMenuItem.Enabled = true;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void compilarProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramaFonte.setPathNome(openFileDialog1.FileName);
            MeuCompiladorBLL.compilarPrograma();
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
            }
            else
                MessageBox.Show("Programa Compilado com sucesso!!!");
        }

        private void MeuCompiladorIHM_Load(object sender, EventArgs e)
        {
            MeuCompiladorDAL.conecta();
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
        }

        private void MeuCompiladorIHM_FormClosing(object sender, FormClosingEventArgs e)
        {
            MeuCompiladorDAL.desconecta();
        }
    }
}
