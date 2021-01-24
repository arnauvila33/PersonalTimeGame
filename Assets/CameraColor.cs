using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColor : MonoBehaviour
{

    private Camera camera;
    private Color forest=new Color(0,.05f,0,.1f);
    private Color desert = new Color(.05f, .05f, 0, .1f);
    private Color winter = new Color(0, .05f, .05f, .1f);
    private Color water = new Color(0, 0, .45f, .1f);
    private Color cave = new Color(.26f, .13f, 0, .1f);
    // Start is called before the first frame update
    void Start()
    {
        camera=GetComponent<Camera>();
    
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        if (x < 0&&y<1)
        {
            camera.backgroundColor = forest;
        }
        else if (x > 1&&y<1)
        {
            camera.backgroundColor = desert;
        }
        else if(x>1)
        {
            camera.backgroundColor = winter;
        }
        else 
        {
            camera.backgroundColor = Color.black;
        }

    }
}
