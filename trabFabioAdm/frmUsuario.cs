using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace trabFabioAdm
{
    /// <summary>
    /// Description of frmUsuario.
    /// </summary>
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            
            InitializeComponent();
            
        }

        

        private void frmUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnGrava_Click(object sender, EventArgs e)
        {

            String login = txtLogin.Text;
            String pass = txtSenha.Text;
            String sql = "insert into usuario(login, senha) values(@login, @pass)";
            String consulNumb = "select count(*) as qtde from usuario where login like @login";

            Conexao bancoUsuario = new Conexao();
            DataSet dt = new DataSet();
            SqlDataAdapter dAdapter = new SqlDataAdapter();

            bancoUsuario.conectar();
            bancoUsuario.command.CommandText = consulNumb;
            bancoUsuario.command.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
            dAdapter.SelectCommand = bancoUsuario.command;
            dAdapter.Fill(dt);
            int qtde = Convert.ToInt32(dt.Tables[0].DefaultView[0].Row["qtde"]);

            if (qtde == 1)
            {
                MessageBox.Show("Esse usuario já existe", "Não foi possível gravar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Text = "";
                txtSenha.Text = "";
            } else
            {
                bancoUsuario.command.CommandText = sql;
                bancoUsuario.command.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                bancoUsuario.command.ExecuteNonQuery();
                MessageBox.Show("Concluído", "Gravado com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLogin.Text = "";
                txtSenha.Text = "";

                
            }

            bancoUsuario.fecharBanco();
        }
    }
}
