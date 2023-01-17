using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour
{

    public Text highscore;

    void Start()
    {
        highscore.text = PlayerPrefs.GetString("Highscore", "0");
    }

}
