using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Look : MonoBehaviour {

    public Camera cam;
    private float x_rotation = 0.0f;

    private float x_sensitivity = 90.0f;
    private float y_sensitivity = 90.0f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked; //hides the cursor in the game
    }

    public void ProcessLook(Vector2 data) {
        float x_mouse = data.x;
        float y_mouse = data.y;

        x_rotation -= (y_mouse * Time.deltaTime) * y_sensitivity;
        x_rotation = Mathf.Clamp(x_rotation, -80.0f, 80.0f);
        cam.transform.localRotation = Quaternion.Euler(x_rotation, 0, 0);
        transform.Rotate(Vector3.up * (x_mouse * Time.deltaTime) * x_sensitivity);
    }
}
