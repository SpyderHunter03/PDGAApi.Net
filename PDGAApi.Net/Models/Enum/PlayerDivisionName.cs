namespace PDGAApi.Net.Models.Enum
{
    public enum PlayerDivisionName
    {
        // Professional Divisions
        Open,

        // Amateur Divisions
        Advanced,
        Intermediate,
        Recreational,
        Novice,

        // Junior Divisions
        JuniorUnder18,
        JuniorUnder15,
        JuniorUnder12,
        JuniorUnder10,
        JuniorUnder8,
        JuniorUnder6,

        // Different Divisions
        Purple,

        JuniorIBoys
    }

    public static class PlayerDivisionNameExtensions
    {
        public static PlayerDivisionName GetPlayerDivisionName(this string divisionName)
        {
            return divisionName switch 
            {
                // Professional Divisions
                "Open" => PlayerDivisionName.Open,

                // Amateur Divisions
                "Advanced" => PlayerDivisionName.Advanced,
                "Intermediate" => PlayerDivisionName.Intermediate,
                "Recreational" => PlayerDivisionName.Recreational,
                "Novice" => PlayerDivisionName.Novice,

                // Junior Divisions
                "Junior ≤18" => PlayerDivisionName.JuniorUnder18,
                "Junior ≤15" => PlayerDivisionName.JuniorUnder15,
                "Junior ≤12" => PlayerDivisionName.JuniorUnder12,
                "Junior ≤10" => PlayerDivisionName.JuniorUnder10,
                "Junior ≤8" => PlayerDivisionName.JuniorUnder8,
                "Junior ≤6" => PlayerDivisionName.JuniorUnder6,

                // Different Divisions
                "Purple" => PlayerDivisionName.Purple,
                "Junior I Boys" => PlayerDivisionName.JuniorIBoys,
                _ => throw new System.NotImplementedException()
            };
        }

        public static string GetPlayerDivisionName(this PlayerDivisionName divisionName)
        {
            return divisionName switch
            {
                // Professional Divisions
                PlayerDivisionName.Open => "Open",

                // Amateur Divisions
                PlayerDivisionName.Advanced => "Advanced",
                PlayerDivisionName.Intermediate => "Intermediate",
                PlayerDivisionName.Recreational => "Recreational",
                PlayerDivisionName.Novice => "Novice",

                // Junior Divisions
                PlayerDivisionName.JuniorUnder18 => "Junior ≤18",
                PlayerDivisionName.JuniorUnder15 => "Junior ≤15",
                PlayerDivisionName.JuniorUnder12 => "Junior ≤12",
                PlayerDivisionName.JuniorUnder10 => "Junior ≤10",
                PlayerDivisionName.JuniorUnder8 => "Junior ≤8",
                PlayerDivisionName.JuniorUnder6 => "Junior ≤6",

                // Different Divisions
                PlayerDivisionName.Purple => "Purple",
                PlayerDivisionName.JuniorIBoys => "Junior I Boys",
                _ => throw new System.NotImplementedException(),
            };
        }
    }
}
