using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User_Movement : MonoBehaviour
{
    private CharacterController userController;
    private Vector3 userVelocity;
    private bool isGrounded;
    private bool isSprinting;
    private float userSpeed = 8.0f;
    private float gravity = -16.8f; //was 9.8, but too floaty
    private float jump_height = 2.4f;

    // Start is called before the first frame update
    void Start()
    {
        userController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = userController.isGrounded;
    }

    public void UserMovement(Vector2 data) {
        Vector3 movementDirection = Vector3.zero;
        movementDirection.x = data.x;
        movementDirection.z = data.y;
        userController.Move(transform.TransformDirection(movementDirection) * userSpeed * Time.deltaTime);
        userVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && userVelocity.y < 0) {
            userVelocity.y = -2.0f;
        }
        userController.Move(userVelocity * Time.deltaTime);
    }

    public void Jump() {
        if(isGrounded) {
            userVelocity.y = Mathf.Sqrt(jump_height * -3.0f * gravity);
        }
    }

    public void Sprint() {
        isSprinting = !isSprinting;
        if(isSprinting) {
            userSpeed = 11.0f;
        }

        else {
            userSpeed = 8.0f;
        }
    }
}
