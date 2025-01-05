using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemReservasiHotel.Model.Entity
{
    public class Reservasi
    {
        public int IdReservasi { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int TamuDewasa { get; set; }
        public int IdTamu { get; set; }
        public int IdKamar { get; set; }
        public int IdFasilitas { get; set; }
    }
}
