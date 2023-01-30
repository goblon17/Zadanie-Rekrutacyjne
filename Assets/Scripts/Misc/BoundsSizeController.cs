using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BoundsSizeController : MonoBehaviour
{
    [SerializeField]
    private Collider2D upCollider;
    [SerializeField]
    private Collider2D downCollider;
    [SerializeField]
    private Collider2D leftCollider;
    [SerializeField]
    private Collider2D rightCollider;

    public Vector2 Size => arena.size;

    private new Camera camera;
    private Rect arena;
    private float oldCameraAspect;

    private void Start()
    {
        camera = FindObjectOfType<Camera>();
        arena.position = Vector2.zero;
        arena.size = Vector2.one;
        ResizeArea();
    }


    private void Update()
    {
        if (camera.aspect != oldCameraAspect)
        {
            ResizeArea();
        }
    }

    private void ResizeArea()
    {
        CalculateArena();
        UpdateBounds();
        oldCameraAspect = camera.aspect;
    }

    private void CalculateArena()
    {
        Vector3 bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, 1));
        Vector3 upperLeft = camera.ViewportToWorldPoint(new Vector3(0, 1, 1));
        Vector3 bottomRight = camera.ViewportToWorldPoint(new Vector3(1, 0, 1));

        arena.width = bottomRight.x - bottomLeft.x;
        arena.height = upperLeft.y - bottomLeft.y;
    }

    private void UpdateBounds()
    {
        upCollider.transform.position = new Vector3(0, arena.height/2 + (float)0.5, 0);
        downCollider.transform.position = new Vector3(0, -(arena.height / 2 + (float)0.5), 0);
        leftCollider.transform.position = new Vector3(-(arena.width / 2 + (float)0.5), 0, 0);
        rightCollider.transform.position = new Vector3(arena.width / 2 + (float)0.5, 0, 0);
    }
}
