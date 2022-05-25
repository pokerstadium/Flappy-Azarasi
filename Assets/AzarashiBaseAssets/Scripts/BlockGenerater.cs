using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerater : MonoBehaviour
{
    public GameObject block;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

    }

    public void Spawn()
    {
        Instantiate(block,transform.position,transform.rotation);
        Invoke("Spawn", 1f);
    }
}
