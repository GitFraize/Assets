using UnityEngine;

public class Field : MonoBehaviour
{
    public int x { get; set; }
    public int y { get; set; }

    public King king;
    private void OnMouseDown()
    {
        int X, Y;
        X = x != king.PosX ? (x - king.PosX) / Mathf.Abs(x - king.PosX) :X=0;
        Y = y != king.PosY ? (y - king.PosY) / Mathf.Abs(y - king.PosY) :Y=0;
        king.moveKing(X, Y);
    }
}
