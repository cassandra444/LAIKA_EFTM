using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaikaAnimation : MonoBehaviour
{
    public Animator _laikaAnimator;
    int horizontal;
    int vertical;

    private void Awake()
    {
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    public void UpdateAnimatorValue(float p_horizontalMovement, float p_verticalMovement, bool p_isSprinting)
    {
        float snappedHorizontal;
        float snappedVertical;

        #region Snapped Horizontal
        if (p_horizontalMovement > 0f && p_horizontalMovement < 0.55f) snappedHorizontal = 0.5f;
        else if (p_horizontalMovement > 0.55f) snappedHorizontal = 1f;
        else if (p_horizontalMovement < 0f && p_horizontalMovement > -0.55f) snappedHorizontal = -0.5f;
        else if (p_horizontalMovement < -0.55f) snappedHorizontal = -1f;
        else snappedHorizontal = 0f;
        #endregion
        #region Snapped Vertical
        if (p_verticalMovement > 0f && p_verticalMovement < 0.55f) snappedVertical = 0.5f;
        else if (p_verticalMovement > 0.55f) snappedVertical = 1f;
        else if (p_verticalMovement < 0f && p_verticalMovement > -0.55f) snappedVertical = -0.5f;
        else if (p_verticalMovement < -0.55f) snappedVertical = -1f;
        else snappedVertical = 0f;
        #endregion

        if (p_isSprinting)
        {
            snappedHorizontal = p_horizontalMovement;
            snappedVertical = 2f;
        }

        _laikaAnimator.SetFloat(horizontal, snappedHorizontal, 0.1f,Time.deltaTime);
        _laikaAnimator.SetFloat(vertical, snappedVertical, 0.1f, Time.deltaTime);
    }

    public void PlayInteractAnim() 
    {
        _laikaAnimator.SetBool("IsInteracting", false);
    }
}
