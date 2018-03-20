export interface BoardGame {
  name: string,
  minPlayers: number,
  maxPlayers: number,
  minLengthMinutes: number,
  maxLengthMinutes: number,
  played: boolean,
}
