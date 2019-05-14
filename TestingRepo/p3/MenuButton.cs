using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {

    [SerializeField] MainMenuController mainMenuController;
    [SerializeField] Animator animator;
    //[SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;
    
	
	// Update is called once per frame
	void Update () {
		if(mainMenuController.index == thisIndex)
        {
            animator.SetBool("selected", true);
            if(Input.GetAxis("Submit") == 1){
                animator.SetBool("pressed", true);
            }else if (animator.GetBool("pressed")){
                animator.SetBool("pressed", false);
            //    animatorFunctions.disableOnce = true;
            }
        }
        else {
            animator.SetBool("selected", false);
        }

	}


    public void animateSelected()
    {
        animator.SetBool("selected", true);
    }
    public void animatePressed()
    {
        animator.SetBool("pressed", true);
    }
    public void animateDeselect()
    {
        animator.SetBool("pressed", false);
        animator.SetBool("selected", false);
    }
}
