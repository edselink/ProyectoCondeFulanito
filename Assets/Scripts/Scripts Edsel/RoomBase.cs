using UnityEngine;
using System.Collections;

public abstract class RoomBase : MonoBehaviour {
    public struct Axis
    {
        public Axis(string axisID, Vector3 axis, int minAngle, int maxAngle)
        {
            this.axisID = axisID;
            this.axis = axis;
            this.minAngle = minAngle;
            this.maxAngle = maxAngle;
        }
        public string axisID;
        public Vector3 axis;
        public int minAngle;
        public int maxAngle;
    }

    protected static Axis[] axesInfo = {new Axis("x", Vector3.right, 90, 270), new Axis("-x", Vector3.left, 270, 450),
                                new Axis("z", Vector3.forward, 0, 180), new Axis("-z", Vector3.back, -180, 0)};
	
}
