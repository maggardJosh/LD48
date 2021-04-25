using UnityEngine;

public class Door : MonoBehaviour
{
    public void Open()
    {
        GetComponent<Animator>().SetBool("Dying", true);
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject, 2f);
    }
}