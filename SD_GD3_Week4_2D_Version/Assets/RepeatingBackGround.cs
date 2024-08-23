using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector2 startPos;
    public float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; //start positio is the transfrom position
        repeatWidth = GetComponent<BoxCollider2D>().size.x / 1; //repeating the box collider of the background and dividing it by  1
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
