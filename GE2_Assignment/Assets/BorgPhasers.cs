using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorgPhasers : MonoBehaviour
{
    public GameObject phaserPrefab;
    public GameObject phaser;
    public GameObject explosionPrefab;
    public GameObject explosion;
    public bool fire = false;
    public float targetDistance;
    public float firingDistance = 30.0f;
    public float firingArc = 30.0f;

    Transform target;


    void Start()
    {
        StartCoroutine("PhaserTimer");
    }

    public IEnumerator PhaserTimer()
    {
        while (1 == 1)
        {
            if (fire == true)
            {
                firePhaser();
                yield return new WaitForSeconds(1);
                Destroy(phaser);
                explosion = Instantiate(explosionPrefab, target.position, transform.rotation);
                explosion.transform.SetParent(target);
                Destroy(target.gameObject);
                yield return new WaitForSeconds(3);
                fire = false;
            }
            yield return null;
        }

    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + (transform.forward * 10), 20);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.SphereCast(transform.position, firingArc, transform.forward, out hit, firingDistance))
        {
            targetDistance = hit.distance;
            target = hit.transform;
            
            if (fire == false)
            {
                fire = true;
            }
        }



    }
    void firePhaser()
    {
        Vector3 pos = Vector3.Lerp(transform.position, target.position, (float)0.5);
        phaser = Instantiate(phaserPrefab, pos, phaserPrefab.transform.rotation);
        phaser.transform.SetParent(transform);
        phaser.transform.localScale = new Vector3(0.01f, targetDistance/2, 0.01f);
        phaser.transform.LookAt(target);
        phaser.transform.Rotate(new Vector3(90, 0, 0), Space.Self);
    }
}
