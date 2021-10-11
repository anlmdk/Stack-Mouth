using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    [SerializeField]
    private float dragSpeed = 15f;

    private Vector3 firstPosition, lastPosition;

    private float min_X = -2f, max_X = 2f;

    bool isDragging = false;

    void Update()
    {
        Move();
    }
    void Move()
    {
        // Character move on Z position
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
    }
    private void OnMouseDown()
    {
        isDragging = true;

        firstPosition = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, 0, 0));
    }
    private void OnMouseDrag()
    {
       if (isDragging)
        {
            lastPosition = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, 0, 0));

            Vector3 distance = lastPosition - firstPosition;
            Vector3 newPosition = transform.position;

            newPosition.x = -distance.x * dragSpeed;
            newPosition.x = Mathf.Clamp(newPosition.x, min_X, max_X);

            transform.position = newPosition;
            lastPosition = firstPosition;
        }
    }
    private void OnMouseUp()
    {
        isDragging = false;
    }
}
