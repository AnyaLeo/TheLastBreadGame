using UnityEngine;

/*
 * Handles spawning a popup with animation
 * and destroys the animation after the animation is done.
 * The PopupUI is attached to the parent of the actual animation component
 * because animator will use the absolute position for the animation.
 */ 
public class PopupUI : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
    }
}
