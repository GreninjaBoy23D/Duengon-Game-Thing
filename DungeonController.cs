using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject northDoor, southDoor, eastDoor, westDoor;
    public GameObject northPellet, southPellet, eastPellet, westPellet;

    void Start()
    {
        this.setDoors();
        this.setPellets();
    }

    //all doors are on by default, so turn off the doors that should not be there.
    private void setDoors()
    {
        Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
        if (theCurrentRoom.hasExit("north"))
        {
            this.northDoor.SetActive(false);

        }

        if (theCurrentRoom.hasExit("south"))
        {
            this.southDoor.SetActive(false);
        }

        if (theCurrentRoom.hasExit("east"))
        {
            this.eastDoor.SetActive(false);
        }

        if (theCurrentRoom.hasExit("west"))
        {
            this.westDoor.SetActive(false);
        }
    }

    //all pellets are on by default, so turn off the ones that shouldnt be there
    private void setPellets()
    {
        Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
        if (!theCurrentRoom.hasPellet("north"))
        {
            this.northPellet.SetActive(false);

        }
        if (!theCurrentRoom.hasPellet("south"))
        {
            this.southPellet.SetActive(false);
        }

        if (!theCurrentRoom.hasPellet("east"))
        {
            this.eastPellet.SetActive(false);
        }

        if (!theCurrentRoom.hasPellet("west"))
        {
            this.westPellet.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
