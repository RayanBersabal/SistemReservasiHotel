using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using SistemReservasiHotel.Model.Entity;
using SistemReservasiHotel.Model.Repository;
using SistemReservasiHotel.Model.Context;


namespace SistemReservasiHotel.Controller
{
    public class TamuController
    {
        // Declare repository object to perform CRUD operations
        private TamuRepository _repository;

        /// <summary>
        /// Method to get all Tamu (guests)
        /// </summary>
        /// <returns>List of Tamu</returns>
        public List<Tamu> ReadAll()
        {
            List<Tamu> list = new List<Tamu>();

            // Create DbContext using a using block
            using (DbContext context = new DbContext())
            {
                // Create an instance of the repository
                _repository = new TamuRepository(context);

                // Call the ReadAll method from the repository
                list = _repository.ReadAll();
            }

            return list;
        }

        /// <summary>
        /// Method to create a new Tamu (guest)
        /// </summary>
        /// <param name="tamu">The Tamu object to be created</param>
        /// <returns>Result of the operation</returns>
        public int Create(Tamu tamu)
        {
            int result = 0;

            // Validate required fields
            if (string.IsNullOrEmpty(tamu.NamaTamu))
            {
                MessageBox.Show("Nama Tamu harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (string.IsNullOrEmpty(tamu.NoHp))
            {
                MessageBox.Show("No Hp harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Create DbContext and repository
            using (DbContext context = new DbContext())
            {
                _repository = new TamuRepository(context);

                // Call Create method from repository to add new Tamu
                result = _repository.Create(tamu);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Tamu berhasil disimpan !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Tamu gagal disimpan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

        /// <summary>
        /// Method to update an existing Tamu (guest)
        /// </summary>
        /// <param name="tamu">The Tamu object to be updated</param>
        /// <returns>Result of the operation</returns>
        public int Update(Tamu tamu)
        {
            int result = 0;

            // Validate required fields
            if (string.IsNullOrEmpty(tamu.NamaTamu))
            {
                MessageBox.Show("Nama Tamu harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (string.IsNullOrEmpty(tamu.NoHp))
            {
                MessageBox.Show("No Hp harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Create DbContext and repository
            using (DbContext context = new DbContext())
            {
                _repository = new TamuRepository(context);

                // Call Update method from repository to modify an existing Tamu
                result = _repository.Update(tamu);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Tamu berhasil diupdate !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Tamu gagal diupdate !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

        /// <summary>
        /// Method to delete a Tamu (guest)
        /// </summary>
        /// <param name="tamu">The Tamu object to be deleted</param>
        /// <returns>Result of the operation</returns>
        public int Delete(Tamu tamu)
        {
            int result = 0;

            // Validate required fields
            if (tamu.IdTamu <= 0)
            {
                MessageBox.Show("Id Tamu harus valid !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Create DbContext and repository
            using (DbContext context = new DbContext())
            {
                _repository = new TamuRepository(context);

                // Call Delete method from repository to remove Tamu
                result = _repository.Delete(tamu.IdTamu);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Tamu berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Tamu gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }
    }
}
