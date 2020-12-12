using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour
{
    public float movingSpeed;
    public float mBFrequency = 0.05f;
    public bool isMoving = true;
    void Start()
    {
        StartCoroutine(movingBoard());
    }
    private IEnumerator movingBoard()
    {
        while (true)
        {
            if (isMoving)
                gameObject.transform.Translate(new Vector3(0, 0, -movingSpeed * mBFrequency));
            yield return new WaitForSecondsRealtime(mBFrequency);
        }
    }
}
