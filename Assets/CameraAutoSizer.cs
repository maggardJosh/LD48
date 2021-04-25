using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[ExecuteInEditMode]
public class CameraAutoSizer : MonoBehaviour
{
    public Collider2D mapBounds;

    private CinemachineVirtualCamera _cam;
    
    void Start()
    {
        _cam = GetComponent<CinemachineVirtualCamera>();
        UpdateCamBounds();
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isPlaying)
            return;
        UpdateCamBounds();
    }

    private void UpdateCamBounds()
    {
        if (!mapBounds)
            return;

        if (!_cam)
        {
            _cam = GetComponent<CinemachineVirtualCamera>();
            if (!_cam)
            {
                Debug.Log("No cam?");
                return;
            }
        }

        float size = mapBounds.bounds.extents.y;
        float sizeBasedOnWidth = mapBounds.bounds.extents.x / _cam.m_Lens.Aspect;
        _cam.m_Lens.OrthographicSize = Mathf.Max(size, sizeBasedOnWidth) + 1f;
        _cam.transform.position = mapBounds.bounds.center + Vector3.down * 1f;
    }
}
