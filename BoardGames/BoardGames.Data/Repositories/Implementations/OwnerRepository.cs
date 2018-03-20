using BoardGames.Common.Models;
using BoardGames.Data.Extensions;
using BoardGames.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BoardGames.Data.Repositories.Implementations
{
    public class OwnerRepository : Repository<Owner>, IOwnerRepository
    {
        public OwnerRepository(AdoNetContext context) : base(context)
        {
        }

        public void Insert(Owner owner)
        {
            using (var cmd = Context.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO Owner (FirstName, LastName) VALUES (@firstname, @lastname);";
                BindParams(cmd, owner);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Owner owner)
        {
            using (var cmd = Context.CreateCommand())
            {
                cmd.CommandText = @"UPDATE Owner SET FirstName = @firstname, LastName = @lastname WHERE Id = @id;";
                BindParams(cmd, owner);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cmd = Context.CreateCommand())
            {
                cmd.CommandText = @"DELETE FROM Owner WHERE Id = @id;";
                cmd.AddParameter("@id", DbType.Int32, id);
                cmd.ExecuteNonQuery();
            }
        }

        public Owner SelectOwnerById(int id)
        {
            using (var cmd = Context.CreateCommand())
            {
                cmd.CommandText = @"SELECT O.* FROM Owner AS O WHERE O.Id = @id;";
                cmd.AddParameter("@id", DbType.Int32, id);
                return ToList(cmd).FirstOrDefault();
            }
        }

        protected override Owner MapToDTO(IDataRecord record)
        {
            return new Owner()
            {
                ID = (int)record["ID"],
                FirstName = (string)record["FirstName"],
                LastName = (string)record["LastName"]
            };
        }

        private void BindParams(IDbCommand cmd, Owner owner)
        {
            if (cmd.CommandText.Contains("@id"))
                cmd.AddParameter("@id", DbType.Int32, owner.ID);

            if (cmd.CommandText.Contains("@firstname"))
                cmd.AddParameter("@firstname", DbType.Int32, owner.FirstName);

            if (cmd.CommandText.Contains("@lastname"))
                cmd.AddParameter("@lastname", DbType.Int32, owner.LastName);
        }
    }
}
