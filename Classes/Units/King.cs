using UnityEngine;
public class King : MonoBehaviour
{
    public int x = 4;
    public int y = 0;
    public int gY = 0;

    public Pattern nowPattern { get; set; }
    public GameObject checkPrefab;
    public Canvas canvas;
    public void moveKing(int _x, int _y, Pattern _pattern)
    {
        int X = _x != x ? (_x - x) / Mathf.Abs(_x - x) : X = 0;
        int Y = _y != y ? (_y - y) / Mathf.Abs(_y - y) : Y = 0;

        if (nowPattern.patternNum >= _pattern.patternNum)
        {
            if (nowPattern.patternNum > _pattern.patternNum)
                if (gY % 12 != 0)
                    Y = -1;
                else
                    Y = 0;
            if (nowPattern.patternMoves[y + Y, x + X])
            {
                y += Y;
                x += X;
                gY += Y;
                gameObject.transform.Translate(new Vector3(X * 1.3f, 0, Y * 1.3f));
            }
            else
                showCheck();
        }
        else if (nowPattern.patternNum < _pattern.patternNum)
        {
            if (nowPattern.patternMoves[y + Y, x + X])
            {
                Y = 1;
                if (y + Y > 11)
                {
                    y = 0;
                    nowPattern = _pattern;
                }
                else
                    y += Y;
                x += X;
                gY += Y;
                gameObject.transform.Translate(new Vector3(X * 1.3f, 0, Y * 1.3f));
            }
            else
                showCheck();
        }
        if (nowPattern.pattern[y, x] != 0)
        {
            nowPattern.pieces[y, x].GetComponent<Piece>().killPiece();
            nowPattern.pattern[y, x] = 0;
            nowPattern.scanPattern();
        }
    }

    void showCheck()
    {
        GameObject check = Instantiate(checkPrefab);
        check.transform.SetParent(canvas.transform);
        check.transform.localPosition = new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0);
    }
}