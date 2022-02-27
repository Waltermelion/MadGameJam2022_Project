using UnityEngine;

public class Rotation : MonoBehaviour
{
    public bool night, hasRotated;
    [SerializeField] private GameObject directionallight;

    [SerializeField] private Quaternion nightV, dayV;


    void Start()
    {
        night = false;
        nightV = new Quaternion(0f, 90f, 90f, 90f);
        dayV = new Quaternion(15f,50f,-30f, 0f);
    }

    void Update()
    {
        if(night == true && hasRotated == false)
        {
            directionallight.transform.rotation = nightV;
            hasRotated = true;
        }
        else if(night == false && hasRotated == true)
        {
            directionallight.transform.rotation = dayV;
            hasRotated=false;
        }
    }
}