using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int y;
    

    private void OnMouseDown()
    {
        GameManager.Instance.ClickedOnGridPositionRpc(x, y, GameManager.Instance.GetLocalPlayerType());
    }
}
