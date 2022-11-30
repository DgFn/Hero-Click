using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Swipe : MonoBehaviour, IPointerClickHandler
{
    public GameObject SwipeList, Buttonb;
    float speed = 300f;
    bool move = true;
   
    float tiltAngle = 180.0f;
    float tiltAngle180 = 0f;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        

        if (move)
        {
            float tiltAroundY = Input.GetAxis("Horizontal") * tiltAngle;
            Quaternion Buttonb = Quaternion.Euler(0, 0, 0 );
            transform.rotation = Quaternion.Slerp(transform.rotation, Buttonb, Time.deltaTime * speed);
            SwipeList.transform.position = Vector2.MoveTowards(transform.position, new Vector2(0.16f, 2.22f), speed * Time.deltaTime);
            move = false;    
        }
        else
        {
            float tiltAroundY = Input.GetAxis("Horizontal") * tiltAngle180;
            Quaternion Buttonb = Quaternion.Euler(0, 0, 180);
            transform.rotation = Quaternion.Slerp(transform.rotation, Buttonb, Time.deltaTime * speed);
            SwipeList.transform.position = Vector2.MoveTowards(transform.position, new Vector2(4.84f, 2.22f), speed * Time.deltaTime);
            move = true;
        }
        
    }




}
