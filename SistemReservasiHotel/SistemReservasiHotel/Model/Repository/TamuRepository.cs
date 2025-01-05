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
    public class TamuRepository
    {
        private MySqlConnection _conn;

        // Constructor
        public TamuRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        // Create a new Tamu
        public int Create(Tamu tamu)
        {
            int result = 0;
            string sql = @"INSERT INTO tamu (NamaTamu, NoHp, Email, Alamat) 
                           VALUES (@NamaTamu, @NoHp, @Email, @Alamat)";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@NamaTamu", tamu.NamaTamu);
                cmd.Parameters.AddWithValue("@NoHp", tamu.NoHp);
                cmd.Parameters.AddWithValue("@Email", tamu.Email);
                cmd.Parameters.AddWithValue("@Alamat", tamu.Alamat);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create Tamu error: {0}", ex.Message);
                }
            }
            return result;
        }

        // Read all Tamus
        public List<Tamu> ReadAll()
        {
            List<Tamu> list = new List<Tamu>();
            string sql = @"SELECT IdTamu, NamaTamu, NoHp, Email, Alamat FROM tamu";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tamu tamu = new Tamu
                        {
                            IdTamu = Convert.ToInt32(reader["IdTamu"]),
                            NamaTamu = reader["NamaTamu"].ToString(),
                            NoHp = reader["NoHp"].ToString(),
                            Email = reader["Email"].ToString(),
                            Alamat = reader["Alamat"].ToString()
                        };
                        list.Add(tamu);
                    }
                }
            }
            return list;
        }

        // Update a Tamu
        public int Update(Tamu tamu)
        {
            int result = 0;
            string sql = @"UPDATE tamu 
                           SET NamaTamu = @NamaTamu, NoHp = @NoHp, Email = @Email, Alamat = @Alamat 
                           WHERE IdTamu = @IdTamu";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@NamaTamu", tamu.NamaTamu);
                cmd.Parameters.AddWithValue("@NoHp", tamu.NoHp);
                cmd.Parameters.AddWithValue("@Email", tamu.Email);
                cmd.Parameters.AddWithValue("@Alamat", tamu.Alamat);
                cmd.Parameters.AddWithValue("@IdTamu", tamu.IdTamu);

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

        // Delete a Tamu
        public int Delete(int tamuId)
        {
            int result = 0;
            string sql = @"DELETE FROM tamu WHERE IdTamu = @IdTamu";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@IdTamu", tamuId);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete Tamu error: {0}", ex.Message);
                }
            }
            return result;
        }

        // Get a specific Tamu by ID
        public Tamu GetById(int tamuId)
        {
            Tamu tamu = null;
            string sql = @"SELECT IdTamu, NamaTamu, NoHp, Email, Alamat FROM tamu WHERE IdTamu = @IdTamu";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@IdTamu", tamuId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tamu = new Tamu
                        {
                            IdTamu = Convert.ToInt32(reader["IdTamu"]),
                            NamaTamu = reader["NamaTamu"].ToString(),
                            NoHp = reader["NoHp"].ToString(),
                            Email = reader["Email"].ToString(),
                            Alamat = reader["Alamat"].ToString()
                        };
                    }
                }
            }
            return tamu;
        }
    }
}
