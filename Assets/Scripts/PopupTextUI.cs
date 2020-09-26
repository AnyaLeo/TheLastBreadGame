using UnityEngine;

public class PopupTextUI : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
    }
}
