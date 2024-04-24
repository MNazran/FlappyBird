using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float Speed;
    //public GameObject Pipe_Up, Pipe_Down;
    //public float RandomValue;

    // Start is called before the first frame update
    void Start()
    {
        //Pipe_Up.transform.localPosition = new Vector3(0, Random.Range(1, RandomValue), 0);
        //Pipe_Down.transform.localPosition = new Vector3(0, Random.Range(-1, RandomValue), 0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;
    }
}
