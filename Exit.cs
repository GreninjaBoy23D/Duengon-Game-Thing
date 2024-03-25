using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit
{
    private string direction;
    private Room destinationRoom;

    public Exit(string direction, Room destinationRoom)
    {
        this.direction = direction;
        this.destinationRoom = destinationRoom;
    }

    public string getDirection()
    {
        return this.direction;
    }
}
