using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;
using System;

public class MineSweeperHost : MonoBehaviour
{
    #region variables
    //difficulty Control
    [SerializeField] private int sizeOfGridTable;

    //Prefabs
    [SerializeField] Tile bomb;
    [SerializeField] Tile emptyTile;

    // random generation


    //grid and array components
    Tile[] gameTiles;


    //Panels n UI
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject gamePanel;

    #endregion

    #region Start in Update
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GenerateGrid();
        }
    }
    #endregion

    #region useful Methods
    void GenerateGrid()
    {
        //initialises the tile array to the size of the grid size
        int totalArraySize = (sizeOfGridTable * sizeOfGridTable) - 1;
        //makes the array that size so we get what we need and no more
        Debug.Log(totalArraySize);
        gameTiles = new Tile[totalArraySize];
        Debug.Log(totalArraySize);
        //fills the array with the appropriate amount of bombs placed in a random location
        FillArray(bomb, emptyTile);
    }

    void PickTile()
    {

    }

    #endregion

    #region Useless Methods

    public void FillArray(Tile bomb, Tile emptyTile)
    {
        for (int i = 0; i < gameTiles.Length; i++)
        {
            gameTiles[i] = emptyTile;
        }

        int bombsPlaced = 0;
        while (bombsPlaced < 5)
        {
            int randomIndex = UnityEngine.Random.Range(0, gameTiles.Length);
            if (gameTiles[randomIndex] == emptyTile)
            {
                gameTiles[randomIndex] = bomb;
                bombsPlaced++;
            }
        }
    }

    void DetectSurroundingTiles()
    {

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
