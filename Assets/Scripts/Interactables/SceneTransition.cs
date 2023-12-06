using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToLevel(int levelIndex)
    {
        animator.SetTrigger("Fade_out");
    }
}
