using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour {

    private Player_Input_Actions playerInputActions;
    [SerializeField] Mouse_Look mouseLooking;
    private User_Movement move;
    Vector2 mouseValues;

    private void Awake() {
        playerInputActions = new Player_Input_Actions();
        move = GetComponent<User_Movement>();
    }

    private void OnEnable() {
        playerInputActions.Enable();
    }

    private void OnDisable() {
        playerInputActions.Disable();

        playerInputActions.User.jump.performed -= DoJump;
    }

    private void DoJump(InputAction.CallbackContext obj) {
        Debug.Log("Jumped");
    }

    private void Start() {
        playerInputActions.User.jump.performed += DoJump;
        playerInputActions.User.mouseX.performed += ctx => mouseValues.x = ctx.ReadValue<float>();
        playerInputActions.User.mouseY.performed += ctx => mouseValues.y = ctx.ReadValue<float>();

    }

    private void Update() {
        mouseLooking.GetInput(mouseValues);
        move.UserMovement(playerInputActions.User.move.ReadValue<Vector2>());
        
        // if(playerInputActions.User.jump.triggered) {
        //     Debug.Log("Jumped");
        // }
    }

}
