using UnityEngine;

public class Field : MonoBehaviour
{
    public int x { get; set; }
    public int y { get; set; }

    public King king;
    public Pattern pattern;
    private void Start()
    {
        pattern = gameObject.GetComponentInParent<Pattern>();
    }
    private void OnMouseDown()
    {
        king.moveKing(x, y, pattern);
    }
    public void spawnField(int _x,int _y,King _king, GameObject _parent)
    {
        gameObject.transform.SetParent(_parent.transform, true);
        x = _x;
        y = _y;
        gameObject.transform.localPosition = new Vector3(-4 + 1.3f * x, -0.65f, 1.3f * y);
        king = _king;
    }
}
