using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    private const float zSpawnPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(Vector3.up * Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);
        targetRb.AddTorque(RandomNum(maxTorque), RandomNum(maxTorque), RandomNum(maxTorque),ForceMode.Impulse);

        transform.position = new Vector3(RandomNum(xRange), ySpawnPos, zSpawnPos);
    }

    // Update is called once per frame

    void Update()
    {

    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    float RandomNum(float num)
    {
        return (Random.Range(-num, num));
    }
}
