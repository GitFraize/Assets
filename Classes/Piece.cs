using UnityEngine;

public class Piece : MonoBehaviour
{
    public void killPiece(int x,int y)
    {
        Destroy(gameObject);
    }
}
