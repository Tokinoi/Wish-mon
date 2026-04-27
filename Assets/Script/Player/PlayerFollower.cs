using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Player _player;// Reference to the player's transform
    [SerializeField] private Vector3 _offset = Vector3.zero; // Distance to maintain from the player

    void Update()
    {
        transform.position = _player.transform.position + _offset; // Update position to follow the player
    }
}