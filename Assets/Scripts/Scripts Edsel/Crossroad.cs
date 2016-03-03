using UnityEngine;
using System.Collections;

public class Crossroad : RoomTransition {

    public RoomTransition up;
    public RoomTransition down;
    public RoomTransition right;
    public RoomTransition left;

    // Use this for initialization
    void Start () {
	
	}

    protected override void transition()
    {
        if (Controller.movementVector.y > 0 && up != null)
        {
            routine(playerControl.moveTo(transform.position), changeAxis(up.localAxis.axisID), playerControl.moveTo(up.transform.position));
        }
        else if (Controller.movementVector.y < 0 && down != null)
        {
            routine(playerControl.moveTo(transform.position), changeAxis(down.localAxis.axisID), playerControl.moveTo(down.transform.position));
        }
        else if (Controller.movementVector.x > 0 && right != null)
        {
            routine(playerControl.moveTo(transform.position), changeAxis(right.localAxis.axisID), playerControl.moveTo(right.transform.position));
        }
        else if (Controller.movementVector.x < 0 && left != null)
        {
            routine(playerControl.moveTo(transform.position), changeAxis(left.localAxis.axisID), playerControl.moveTo(left.transform.position));
        }
    }
}
