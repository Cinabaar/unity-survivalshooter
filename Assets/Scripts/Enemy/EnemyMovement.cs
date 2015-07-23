using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform _player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent _nav;


    void Awake ()
    {
        _player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = _player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        _nav = GetComponent <NavMeshAgent> ();
    }


    void Update ()
    {
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            _nav.SetDestination (_player.position);
        }
        else
        {
            _nav.enabled = false;
        }
    }
}
