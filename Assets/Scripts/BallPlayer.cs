using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D hook;

    public float releaseTime = 3f;
    public float maxDragDistance = 2f;

    private bool isPressed = false;

    void Update()
    {
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
            rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
            rb.position = mousePos;
        }
    }
    void OnMouseDown ()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp ()
    {
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }

    IEnumerator Release ()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;

        }

    }
