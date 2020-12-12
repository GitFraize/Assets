using UnityEngine;

public class Field : MonoBehaviour
{
    int x, y;

    public GameObject piece;
    public GameObject parent;
    public Piece _piece;
    public King king;

    public bool kingCanMove = true;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Destroyer")
        {
            if (king.x == x && king.y == y)
                king.gameOver();
            if (x == 0)
                king.board.deleteOldLine(parent);
        }
    }
    private void OnMouseDown()
    {
        king.moveKing(x, y);
    }
    public void spawnField(int _x, int _y, GameObject _parent, King _king, int _pId, GameObject _pPrefab)
    {
        x = _x;
        y = _y;
        parent=_parent;
        king = _king;
        gameObject.name = "field #" + _x;
        gameObject.transform.localPosition = new Vector3(_x * 1.3f - 4.55f, 0, _y * 1.3f);
        if (_pPrefab != null)
        {
            piece = Instantiate(_pPrefab);
            piece.transform.SetParent(gameObject.transform);
            piece.AddComponent<Piece>();
            piece.GetComponent<Piece>().spawnPiece(_pId);
            _piece = piece.GetComponent<Piece>();
        }
        else
        {
            piece = null;
            _piece = null;
        }
    }
}
