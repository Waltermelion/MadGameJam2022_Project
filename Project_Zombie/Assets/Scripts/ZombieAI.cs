using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] float speed = 1.5f;
    [SerializeField] private GameObject Target;
    [SerializeField] private Animator m_animator = null;
    [SerializeField] private bool lookatplayer = true;
    
    [SerializeField] private GameObject spawner;
    
    public float health = 50f;

    void Update()
    {
        if (lookatplayer)
        {
            Vector3 targetposition = new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z);
            transform.LookAt(targetposition);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (health <= 0f)
        {
            lookatplayer = false;
            m_animator.SetFloat("MoveSpeed", 0);
            m_animator.SetTrigger("Dead");
            Invoke("Die", 3f);
        }
    }
    void OnMouseUp()
    {
        TakeDamage(10f);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            speed = 0f;
            m_animator.SetFloat("MoveSpeed", 0);
            m_animator.SetTrigger("Dead");
            Invoke("Die", 2f);
        }
    }

    void Die()
    {
        spawner.GetComponent<Spawner>().enemiesKilled += 1;
        Debug.Log(spawner.GetComponent<Spawner>().enemiesKilled);
        Destroy(gameObject);
    }
}
