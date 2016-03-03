using UnityEngine;
using System.Collections;

public class Room : RoomBase {

    public enum axis { x, minusX, z, minusZ };
    public axis localAxis;

    public Axis axisInfo;
    private RoomTransition[] transitions;

    void Awake()
    {
        axisInfo = axesInfo[(int)localAxis];
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
