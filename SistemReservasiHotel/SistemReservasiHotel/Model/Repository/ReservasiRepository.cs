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
    public class ReservasiRepository
    {
        private MySqlConnection _conn;

        // constructor
        public ReservasiRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Reservasi reservasi)
        {
            int result = 0;
            string sql = @"INSERT INTO reservasi (CheckIn, CheckOut, TamuDewasa, IdTamu, IdKamar, IdFasilitas) 
                           VALUES (@CheckIn, @CheckOut, @TamuDewasa, @IdTamu, @IdKamar, @IdFasilitas)";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@CheckIn", reservasi.CheckIn);
                cmd.Parameters.AddWithValue("@CheckOut", reservasi.CheckOut);
                cmd.Parameters.AddWithValue("@TamuDewasa", reservasi.TamuDewasa);
                cmd.Parameters.AddWithValue("@IdTamu", reservasi.IdTamu);
                cmd.Parameters.AddWithValue("@IdKamar", reservasi.IdKamar);
                cmd.Parameters.AddWithValue("@IdFasilitas", reservasi.IdFasilitas);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create Reservasi error: {0}", ex.Message);
                }
            }
            return result;
        }

        public List<Reservasi> ReadAll()
        {
            List<Reservasi> list = new List<Reservasi>();
            string sql = @"SELECT IdReservasi, CheckIn, CheckOut, TamuDewasa, IdTamu, IdKamar, IdFasilitas FROM reservasi";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Reservasi reservasi = new Reservasi
                        {
                            IdReservasi = Convert.ToInt32(reader["IdReservasi"]),
                            CheckIn = Convert.ToDateTime(reader["CheckIn"]),
                            CheckOut = Convert.ToDateTime(reader["CheckOut"]),
                            TamuDewasa = Convert.ToInt32(reader["TamuDewasa"]),
                            IdTamu = Convert.ToInt32(reader["IdTamu"]),
                            IdKamar = Convert.ToInt32(reader["IdKamar"]),
                            IdFasilitas = Convert.ToInt32(reader["IdFasilitas"])
                        };
                        list.Add(reservasi);
                    }
                }
            }
            return list;
        }
    }
}
