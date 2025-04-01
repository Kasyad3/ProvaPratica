namespace ProvaPratica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AtualizarTabela();

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            Usuario novoUsuario = new Usuario()
            {
                nome = txtNome.Text,
                telefone = txtTelefone.Text,
            };


            if (Database.ExisteTelefone(txtTelefone.Text))
            {
                MessageBox.Show("Telefone já existente!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {

                bool sucesso = Database.SalvarUsuario(novoUsuario);
                if (sucesso)
                {
                    MessageBox.Show("Cadastrado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LimparCampos();

                AtualizarTabela();
            }







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
