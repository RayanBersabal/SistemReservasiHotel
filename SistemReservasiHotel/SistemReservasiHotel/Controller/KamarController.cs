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
    public class KamarController
    {
        // Declare repository object to perform CRUD operations
        private KamarRepository _repository;

        /// <summary>
        /// Method to get all Tamu (guests)
        /// </summary>
        /// <returns>List of Tamu</returns>
        public List<Kamar> ReadAll()
        {
            List<Kamar> list = new List<Kamar>();

            // Create DbContext using a using block
            using (DbContext context = new DbContext())
            {
                // Create an instance of the repository
                _repository = new KamarRepository(context);

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
        public int Create(Kamar kamar)
        {
            int result = 0;

            // Validate required fields
            if (string.IsNullOrEmpty(kamar.NoKamar))
            {
                MessageBox.Show("No Kamar harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (string.IsNullOrEmpty(kamar.TipeKamar))
            {
                MessageBox.Show("Tipe Kamar harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Create DbContext and repository
            using (DbContext context = new DbContext())
            {
                _repository = new KamarRepository(context);

                // Call Create method from repository to add new Kamar
                result = _repository.Create(kamar);
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
        public int Update(Kamar kamar)
        {
            int result = 0;

            // Validate required fields
            if (string.IsNullOrEmpty(kamar.NoKamar))
            {
                MessageBox.Show("No Kamar harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (string.IsNullOrEmpty(kamar.TipeKamar))
            {
                MessageBox.Show("Tipe Kamar harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Create DbContext and repository
            using (DbContext context = new DbContext())
            {
                _repository = new KamarRepository(context);

                // Call Update method from repository to modify an existing Tamu
                result = _repository.Update(kamar);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Kamar berhasil diupdate !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Kamar gagal diupdate !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

        /// <summary>
        /// Method to delete a Tamu (guest)
        /// </summary>
        /// <param name="tamu">The Tamu object to be deleted</param>
        /// <returns>Result of the operation</returns>
        public int Delete(Kamar kamar)
        {
            int result = 0;

            // Validate required fields
            if (kamar.IdKamar <= 0)
            {
                MessageBox.Show("No Kamar  harus valid !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Create DbContext and repository
            using (DbContext context = new DbContext())
            {
                _repository = new KamarRepository(context);

                // Call Delete method from repository to remove Tamu
                result = _repository.Delete(kamar.IdKamar);
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

