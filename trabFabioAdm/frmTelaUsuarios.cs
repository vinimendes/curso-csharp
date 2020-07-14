using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace trabFabioAdm
{
    public partial class frmTelaUsuarios : Form
    {
        public frmTelaUsuarios()
        {
            InitializeComponent();
        }

        public void Pesquisar()
        {
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            DataSet dt = new DataSet();
            Conexao bancoUsuarios = new Conexao();
            String cod = "%" + txtPesq.Text + "%";
            String sql = "select * from usuario where login like @cod";

            bancoUsuarios.conectar();
            bancoUsuarios.command.CommandText = sql;
            bancoUsuarios.command.Parameters.Add("@cod", SqlDbType.VarChar).Value = cod;
            dAdapter.SelectCommand = bancoUsuarios.command;
            dAdapter.Fill(dt);
            bancoUsuarios.fecharBanco();
            grdView.DataSource = dt.Tables[0];
        }

        private void btnPesq_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt32(grdView.SelectedRows[0].Cells[0].Value);
            String sql = "delete from usuario where codigo = @cod";
            Conexao bancoUsuario = new Conexao();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet dSet = new DataSet();

            bancoUsuario.conectar();
            bancoUsuario.command.CommandText = sql;
            bancoUsuario.command.Parameters.Add("@cod", SqlDbType.Int).Value = cod;
            dataAdapter.SelectCommand = bancoUsuario.command;
            dataAdapter.Fill(dSet);
            bancoUsuario.fecharBanco();
            grdView.DataSource = dSet;

            Pesquisar();

        }
    }
}
