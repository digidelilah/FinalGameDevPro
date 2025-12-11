using UnityEngine;

public class MenuCharacter : MonoBehaviour
{
   // public float speed = 2f;
    private Animator animator;
    //public Transform point;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Menu_Idle");
    }
}
