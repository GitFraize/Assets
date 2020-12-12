using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour
{
    public King king;
    public Prefabs prefabs;
    public Patterns patterns;
    int _lN = 0, _l = 0;
    public Field[,] _fields = new Field[49, 8];
    int[,] nextPattern = new int[12, 8];

    public float movingSpeed;
    public float mBFrequency = 0.05f;
    public bool isMoving = true;

    public void Start()
    {
        patterns = gameObject.AddComponent<Patterns>();
        generateNextPattern();
        for (int i = 0; i < 49; i++)
            createNewLine();
        scanPattern();
        StartCoroutine(movingBoard());
    }
    public void generateNextPattern()
    {
        patterns.getRandomPattern(ref nextPattern);
    }

    public void createNewLine()
    {
        GameObject newLine = new GameObject();
        newLine.name = "line #" + _l;
        newLine.transform.SetParent(gameObject.transform);
        newLine.transform.localPosition = new Vector3(0, 0, 0);
        for (int i = 0; i < 8; i++)
        {
            GameObject newField = Instantiate(prefabs.getPrefabByID((i + _l) % 2 + 1));
            newField.transform.SetParent(newLine.transform);
            newField.AddComponent<Field>();
            _fields[_l%48, i] = newField.GetComponent<Field>();
            _fields[_l%48, i].spawnField(i, _l, newLine, king, nextPattern[_lN % 12, i], prefabs.getPrefabByID(nextPattern[_lN % 12, i]));
        }
        if (_lN < 48)
            _lN++;
        else
            _lN = 0;
        if(_lN%12==0)
            generateNextPattern();
        _l++;
    }
    public void deleteOldLine(GameObject line)
    {
        Destroy(line);
        createNewLine();
        scanPattern();
    }
    public void scanPattern()
    {
        for (int i = 0; i < 48; i++)
            for (int j = 0; j < 8; j++)
                _fields[i, j].kingCanMove = true;
        for (int i = 0; i < 48; i++)
            for (int j = 0; j < 8; j++)
            {
                if (_fields[i, j].piece != null)
                    switch (_fields[i, j]._piece.pId)
                    {
                        case 101:
                            {
                                int _i = i;
                                if (i == 0)
                                    _i = 48;
                                if (j > 0)
                                    _fields[_i - 1, j - 1].kingCanMove = false;
                                if (j < 7)
                                    _fields[_i - 1, j + 1].kingCanMove = false;
                            }
                            break;
                        case 102:
                            {
                                int n = j - 1;
                                while (n >= 0)
                                {
                                    _fields[i, n].kingCanMove = false;
                                    if (_fields[i, n]._piece == null)
                                        n--;
                                    else
                                        break;
                                }
                                n = j + 1;
                                while (n <= 7)
                                {
                                    _fields[i, n].kingCanMove = false;
                                    if (_fields[i, n]._piece == null)
                                        n++;
                                    else
                                        break;
                                }
                                n = i + 1;
                                while (n <= 11)
                                {
                                    _fields[n, j].kingCanMove = false;
                                    if (_fields[n, j]._piece == null)
                                        n++;
                                    else
                                        break;
                                }
                                n = i - 1;
                                while (n >= 0)
                                {
                                    _fields[n, j].kingCanMove = false;
                                    if (_fields[n, j]._piece == null)
                                        n--;
                                    else
                                        break;
                                }
                            }
                            break;
                        case 103:
                            {
                                if (i > 0 && j > 1)
                                    _fields[i - 1, j - 2].kingCanMove = false;
                                if (i > 0 && j < 6)
                                    _fields[i - 1, j + 2].kingCanMove = false;
                                if (i > 1 && j > 0)
                                    _fields[i - 2, j - 1].kingCanMove = false;
                                if (i > 1 && j < 7)
                                    _fields[i - 2, j + 1].kingCanMove = false;
                                if (i < 11 && j > 1)
                                    _fields[i + 1, j - 2].kingCanMove = false;
                                if (i < 11 && j < 6)
                                    _fields[i + 1, j + 2].kingCanMove = false;
                                if (i < 10 && j > 0)
                                    _fields[i + 2, j - 1].kingCanMove = false;
                                if (i < 10 && j < 7)
                                    _fields[i + 2, j + 1].kingCanMove = false;
                            }
                            break;
                        case 104:
                            {
                                int n = i - 1;
                                int m = j - 1;
                                while (n >= 0 && m >= 0)
                                {
                                    _fields[n, m].kingCanMove = false;
                                    if (_fields[n, m]._piece == null)
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
                                    _fields[n, m].kingCanMove = false;
                                    if (_fields[n, m]._piece == null)
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
                                    _fields[n, m].kingCanMove = false;
                                    if (_fields[n, m]._piece == null)
                                    {
                                        n++;
                                        m++;
                                    }
                                    else
                                        break;
                                }
                                n = i - 1;
                                m = j + 1;
                                while (n >= 0 && m <= 7)
                                {
                                    _fields[n, m].kingCanMove = false;
                                    if (_fields[n, m]._piece == null)
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
    private IEnumerator movingBoard()
    {
        while (true)
        {
            if (isMoving)
                gameObject.transform.Translate(new Vector3(0, 0, -movingSpeed * mBFrequency));
            yield return new WaitForSeconds(mBFrequency);
        }
    }
}