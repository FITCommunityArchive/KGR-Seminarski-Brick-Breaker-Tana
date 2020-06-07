using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    private BrickParent brickParent;
    private int count;
    public bool change;
    void Start()
    {
        count = brickParent.transform.childCount;
        change = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(count>brickParent.transform.childCount)
        {
            if(!change)
            {
                change = true;
            }
            else
            {
                change = false;
            }
            count = brickParent.transform.childCount;
        }
    }
}
