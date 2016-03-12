using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour
{
    public float rotationSpeed;

    void Start()
    {
    }

	void Update()
    {
        transform.Rotate(new Vector3(1,1,0) * Time.deltaTime * rotationSpeed, Space.World);
    }
}
