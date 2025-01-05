using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemReservasiHotel.Model.Entity
{
    public class Tamu  
    {  
        public int IdTamu { get; set; }
        public string NamaTamu { get; set; }
        public string NoHp  { get; set; }
        public string Email { get; set; }
        public string Alamat { get; set; }
    }
}
