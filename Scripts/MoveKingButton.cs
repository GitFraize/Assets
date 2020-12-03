using UnityEngine;

public class MoveKingButton : MonoBehaviour
{
    public King king;
    public int x;
    public int y;

    public void onClick()
    {
        king.moveKing(x, y);
    }
}