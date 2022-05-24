using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerater : MonoBehaviour
{
    public GameObject block;
    protected GameController controller;
    protected bool controll = false;
    float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();
        Invoke("Spawn", 1f);
    }

    void Update()
    {

    }

    void Spawn()
    {
        Instantiate(block,transform.position,transform.rotation);
    }
}
