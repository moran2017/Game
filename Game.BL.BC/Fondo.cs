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
   public  class Fondo
    {
       
        public Fondo objFondo { get; set; }
        public void Wall(Graphics g, Bitmap f)
        {
            Rectangle recFondo = new Rectangle(0,0, f.Width, f.Height);

            g.DrawImage(f, g.VisibleClipBounds, recFondo, GraphicsUnit.Pixel);
        }
    }
}
