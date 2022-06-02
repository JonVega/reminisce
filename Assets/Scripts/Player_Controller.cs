using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour {

    private Player_Input_Actions playerInputActions;
    private Mouse_Look look;
    private User_Movement move;

    private void Awake() {
        playerInputActions = new Player_Input_Actions();
        
        move = GetComponent<User_Movement>();
        look = GetComponent<Mouse_Look>();
        
        playerInputActions.User.jump.performed += ctx => move.Jump();

    }

    private void OnEnable() {
        playerInputActions.Enable();
    }

    private void OnDisable() {
        playerInputActions.Disable();
    }

    private void Start() {

    }

    private void Update() {
        
        // if(playerInputActions.User.jump.triggered) {
        //     Debug.Log("Jumped");
        // }
    }

    void FixedUpdate() {
        move.UserMovement(playerInputActions.User.move.ReadValue<Vector2>());
    }

    private void LateUpdate() {
        look.ProcessLook(playerInputActions.User.look.ReadValue<Vector2>());
    }
}
