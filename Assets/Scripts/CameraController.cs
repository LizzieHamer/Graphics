using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 110f;
    public float scrollSpeed = 20f;
    public float sensitivity = 2f;
    public float yRotationLimit = 88f;
    Vector2 rotation = Vector2.zero;
    const string AxisX = "Mouse X";
    const string AxisY = "Mouse Y";
    // Update is called once per frame
    void Update()
    {
        Vector3 CamPosition = transform.position;
        if (Input.GetKey("s"))
        {
            CamPosition.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("w"))
        {
            CamPosition.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            CamPosition.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            CamPosition.z -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        CamPosition.y -= scroll * scrollSpeed *100f* Time.deltaTime;
        
        rotation.x += Input.GetAxis(AxisX) * sensitivity;
        rotation.y += Input.GetAxis(AxisY) * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);
        transform.localRotation = xQuat * yQuat;
        
        transform.position = CamPosition;
    }
}
