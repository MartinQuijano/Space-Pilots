using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject sectionGeneratorGO;
    public SectionGenerator sectionGeneratorScript;

    public float distance;

    public Text txtDistance;
    public Text txtFinalScore;

    public Text txtHighscore;

    // Start is called before the first frame update
    void Start()
    {
        sectionGeneratorGO = GameObject.Find("SectionGenerator");
        sectionGeneratorScript = sectionGeneratorGO.GetComponent<SectionGenerator>();

        txtDistance.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if(sectionGeneratorScript.gameRunning && !sectionGeneratorScript.gameEnded)
            CalculateDistance();
    }

    void CalculateDistance()
    {
        distance += Time.deltaTime * sectionGeneratorScript.speed;

        txtDistance.text = ((int)distance).ToString();
    }

    public void SetFinalScore()
    {
        txtFinalScore.text = txtDistance.text;
    }

    public void CheckHighscore()
    {
        int currentHighscore = int.Parse(PlayerPrefs.GetString("Highscore", "0"));
        if(currentHighscore < int.Parse(txtFinalScore.text))
        {
            PlayerPrefs.SetString("Highscore", txtFinalScore.text);
        }
        txtHighscore.text = PlayerPrefs.GetString("Highscore", "0");
    }

}
