using MySql.Data.MySqlClient;

namespace ProvaPratica
{
    internal class Database
    {
        public static bool SalvarUsuario(Usuario usuario)
        {
            string stringDeConexao = "Server=localhost;Port=3306;User Id=root; database=ti113_windowsforms;";
            MySqlConnection conexao = new MySqlConnection(stringDeConexao);
            conexao.Open();

            string query = "insert into Usuarios (Nome, Telefone) values(@nome, @telefone)";
            MySqlCommand cmd = conexao.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@nome", usuario.nome);
            cmd.Parameters.AddWithValue("@telefone", usuario.telefone);

            int quantidade = cmd.ExecuteNonQuery();
            conexao.Close();
            if (quantidade == 0)
                return false;
            else
                return true;

        }

        public static List<Usuario> ListarUsuarios() 
        {
            List<Usuario> usuarios = new List<Usuario>();

            string stringDeConexao = "Server=localhost;Port=3306;User Id=root" +
           "; database=ti113_windowsforms;";
            MySqlConnection conexao = new MySqlConnection(stringDeConexao);
            conexao.Open();

            string query = "select * from usuarios";
            MySqlCommand cmd = conexao.CreateCommand();
            cmd.CommandText = query;

            MySqlDataReader sqlDataReader = cmd.ExecuteReader();

            List<Usuario> listaUsuarios = new List<Usuario>();
            while (sqlDataReader.Read())
            {
                usuarios.Add(new Usuario
                {
                    id = sqlDataReader.GetInt32("id"),

                    nome = sqlDataReader.GetString("nome"),

                    telefone = sqlDataReader.GetString("telefone")

                });

                
            }
            return usuarios;
        }
    }
}
