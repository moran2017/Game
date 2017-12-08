using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.DL.DataModel;
using System.Drawing;
using System.Data.Entity;


namespace Game.BL.BC
{
    public class PersonajeBC
    {
        public Personaje objPersonaje { get; set; }

        public List<DetalleMovimiento> LstDetalleMovimiento { get; set; }
        private GameEntities context; // crea las cosas del entity framework

        public int NroMovimientos { get; set; }
        public int Indice { get; set; }
        public int Direccion { get; set; }
        public int MovimientoId { get; set; }
        public int Desviacion { get; set; }
        public bool EstaMovimiento { get; set; }


        public PersonajeBC()
        {
            context = new GameEntities();
            objPersonaje = context.Personaje.FirstOrDefault(x => x.PersonajeId == 1);
            // SELECT * FROM Personaje WHERE PersonajeId = 1
            Direccion = 1;
            EstaMovimiento = false;
            CambiarMovimiento(1);
        }
        public void CambiarMovimiento(int MovimientoId)
        {
            this.MovimientoId = MovimientoId;
            LstDetalleMovimiento = context.DetalleMovimiento.Where(x => x.MovimientoId == MovimientoId).ToList();
            Desviacion = LstDetalleMovimiento.Min(x => x.Ancho);
            NroMovimientos = context.Movimiento.FirstOrDefault(x => x.MovimientoId == MovimientoId).NroMovimientos;
            Indice = 0;
        }

        public void Dibujar(Graphics g, Bitmap b)
        {
            Rectangle ZonaaUsar = new Rectangle(
                LstDetalleMovimiento[Indice].X,
                LstDetalleMovimiento[Indice].Y,
                LstDetalleMovimiento[Indice].Ancho,
                LstDetalleMovimiento[Indice].Largo);
            Rectangle ZonaaDibujar = new Rectangle(
                Direccion == 1 ? objPersonaje.X : objPersonaje.X + Desviacion,
                objPersonaje.Y - LstDetalleMovimiento[Indice].Largo,
                Direccion * LstDetalleMovimiento[Indice].Ancho,
                LstDetalleMovimiento[Indice].Largo);

            g.DrawImage(b, ZonaaDibujar, ZonaaUsar, GraphicsUnit.Pixel);

            objPersonaje.X += (Direccion * LstDetalleMovimiento[Indice].DX);
            objPersonaje.Y += LstDetalleMovimiento[Indice].DY;

            if (Indice == NroMovimientos - 1)
            {
                if (MovimientoId == 1)
                    Indice = 0;
                else
                {
                    CambiarMovimiento(1);
                    EstaMovimiento = false;
                }
            }
            else
                Indice++;
        }
    }
}
