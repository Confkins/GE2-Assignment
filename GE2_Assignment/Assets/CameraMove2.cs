using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove2 : MonoBehaviour
{
    public GameObject Targetposition;
    public Camera camera2;
    public float speed;
    public bool foo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        camera2.transform.position = Vector3.Slerp(transform.position, Targetposition.transform.position, speed * Time.deltaTime);
        camera2.transform.rotation = Quaternion.Lerp(transform.rotation, Targetposition.transform.rotation, speed * Time.deltaTime);

    }
}
