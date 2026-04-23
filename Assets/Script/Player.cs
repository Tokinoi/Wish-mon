using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController _controller = null;
    [SerializeField] private InputActionReference _moveRef = null;
    [SerializeField] private InputActionReference _interactRef = null;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _interactRange = 2f;
    [SerializeField] private Animator _animator = null;

    private NPCCollider _currentNPC = null;

    private void Interact()
    {
        if (_currentNPC == null) return;
        _animator.SetTrigger("Yes");
        _currentNPC.OnInteract();
    }

    private void Update()
    {
        Vector2 move = _moveRef.action.ReadValue<Vector2>();
        bool isWalking = move.magnitude > 0.1f;
        _animator.SetBool("isWalking", isWalking);
        if (isWalking)
        {
            float angle = Mathf.Atan2(move.x, move.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            _controller.SimpleMove(transform.forward * _speed);
        }


        if (_interactRef.action.WasPressedThisFrame())
        {
            UpdateNPCDetection();
            Interact();
        }
    }

    private void UpdateNPCDetection()
    {
        NPCCollider detected = null;
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _interactRange))
            detected = hit.collider.GetComponent<NPCCollider>();

        if (detected == _currentNPC) return;

        _currentNPC = detected;
    }
}
