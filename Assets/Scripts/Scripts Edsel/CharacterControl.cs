using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class CharacterControl : MonoBehaviour
{
    public float velocityX = 3f;
    public float velocityY = 10f;
    public float turningTime = 0.2f;
    public bool controllable = true;

    public string horizontalAxis
    {
        get
        {
            if (axis == Vector3.right)
                return "x";
            else if (axis == Vector3.left)
                return "-x";
            else if (axis == Vector3.forward)
                return "z";
            else
                return "-z";
        }
        set
        {
            switch (value)
            {
                default:
                case "x":
                    axis = Vector3.right;
                    minAngle = 90;
                    maxAngle = 270;
                    break;
                case "-x":
                    axis = Vector3.left;
                    minAngle = 270;
                    maxAngle = 450;
                    break;
                case "z":
                    axis = Vector3.forward;
                    minAngle = 0;
                    maxAngle = 180;
                    break;
                case "-z":
                    axis = Vector3.back;
                    minAngle = -180;
                    maxAngle = 0;
                    break;
            }
            turnAround();
        }
    }

    bool isGrounded
    {
        get
        {
            return Mathf.Abs(rigidBody.velocity.y) < 0.00001f;
        }
    }

    Rigidbody rigidBody;
    int direction = 1;
    Vector3 axis = Vector3.right;
    int minAngle = 90;
    int maxAngle = 270;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.interpolation = RigidbodyInterpolation.Interpolate;     //Para que el movimiento sea suave
        Controller.movement += control;
        //horizontalAxis = "-x";
    }

    // Use this for initialization

    private void control(Vector2 move)
    {
        if (!controllable)
            return;
        this.move(move);
        
    }

    private void move(Vector2 move)
    {
        Vector3 velocity = (move.x * velocityX) * axis;

        if (move.y > 0 && isGrounded) //cheap check for ground
        {
            velocity.y = velocityY;
        }
        else
        {
            velocity.y = rigidBody.velocity.y;
        }
        rigidBody.velocity = velocity;

        /*
        rigidBody.AddForce(move * velocityX);
        Debug.Log("k ondap");
        */
        if (move.x != 0 && move.x != direction)
        {
            direction = (int)move.x;
            turnAround();
            //StopAllCoroutines();
            //StartCoroutine(turnA(direction));
        }
    }

    void turnAround()
    {
        if (direction > 0)
        {
            //StopAllCoroutines();
            StartCoroutine(turn_(minAngle, turningTime));
        }
        else
        {
            //StopAllCoroutines();
            StartCoroutine(turn_(maxAngle, turningTime));
        }
    }

    public IEnumerator turn(float angle, float duration)
    {
        //StopAllCoroutines();
        return turn_(angle, duration);
    }

    IEnumerator turn_(float angle, float duration = 1, int direction = 0)
    {
        Vector3 rotation = transform.eulerAngles;
        direction = direction == 0 ? this.direction : direction;
        float timer = 0;
        float angleY = rotation.y;
        angleY -= direction;
        while (timer < 1)
        {
            rotation.y = Mathf.LerpAngle(angleY, angle, timer);
            transform.eulerAngles = rotation;
            timer += Time.deltaTime / duration;
            yield return null;
        }
        rotation.y = angle;
        transform.eulerAngles = rotation;
        /*Vector3 rotation = transform.eulerAngles;
        direction = direction == 0 ? this.direction : direction;
        float minAngle = angle > angleY ? angleY : angle;
        float maxAngle = angle < angleY ? angleY : angle;
        while (!Mathf.Approximately(angle, angleY))
        {
            angleY = Mathf.Clamp(angleY + -direction * Time.deltaTime * speed, minAngle, maxAngle);
            rotation.y = angleY;
            transform.eulerAngles = rotation;
            yield return null;
        }*/
    }

    //Not in use currently, could be useful to move ignoring gravity
    IEnumerator moveTo_(Vector3 destination, float seconds)
    {
        float timer = 0;
        Vector3 position = rigidBody.position;
        while(timer < 1)
        {
            rigidBody.position = Vector3.Lerp(position, destination, timer);
            timer += Time.deltaTime / seconds;
            yield return null;
        }
        rigidBody.position = destination;
    }

    public IEnumerator moveInAxis(Vector3 destination)
    {
        while (!isGrounded)
        {
            yield return null;
        }
        Vector3 difference = Vector3.Scale(destination - rigidBody.position, axis);
        destination = rigidBody.position + difference;
        float velocity = (difference.x > 0 || difference.z > 0) ? 1 : -1;
        float seconds = Mathf.Abs(difference.magnitude / velocityX);
        while (seconds > 0)
        {
            move(Vector3.right * velocity);
            seconds -= Time.deltaTime;
            yield return null;
        }
        //rigidBody.MovePosition(destination);
    }
}
