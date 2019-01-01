
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{

    // Use this for initialization
    public static string id
    {
        get
        {
            return PlayerPrefs.GetString("id");
        }
        set
        {
            PlayerPrefs.SetString("id", value);
        }
    }
    public static int countChange
    {
        get
        {
            return PlayerPrefs.GetInt("countChange");
        }
        set
        {
            PlayerPrefs.SetInt("countChange", value);
        }
    }
    public static int countSettime
    {
        get
        {
            return PlayerPrefs.GetInt("countSettime");
        }
        set
        {
            PlayerPrefs.SetInt("countSettime", value);
        }
    }
}
