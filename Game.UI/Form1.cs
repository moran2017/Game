using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Game.BL.BC;
using Game.DL.DataModel;
namespace Game.UI
{
    public partial class Form1 : Form
    {
        private PersonajeBC objPersonajeBC;
        private Fondo objFondo;
        private Graphics g;
        private BufferedGraphics buffer;
        private Bitmap imgPersonaje;
        private Bitmap imgFondo;
      

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            buffer.Graphics.Clear(this.BackColor);
            objFondo.Wall(buffer.Graphics, imgFondo);
            objPersonajeBC.Dibujar(buffer.Graphics, imgPersonaje);
            buffer.Render(g);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            objPersonajeBC = new PersonajeBC();
            objFondo = new Fondo();
            g = this.CreateGraphics();
            BufferedGraphicsContext context = BufferedGraphicsManager.Current;
            buffer = context.Allocate(g, this.ClientRectangle);
            imgPersonaje = new Bitmap(Resource.Kisame_Sprite_Sheet);
            imgFondo = new Bitmap(Resource.Sprite);
            imgPersonaje.MakeTransparent(imgPersonaje.GetPixel(1, 1));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (objPersonajeBC.EstaMovimiento) return;

            if (e.KeyData == Keys.Right)
            {
                objPersonajeBC.CambiarMovimiento(2);
                objPersonajeBC.EstaMovimiento = true;
                objPersonajeBC.Direccion = 1;
            }

            if (e.KeyData == Keys.Left)
            {
                objPersonajeBC.CambiarMovimiento(2);
                objPersonajeBC.EstaMovimiento = true;
                objPersonajeBC.Direccion = -1;
            }

            else if (e.KeyData == Keys.Space)
            {
                objPersonajeBC.CambiarMovimiento(3);
                objPersonajeBC.EstaMovimiento = true;
            }

            else if (e.KeyData == Keys.A)
            {
                objPersonajeBC.CambiarMovimiento(4);
                objPersonajeBC.EstaMovimiento = true;
            }

            else if (e.KeyData == Keys.S)
            {
                objPersonajeBC.CambiarMovimiento(5);
                objPersonajeBC.EstaMovimiento = true;
            }
                       
        }

       
    }
}
