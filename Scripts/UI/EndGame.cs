using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGame : MonoBehaviour
{
    Text crownsShow;
    GameObject crownImage;
    int crowns = 0;
    public float frequency=0.001f;
    private void Start()
    {
    }
    public void setText(Text _crownsShow, GameObject _crownImage, int _crowns)
    {
        crownImage = _crownImage;
        crownsShow = _crownsShow;
        crownsShow.text = crowns + "";
        crowns = _crowns;
        gameObject.GetComponent<Image>().color = new Vector4(0, 0, 0, 0);
        StartCoroutine(animate());
    }
    private IEnumerator animate()
    {
        float crownsNow = 0;
        while (true)
        {
            if (gameObject.transform.localScale.x < 1.8f)
            {
                gameObject.transform.localPosition -= new Vector3(0, frequency * 10000, 0);
                gameObject.transform.localScale *= 1.01f;
            }
            else if (crownsNow < crowns)
            {
                crownsNow += crowns * frequency * 2;
                crownsShow.text = (int)crownsNow + "";
            }
            else
            {
                crownImage.GetComponent<CrownAnimate>().startAnimate();
            }
            yield return new WaitForSeconds(frequency);
        }
    }
}
