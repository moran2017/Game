//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Game.DL.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleMovimiento
    {
        public int DetalleMovimientoId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int DX { get; set; }
        public int DY { get; set; }
        public int Ancho { get; set; }
        public int Largo { get; set; }
        public int MovimientoId { get; set; }
    
        public virtual Movimiento Movimiento { get; set; }
    }
}
