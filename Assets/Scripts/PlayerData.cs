public static class PlayerData
{
    public static int CharacterID { get; set; }

    public static int Exp { get; set; }

    public static float MP { get; set; }

    public static float HP { get; set; }

    public static int MapID { get; set; }

    public static int[] noteHit = new int[3] { 0, 0, 0 };

    public static int[] noteTotal = new int[3] { 0, 0, 0 };

    public static bool isPass = false;
}
    