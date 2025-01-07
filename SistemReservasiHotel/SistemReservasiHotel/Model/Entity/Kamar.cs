using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemReservasiHotel.Model.Entity
{
    public class Kamar
    {
        public int IdKamar { get; set; }
        public string NoKamar { get; set; }
        public string TipeKamar { get; set; }
        public int IdTamu { get; set; }
    }
}
