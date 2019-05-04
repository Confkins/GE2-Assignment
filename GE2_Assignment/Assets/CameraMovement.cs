using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    //public Camera camera3;
    //public Camera camera4;
    //public Camera camera5;

    public GameObject cameraTarget1;
    public GameObject cameraTarget2;

    public float cameraSpeed1 = 0.25f;
    public float cameraSpeed2 = 0.10f;

    // Start is called before the first frame update
    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
        StartCoroutine("CameraChanges");
    }

    // Update is called once per frame
    void Update()
    {
        if(camera1.enabled)
        {
            camera1.transform.position = Vector3.Slerp(camera1.transform.position, cameraTarget1.transform.position, cameraSpeed1 * Time.deltaTime);
            camera1.transform.rotation = Quaternion.Lerp(camera1.transform.rotation, cameraTarget1.transform.rotation, cameraSpeed1 * Time.deltaTime);
        }
        if (camera2.enabled)
        {
            camera2.transform.position = Vector3.Slerp(camera2.transform.position, cameraTarget2.transform.position, cameraSpeed2 * Time.deltaTime);
            camera2.transform.rotation = Quaternion.Lerp(camera2.transform.rotation, cameraTarget2.transform.rotation, cameraSpeed2 * Time.deltaTime);
        }
        /*
        if (camera3.enabled)
        {
            
        }
        if (camera4.enabled)
        {
            
        }
        if (camera5.enabled)
        {
            
        }
        */
    }

    public IEnumerator CameraChanges()
    {
        yield return new WaitForSeconds(10);

        camera2.enabled = true;
        camera1.enabled = false;
    }
}
