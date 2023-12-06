using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOLight : MonoBehaviour
{
    public float speed;// = 5;
    public float frequency;// = 1.0f;
    public float magnitude;// = 500f;

    Vector3 pos;
    Vector3 axis;

    private void Awake()
    {
        pos = transform.position;
        axis = transform.up;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos += Vector3.right * Time.deltaTime * speed;
        transform.position=pos+axis*Mathf.Sin(Time.time * frequency) * magnitude;
        //float x = 10;

       // Vector3 movement = new Vector3 (x, 0, 0);
        //transform.Translate(movement*speed*Time.deltaTime);
    }
}
