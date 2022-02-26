using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] float speed = 1.5f;
    [SerializeField] private GameObject Target;

    void Update()
    {
        Vector3 targetposition = new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z);
        transform.LookAt(targetposition);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
