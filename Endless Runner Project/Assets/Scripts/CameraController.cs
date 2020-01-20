using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Player player;
    public Controller2D target;

    private Vector3 lastPlayerPosition;
    private Vector3 lastFocusPosition;
    private float distanceToMoveX;
    private float distanceToMoveY;


    FocusArea focusArea;
    public Vector2 focusAreaSize;
    public float verticalOffset;


    void Start()
    {
        player = FindObjectOfType<Player>();
        lastPlayerPosition = player.transform.position;

        focusArea = new FocusArea(target.collider.bounds, focusAreaSize, target);
    }

    void LateUpdate()
    {
        focusArea.Update(target.collider.bounds);


        if (target.collisions.below)
        {
            distanceToMoveX = player.transform.position.x - lastPlayerPosition.x;
            distanceToMoveY = player.transform.position.y - lastPlayerPosition.y;

            transform.position = new Vector3(transform.position.x + distanceToMoveX, transform.position.y + distanceToMoveY, transform.position.z);
            lastPlayerPosition = player.transform.position;
        }
        else 
        {
            /*
            Vector2 focusPosition = focusArea.centre + Vector2.up * verticalOffset;
            transform.position = (Vector3)focusPosition + Vector3.forward * -10;
            lastFocusPosition = transform.position;
            */

        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, .5f);
        Gizmos.DrawCube(focusArea.centre, focusAreaSize);
    }

    public struct FocusArea
    {
        public Vector2 centre;
        public Vector2 velocity;
        public Vector2 area;

        public float left, right;
        public float top, bottom;
        Vector2 areaSize;
        Controller2D targetController;

        public FocusArea(Bounds targetBounds, Vector2 size, Controller2D controller)
        {
            left = targetBounds.center.x - size.x / 2;
            right = targetBounds.center.x + size.x / 2;

            bottom = 0;
            top = 0;

            bottom = targetBounds.min.y;
            top = targetBounds.min.y + size.y;


            velocity = Vector2.zero;
            centre = new Vector2((left + right) / 2, (top + bottom) / 2);
            area = new Vector2((left + right), (top + bottom));

            areaSize = size;
            targetController = controller;
        }

        public void Update(Bounds targetBounds)
        {

            float shiftX = 0;
            if (targetBounds.min.x < left)
            {
                shiftX = targetBounds.min.x - left;
            }
            else if (targetBounds.max.x > right)
            {
                shiftX = targetBounds.max.x - right;
            }

            left += shiftX;
            right += shiftX;


            float shiftY = 0;

            if (targetController.collisions.below)
            {
                bottom = targetBounds.min.y;
                top = targetBounds.min.y + areaSize.y;
            }
            else 
            {
                if (targetBounds.min.y < bottom)
                {
                    shiftY = targetBounds.min.y - bottom;
                }
                else if (targetBounds.max.y > top)
                {
                    shiftY = targetBounds.max.y - top;
                }
            }

            top += shiftY;
            bottom += shiftY;



            centre = new Vector2((left + right) / 2, (top + bottom) / 2);
            area = new Vector2((left + right), (top + bottom));
            velocity = new Vector2(shiftX, shiftY);
        }
    }
}
