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
            string sql = @"INSERT INTO kamar (IdKamar, NoKamar, TipeKamar, IdTamu) 
                           VALUES (@IdKamar, @NoKamar, @TipeKamar, @IdTamu)";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@IdKamar", kamar.IdKamar);
                cmd.Parameters.AddWithValue("@NoKamar", kamar.NoKamar);
                cmd.Parameters.AddWithValue("@TipeKamar", kamar.TipeKamar);
                cmd.Parameters.AddWithValue("@TamuId", kamar.IdTamu);

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
            string sql = @"SELECT IdKamar, NoKamar, TipeKamar, IdTamu FROM kamar";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Kamar kamar = new Kamar
                        {
                            IdKamar = Convert.ToInt32(reader["IdKamar"]),
                            NoKamar = reader["NoKamar"].ToString(),
                            TipeKamar = reader["TipeKamar"].ToString(),
                            IdTamu = Convert.ToInt32(reader["IdTamu"])
                        };
                        list.Add(kamar);
                    }
                }
            }
            return list;
        }

        // Update Kamar
        public int Update(Kamar kamar)
        {
            int result = 0;
            string sql = @"UPDATE kamar 
                           SET IdKamar = @IdKamar, NoKamar = @NoKamar, TipeKamar = @TipeKamar, IdTamu = @IdTamu 
                           WHERE IdKamar = @IdKamar";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                //cmd.Parameters.AddWithValue("@IdKamar", kamar.IdKamar);
                cmd.Parameters.AddWithValue("@NoKamar", kamar.NoKamar);
                cmd.Parameters.AddWithValue("@TipeKamar", kamar.TipeKamar);
                cmd.Parameters.AddWithValue("@IdTamu", kamar.IdTamu);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update Tamu error: {0}", ex.Message);
                }
            }
            return result;
        }
        public int Delete(int IdKamar)
        {
            int result = 0;
            string sql = @"DELETE FROM tamu WHERE IdKamar = @IdKamar";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@IdKamar", "%%" + IdKamar + "%");

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete Kamar error: {0}", ex.Message);
                }
            }
            return result;
        }
    }
}
