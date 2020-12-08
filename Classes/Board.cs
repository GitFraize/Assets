using UnityEngine;

public class Board : MonoBehaviour
{
    public int nowPatternNum = 0;
    public int patternNum = 0;
    public GameObject[] patterns = new GameObject[8];

    public King king;

    private void Start()
    {
        createNewPattern();
        king.nowPattern = patterns[0].GetComponent<Pattern>();
        for (int i = 1; i < 8; i++)
            createNewPattern();
    }

    public void createNewPattern()
    {
        patterns[patternNum] = Instantiate(gameObject.GetComponent<Prefabs>().getPrefabByID(201));
        patterns[patternNum].transform.SetParent(gameObject.transform, true);
        patterns[patternNum].transform.Translate(new Vector3(0,0, 1.3f * 16 * nowPatternNum));
        patterns[patternNum].GetComponent<Pattern>().patterns = gameObject.GetComponent<Patterns>();
        patterns[patternNum].GetComponent<Pattern>().prefabs = gameObject.GetComponent<Prefabs>();
        patterns[patternNum].GetComponent<Pattern>().king = king;
        patterns[patternNum].GetComponent<Pattern>().patternNum = nowPatternNum;

        if (patternNum != 7)
            patternNum++;
        else
            patternNum = 0;
        nowPatternNum++;
    }
}
