using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemReservasiHotel.Model.Entity
{
    public class Kamar
    {
        public string IdKamar { get; set; }
        public int NoKamar { get; set; }
        public string TipeKamar { get; set; }
        public int TamuId { get; set; }
    }
}
