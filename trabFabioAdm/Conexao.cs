using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace trabFabioAdm
{
    class Conexao
    {
        String sql = "Server=localhost;Database=exe_servicos;user id=sa;password=**";

        public SqlConnection conexaoBanco;
        public SqlCommand command;

        public void conectar()
        {
            conexaoBanco = new SqlConnection(sql);
            conexaoBanco.Open();
            command = new SqlCommand();
            command.Connection = conexaoBanco;


        }
        public void fecharBanco()
        {
            command = null;
            conexaoBanco.Close();
            conexaoBanco = null;
        }

        
    }
}
