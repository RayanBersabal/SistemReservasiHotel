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
    public class TransaksiRepository
    {
        private MySqlConnection _conn;

        // constructor
        public TransaksiRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Transaksi transaksi)
        {
            int result = 0;
            string sql = @"INSERT INTO transaksi (TotalBayar, HargaPerMalam, Tanggal, IdReservasi, IdResepsionis, IdTamu) 
                           VALUES (@TotalBayar, @HargaPerMalam, @Tanggal, @IdReservasi, @IdResepsionis, @IdTamu)";
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@TotalBayar", transaksi.TotalBayar);
                cmd.Parameters.AddWithValue("@HargaPerMalam", transaksi.HargaPerMalam);
                cmd.Parameters.AddWithValue("@Tanggal", transaksi.Tanggal);
                cmd.Parameters.AddWithValue("@IdReservasi", transaksi.IdReservasi);
                cmd.Parameters.AddWithValue("@IdResepsionis", transaksi.IdResepsionis);
                cmd.Parameters.AddWithValue("@IdTamu", transaksi.IdTamu);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create Transaksi error: {0}", ex.Message);
                }
            }
            return result;
        }
    }
}
