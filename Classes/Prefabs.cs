using UnityEngine;

public class Prefabs : MonoBehaviour
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
    public GameObject _201;
    public GameObject _001;
    public GameObject _002;
    public GameObject _101;
    public GameObject _102;
    public GameObject _103;
    public GameObject _104;
    public GameObject _105;

    public GameObject getPrefabByID(int id)
    {
        switch (id)
        {
            case 1: return _001;
            case 2: return _002;
            case 101: return _101;
            case 102: return _102;
            case 103: return _103;
            case 104: return _104;
            case 105: return _105;
            case 201: return _201;
            default: return _001;
        }
    }
}
