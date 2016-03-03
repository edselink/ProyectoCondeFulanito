using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public static event System.Action ActionKeyPressed;
    public static event System.Action switchCharactersKeyPressed;
    public static event System.Action Attack1KeyPressed;
    public static event System.Action Attack2KeyPressed;
    public static event System.Action PauseGame;
    public static event System.Action ResumeGame;
    public static event System.Action<Vector2> movement;
    public static Vector2 movementVector;
    //public static Vector2

    private KeyCode ActionKey = KeyCode.E;
    private KeyCode SwitchCharactersKey = KeyCode.Q;
    private KeyCode Attack1 = KeyCode.J;
    private KeyCode Attack2 = KeyCode.K;
    private KeyCode PauseKey = KeyCode.Return;

	void Update () {
        movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (movement != null)
            movement(movementVector);
        if (Input.GetKeyDown(ActionKey) && ActionKeyPressed != null)
        {
            ActionKeyPressed();
        }
        if (Input.GetKeyDown(SwitchCharactersKey) && switchCharactersKeyPressed != null)
        {
            switchCharactersKeyPressed();
        }
        if (Input.GetKeyDown(Attack1) && Attack1KeyPressed != null)
        {
            Attack1KeyPressed();
        }
        if (Input.GetKeyDown(Attack2) && Attack1KeyPressed != null)
        {
            Attack2KeyPressed();
        }
        if (Input.GetKeyDown(PauseKey))
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            if (Time.timeScale == 0 && PauseGame != null)
            {
                PauseGame();
            }
            else if (ResumeGame != null)
            {
                ResumeGame();
            }
        }
	}
}
