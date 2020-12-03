using UnityEngine;

public class MovingKing : MonoBehaviour
{
    public float swipeLong = 0;
    public float startPosX = 0;
    public float startPosY = 0;
    public bool isSwipe = false;
    public float cosinus;
    King king;

    private void Start()
    {
        king = gameObject.GetComponent<King>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (isSwipe)
            {
                if (Mathf.Abs(swipeLong) > 400)
                {
                    doSwipe(startPosX, startPosY, Input.mousePosition.x, Input.mousePosition.y);
                }
                else
                {
                    swipeLong = Mathf.Sqrt(Mathf.Pow(Input.mousePosition.x-startPosX,2)+ Mathf.Pow(Input.mousePosition.y - startPosY,2));
                }
            }
            else
            {
                startPosX = Input.mousePosition.x;
                startPosY = Input.mousePosition.y;
                isSwipe = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            doSwipe(startPosX, startPosY, Input.mousePosition.x, Input.mousePosition.y);
            isSwipe = false;
            swipeLong = 0;
            startPosX = 0;
            startPosY = 0;
        }
    }

    void doSwipe(float x1, float y1, float x2, float y2)
    {
        float x, y;
        x = x2 - x1;
        y = y2 - y1;
        cosinus = x / (Mathf.Sqrt(y * y + x * x));


    }

    float side(float num)
    {
        num = Mathf.Abs(num);
        float[] n = new float[8];
        for(int i = 0; i < 8; i ++)
        {
            n[i]=
        }
    }
}
