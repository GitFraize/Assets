using UnityEngine;
public class King : MonoBehaviour
{
    public int x = 4;
    public int y= 0;
    public int gY = 0;

    public Pattern nowPattern { get; set; }
    public void moveKing(int _x,int _y, Pattern _pattern)
    {
        int X = 0, Y = 0;
        X = _x != x ? (_x - x) / Mathf.Abs(_x - x) : X = 0;
        x += X;
        if (nowPattern.patternNum == _pattern.patternNum) {
            Y = _y != y ? (_y - y) / Mathf.Abs(_y - y) : Y = 0;
            y += Y;
        }
        else
        {
            Y = 1;
            if (y + 1 > 15)
            {
                y = 0;
                Destroy(nowPattern.gameObject);
                nowPattern = _pattern;
            }
            else
                y+=Y;
        }
        gY += Y;
        gameObject.transform.Translate(new Vector3(X * 1.3f, 0, Y * 1.3f));
    }
}