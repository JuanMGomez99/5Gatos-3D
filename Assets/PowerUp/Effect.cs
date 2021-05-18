using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(75 * Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(10 * Vector3.forward * Time.deltaTime);   
    }
}
