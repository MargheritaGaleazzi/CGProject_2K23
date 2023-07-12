using UnityEngine;


public class IdleState : StateMachineBehaviour
{
    private Transform attackWayPoint;
    private float distanceRangeMax = 20f;
    private string[] attacks = new string[]{"Punch","Kick"};
    private int randomNum;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackWayPoint=GameObject.FindGameObjectWithTag("AttackWayPoint").transform;
        //timer = 0;
        //randTime = Random.Range(1, 3);
        randomNum = Random.Range(0, attacks.Length+1);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Mathf.Abs(attackWayPoint.position.x-animator.transform.position.x);
        if (distance>0.5 && distance<distanceRangeMax)
        {
            animator.SetBool("IsWalking",true);
        }
        else
        {
            if (randomNum==2)
            {
                animator.SetBool("Block",true);
            }
            else{
            animator.transform.rotation=Quaternion.Euler(0f,269.445f,0f);
            animator.SetTrigger(attacks[randomNum]);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //     
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //   
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //}
}
