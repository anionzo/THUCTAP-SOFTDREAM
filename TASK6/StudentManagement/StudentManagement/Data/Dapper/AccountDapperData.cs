using StudentManagement.Interfaces.IData;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Dapper
{
    internal class AccountDapperData : IAccountData
    {
        private readonly string _connectionString;
        public AccountDapperData(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public bool Create(Account entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Account entity)
        {
            throw new NotImplementedException();
        }

        public Account Get(object key)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
