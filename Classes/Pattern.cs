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

    public Prefabs prefabs;

    private void Start()
    {
        for (int i = 0; i < 8; i +=2)
            pattern[3,i]=101;

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
                }
            }
        }
    }

    public void spawnPattern()
    {
        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (pattern[i, j] != 0)
                {
                    pieces[i, j] = Instantiate(prefabs.getPrefabByID(pattern[i, j]));
                    pieces[i, j].transform.SetParent(gameObject.transform, true);
                    pieces[i, j].transform.localPosition = new Vector3(-4.375f + 1.25f * j, 0, 4.375f - 1.25f * i);
                }
            }
        }
    }
}
