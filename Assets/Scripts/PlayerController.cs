using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IMoveable
{
    public float moveSpeed = 5f;

    [SerializeField]
    private float dragSpeed = 15f;

    private Vector3 startPosition, endPosition;

    private float min_X = -2f, max_X = 2f;

    private bool isDragging = false;

    void Update()
    {
        Move();
    }
    public void Move()
    {
        // Character move on Z position
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
    }
    private void OnMouseDown()
    {
        isDragging = true;

        startPosition = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, 0, 0));
    }
    private void OnMouseDrag()
    {
       if (isDragging)
        {
            endPosition = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, 0, 0));

            Vector3 distance = endPosition - startPosition;
            Vector3 newPosition = transform.position;

            newPosition.x = -distance.x * dragSpeed;
            newPosition.x = Mathf.Clamp(newPosition.x, min_X, max_X);

            transform.position = newPosition;
            endPosition = startPosition;
        }
    }
    private void OnMouseUp()
    {
        isDragging = false;
    }
}
