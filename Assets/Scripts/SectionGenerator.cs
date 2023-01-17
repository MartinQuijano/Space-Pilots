using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SectionGenerator : MonoBehaviour
{
    public GameObject sectionContainerGO;
    public GameObject[] sectionContainerArray;

    public float speed;
    public bool gameRunning;
    public bool gameEnded;

    private int sectionsCounter = 0;
    private int numberSectionsSelector;

    public GameObject previousSection;
    public GameObject newSection;

    public float sectionSize;

    public Vector3 screenLimitSize;
    public bool outOfScreen;

    public GameObject mCamGo;
    public Camera mCamComp;

    public GameObject spaceshipGO;
    public GameObject bgFinalGO;

    public ScoreManager scoreManager;

    public int currentZoneLevel;
    public float pointsToChangeZone;

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        currentZoneLevel = 0;
        pointsToChangeZone = 0;
        sectionContainerGO = GameObject.Find("SectionContainer");
        mCamGo = GameObject.Find("Main Camera");
        mCamComp = mCamGo.GetComponent<Camera>();

        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        bgFinalGO = GameObject.Find("GameOverPanel");
        bgFinalGO.SetActive(false);

        spaceshipGO = GameObject.FindObjectOfType<Spaceship>().gameObject;

        GeneratorSpeed();
        MeasureScreen();
        FindSections();
    }

    public void GameOverStates()
    {
        scoreManager.SetFinalScore();
        scoreManager.CheckHighscore();
        bgFinalGO.SetActive(true);
    }

    void GeneratorSpeed()
    {
        speed = 8;
    }

    void FindSections()
    {
      //  sectionContainerArray = GameObject.FindGameObjectsWithTag("Section");
        for(int i = 0; i < sectionContainerArray.Length; i++)
        {
        //    sectionContainerArray[i].gameObject.transform.parent = sectionContainerGO.transform;
            sectionContainerArray[i].gameObject.SetActive(false);
         //   sectionContainerArray[i].gameObject.name = "SectionOFF_" + i;
        }
        BuildSection();
    }

    void BuildSection()
    {
        sectionsCounter++;
        numberSectionsSelector = Random.Range(0, 5);
        GameObject Section = Instantiate(sectionContainerArray[numberSectionsSelector+(currentZoneLevel*5)]);
        Section.SetActive(true);
        Section.name = "Section" + sectionsCounter;
        Section.transform.parent = gameObject.transform;
        SectionPositioning();
    }

    void SectionPositioning()
    {
        previousSection = GameObject.Find("Section"+(sectionsCounter-1));
        newSection = GameObject.Find("Section"+sectionsCounter);
        MeasureSection();
        newSection.transform.position = new Vector3(previousSection.transform.position.x + sectionSize, previousSection.transform.position.y, 0);
        outOfScreen = false;
    }

    void MeasureSection()
    {
        for(int i = 0; i < previousSection.transform.childCount; i++)
        {
            if (previousSection.transform.GetChild(i).gameObject.GetComponent<Piece>() != null)
            {
                float pieceSize = previousSection.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
                sectionSize = sectionSize + pieceSize;
            }
        }
    }

    void MeasureScreen()
    {
        screenLimitSize = new Vector3(mCamComp.ScreenToWorldPoint(new Vector3(0,0,0)).x - 0.5f,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunning && !gameEnded)
        {
            pointsToChangeZone += Time.deltaTime * speed;
            if(pointsToChangeZone >= 250)
            {
                if(currentZoneLevel == 5)
                {
                    currentZoneLevel = 0;
                    pointsToChangeZone = 0;
                    speed += 0.5f;
                }
                else {
                    pointsToChangeZone = 0;
                    currentZoneLevel++;
                }
                
            }

            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (previousSection.transform.position.x + sectionSize < screenLimitSize.x && !outOfScreen)
            {
                outOfScreen = true;
                DestroySection();
            }
        }
    }

    void DestroySection()
    {
        Destroy(previousSection);
        sectionSize = 0;
        previousSection = null;
        BuildSection();
    }
}
