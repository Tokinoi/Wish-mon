using UnityEngine;
public class Wishemon : MonoBehaviour
{
    public WishemonState State { get; private set; }

    public void Initialize(WishemonState state)
    {
        State = state;

        GameObject model = Instantiate(State.Data.WishemonPrefab, transform);
        model.transform.localPosition = Vector3.zero;
        model.transform.localRotation = Quaternion.identity;
    }

    public void Initialize(WishemonData data)
    {
        Initialize(new WishemonState(data));
    }

}