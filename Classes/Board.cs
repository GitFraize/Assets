using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    static int ArraySize = 25; //Константа размера массива _fields
    public int getArraySize()
    {
        return ArraySize;
    }//Метод, возвращающий Константу ArraySize. Не использовать в классе Board!
    [Header("King ")]
    public King king;//Ссылка на экземпляр класса King
    public bool isSpawnKing = true;
    public int crowns = 0;
    [Header("Kits prefabs")]//Префабы наборов
    public GameObject DefaultSet;
    public GameObject VoxelSet;
    [Header("UI objects")]//Объекты UI: Canvas, Text и т.д.
    public Canvas canvas;
    public Text crownsShow;
    public GameObject crownImage;
    public GameObject panel;
    [Header("Array _fields")]
    public Field[,] _fields = new Field[ArraySize, 8];
    [Header("Private variables")]
    int _lN = 0, _l = 0, padding=0;
    int[,] nextPattern = new int[12, 8];
    Prefabs prefabs;
    Patterns patterns;

    public void endGame()
    {
        panel.AddComponent<EndGame>();
        panel.GetComponent<EndGame>().setText(crownsShow, crownImage, crowns);
    }
    public void addCrowns(int value)
    {
        crowns += value;
        crownsShow.text = crowns + "";
        crownImage.GetComponent<CrownAnimate>().startAnimate();
    }

    public void Start()
    {
        changeSet("VoxelSet");
        if (isSpawnKing)
            spawnKing();
        patterns = gameObject.AddComponent<Patterns>();
        generateNextPattern();
        for (int i = 0; i < ArraySize; i++)
            createNewLine();
        scanPattern();
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
            _fields[_l % (ArraySize - 1), i] = newField.GetComponent<Field>();
            _fields[_l % (ArraySize-1), i].spawnField(i, _l, this,
                newLine, king, nextPattern[_lN % 12, i], prefabs.getPrefabByID(nextPattern[_lN % 12, i]));
        }
        if (_lN < (ArraySize - 1))
            _lN++;
        else
            _lN = 0;
        if (_lN % 12 == 0)
            generateNextPattern();
        _l++;
    }
    public void deleteOldLine(GameObject line)
    {
        Destroy(line);
        createNewLine();
        padding++;
        scanPattern();
    }
    public void scanPattern()
    {
        for (int i = 0; i < (ArraySize - 1); i++)
            for (int j = 0; j < 8; j++)
                if (_fields[i, j] != null)
                    _fields[i, j].kingCanMove = true;
        for (int i = 0; i < (ArraySize - 1); i++)
            for (int j = 0; j < 8; j++)
            {
                if (_fields[i, j] != null)
                    if (_fields[i, j].piece != null)
                        switch (_fields[i, j]._piece.pId)
                        {
                            case 101:
                                {
                                    int _i = i;
                                    if (i == 0)
                                        _i = (ArraySize - 1);
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
                                    while (n < ArraySize-1-padding)
                                    {
                                        _fields[n, j].kingCanMove = false;
                                        if (_fields[n, j]._piece == null)
                                            n++;
                                        else
                                            break;
                                    }
                                    n = i - 1;
                                    while (n >= padding)
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
                                    else
                                        _fields[ArraySize - 2, j - 1].kingCanMove = false;
                                    if (j < 7)
                                        if (i > 1)
                                            _fields[i - 2, j + 1].kingCanMove = false;
                                        else
                                            _fields[ArraySize - 3, j + 1].kingCanMove = false;
                                    if (j > 1)
                                        if (i < ArraySize - 2)
                                            _fields[i + 1, j - 2].kingCanMove = false;
                                        else
                                            _fields[ArraySize - i, j - 2].kingCanMove = false;
                                    if (j < 6)
                                        if (i < ArraySize - 2)
                                            _fields[i + 1, j + 2].kingCanMove = false;
                                        else
                                            _fields[ArraySize - i, j + 2].kingCanMove = false;
                                    if (j > 0)
                                        if (i < ArraySize - 3)
                                            _fields[i + 2, j - 1].kingCanMove = false;
                                        else
                                            _fields[ArraySize - i + 2-1, j - 1].kingCanMove = false;
                                    if(j < 7)
                                    if (i < ArraySize-3)
                                        _fields[i + 2, j + 1].kingCanMove = false;
                                    else
                                        _fields[ArraySize-i-1, j + 1].kingCanMove = false;
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
                                    while (n < ArraySize-1 && m >= 0)
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
                                    while (n < ArraySize-1 && m <= 7)
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
    void spawnKing()
    {
        GameObject King;
        King = Instantiate(prefabs.getPrefabByID(100));
        King.transform.SetParent(gameObject.transform);
        King.AddComponent<King>();
        king = King.GetComponent<King>();
        king.x = 4;
        king.y = 2;
        King.transform.localPosition = new Vector3(1.3f * king.x - 3 * 1.3f - 0.65f, 0.65f, 1.3f * king.y);
        king.canvas = canvas;
        king.checkPrefab = prefabs.getPrefabByID(401);
    }
    public void changeSet(string setName)
    {
        switch (setName)
        {
            case "DefaultSet":
                {
                    DefaultSet = Instantiate(DefaultSet);
                    prefabs = DefaultSet.GetComponent<Prefabs>();
                    Destroy(DefaultSet);
                }
                break;
            case "VoxelSet":
                {
                    VoxelSet = Instantiate(VoxelSet);
                    prefabs = VoxelSet.GetComponent<Prefabs>();
                    Destroy(VoxelSet);
                }
                break;
        }
    }
}