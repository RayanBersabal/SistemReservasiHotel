using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemReservasiHotel.Model.Entity
{
    public class Transaksi
    {
        public int IdTransaksi { get; set; }
        public float TotalBayar { get; set; }
        public float HargaPerMalam { get; set; }
        public DateTime Tanggal { get; set; }
        public int IdReservasi  { get; set; }
        public int IdResepsionis { get; set; }
        public int IdTamu{ get; set; }

    }
}
