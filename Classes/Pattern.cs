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
    public int patternNum
    {
        get;set;
    }
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
        for (int i = 0; i < 16; i++)
            for (int j = 0; j < 8; j++)
                patternMoves[i, j] = false;
        for (int i = 0; i< 16; i++)
        {
            for(int j=0; j < 8; j++)
            {
                switch (pattern[i, j])
                {
                    case 101:
                        if(j!=0)
                            patternMoves[i + 1, j - 1] = true;
                        if(j!=7)
                            patternMoves[i + 1, j + 1] = true;
                        break;
                    /*case 102:
                        int n = i;
                        int m = j;
                        while (pattern[n + 1, m] == 0)
                        {
                            patternMoves[n + 1, m] = true;
                            n++;
                        }
                        break;*/
                }
            }
        }
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
                fields[i, j].transform.SetParent(gameObject.transform, true);
                fields[i, j].transform.localPosition = new Vector3(-4 + 1.3f * j, -0.65f, 1.3f * i);
                fields[i, j].GetComponent<Field>().x = j;
                fields[i, j].GetComponent<Field>().y = i;
                fields[i, j].GetComponent<Field>().king = king;
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
