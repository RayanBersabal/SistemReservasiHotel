using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using SistemReservasiHotel.Model.Context;
using SistemReservasiHotel.Model.Entity;

namespace SistemReservasiHotel.Model.Repository
{
    public class KamarRepository
    {
        private MySqlConnection _conn;

        // constructor
        public KamarRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Kamar kamar)
        {
            int result = 0;
            string sql = @"INSERT INTO kamar (IdKamar, NoKamar, TipeKamar, TamuId) 
                           VALUES (@IdKamar, @NoKamar, @TipeKamar, @TamuId)";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@IdKamar", kamar.IdKamar);
                cmd.Parameters.AddWithValue("@NoKamar", kamar.NoKamar);
                cmd.Parameters.AddWithValue("@TipeKamar", kamar.TipeKamar);
                cmd.Parameters.AddWithValue("@TamuId", kamar.TamuId);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create Kamar error: {0}", ex.Message);
                }
            }
            return result;
        }

        public List<Kamar> ReadAll()
        {
            List<Kamar> list = new List<Kamar>();
            string sql = @"SELECT IdKamar, NoKamar, TipeKamar, TamuId FROM kamar";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Kamar kamar = new Kamar
                        {
                            IdKamar = reader["IdKamar"].ToString(),
                            NoKamar = Convert.ToInt32(reader["NoKamar"]),
                            TipeKamar = reader["TipeKamar"].ToString(),
                            TamuId = Convert.ToInt32(reader["TamuId"])
                        };
                        list.Add(kamar);
                    }
                }
            }
            return list;
        }

        // Method untuk Update dan Delete bisa ditambahkan dengan cara yang sama.
    }
}
