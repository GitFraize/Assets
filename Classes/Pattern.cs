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
    public int[,] pattern = new int[12,8];
    public bool[,] patternMoves = new bool[12, 8];
    public GameObject[,] pieces = new GameObject[12, 8];
    public GameObject[,] fields = new GameObject[12, 8];

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
        for (int i = 0; i < 12; i++)
            for (int j = 0; j < 8; j++)
                patternMoves[i, j] = true;
        for (int i=0;i<12;i++)
            for(int j = 0; j < 8; j++)
            {
                switch (pattern[i, j])
                {
                    case 101:
                        {
                            if (j > 0)
                                patternMoves[i - 1, j - 1] = false;
                            if (j < 7)
                                patternMoves[i - 1, j + 1] = false;
                        }
                        break;
                    case 102:
                        {
                            int n = j - 1;
                            while (n >= 0)
                            {
                                patternMoves[i, n] = false;
                                if (pattern[i, n] == 0)
                                    n--;
                                else
                                    break;
                            }
                            n = j + 1;
                            while (n <= 7)
                            {
                                patternMoves[i, n] = false;
                                if (pattern[i, n] == 0)
                                    n++;
                                else
                                    break;
                            }
                            n = i + 1;
                            while (n <= 11)
                            {
                                patternMoves[n, j] = false;
                                if (pattern[n, j] == 0)
                                    n++;
                                else
                                    break;
                            }
                            n = i - 1;
                            while (n >= 0)
                            {
                                patternMoves[n, j] = false;
                                if (pattern[n, j] == 0)
                                    n--;
                                else
                                    break;
                            }
                        }
                        break;
                    case 103:
                        {
                            if (i > 0 && j > 1)
                                patternMoves[i - 1, j - 2] = false;
                            if (i > 0 && j < 6)
                                patternMoves[i - 1, j + 2] = false;
                            if (i > 1 && j > 0)
                                patternMoves[i - 2, j - 1] = false;
                            if (i > 1 && j < 7)
                                patternMoves[i - 2, j + 1] = false;
                            if (i < 11 && j > 1)
                                patternMoves[i + 1, j - 2] = false;
                            if (i < 11 && j < 6)
                                patternMoves[i + 1, j + 2] = false;
                            if (i <10 && j > 0)
                                patternMoves[i + 2, j - 1] = false;
                            if (i <10 && j < 7)
                                patternMoves[i + 2, j + 1] = false;
                        }
                        break;
                    case 104:
                        {
                            int n = i - 1;
                            int m = j - 1;
                            while (n >= 0 && m >= 0)
                            {
                                patternMoves[n, m] = false;
                                if (pattern[n, m] == 0)
                                {
                                    n--;
                                    m--;
                                }
                                else
                                    break;
                            }
                            n = i + 1;
                            m = j - 1;
                            while (n <= 11 && m >= 0)
                            {
                                patternMoves[n, m] = false;
                                if (pattern[n, m] == 0)
                                {
                                    n++;
                                    m--;
                                }
                                else
                                    break;
                            }
                            n = i + 1;
                            m = j + 1;
                            while (n <= 11 && m <= 7)
                            {
                                patternMoves[n, m] = false;
                                if (pattern[n, m] == 0)
                                {
                                    n++;
                                    m++;
                                }
                                else
                                    break;
                            }
                            n = i - 1;
                            m = j + 1;
                            while (n >=0 && m <= 7)
                            {
                                patternMoves[n, m] = false;
                                if (pattern[n, m] == 0)
                                {
                                    n--;
                                    m++;
                                }
                                else
                                    break;
                            }
                        }
                        break;
                }
            }
    }

    public void spawnPattern()
    {
        for (int i = 0; i < 12; i++)
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
