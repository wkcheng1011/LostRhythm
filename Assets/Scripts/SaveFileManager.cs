using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class SaveFileManager
{
    public static void Reset()
    {
        PlayerPrefs.DeleteAll();
    }

    public static bool IsInBoundary(int a, int lower)
    {
        return a >= lower;
    }

    public static bool IsInBoundary(int a, int lower, int upper)
    {
        return a >= lower && a <= upper;
    }

    public static bool Check(bool load)
    {
        int CharacterID = PlayerPrefs.GetInt("CharacterID", -1);
        int Exp = PlayerPrefs.GetInt("Exp", -1);
        int MP = PlayerPrefs.GetInt("MP", -1);
        int HP = PlayerPrefs.GetInt("HP", -1);
        int MapID = PlayerPrefs.GetInt("MapID", -1);

        if (
            IsInBoundary(CharacterID, 0, 3) &&
            IsInBoundary(Exp, 0) &&
            IsInBoundary(MP, 0) &&
            IsInBoundary(HP, 0) &&
            IsInBoundary(MapID, 0, 3)
        )
        {
            if (load)
            {
                Player.CharacterID = CharacterID;
                Player.Exp = Exp;
                Player.MP = MP;
                Player.HP = HP;
                Player.MapID = MapID;
            }

            return true;
        }
        if (load) PlayerPrefs.DeleteAll();
        return false;
    }

    public static bool Save()
    {
        PlayerPrefs.SetInt("CharacterID", Player.CharacterID);
        PlayerPrefs.SetInt("Exp", Player.Exp);
        PlayerPrefs.SetInt("MP", Player.MP);
        PlayerPrefs.SetInt("HP", Player.HP);
        PlayerPrefs.SetInt("MapID", Player.MapID);

        return true;
    }
}
