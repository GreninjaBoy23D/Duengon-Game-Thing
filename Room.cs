using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    private string name;

    private Exit[] theExits = new Exit[4];
    private int howManyExits = 0;
    private Player currentPlayer;
    private Pellet northPellet = null;
    private Pellet southPellet = null;
    private Pellet eastPellet = null;
    private Pellet westPellet = null;


    public Room(string name)
    {
        this.name = name;
        this.currentPlayer = null;
    }

    public void addPlayer(Player thePlayer)
    {
        this.currentPlayer = thePlayer;
        this.currentPlayer.setCurrentRoom(this); //this updates the player to their new current room
    }

    public void addPellet(Pellet p, string direction)
    {
        if(direction.Equals("north"))
        {
            this.northPellet = p;
        }
        else if (direction.Equals("south"))
        {
            this.southPellet = p;
        }
        else if (direction.Equals("east"))
        {
            this.eastPellet = p;
        }
        else if (direction.Equals("west"))
        {
            this.westPellet = p;
        }
        else
        {
            Debug.Log("Not a valid pellet direction to add!!!!!!");
        }
    }

    public void removePellet(string direction)
    {
        if (direction.Equals("north"))
        {
            this.northPellet = null;
        }
        else if (direction.Equals("south"))
        {
            this.southPellet = null;
        }
        else if (direction.Equals("east"))
        {
            this.eastPellet = null;
        }
        else if (direction.Equals("west"))
        {
            this.westPellet = null;
        }
        else
        {
            Debug.Log("Not a valid pellet direction to remove!!!!!!");
        }
    }

    public bool hasPellet(string direction)
    {
        if (direction.Equals("north"))
        {
            return this.northPellet != null;
        }
        else if (direction.Equals("south"))
        {
            if (this.southPellet != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (direction.Equals("east"))
        {
            return this.eastPellet != null;
        }
        else if (direction.Equals("west"))
        {
            return this.westPellet != null;
        }
        else
        {
            Debug.Log("Not a valid pellet direction to check!!!!!!");
            return false;
        }
        
    }
    //remove the current player from this room

    private Exit getExitGivenDirection(string direction)
    {
        for (int i = 0; i < this.howManyExits; i++)
        {
            if (this.theExits[i].getDirection().Equals(direction))
            {
                return this.theExits[i]; //returns the exit in the given direction
            }
        }
        return null; //never found the exit
    }

    public bool hasExit(string direction)
    {
        for(int i = 0; i < this.howManyExits; i++)
        {
            if(this.theExits[i].getDirection().Equals(direction))
            {
                return true;
            }
        }
        return false;
    }

    public void addExit(string direction, Room destinationRoom)
    {
        if(this.howManyExits < this.theExits.Length)
        {
            Exit e = new Exit(direction, destinationRoom);
            this.theExits[this.howManyExits] = e;
            this.howManyExits++;

            if(direction.Equals("north"))
            {
                this.northPellet = new ArmorPellet();
            }
            else if (direction.Equals("south"))
            {
                this.southPellet = new ArmorPellet();
            }
            else if (direction.Equals("east"))
            {
                this.eastPellet = new ArmorPellet();
            }
            else if (direction.Equals("west"))
            {
                this.westPellet = new ArmorPellet();
            }
        }
    }
}
