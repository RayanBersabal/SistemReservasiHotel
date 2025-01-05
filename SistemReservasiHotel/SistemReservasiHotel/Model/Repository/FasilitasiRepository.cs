using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SistemReservasiHotel.Model.Context;
using SistemReservasiHotel.Model.Entity;

namespace SistemReservasiHotel.Model.Repository
{
    public class FasilitasRepository
    {
        private MySqlConnection _conn;

        // constructor
        public FasilitasRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Fasilitas fasilitas)
        {
            int result = 0;
            string sql = @"INSERT INTO fasilitas (TipeFasilitas) 
                           VALUES (@TipeFasilitas)";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@TipeFasilitas", fasilitas.TipeFasilitas);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create Fasilitas error: {0}", ex.Message);
                }
            }
            return result;
        }
    }
}
