using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User_Movement : MonoBehaviour
{
    private CharacterController userController;
    private Vector3 userVelocity;
    [SerializeField] float userSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        userController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UserMovement(Vector2 data) {
        Vector3 movementDirection = Vector3.zero;
        movementDirection.x = data.x;
        movementDirection.z = data.y;
        userController.Move(transform.TransformDirection(movementDirection) * userSpeed * Time.deltaTime);
    }
}
