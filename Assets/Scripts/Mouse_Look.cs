using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Look : MonoBehaviour {
    [SerializeField] float mouseX_sensitivity = 100.0f;
    [SerializeField] float mouseY_sensitivity = 0.5f;
    float x_mouse, y_mouse;

    [SerializeField] Transform playerCamera;
    [SerializeField] float x_clamp = 85.0f;
    float x_rotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //hides the cursor in the game
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, x_mouse * Time.deltaTime);
        x_rotation -= y_mouse;
        x_rotation = Mathf.Clamp(x_rotation, -x_clamp, x_clamp);
        Vector3 rotationGoal = transform.eulerAngles;
        rotationGoal.x = x_rotation;
        playerCamera.eulerAngles = rotationGoal;
    }

    public void GetInput(Vector2 mouseValues) {
        x_mouse = mouseValues.x * mouseX_sensitivity;
        y_mouse = mouseValues.y * mouseY_sensitivity;
    }
}
