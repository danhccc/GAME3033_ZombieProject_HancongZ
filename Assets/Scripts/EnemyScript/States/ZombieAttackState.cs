using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackState : ZombieStates
{
    GameObject followTarget;
    float attackRange = 2;

    int movementZhash = Animator.StringToHash("MovementZ");
    int isAttackinghash = Animator.StringToHash("isAttacking");

    private IDamageable damageableObject;

    public ZombieAttackState(GameObject _followTarget, ZombieComponent zombie, ZombieStateMachine stateMachine) : base (zombie, stateMachine)
    {
        followTarget = _followTarget;
        updateInterval = 2f;

        // Set damageable object here, ADD LATER
        damageableObject = followTarget.GetComponent<IDamageable>();
    }

    // Start is called before the first frame update
    public override void Start()
    {
        // base.Start()
        ownerZombie.zombieNavMeshAgent.isStopped = true;
        ownerZombie.zombieNavMeshAgent.ResetPath();
        ownerZombie.zombieAnimator.SetFloat(movementZhash, 0);
        ownerZombie.zombieAnimator.SetBool(isAttackinghash, true);
    }

    public override void IntervalUpdate()
    {
        base.Update();
        damageableObject?.TakeDamage(ownerZombie.zombieDamage);


        //ownerZombie.transform.LookAt(followTarget.transform.position, Vector3.up);
        //ownerZombie.zombieAnimator.SetBool(isAttackinghash, true);

        //float distanceBetween = Vector3.Distance(ownerZombie.transform.position, followTarget.transform.position);
        //if (distanceBetween > attackRange)
        //{
        //    // Change state to following here
        //    stateMachine.ChangeState(ZombieStateType.Following);
        //}
    }

    public override void Exit()
    {
        base.Exit();

        ownerZombie.zombieNavMeshAgent.isStopped = false;
        ownerZombie.zombieAnimator.SetBool(isAttackinghash, false);
    }
}
