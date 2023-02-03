using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab; //prefab for apples
    public float speed = 1f; //speed of the appletree
    public float leftAndRightEdge = 10f; //appletree's distance to change direction
    public float changeDirChance = 0.1f; //appletree's chance to change direction
    public float appleDropDelay = 1f; //delay between apple creations

    // Start is called before the first frame update
    void Start()
    {
        // Start Dropping the Apples
        Invoke ( "DropApple", 2f );
    }

    void DropApple() {
        GameObject apple = Instantiate<GameObject>( applePrefab );
        apple.transform.position = transform.position;
        Invoke( "DropApple", appleDropDelay );
    }

    // Update is called once per frame
    void Update()
    {
        //AppleTree basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing Direction of AppleTree
        if ( pos.x < -leftAndRightEdge ) {
            speed = Mathf.Abs( speed ); //moving right
        } else if ( pos.x > leftAndRightEdge ) {
            speed = -Mathf.Abs( speed ); //moving left
        } //else if ( Random.value < changeDirChance ) {
            //  speed *= -1; //direction change
        //}

    }

    void FixedUpdate() {
        //using FixedUpdate for random direction changes
        if ( Random.value < changeDirChance ) {
            speed *= -1; //changing direction
        }
    }
}
