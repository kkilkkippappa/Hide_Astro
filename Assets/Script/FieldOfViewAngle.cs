using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class FieldOfViewAngle : MonoBehaviour
{
      public float viewRadius;
      [Range(0, 360)]
      public float viewAngle;

      public LayerMask targetMask;
      public LayerMask obstacleMask;
      //있어야함, 왜냐면 타겟 사이에 다른 오브젝트가 있는데 그 오브젝트를 투과해서 뒤의 타겟오브젝트를 볼 수 있음 

      public List<Transform> visibleTargets = new List<Transform>();
      void Start()
      { //플레이 시 FindTargetsDelay 코루틴을 실행한다. 0.5초 간격으로 
            StartCoroutine("FindTargetsDelay", .5f);
            OnDrawGizmos();
      }

      IEnumerator FindTargetsDelay(float delay)
      {
            while (true)
            {
                  yield return new WaitForSeconds(delay);
                  FindTargets();
            }
      }
      void DrawFov()
      {

            Vector3 fromAnglePos = CirclePoint(-viewAngle * 0.5f);

            Handles.color = new Color(1, 0, 0, 0.2f);

            Handles.DrawWireDisc(transform.position,
                                Vector3.up,
                                viewRadius);

            //부책꼴의 색상을 지정
            Handles.DrawSolidArc(transform.position
                                                , Vector3.up
                                                , fromAnglePos
                                                , viewAngle
                                                , viewRadius);
            Handles.Label(transform.position + (transform.forward * 2.0f)
            , viewAngle.ToString());
      }
      void FindTargets()
      {
            Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

            for (int i = 0; i < targetInViewRadius.Length; i++)
            //ViewRadius 안에 있는 타겟의 개수 = 배열의 개수보다 i가 작을 때 for 실행 
            {
                  Transform target = targetInViewRadius[i].transform; //타겟[i]의 위치 
                  Vector3 dirToTarget = (target.position - transform.position).normalized;
                  //vector3타입의 타겟의 방향 변수 선언 = 타겟의 방향벡터, 타겟의 position - 이 게임오브젝트의 position) normalized 
                  if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
                  // 전방 벡터와 타겟방향벡터의 크기가 시야각의 1/2이면 = 시야각 안에 타겟 존재 
                  {
                        float dstToTarget = Vector3.Distance(transform.position, target.position); //타겟과의 거리를 계산 
                        if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                        //레이캐스트를 쐈는데 obstacleMask가 아닐 때 참이고 아래를 실행함 
                        {
                              visibleTargets.Add(target);
                              print("raycast hit!");
                              Debug.DrawRay(transform.position, dirToTarget * 10f, Color.red, 5f);
                        }
                  }
            }
      }
      public Vector3 CirclePoint(float angle)
      {
            angle += transform.eulerAngles.y;
            return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad),
            0,
            Mathf.Cos(angle * Mathf.Deg2Rad));
      }
      private void OnDrawGizmos()
      {
            Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, viewAngle / 2, viewRadius);
            Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -viewAngle / 2, viewRadius);
            Handles.color = new Color(1, 0, 0, 0.2f);
      }
}