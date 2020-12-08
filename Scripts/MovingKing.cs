using UnityEngine;
using UnityEngine.UI;

public class MovingKing : MonoBehaviour
{
    public float lenghtX = 0;
    public float lenghtY = 0;
    public float alfa;
    King king;
    public Text lx;
    public Text ly;
    public Text la;

    private void Start()
    {
        king = gameObject.GetComponent<King>();
    }

    void Update()
    {
        /*if (Input.GetKey(KeyCode.Mouse0))
        {
            lenghtX += Input.GetAxis("Mouse X");
            lenghtY += Input.GetAxis("Mouse Y");
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            doSwipe(lenghtX, lenghtY);
            lenghtX = 0;
            lenghtY = 0;
        }
        lx.text = "" + lenghtX;
        ly.text = "" + lenghtY;
        la.text = "" + alfa;
        */
    }

    /*void doSwipe(float x,float y)
    {
        float beta=999;
        alfa = 57.3f * Mathf.Acos(x / (Mathf.Sqrt(x * x + y * y)));
        if (y < 0)
            alfa = 180-alfa+180;
        int i = 0;
        while (beta == 999)
        {
            
        }
        switch (beta)
        {
            case 0: king.moveKing(1, 0); break;
            case 45: king.moveKing(1, 1); break;
            case 90: king.moveKing(0, 1); break;
            case 135: king.moveKing(-1, 1); break;
            case 180: king.moveKing(-1, 0); break;
            case 225: king.moveKing(-1, -1); break;
            case 270: king.moveKing(0, -1); break;
            case 315: king.moveKing(1, -1); break;
            case 360: king.moveKing(1, 0); break;
        }
    }*/
}
