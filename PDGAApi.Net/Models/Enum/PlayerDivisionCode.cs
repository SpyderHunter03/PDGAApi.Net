namespace PDGAApi.Net.Models.Enum
{
    public enum PlayerDivisionCode
    {
        // Professional Divisions
        MPO,
        FPO,

        // Amateur Divisions
        MA1,
        MA2,
        MA3,
        MA4,
        FA1,
        FA2,
        FA3,
        FA4,

        // Junior Divisions
        MJ18,
        MJ15,
        MJ12,
        MJ10,
        MJ8,
        MJ6,
        FJ18,
        FJ15,
        FJ12,
        FJ10,
        FJ8,
        FJ6,

        // Different Divisions
        RAG,
        MJ1
    }

    public static class PlayerDivisionCodeExtensions
    {
        public static PlayerDivisionCode GetPlayerDivisionCode(this string divisionCode)
        {
            return divisionCode switch
            {
                // Professional Divisions
                "MPO" => PlayerDivisionCode.MPO,
                "FPO" => PlayerDivisionCode.FPO,

                // Amateur Divisions
                "MA1" => PlayerDivisionCode.MA1,
                "MA2" => PlayerDivisionCode.MA2,
                "MA3" => PlayerDivisionCode.MA3,
                "MA4" => PlayerDivisionCode.MA4,
                "FA1" => PlayerDivisionCode.FA1,
                "FA2" => PlayerDivisionCode.FA2,
                "FA3" => PlayerDivisionCode.FA3,
                "FA4" => PlayerDivisionCode.FA4,

                // Junior Divisions
                "MJ18" => PlayerDivisionCode.MJ18,
                "MJ15" => PlayerDivisionCode.MJ15,
                "MJ12" => PlayerDivisionCode.MJ12,
                "MJ10" => PlayerDivisionCode.MJ10,
                "MJ8" => PlayerDivisionCode.MJ8,
                "MJ6" => PlayerDivisionCode.MJ6,
                "FJ18" => PlayerDivisionCode.FJ18,
                "FJ15" => PlayerDivisionCode.FJ15,
                "FJ12" => PlayerDivisionCode.FJ12,
                "FJ10" => PlayerDivisionCode.FJ10,
                "FJ8" => PlayerDivisionCode.FJ8,
                "FJ6" => PlayerDivisionCode.FJ6,

                // Different Divisions
                "RAG" => PlayerDivisionCode.RAG,
                "MJ1" => PlayerDivisionCode.MJ1,
                _ => throw new System.NotImplementedException()
            };
        }

        public static string GetPlayerDivisionCode(this PlayerDivisionCode divisionCode)
        {
            return divisionCode switch
            {
                // Professional Divisions
                PlayerDivisionCode.MPO => "MPO",
                PlayerDivisionCode.FPO => "FPO",

                // Amateur Divisions
                PlayerDivisionCode.MA1 => "MA1",
                PlayerDivisionCode.MA2 => "MA2",
                PlayerDivisionCode.MA3 => "MA3",
                PlayerDivisionCode.MA4 => "MA4",
                PlayerDivisionCode.FA1 => "FA1",
                PlayerDivisionCode.FA2 => "FA2",
                PlayerDivisionCode.FA3 => "FA3",
                PlayerDivisionCode.FA4 => "FA4",

                // Junior Divisions
                PlayerDivisionCode.MJ18 => "MJ18",
                PlayerDivisionCode.MJ15 => "MJ15",
                PlayerDivisionCode.MJ12 => "MJ12",
                PlayerDivisionCode.MJ10 => "MJ10",
                PlayerDivisionCode.MJ8 => "MJ8",
                PlayerDivisionCode.MJ6 => "MJ6",
                PlayerDivisionCode.FJ18 => "FJ18",
                PlayerDivisionCode.FJ15 => "FJ15",
                PlayerDivisionCode.FJ12 => "FJ12",
                PlayerDivisionCode.FJ10 => "FJ10",
                PlayerDivisionCode.FJ8 => "FJ8",
                PlayerDivisionCode.FJ6 => "FJ6",

                // Different Divisions
                PlayerDivisionCode.RAG => "RAG",
                PlayerDivisionCode.MJ1 => "MJ1",
                _ => throw new System.NotImplementedException(),
            };
        }
    }
}
