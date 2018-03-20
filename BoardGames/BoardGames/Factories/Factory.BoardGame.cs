using BoardGames.ViewModels;

namespace BoardGames.Factories
{
    public static partial class Factory
    {
        public static BoardGameVM CreateBoardGameVM(Common.Models.BoardGame input)
        {
            var result = new BoardGameVM()
            {
                Name = input.Name,
                MinPlayers = input.MinPlayers,
                MaxPlayers = input.MaxPlayers,
                MinLengthMinutes = input.MinLengthMinutes,
                MaxLengthMinutes = input.MaxLengthMinutes,
                Played = input.Played
            };

            return result;
        }

        public static BoardGameDetailsVM CreateBoardGameDetailsVM(Common.Models.BoardGame input)
        {
            var result = new BoardGameDetailsVM()
            {
                Name = input.Name,
                MinPlayers = input.MinPlayers,
                MaxPlayers = input.MaxPlayers,
                IdealMinPlayers = input.IdealMinPlayers,
                IdealMaxPlayers = input.IdealMaxPlayers,
                MinLengthMinutes = input.MinLengthMinutes,
                MaxLengthMinutes = input.MaxLengthMinutes,
                ImageFileName = input.ImageFileName,
                Intensity = input.Intensity,
                Played = input.Played,
                Comments = input.Comments
            };

            result.Owner = input.Owner == null ? string.Empty : $"{input.Owner.FirstName} {input.Owner.LastName}";
            result.Expansions = input.BoardGameExpansions?.Select(CreateBoardGameExpansionVM);
            return result;
        }
    }
}
