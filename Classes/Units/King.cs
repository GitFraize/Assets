using UnityEngine;

public class King : MonoBehaviour
{
    public int PosX = 4;
    public int PosY= 0;
    public Pattern nowPattern;


    public void moveKing(int x,int y) {
        PosX += x;
        PosY += y;
        gameObject.transform.Translate(new Vector3(x * 1.3f, 0, y * 1.3f));
    }
}