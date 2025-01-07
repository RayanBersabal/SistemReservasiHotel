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
    public class ResepsionisRepository
    {
        private MySqlConnection _conn;

        // constructor
        public ResepsionisRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Resepsionis resepsionis)
        {
            int result = 0;
            string sql = @"INSERT INTO resepsionis (IdResepsionis, NamaPetugas, NoHp, Email) 
                           VALUES (@NamePetugas, @NoHp, @Email)";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@IdPetugas", resepsionis.IdResepsionis);
                cmd.Parameters.AddWithValue("@NamePetugas", resepsionis.NamaPetugas);
                cmd.Parameters.AddWithValue("@NoHp", resepsionis.NoHp);
                cmd.Parameters.AddWithValue("@Email", resepsionis.Email);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create Resepsionis error: {0}", ex.Message);
                }
            }
            return result;
        }

        public List<Resepsionis> ReadAll()
        {
            List<Resepsionis> list = new List<Resepsionis>();
            string sql = @"SELECT IdResepsionis, NamaPetugas, NoHp, Email FROM resepsionis";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                using (MySqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        Resepsionis resepsionis = new Resepsionis
                        {
                            IdResepsionis = Convert.ToInt32(dtr["IdResepsionis"]),
                            NamaPetugas = dtr["NamaPetugas"].ToString(),
                            NoHp = Convert.ToInt32(dtr["NoHp"]),
                            Email = dtr["Email"].ToString()
                        };
                        list.Add(resepsionis);
                    }
                }
            }
            return list;
        }

        // Method untuk Update dan Delete bisa ditambahkan dengan cara yang sama.
    }
}
