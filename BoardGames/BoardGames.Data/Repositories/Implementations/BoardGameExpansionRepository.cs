using BoardGames.Common.Models;
using BoardGames.Data.Extensions;
using BoardGames.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BoardGames.Data.Repositories.Implementations
{
    public class BoardGameExpansionRepository : Repository<BoardGameExpansion>, IBoardGameExpansionRepository
    {
        public BoardGameExpansionRepository(AdoNetContext context) : base(context)
        {
        }

        public void Insert(BoardGameExpansion boardGameExpansion)
        {
            using (var cmd = Context.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO BoardGameExpansion (BoardGameID, OwnerID, Name, MinPlayers, MaxPlayers, IdealMinPlayers, IdealMaxPlayers, MinLengthMinutes, MaxLengthMinutes, ImageFileName, Intensity,Played, Comments) VALUES (@ownerid, @name, @minplayers, @maxplayers, @idealminplayers, @idealmaxplayers, @minlengthminutes, @maxlengthminutes, @imageFileName, @intensity, @played, @comments);";
                BindParams(cmd, boardGameExpansion);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BoardGameExpansion boardGameExpansion)
        {
            using (var cmd = Context.CreateCommand())
            {
                cmd.CommandText = @"UPDATE BoardGameExpansion SET BoardGameID = @boardgameid, OwnerID = @ownerid, Name = @name, MinPlayers = @minplayers, MaxPlayers = @maxplayers, IdealMinPlayers = @idealminplayers, IdealMaxPlayers = @idealmaxplayers, MinLengthMinutes = @minlengthminutes, MaxLengthMinutes = @maxlengthminutes, ImageFileName = @imagefilename, Intensity = @intensity, Played = @played, Comments = @comments WHERE Id = @id;";
                BindParams(cmd, boardGameExpansion);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cmd = Context.CreateCommand())
            {
                cmd.CommandText = @"DELETE FROM BoardGameExpansion WHERE Id = @id;";
                cmd.AddParameter("@id", DbType.Int32, id);
                cmd.ExecuteNonQuery();
            }
        }

        public BoardGameExpansion SelectBoardGameExpansionById(int id)
        {
            using (var cmd = Context.CreateCommand())
            {
                cmd.CommandText = @"SELECT BGE.* FROM BoardGameExpansion AS BGE WHERE Id = @id;";
                cmd.AddParameter("@id", DbType.Int32, id);
                return ToList(cmd).FirstOrDefault();
            }
        }

        public IEnumerable<BoardGameExpansion> SelectBoardGameExpansionsByBoardGameId(int boardGameId)
        {
            using (var cmd = Context.CreateCommand())
            {
                cmd.CommandText = @"SELECT BGE.* FROM BoardGameExpansion AS BGE WHERE BoardGameId = @boardgameid;";
                cmd.AddParameter("@boardgameid", DbType.Int32, boardGameId);
                return ToList(cmd);
            }
        }

        protected override BoardGameExpansion MapToDTO(IDataRecord record)
        {
            return new BoardGameExpansion()
            {
                ID = (int)record["ID"],
                BoardGameID = (int)record["BoardGameID"],
                OwnerID = (int)record["OwnerID"],
                Name = (string)record["Name"],
                MinPlayers = (int)record["MinPlayers"],
                MaxPlayers = (int)record["MaxPlayers"],
                IdealMinPlayers = (int)record["IdealMinPlayers"],
                IdealMaxPlayers = (int)record["IdealMaxPlayers"],
                MinLengthMinutes = (int)record["MinLengthMinutes"],
                MaxLengthMinutes = (int)record["MaxLengthMinutes"],
                ImageFileName = (string)record["ImageFileName"],
                Intensity = (int)record["Intensity"],
                Played = (bool)record["Played"],
                Comments = (string)record["Comments"]
            };
        }

        private void BindParams(IDbCommand cmd, BoardGameExpansion boardGameExpansion)
        {
            if (cmd.CommandText.Contains("@id"))
                cmd.AddParameter("@id", DbType.Int32, boardGameExpansion.ID);

            if (cmd.CommandText.Contains("@boardgameid"))
                cmd.AddParameter("@boardgameid", DbType.Int32, boardGameExpansion.OwnerID);

            if (cmd.CommandText.Contains("@ownerid"))
                cmd.AddParameter("@ownerid", DbType.Int32, boardGameExpansion.OwnerID);

            if (cmd.CommandText.Contains("@minplayers"))
                cmd.AddParameter("@minplayers", DbType.Int32, boardGameExpansion.MinPlayers);

            if (cmd.CommandText.Contains("@maxplayers"))
                cmd.AddParameter("@maxplayers", DbType.Int32, boardGameExpansion.MaxPlayers);

            if (cmd.CommandText.Contains("@idealminplayers"))
                cmd.AddParameter("@idealminplayers", DbType.Int32, boardGameExpansion.IdealMinPlayers);

            if (cmd.CommandText.Contains("@idealmaxplayers"))
                cmd.AddParameter("@idealmaxplayers", DbType.Int32, boardGameExpansion.IdealMaxPlayers);

            if (cmd.CommandText.Contains("@minlengthminutes"))
                cmd.AddParameter("@minlengthminutes", DbType.Int32, boardGameExpansion.MinLengthMinutes);

            if (cmd.CommandText.Contains("@maxlengthminutes"))
                cmd.AddParameter("@maxlengthminutes", DbType.Int32, boardGameExpansion.MaxLengthMinutes);

            if (cmd.CommandText.Contains("@imagefilename"))
                cmd.AddParameter("@imagefilename", DbType.String, boardGameExpansion.ImageFileName);

            if (cmd.CommandText.Contains("@intensity"))
                cmd.AddParameter("@intensity", DbType.Int32, boardGameExpansion.Intensity);

            if (cmd.CommandText.Contains("@played"))
                cmd.AddParameter("@played", DbType.Boolean, boardGameExpansion.Played);

            if (cmd.CommandText.Contains("@comments"))
                cmd.AddParameter("@comments", DbType.String, boardGameExpansion.Comments);
        }
    }
}
