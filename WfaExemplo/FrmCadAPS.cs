using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfaExemplo
{
    public partial class FrmCadAPS : Form
    {
        public FrmCadAPS()
        {
            InitializeComponent();
        }

        private void cmbForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbForma.Text)
            {
                case "Quadrado":
                    SelecionarQuadrado();
                    break;
                case "Retangulo":
                    SelecionarRetangulo();
                    break;
                case "Triangulo":
                    SelecionarTriangulo();
                    break;
                case "Circunferencia":
                    SelecionarCircunferencia();
                    break;
                default:
                    break;
            }
        }

        private void SelecionarQuadrado()
        {
            ExibirBase(true);
            ExibirAltura(false);
            lblRaio.Visible = txtRaio.Visible = false;
            cmbTriangulo.Visible = false;
        }

        private void ExibirAltura(bool visivel)
        {
            lblAltura.Visible = txtAltura.Visible = visivel;
        }

        private void ExibirBase(bool visivel)
        {
            lblBase.Visible = txtBase.Visible = visivel;
        }
        private void ExibirRaio(bool visivel)
        {
            lblRaio.Visible = txtRaio.Visible = visivel;
        }

        private void SelecionarTriangulo()
        {
            cmbTriangulo.Visible = cmbForma.Text.Equals("Triangulo");
            ExibirBase(true);
            ExibirAltura(true);
            lblRaio.Visible = txtRaio.Visible = false;

        }
        private void SelecionarRetangulo()
        {
            ExibirBase(true);
            ExibirAltura(true);
            lblRaio.Visible = txtRaio.Visible = false;
            cmbTriangulo.Visible = false;
        }
        private void SelecionarCircunferencia()
        {
            ExibirBase(false);
            ExibirAltura(false);
            lblRaio.Visible = txtRaio.Visible = true;
            cmbTriangulo.Visible = false;
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            if (cmbForma.Text.Equals("Quadrado"))
            {
                cmbQuadrado();
            }
            else if (cmbForma.Text.Equals("Retangulo"))
            {
                cmbRetangulo();
            }
            else if (cmbForma.Text.Equals("Triangulo"))
            {
                switch (cmbTriangulo.Text)
                {
                    case "Equilatero":
                        cmbEquilatero();
                        break;
                    case "Reto":
                        cmbReto();
                        break;
                    case "Isosceles":
                        cmbIsosceles();
                        break;
                }
            }
            else
            {
                cmbCircunferencia();
            }
        }

        private void cmbEquilatero()
        {
            FormaGeometrica trianguloE = new TE()
            {
                BaseT = Convert.ToDouble(txtBase.Text),
                AlturaT = Convert.ToDouble(txtAltura.Text)
            };
            cmbObjetos.Items.Add(trianguloE);
        }
        private void cmbReto()
        {
            FormaGeometrica trianguloR = new TR()
            {
                BaseT = Convert.ToDouble(txtBase.Text),
                AlturaT = Convert.ToDouble(txtAltura.Text)
            };
            cmbObjetos.Items.Add(trianguloR);
        }
        private void cmbIsosceles()
        {
            FormaGeometrica trianguloI = new TI()
            {
                Base = Convert.ToDouble(txtBase.Text),
                Altura = Convert.ToDouble(txtAltura.Text)
            };
            cmbObjetos.Items.Add(trianguloI);
        }

        private void cmbQuadrado()
        {
            if (cmbForma.Text.Equals("Quadrado"))
            {
                FormaGeometrica quadrado = new Quadrado()
                {
                    Base = Convert.ToDouble(txtBase.Text)
                };
                cmbObjetos.Items.Add(quadrado);
            }
        }
        private void cmbRetangulo()
        {
            if (cmbForma.Text.Equals("Retangulo"))
            {
                FormaGeometrica retangulo = new Retangulo()
                {
                    Base = Convert.ToDouble(txtBase.Text),
                    Altura = Convert.ToDouble(txtAltura.Text)
                };
                cmbObjetos.Items.Add(retangulo);
            }
        }
        private void cmbCircunferencia()
        {
            if (cmbForma.Text.Equals("Circunferencia"))
            {
                FormaGeometrica circunferencia = new Circunferencia()
                {
                    Raio = Convert.ToDouble(txtRaio.Text)           
                };
                cmbObjetos.Items.Add(circunferencia);
            }
        }


        private void cmbObjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormaGeometrica obj = cmbObjetos.SelectedItem as FormaGeometrica;
            txtArea.Text = obj.CalcularArea().ToString();
            txtPerimetro.Text = obj.CalcularPerimetro().ToString();
        }
    }
}
