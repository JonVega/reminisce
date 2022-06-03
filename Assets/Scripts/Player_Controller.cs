using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour {

    private InputActionAsset inputAsset;
    private InputActionMap player;
    
    private Mouse_Look look;
    private User_Movement move;

    private void Awake() {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        player = inputAsset.FindActionMap("User");
        
        move = GetComponent<User_Movement>();
        look = GetComponent<Mouse_Look>();
        
        player.FindAction("jump").performed += ctx => move.Jump();
        player.FindAction("sprint").performed += ctx => move.Sprint();

    }

    private void OnEnable() {
        player.Enable();
    }

    private void OnDisable() {
        player.Disable();
    }

    private void Start() {

    }

    private void Update() {
        
    }

    void FixedUpdate() {
        move.UserMovement(player.FindAction("move").ReadValue<Vector2>());
    }

    void LateUpdate() {
        look.ProcessLook(player.FindAction("look").ReadValue<Vector2>());
    }
}
