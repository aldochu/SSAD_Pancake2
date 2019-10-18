using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariable : MonoBehaviour
{
    public static string UserID;
    public static User UserProfile = new User();

    // Total score for easy medium hard

    public static int easy = 10;
    public static int medium = 15;
    public static int hard = 20;


    // Static Variable if Game can be started
    public static bool game1 = true;
    public static bool game2;
    public static bool game3;
    public static bool game4;

    public static int characterSelect;
    public static string world;
    public static string chapter;
    public static string difficulty;
    public static int game;

}