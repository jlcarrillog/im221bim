using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure
{
    public class PagosDbContext
    {
        private readonly string _connectionString;
        public PagosDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Pago> List()
        {
            var data = new List<Pago>();
            // ToDo
            try
            {
                // ToDo
                return data;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // ToDo
            }
        }

        public Pago Details(Guid id)
        {
            var data = new Pago();
            // ToDo
            try
            {
                // ToDo
                return data;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // ToDo
            }
        }

        public void Create(Pago data)
        {
            // ToDo
            try
            {
                // ToDo
            }
            catch (Exception) { throw; }
            finally
            {
                // ToDo
            }
        }

        public void Edit(Pago data)
        {
            // ToDo
            try
            {
                // ToDo
            }
            catch (Exception) { throw; }
            finally
            {
                // ToDo
            }
        }

        public void Delete(Guid id)
        {
            // ToDo
            try
            {
                // ToDo
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // ToDo
            }
        }
    }
}
