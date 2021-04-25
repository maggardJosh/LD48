using UnityEngine;

public class Door : MonoBehaviour
{
    public void Open()
    {
        AudioManager.PlayOneShot(AudioClips.Instance.DoorOpen);
        GetComponent<Animator>().SetBool("Dying", true);
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject, 2f);
    }
}