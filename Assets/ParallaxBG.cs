using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    public float parallaxScalar = .1f;

    private Vector3 disp = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        var camPosition = Camera.main.transform.position;


        Vector3 pos = Vector3.zero;
        pos.x = disp.x + camPosition.x * parallaxScalar;

        int loops = 0;
        int max_loops = 100;
        while (pos.x - camPosition.x > 1)
        {
            loops++;
            if (loops >= max_loops)
            {
                Debug.LogError("Too many loops");
                break;
            }
            disp.x -= 1;
            pos.x = disp.x + camPosition.x * parallaxScalar;
        }

        loops = 0;
        while (pos.x - camPosition.x < 1)
        {
            loops++;
            if (loops >= max_loops)
            {
                Debug.LogError("Too many loops");
                break;
            }
            disp.x += 1;
            pos.x = disp.x + camPosition.x * parallaxScalar;
        }
        loops = 0;
        pos.y = disp.y + camPosition.y * parallaxScalar;
        while (pos.y - camPosition.y > 1)
        {
            loops++;
            if (loops >= max_loops)
            {
                Debug.LogError("Too many loops");
                break;
            }
            disp.y -= 1;
            pos.y = disp.y + camPosition.y * parallaxScalar;
        }
        loops = 0;
        while (pos.y - camPosition.y < 1)
        {
            loops++;
            if (loops >= max_loops)
            {
                Debug.LogError("Too many loops");
                break;
            }
            disp.y += 1;
            pos.y = disp.y + camPosition.y * parallaxScalar;
        }
        transform.position = pos;
        
        
    }
}
