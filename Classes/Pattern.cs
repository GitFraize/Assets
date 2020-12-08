using UnityEngine;

public class Pattern : MonoBehaviour
{
    /*
     * ID 000 : Empty field
     * ID 100 : King
     * ID 101 : Pawn
     * ID 102 : Rook
     * ID 103 : Knight
     * ID 104 : Bishop
     * ID 105 : Queen
     */
    public int patternNum;
    public int[,] pattern = new int[16,8];
    public bool[,] patternMoves = new bool[16, 8];
    public GameObject[,] pieces = new GameObject[16, 8];
    public GameObject[,] fields = new GameObject[16, 8];

    public Prefabs prefabs;
    public Patterns patterns;

    public King king;

    private void Start()
    {
        patterns.getRandomPattern(ref pattern);

        spawnPattern();
        scanPattern();
    }
    public void scanPattern()
    {
    }

    public void spawnPattern()
    {
        for (int i = 0; i < 16; i++)
        {
            bool isWhite = i%2==0;
            for (int j = 0; j < 8; j++)
            {
                int id = 2;
                if (isWhite)
                    id = 1;
                fields[i, j] = Instantiate(prefabs.getPrefabByID(id));
                fields[i, j].GetComponent<Field>().spawnField(j,i,king,gameObject);
                isWhite = !isWhite;
                if (pattern[i, j] != 0)
                {
                    pieces[i, j] = Instantiate(prefabs.getPrefabByID(pattern[i, j]));
                    pieces[i, j].transform.SetParent(gameObject.transform, true);
                    pieces[i, j].transform.localPosition = new Vector3(-4 + 1.3f * j, 0, 1.3f * i);
                }
            }
        }
    }
}
