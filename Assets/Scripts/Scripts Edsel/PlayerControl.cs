using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class PlayerControl : MonoBehaviour
{
    public float horizontalVelocity = 3f;
    public float jumpingVelocity = 0.1f;
    public float maxFlutterTime = 0.2f;
    public float gravityVelocity = 1.5f;
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
            return controller.isGrounded;
        }
    }

    CharacterController controller;
    int direction = 1;
    Vector3 axis = Vector3.right;
    int minAngle = 90;
    int maxAngle = 270;
    private float gravityForce = 0;
    private float flutterTime;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        //rigidBody.interpolation = RigidbodyInterpolation.Interpolate;     //Para que el movimiento sea suave
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
        Vector3 velocity = (move.x * horizontalVelocity) * axis * Time.deltaTime;

        if (isGrounded)
        {  
            gravityForce = 0;
            if(move.y > 0)
            {
                gravityForce = jumpingVelocity;
                flutterTime = 0;
            }
        }
        else
        {
            if(flutterTime <= maxFlutterTime && move.y > 0)
            {
                gravityForce = jumpingVelocity;
                flutterTime += Time.deltaTime;
            }
            else
            {
                gravityForce -= gravityVelocity * Time.deltaTime;
                flutterTime = 1;
            }
        }

        velocity.y = gravityForce;

        controller.Move(velocity);

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
            StartCoroutine(turn(minAngle, turningTime));
        }
        else
        {
            //StopAllCoroutines();
            StartCoroutine(turn(maxAngle, turningTime));
        }
    }

    public IEnumerator turn(float angle, float duration = 1, int direction = 0)
    {
        Vector3 rotation = transform.eulerAngles;
        direction = direction == 0 ? this.direction : direction;
        float timer = 0;
        float angleY = rotation.y;
        angleY -= direction;
        if (controllable) //Not necessary (¡?¡)
        {
            yield return new WaitForSeconds(0.04f);
            if (Controller.movementVector.x != direction)
            {
                duration /= 2;
            }
        }
        while (timer < 1)
        {
            rotation.y = Mathf.LerpAngle(angleY, angle, timer);
            transform.eulerAngles = rotation;
            timer += Time.deltaTime / duration;
            yield return null;
        }
        rotation.y = angle;
        transform.eulerAngles = rotation;
    }

    public IEnumerator moveTo(Vector3 destination, float seconds = -1, bool ignoreY = true)
    {
        while (!isGrounded)
        {
            move(Vector3.zero); //Allow it to fall to ground
            yield return null;
        }
        if (ignoreY)
        {
            destination.y = transform.position.y;
        }
        Vector3 difference = destination - transform.position;
        float angle = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
        seconds = seconds < 0 ? Vector3.Distance(transform.position, destination) / horizontalVelocity : seconds;
        Vector3 motionDelta = difference / seconds;
        float timer = 0;
        StartCoroutine(turn(angle, turningTime));
        
        while (timer <= seconds)
        {
            controller.Move(motionDelta * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
        direction = 0;
    }

    /*
    //Prolly can be optimized to hell and back
    //Legacy, not necessary ATM lol brb
    public IEnumerator moveInAxis(Vector3 destination)
    {
        while (!isGrounded)
        {
            move(Vector3.zero); //Allow it to fall to ground
            yield return null;
        }
        Vector3 difference = Vector3.Scale(destination - transform.position, axis);
        //destination = transform.position + difference;
        int velocity = (difference.x > 0 || difference.z > 0) ? 1 : -1;
        float seconds = Mathf.Abs(difference.magnitude / horizontalVelocity);
        while (seconds > 0)
        {
            move(Vector3.right * velocity);
            seconds -= Time.deltaTime;
            yield return null;
        }
        
    }
    */
}