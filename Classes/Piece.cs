using UnityEngine;

public class Piece : MonoBehaviour
{
    public int pieceCost = 1;
    bool isAnimate = false;
    public float animateSpeed=1;
    float startT, stopT;

    private void Update()
    {
        if (isAnimate)
        {
            int k = Random.Range(0,1);
            if (k == 0)
                k = -1;
            gameObject.transform.Rotate(new Vector3(Time.deltaTime * animateSpeed*k, Time.deltaTime * animateSpeed*k, k*Time.deltaTime * animateSpeed));
            stopT = Time.time;
        }
    }
    public void killPiece()
    {
        isAnimate = true;
        startT = Time.time;
    }
}
