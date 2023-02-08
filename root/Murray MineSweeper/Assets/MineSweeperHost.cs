//////////////////////////////////////////////////////
// Assignment/Lab/Project: mineSweeper
//Name: Wyatt Murray
//Section: 2023SP.SGD.213.2172
//Instructor: Brian Sowers
// Date: 2/7/23
//////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class MineSweeperHost : MonoBehaviour
{
    #region variables
    //difficulty Control
    [SerializeField] private int sizeOfGridTable;

    //Prefabs
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject emptyTile;

    // random generation


    //grid and array components
    [SerializeField] private GameObject[] gameTiles;


    //Panels n UI
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    #endregion

    #region Start in Update
    void Start()
    {
        //FastCopy();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GenerateGrid();
        }
    }
    #endregion

    //did not complete the top or bottom rows, or display a win screen.

    #region useful Methods
    void GenerateGrid()
    {
        //initialises the tile array to the size of the grid size
        int totalArraySize = (sizeOfGridTable * sizeOfGridTable) - 1;
        //fills the array with the appropriate amount of bombs placed in a random location
        FillArray(bomb, emptyTile);
    }

    void FillArray(GameObject bomb, GameObject emptyTile)
    {
        //fill all the tiles with empty tile first
        for (int i = 0; i < gameTiles.Length; i++)
        {
            gameTiles[i] = emptyTile;
        }


        int bombsPlaced = 0;
        //keep track of how many are placed
        while (bombsPlaced < 5)
        {
            int randomIndex = UnityEngine.Random.Range(0, gameTiles.Length);
            //confimr a bomb already isnt there, and if its not, place one while there are bombs
            //left to place
            if (gameTiles[randomIndex] == emptyTile)
            {
                gameTiles[randomIndex] = bomb;
                bombsPlaced++;
                //keep to know where the bombs are
                Debug.Log(randomIndex);
            }
        }
    }



    //note, needs conditionals to confirm that if the top or bottom rows are selected
    //that they dont run the check negatives for top or check positives for bottom
    //as they will error and fail to finish.

    void DetectSurroundingTiles(int ButtonElementNumber)
    {
        //get the element number of the object
        if(gameTiles[ButtonElementNumber] == bomb)
        {
            losePanel.SetActive(true);
        }

        int bombsNearby = 0;

        //numbers to check for. -1, +1, itself, -5, +5, -4, +4, -6, +6
        //check for corners, and then return the amount of bombs near it
        if (ButtonElementNumber == 0 || ButtonElementNumber == 5 || ButtonElementNumber == 10 || ButtonElementNumber == 15 || ButtonElementNumber == 20)
        {
            //PARTIAL CHECK FOR LEFT MOST TILES

            //check for +1
            if (ButtonElementNumber < gameTiles.Length - 1 && gameTiles[ButtonElementNumber + 1] == bomb)
            {
                bombsNearby++;
            }
            //check for +5
            if (ButtonElementNumber < gameTiles.Length - 1 && gameTiles[ButtonElementNumber + 5] == bomb)
            {
                bombsNearby++;
            }
            //check for +6
            if (ButtonElementNumber < gameTiles.Length - 1 && gameTiles[ButtonElementNumber + 6] == bomb)
            {
                bombsNearby++;
            }
            //check for -4
            if (ButtonElementNumber > 0 && gameTiles[ButtonElementNumber - 4] == bomb)
            {
                bombsNearby++;
            }
            //check for -5
            if (ButtonElementNumber > 0 && gameTiles[ButtonElementNumber - 5] == bomb)
            {
                bombsNearby++;
            }
            //check for -6
        }
        else if (ButtonElementNumber == 4 || ButtonElementNumber == 9 || ButtonElementNumber == 14 || ButtonElementNumber == 19 || ButtonElementNumber == 24)
        {
            //PARTIAL CHECK FOR RIGHT MOST TILES

            //check for +4
            if (ButtonElementNumber < gameTiles.Length - 1 && gameTiles[ButtonElementNumber + 4] == bomb)
            {
                bombsNearby++;
            }
            //check for +5
            if (ButtonElementNumber < gameTiles.Length - 1 && gameTiles[ButtonElementNumber + 5] == bomb)
            {
                bombsNearby++;
            }
            //check for -1
            if (ButtonElementNumber > 0 && gameTiles[ButtonElementNumber - 1] == bomb)
            {
                bombsNearby++;
            }
            //check for -4
            if (ButtonElementNumber > 0 && gameTiles[ButtonElementNumber - 4] == bomb)
            {
                bombsNearby++;
            }
            //check for -5
            if (ButtonElementNumber > 0 && gameTiles[ButtonElementNumber - 5] == bomb)
            {
                bombsNearby++;
            }
        }
        else
        {
            //FULL CHECK FOR ALL POSSIBLE COMBINATIONS

            //check for +1
            if (ButtonElementNumber < gameTiles.Length - 1 && gameTiles[ButtonElementNumber + 1] == bomb)
            {
                bombsNearby++;
            }
            //check for +4
            if (ButtonElementNumber < gameTiles.Length - 1 && gameTiles[ButtonElementNumber + 4] == bomb)
            {
                bombsNearby++;
            }
            //check for +5
            if (ButtonElementNumber < gameTiles.Length - 1 && gameTiles[ButtonElementNumber + 5] == bomb)
            {
                bombsNearby++;
            }
            //check for +6
            if (ButtonElementNumber < gameTiles.Length - 1 && gameTiles[ButtonElementNumber + 6] == bomb)
            {
                bombsNearby++;
            }
            //check for -1
            if (ButtonElementNumber > 0 && gameTiles[ButtonElementNumber - 1] == bomb)
            {
                bombsNearby++;
            }
            //check for -4
            if (ButtonElementNumber > 0 && gameTiles[ButtonElementNumber - 4] == bomb)
            {
                bombsNearby++;
            }
            //check for -5
            if (ButtonElementNumber > 0 && gameTiles[ButtonElementNumber - 5] == bomb)
            {
                bombsNearby++;
            }
            //check for -6
            if (ButtonElementNumber > 0 && gameTiles[ButtonElementNumber - 6] == bomb)
            {
                bombsNearby++;
            }
        } // all other locations


        GameObject textToReturnTo = GameObject.Find(ButtonElementNumber.ToString()).transform.GetChild(1).gameObject;
        Debug.Log(textToReturnTo.name);
        Debug.Log(bombsNearby);
        textToReturnTo.GetComponent<TextMeshProUGUI>().text = bombsNearby.ToString();
        //get the text underneith it, and set it = to the bombsNearby
        
    }

    #endregion

    #region very bad no good code but not enough time for a more thought out solution

    //i made this code to write out the onclicks faster
    void FastCopy()
    {
        string[] ShortTerm = new string[gameTiles.Length];
        for (int i = 0; i < gameTiles.Length; i++)
        {
            ShortTerm[i] = $"public void OnClickButton{i}()";
        }
        string result = string.Join(" ", ShortTerm);
        Debug.Log(result);
    }


    //i condone the use of this code style, as there are much better methods
    //as i scapped the old code so late, i must take a less refined approach
    //not enough time to find a better method :/
    public void OnClickButton0()
    {
        DetectSurroundingTiles(0);
        GameObject button = GameObject.Find("0").transform.GetChild(2).gameObject;
        Debug.Log(button);
        button.SetActive(false);
    }
    public void OnClickButton1()
    {
        DetectSurroundingTiles(1);
        GameObject button = GameObject.Find("1").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton2()
    {
        DetectSurroundingTiles(2);
        GameObject button = GameObject.Find("2").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton3()
    {
        DetectSurroundingTiles(3);
        GameObject button = GameObject.Find("3").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton4()
    {
        DetectSurroundingTiles(4);
        GameObject button = GameObject.Find("4").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton5()
    {
        DetectSurroundingTiles(5);
        GameObject button = GameObject.Find("5").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton6()
    {
        DetectSurroundingTiles(6);
        GameObject button = GameObject.Find("6").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton7()
    {
        DetectSurroundingTiles(7);
        GameObject button = GameObject.Find("7").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton8()
    {
        DetectSurroundingTiles(8);
        GameObject button = GameObject.Find("8").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton9()
    {
        DetectSurroundingTiles(9);
        GameObject button = GameObject.Find("9").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton10()
    {
        DetectSurroundingTiles(10);
        GameObject button = GameObject.Find("10").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton11()
    {
        DetectSurroundingTiles(11);
        GameObject button = GameObject.Find("11").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton12()
    {
        DetectSurroundingTiles(12);
        GameObject button = GameObject.Find("12").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton13()
    {
        DetectSurroundingTiles(13);
        GameObject button = GameObject.Find("13").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton14()
    {
        DetectSurroundingTiles(14);
        GameObject button = GameObject.Find("14").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton15()
    {
        DetectSurroundingTiles(15);
        GameObject button = GameObject.Find("15").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton16()
    {
        DetectSurroundingTiles(16);
        GameObject button = GameObject.Find("16").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton17()
    {
        DetectSurroundingTiles(17);
        GameObject button = GameObject.Find("17").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton18()
    {
        DetectSurroundingTiles(18);
        GameObject button = GameObject.Find("18").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton19()
    {
        DetectSurroundingTiles(19);
        GameObject button = GameObject.Find("19").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton20()
    {
        DetectSurroundingTiles(20);
        GameObject button = GameObject.Find("20").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton21()
    {
        DetectSurroundingTiles(21);
        GameObject button = GameObject.Find("21").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton22()
    {
        DetectSurroundingTiles(22);
        GameObject button = GameObject.Find("22").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton23()
    {
        DetectSurroundingTiles(23);
        GameObject button = GameObject.Find("23").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }
    public void OnClickButton24()
    {
        DetectSurroundingTiles(24);
        GameObject button = GameObject.Find("24").transform.GetChild(2).gameObject;
        button.SetActive(false);
    }

    #endregion

    #region buttons
    public void Quitbutton()
    {
        Application.Quit();
    }

    public void Playbutton()
    {
        GenerateGrid();
        //hide the main menu panel
        mainMenuPanel.SetActive(false);
    }
    #endregion

}
