using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BoardGames.Common.Models;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using BoardGames.Data.Extensions;
using BoardGames.Data.Repositories.Interfaces;
using System.Linq;

namespace BoardGames.Data.Repositories.Implementations
{
    public class BoardGameRepository : Repository<BoardGame>, IBoardGameRepository
    {
        public BoardGameRepository(AdoNetContext context)
            : base(context)
        {
        }

        public void Insert(BoardGame boardGame)
        {
            using (var cmd = Context.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO BoardGame (OwnerID, Name, MinPlayers, MaxPlayers, IdealMinPlayers, IdealMaxPlayers, MinLengthMinutes, MaxLengthMinutes, ImageFileName, Intensity,Played, Comments) VALUES (@ownerid, @name, @minplayers, @maxplayers, @idealminplayers, @idealmaxplayers, @minlengthminutes, @maxlengthminutes, @imageFileName, @intensity, @played, @comments);";
                BindParams(cmd, boardGame);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BoardGame boardGame)
        {
            using (var cmd = Context.CreateCommand())
            {
                cmd.CommandText = @"UPDATE BoardGame SET OwnerID = @ownerid, Name = @name, MinPlayers = @minplayers, MaxPlayers = @maxplayers, IdealMinPlayers = @idealminplayers, IdealMaxPlayers = @idealmaxplayers, MinLengthMinutes = @minlengthminutes, MaxLengthMinutes = @maxlengthminutes, ImageFileName = @imagefilename, Intensity = @intensity, Played = @played, Comments = @comments WHERE Id = @id;";
                BindParams(cmd, boardGame);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cmd = Context.CreateCommand())
            {
                cmd.CommandText = @"DELETE FROM BoardGame WHERE Id = @id;";
                cmd.AddParameter("@id", DbType.Int32, id);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<BoardGame> SelectAll()
        {
            using (var cmd = Context.CreateCommand())
            {
                cmd.CommandText = @"SELECT BG.* FROM BoardGame AS BG;";
                return ToList(cmd);
            }
        }

        public BoardGame SelectBoardGameById(int id)
        {
            using (var cmd = Context.CreateCommand())
            {
                cmd.CommandText = @"SELECT BG.* FROM BoardGame AS BG WHERE BG.ID = @id;";
                cmd.AddParameter("@id", DbType.Int32, id);
                return ToList(cmd).FirstOrDefault();
            }
        }

        protected override BoardGame MapToDTO(IDataRecord record)
        {
            var dbNullType = typeof(DBNull);
            return new BoardGame()
            {
                ID = (int)record["ID"],
                OwnerID = (int)record["OwnerID"],
                Name = record["Name"].GetType() == dbNullType ? null : (string)record["Name"],
                MinPlayers = record["MinPlayers"].GetType() == dbNullType ? null : (int?)record["MinPlayers"],
                MaxPlayers = record["MaxPlayers"].GetType() == dbNullType ? null : (int?)record["MaxPlayers"],
                IdealMinPlayers = record["IdealMinPlayers"].GetType() == dbNullType ? null : (int?)record["IdealMinPlayers"],
                IdealMaxPlayers = record["IdealMaxPlayers"].GetType() == dbNullType ? null : (int?)record["IdealMaxPlayers"],
                MinLengthMinutes = record["MinLengthMinutes"].GetType() == dbNullType ? null : (int?)record["MinLengthMinutes"],
                MaxLengthMinutes = record["MaxLengthMinutes"].GetType() == dbNullType ? null : (int?)record["MaxLengthMinutes"],
                ImageFileName = record["ImageFileName"].GetType() == dbNullType ? null : (string)record["ImageFileName"],
                Intensity = record["Intensity"].GetType() == dbNullType ? null : (int?)record["Intensity"],
                Played = Convert.ToBoolean(record["Played"]),
                Comments = record["Comments"].GetType() == dbNullType ? null : (string)record["Comments"],
            };
        }

        private void BindParams(IDbCommand cmd, BoardGame boardGame)
        {
            if (cmd.CommandText.Contains("@id"))
                cmd.AddParameter("@id", DbType.Int32, boardGame.ID);

            if (cmd.CommandText.Contains("@ownerid"))
                cmd.AddParameter("@ownerid", DbType.Int32, boardGame.OwnerID);

            if (cmd.CommandText.Contains("@minplayers"))
                cmd.AddParameter("@minplayers", DbType.Int32, boardGame.MinPlayers);

            if (cmd.CommandText.Contains("@maxplayers"))
                cmd.AddParameter("@maxplayers", DbType.Int32, boardGame.MaxPlayers);

            if (cmd.CommandText.Contains("@idealminplayers"))
                cmd.AddParameter("@idealminplayers", DbType.Int32, boardGame.IdealMinPlayers);

            if (cmd.CommandText.Contains("@idealmaxplayers"))
                cmd.AddParameter("@idealmaxplayers", DbType.Int32, boardGame.IdealMaxPlayers);

            if (cmd.CommandText.Contains("@minlengthminutes"))
                cmd.AddParameter("@minlengthminutes", DbType.Int32, boardGame.MinLengthMinutes);

            if (cmd.CommandText.Contains("@maxlengthminutes"))
                cmd.AddParameter("@maxlengthminutes", DbType.Int32, boardGame.MaxLengthMinutes);

            if (cmd.CommandText.Contains("@imagefilename"))
                cmd.AddParameter("@imagefilename", DbType.String, boardGame.ImageFileName);

            if (cmd.CommandText.Contains("@intensity"))
                cmd.AddParameter("@intensity", DbType.Int32, boardGame.Intensity);

            if (cmd.CommandText.Contains("@played"))
                cmd.AddParameter("@played", DbType.Boolean, boardGame.Played);

            if (cmd.CommandText.Contains("@comments"))
                cmd.AddParameter("@comments", DbType.String, boardGame.Comments);
        }
    }
}
