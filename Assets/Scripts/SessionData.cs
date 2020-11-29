using UnityEngine;

public static class SessionData
{
    public static bool SaveFileExist
    {
        get
        {
            return SaveFileManager.Check(false);
        }
    }
}