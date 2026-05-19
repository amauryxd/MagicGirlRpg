using UnityEngine;

public class VolumeChangerDungeon : MonoBehaviour
{
    public AudioSource musicSource;
    public Transform EndoPointo;
    public float maxDistance = 10f;
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            float distance = Vector3.Distance(collision.transform.position, EndoPointo.position);
            float volume = Mathf.Clamp01(1 - (distance / maxDistance));
            musicSource.volume = volume;
        }
    }
}
