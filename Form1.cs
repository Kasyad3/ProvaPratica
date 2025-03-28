using System.Xml;

namespace ProvaPratica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            AtualizarTabela();
            Usuario novoUsuario = new Usuario()
            {
                nome = txtNome.Text,
                telefone = txtTelefone.Text

            };
                bool sucesso = Database.SalvarUsuario(novoUsuario);

            LimparCampos();

            AtualizarTabela();
          
        }

        public void LimparCampos()
        {
            txtNome.Clear();
           
            txtTelefone.Clear();
        }

        public void AtualizarTabela()
        {
            dgvLista.DataSource = Database.ListarUsuarios();
        }
    }
}
