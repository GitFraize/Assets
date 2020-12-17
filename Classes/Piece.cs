using UnityEngine;

public class Piece : MonoBehaviour
{
    public int pId = 0;
    public void spawnPiece(int _pId)
    {
        pId = _pId;
        gameObject.transform.localPosition = new Vector3(0, 0.5f, 0);
        gameObject.transform.Rotate(new Vector3(0, Random.Range(-90, 90), 0));
    }
    public void killPiece()
    {
        gameObject.GetComponentInParent<Field>().piece = null;
        gameObject.GetComponentInParent<Field>()._piece = null;
        Destroy(gameObject);
    }
}