using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAction : MonoBehaviour
{
    private float timer;
    public float idle_rot_mag;
    public float mouse_rot_mag;
    private Vector3 initial_rot;
    private Vector3 initial_mouse;
    public Vector3 start_pos;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initial_rot = transform.localEulerAngles;
            initial_mouse = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            initial_rot = transform.localEulerAngles;
            timer = 0f;

        }
        if (Input.GetMouseButton(0))
        {
            Vector3 delta_mouse = initial_mouse - Input.mousePosition;
            Vector3 rot_from_mouse = new Vector3(0f, delta_mouse.x / Screen.width, 0f);
            transform.localEulerAngles = initial_rot + rot_from_mouse * mouse_rot_mag;
        }
        else
        {
            timer += Time.deltaTime;
            transform.localEulerAngles = initial_rot + Vector3.up * timer * idle_rot_mag;
        }
    }
}
