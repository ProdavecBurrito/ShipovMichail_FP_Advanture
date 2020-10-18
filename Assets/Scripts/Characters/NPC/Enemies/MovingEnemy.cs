using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace Shipov_FP_Adventure
{
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class MovingEnemy : BaseEnemy
    {
        #region Fields

        [SerializeField] protected Sword _sword;
        [SerializeField] protected List<Vector3> _wayPoints;
        [SerializeField] protected Transform _wayPointMain;
        [SerializeField] protected int _attackDamage;
        [SerializeField] protected float _patrolStopDistance;
        [SerializeField] protected float _pursuingStopDistance;
        [SerializeField] protected float _patrolMoveSpeed;
        [SerializeField] protected float _pursueMoveSpeed;
        [SerializeField] protected float _timeToWaitOnPoint;

        private int _pointCounter;

        #endregion


        #region UnityMethods

        protected override void Start()
        {
            base.Start();
            _attackDamage = _weaponData.Damage;
            _wayPoints = new List<Vector3>();
            _agentNavMesh = GetComponent<NavMeshAgent>();
            _agentNavMesh.stoppingDistance = _patrolStopDistance;
            AddPatrolPoints();
        }

        protected override void Update()
        {
            if (!_isPassive)
            {
                if (!die)
                {
                    base.Update();
                    CheckVisibleTargets();
                    CheckPatrol();
                }
            }
        }

        protected virtual void LateUpdate()
        {
            ReloadAttack();
        }

        #endregion


        #region Methods

        protected void CheckPatrol()
        {
            if (_isPatroling)
            {
                Patrol();
                CheckinMinDistanceToPlayer();
            }
        }

        protected virtual void Patrol()
        {
            _agentNavMesh.speed = _patrolMoveSpeed;
            _agentNavMesh.stoppingDistance = _patrolStopDistance;
            if (_wayPoints.Count > 1)
            {
                _animator.SetBool("Stop", false);
                _animator.SetBool("IsWalk", true);
                _agentNavMesh.SetDestination(_wayPoints[_pointCounter]);
                ChangeDestination();
            }
        }

        protected void ChangeDestination()
        {
            if (!_agentNavMesh.hasPath)
            {
                _animator.SetBool("IsWalk", false);
                _animator.SetBool("Stop", true);
                _currentTimeToWait += Time.deltaTime;
                if (_currentTimeToWait >= _timeToWaitOnPoint)
                {
                    _currentTimeToWait = 0;
                    if (_pointCounter < _wayPoints.Count - 1)
                    {
                        _pointCounter++;
                    }
                    else
                    {
                        _pointCounter = 0;
                    }
                }
            }
        }

        protected void SetDamage(IGetDamageable obj)
        {
            obj?.GetDamage(_attackDamage);
        }

        protected override void ReloadAttack()
        {
            if (!_canAttack)
            {
                _currentReload += Time.deltaTime;
                if (_currentReload >= _attackSpeed)
                {
                    _canAttack = true;
                    _currentReload = 0;
                }
            }
        }

        protected override void Die()
        {
            base.Die();
            die = true;
            _animator.SetTrigger("Die");
            _agentNavMesh.enabled = false;

        }

        public void GetWayPoint(Transform mainWayPoint)
        {
            _wayPointMain = mainWayPoint;
        }

        private void AddPatrolPoints()
        {
            foreach (Transform wayPoint in _wayPointMain)
            {
                _wayPoints.Add(wayPoint.position);
            }
        }

        protected override void CheckVisibleTargets()
        {
            if (_visibleTarget != null)
            {
                PursueTarget(_agrTarget);
            }
        }

        protected override void PursueTarget(Transform target)
        {
            base.PursueTarget(target);
            if ((transform.position - _agrTarget.position).sqrMagnitude < _pursuingStopDistance * _pursuingStopDistance)
            {
                _animator.SetBool("Stop", true);
                _animator.SetBool("IsRun", false);
                _animator.SetBool("IsWalk", false);
            }
            else
            {
                _animator.SetBool("IsRun", true);
                _animator.SetBool("IsWalk", false);
                _animator.SetBool("Stop", false);
            }
            _agentNavMesh.speed = _pursueMoveSpeed;
            _agentNavMesh.stoppingDistance = _pursuingStopDistance;
            _agentNavMesh.SetDestination(_agrTarget.position);
            CheckRangeForAttack();
        }

        private void CheckRangeForAttack()
        {
            if ((transform.position - _agrTarget.position).sqrMagnitude < _pursuingStopDistance * _pursuingStopDistance)
            {
                if (_canAttack)
                {
                    AttackTarget();
                }
            }
        }

        protected void AttackTarget()
        {
            _animator.SetBool("IsRun", false);
            _animator.SetTrigger("Attack");
            _canAttack = false;
        }

        #endregion
    }
}
