/*
 * Created by SharpDevelop.
 * User: v
 * Date: 10/05/2020
 * Time: 12:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace trabFabioAdm
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class frmPrincipal : Form
	{
		public frmPrincipal()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void OpcaoCadastroClick(object sender, EventArgs e)
		{
			//INSTANCIA DO FORM
			frmUsuario formUsuario = new frmUsuario();
			formUsuario.MdiParent = this;
			formUsuario.Show();
		}

        private void pesquisarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTelaUsuarios formTelaUsuario = new frmTelaUsuarios();
            formTelaUsuario.MdiParent = this;
            formTelaUsuario.Show();
        }
    }
}
