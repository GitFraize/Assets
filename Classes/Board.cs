using UnityEngine;

public class Board : MonoBehaviour
{
    public int lastPatternNum = 0;
    public int patternNum = 0;
    public GameObject[] patterns = new GameObject[8];

    public King king;

    public float speed;
    private void Update()
    {
        gameObject.transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
    }
    private void Start()
    {
        createNewPattern();
        king.nowPattern = patterns[0].GetComponent<Pattern>();
        for (int i = 0; i < 7; i++)
            createNewPattern();
    }

    public void createNewPattern()
    {
        patterns[patternNum] = Instantiate(gameObject.GetComponent<Prefabs>().getPrefabByID(201));
        patterns[patternNum].transform.SetParent(gameObject.transform, true);
        patterns[patternNum].transform.localPosition=new Vector3(-0.5f,0, 1.3f * 12 * lastPatternNum);
        patterns[patternNum].GetComponent<Pattern>().patterns = gameObject.GetComponent<Patterns>();
        patterns[patternNum].GetComponent<Pattern>().prefabs = gameObject.GetComponent<Prefabs>();
        patterns[patternNum].GetComponent<Pattern>().king = king;
        patterns[patternNum].GetComponent<Pattern>().patternNum = lastPatternNum;

        if (patternNum != 7)
            patternNum++;
        else
            patternNum = 0;
        lastPatternNum++;
    }
    public void deleteOldPattern(GameObject _pattern)
    {
        Destroy(_pattern);
        createNewPattern();
        speed *= 1.33f;
    }
}
