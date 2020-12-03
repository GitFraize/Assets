using UnityEngine;

public class King : MonoBehaviour
{
    int globalPosX = 0;
    int globalPosY = 0;
    public int patternPosX = 4;
    public int patternPosY = 12;
    public Pattern nowPattern;
    public void moveKing(int x,int y) {
        int x1 = patternPosX + x;
        int y1 = patternPosY - y;
        if (!nowPattern.patternMoves[y1, x1])
        {
            if (nowPattern.pattern[y1, x1] != 0)
            {
                nowPattern.pieces[y1, x1].GetComponent<Piece>().killPiece(y1, x1);
                nowPattern.pieces[y1, x1] = null;
                nowPattern.pattern[y1, x1] = 0;
                nowPattern.scanPattern();
            }
            patternPosX = x1;
            patternPosY = y1;
            gameObject.transform.Translate(new Vector3(x * 1.25f, 0, y * 1.25f));
        }
    }
}