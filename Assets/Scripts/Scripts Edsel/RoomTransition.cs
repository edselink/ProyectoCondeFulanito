using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public abstract class RoomTransition : RoomBase {

    public static PlayerControl playerControl;

    public Axis localAxis;

	// Use this for initialization
	void Awake () {
        if (playerControl == null)
            playerControl = FindObjectOfType<PlayerControl>();
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.isTrigger = true;
        //Find room transition is on
        Transform parent = transform.parent;
        if (parent)
        {
            Room room = parent.GetComponent<Room>();
            if (room)
            {
                localAxis = room.axisInfo;
            }
            else
            {
                Debug.LogError("Parent room has no Room script assigned", parent);
            }
        }
        else
        {
            Debug.LogError("Room transitions shouldn't be parentless", this);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!playerControl.controllable)
                return;
            transition();
        }
    }

    abstract protected void transition();

    virtual protected void leaveRoom()
    {
        //
    }

    virtual protected void enterRoom()
    {
        //
    }

    protected void routine(params IEnumerator[] routines)
    {
        StartCoroutine(routine_(routines));
    }

    private IEnumerator routine_(IEnumerator[] routines)
    {
        playerControl.controllable = false;
        for(int i = 0; i<routines.Length; i++)
        {
            yield return StartCoroutine(routines[i]);
        }
        playerControl.controllable = true;
    }

    protected IEnumerator changeAxis(string axisID)
    {
        playerControl.horizontalAxis = axisID;
        yield return null;
    }
}
