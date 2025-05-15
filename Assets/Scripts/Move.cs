using UnityEngine;
using UnityEngine.AI;
using Zenject;


public class Move : MonoBehaviour
{
    private Player _player;
    private NavMeshAgent _agent;

    [Inject]
    public void Construct(Player player) 
    {
        _player = player;
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_player != null && _player.IsAlive) 
        {
            _agent.SetDestination(_player.transform.position);
        }
    }
}
