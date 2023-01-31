using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class MineSweeperHost : MonoBehaviour
{
    #region variables
    //difficulty Control
    private int sizeOfGridTable;
    private int DifficultyOfGrid; //must be 1-4, change the slider to relfect the opposite
    [SerializeField] TMP_Dropdown dropdown;

    //Prefabs
    [SerializeField] Tile bomb;
    [SerializeField] Tile emptyTile;

    // random generation


    //grid and array components
    Tile[] gameTiles;


    //fill me in later

    #endregion

    #region Start in Update
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    #endregion

    #region useful Methods
    void GenerateGrid()
    {
        //initialises the tile array to the size of the grid size
        int totalArraySize = (sizeOfGridTable * sizeOfGridTable) - 1;
        //makes the array that size so we get what we need and no more
        gameTiles = new Tile[totalArraySize];

        //set some empty values to keep track of later
        int xValue = 0;
        int yValue = 0;

        
        for (int i = 0; i < totalArraySize; i++)
        {

            //spawn tiles there, and place those tiles into the array at their position
            var createdTile = Instantiate(BombDifficultyRandomiser(), new Vector3(xValue, yValue), quaternion.identity);
            //give th tile a name so we can check it later
            createdTile.name = $"Tile {xValue}, {yValue}, Pos ";
            gameTiles[i] = createdTile;
            //keep track of the X & y position
            if (i % sizeOfGridTable == 0)
            {
                xValue++;
                yValue = 0;
            }
            else
            {
                yValue++;
            }
        }
        //run the following to confirm thaty at least 1 bomb is always present in the game
        int bombsInScene = 0;
        for (int i = 0; i < totalArraySize; i++)
        {
            if (gameTiles[i] == bomb)
            {
                bombsInScene++;
            }
        }
        if (bombsInScene == 0)
        {
            GenerateGrid();
        }
    }

    #endregion

    #region Useless Methods

    int DropdownValueChanged(TMP_Dropdown change)
    {
        int selectedOption = change.value;
        Debug.Log("Selected Option: " + selectedOption);
        switch(selectedOption)
        {
            case 0:
                return 4;
            case 1:
                return 3;
            case 2:
                return 2;
            default:
                return 4;
        }   
    }

    Tile BombDifficultyRandomiser()
    {
        int chooseOne = UnityEngine.Random.Range(0, DropdownValueChanged(dropdown));

        if (chooseOne == 0)
        {
            return bomb;
        }
        else
        {
            return emptyTile;
        }
    }

    #endregion

    #region buttons
    void StartButton()
    {

    }
    void Quitbutton()
    {

    }

    void Playbutton()
    {
        GenerateGrid();
    }
    #endregion

}
