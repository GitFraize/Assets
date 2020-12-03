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
    public GameObject _000;
    public GameObject _101;
    public GameObject _102;
    public GameObject _103;
    public GameObject _104;
    public GameObject _105;

    public GameObject getPrefabByID(int id)
    {
        switch (id)
        {
            case 101: return _101;
            case 102: return _102;
            case 103: return _103;
            case 104: return _104;
            case 105: return _105;
            default: return _000;
        }
    }
}
