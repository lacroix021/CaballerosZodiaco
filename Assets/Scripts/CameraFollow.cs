using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraFollow : MonoBehaviour
{
    private BoxCollider2D cameraBox;    //el box collider de la camara
    private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        cameraBox = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        //AspectRatioBoxChange();
        //Debug.Log(Camera.main.aspect);    //para saber que medidas tiene el aspecto
    }

    /*
    void AspectRatioBoxChange()
    {
        //21:9 ratio
        if (Camera.main.aspect >= (2.03f) && Camera.main.aspect < 2.05f)
        {
            cameraBox.size = new Vector2(6.97f, 3.40f);
        }

        //20:9 ratio
        if (Camera.main.aspect >= (1.93f) && Camera.main.aspect < 1.95f)
        {
            cameraBox.size = new Vector2(6.62f, 3.40f);
        }

        //19:9 ratio
        if (Camera.main.aspect >= (1.83f) && Camera.main.aspect < 1.85f)
        {
            cameraBox.size = new Vector2(6.30f, 3.40f);
        }

        //18:9 ratio
        if (Camera.main.aspect >= (1.74f) && Camera.main.aspect < 1.8f)
        {
            cameraBox.size = new Vector2(5.94f, 3.40f);
        }

        //16:10 ratio
        if (Camera.main.aspect >= (1.39f) && Camera.main.aspect < 1.41f)
        {
            cameraBox.size = new Vector2(4.78f, 3.40f);
        }

        //16:9 Ratio
        if (Camera.main.aspect >= (1.54f) && Camera.main.aspect < 1.56f)
        {
            cameraBox.size = new Vector2(3.522243f, 1.961648f);
        }

        //5:4 Ratio
        if (Camera.main.aspect >= (1.08f) && Camera.main.aspect < 1.10f)
        {
            cameraBox.size = new Vector2(3.73f, 3.40f);
        }
        //4:3 Ratio
        if (Camera.main.aspect >= (1.15f) && Camera.main.aspect < 1.17f)
        {
            cameraBox.size = new Vector2(3.98f, 3.40f);
        }
        //3:2 Ratio
        if (Camera.main.aspect >= (1.30f) && Camera.main.aspect < 1.32f)
        {
            cameraBox.size = new Vector2(4.48f, 3.40f);
        }

    }
    */

    void FollowPlayer()
    {
        var boundary = GameObject.Find("Boundary");
        if (boundary)
        {
            var bounds = boundary.GetComponent<BoxCollider2D>().bounds;
            var p = this.player;
            if (p == null) return;
            transform.position = new Vector3(Mathf.Clamp(p.position.x, bounds.min.x + cameraBox.size.x / 2, bounds.max.x - cameraBox.size.x / 2),
                                             Mathf.Clamp(p.position.y, bounds.min.y + cameraBox.size.y / 2, bounds.max.y - cameraBox.size.y / 2),
                                             transform.position.z);
        }
    }
}

