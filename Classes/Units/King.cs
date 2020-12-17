using UnityEngine;
using UnityEngine.UI;
public class King : MonoBehaviour
{
    public int x = 4;
    public int y = 0;
    public int gY = 0;

    public GameObject checkPrefab;
    public Canvas canvas;

    public Board board;
    
    private void Start()
    {
        board = gameObject.GetComponentInParent<Board>();
    }

    public void moveKing(int _x, int _y)
    {
        int X = _x != x ? (_x - x) / Mathf.Abs(_x - x) : X = 0;
        int Y = _y != y ? (_y - y) / Mathf.Abs(_y - y) : Y = 0;
        _y = Y + y;
        _y %= board.arraySize - 1;
        if (board._fields[_y, x + X].kingCanMove)
        {
            x += X;
            y += Y;
            gameObject.transform.Translate(new Vector3(1.3f * X, 0, 1.3f * Y));
            if (board._fields[_y, x].piece != null)
            {
                board._fields[_y, x]._piece.killPiece();
                board.scanPattern();
                showText("Ням!", 0.15f, 0.3f, 0.9f);
            }
        }
        else
            showText("Шах!", 1, 0.15f, 0.15f);
    }

    public void showText(string text,float r, float g, float b)
    {
        GameObject check = Instantiate(checkPrefab);
        check.GetComponent<CheckText>().text.color = new Color(r, g, b);
        check.GetComponent<CheckText>().text.text = text;
        check.transform.SetParent(canvas.transform);
        check.transform.localPosition = new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0);
    }
    public void gameOver()
    {
        board.gameObject.GetComponent<Moving>().isMoving= false;
        Destroy(gameObject);
    }
}