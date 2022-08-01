using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private string monkeyTag = "Monkey";
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Began)
        {
            Touch currentTouch = Input.touches[0];
            if(!Physics.Raycast(Camera.main.ScreenPointToRay(Input.touches[0].position), out RaycastHit hitInfo)) return;
            
            if(hitInfo.collider.gameObject.CompareTag(monkeyTag))
            {
                BaseMonkey tappedMonkey = hitInfo.collider.GetComponent<BaseMonkey>();
                if (tappedMonkey != null) tappedMonkey.Interact();
            }
        }
        // Camera controls
        if(Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Moved)
        {
            Debug.Log(Input.touches[0].deltaPosition);
            Camera.main.transform.position += new Vector3(Input.touches[0].deltaPosition.x * -0.01f, 0, Input.touches[0].deltaPosition.y * -0.01f);
            //Physics.Raycast(Camera.main.ScreenPointToRay(Input.touches[0].position), out RaycastHit hitInfo);
            //Debug.Log(Camera.main.ScreenToWorldPoint(Input.touches[0].position));
        }
        
       if(Input.touchCount == 2)
        {
            if(Input.touches[0].phase == TouchPhase.Moved && Input.touches[0].phase == TouchPhase.Moved)
            {
                float currentDistSq = (Input.touches[0].position - Input.touches[1].position).sqrMagnitude;
                float previousDistSq = (Input.touches[0].position - Input.touches[0].deltaPosition - Input.touches[1].position - Input.touches[1].deltaPosition).sqrMagnitude;

                Debug.Log($"current square distance: {currentDistSq}");
                Debug.Log($"previous square distance: {previousDistSq}");
                //if (previousDistSq > currentDistSq) Debug.Log("Zoom in");
                //if (previousDistSq < currentDistSq) Debug.Log("Zoom out");
                //float dot = Vector2.Dot(Input.touches[0].deltaPosition, Input.touches[1].deltaPosition
                //Debug.Log($"dot: {dot}");
            }
        }
    }
}
