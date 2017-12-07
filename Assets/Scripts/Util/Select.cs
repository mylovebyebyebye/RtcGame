using System.Collections;
using UnityEngine;
///每个能被操作的单位的触发器
public class Select : Selection
{
  NavMeshAgent agent;
  Animator animator;
  bool isMove;
  bool selected;
  Vector3 movePostion;
  public bool _selected { get { return selected; } }
  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    animator = GetComponent<Animator>();
  }
  public override void DeSetlect()
  {
    selected = false;
    RemoveHeightlight();
  }
  public override void Setlect()
  {
    selected = true;
    AddHightlight();
  }

  ///选中添加高亮组件
  void AddHightlight()
  {
    if (gameObject.GetComponent<SpectrumController>() == null)
    {
      gameObject.AddComponent<SpectrumController>();
    }
  }

  ///未选中取消高亮组件
  void RemoveHeightlight()
  {
    if (gameObject.GetComponent<SpectrumController>() != null)
    {
      Destroy(gameObject.GetComponent<SpectrumController>());
    }

    if (gameObject.GetComponent<HighlightableObject>() != null)
    {
      Destroy(gameObject.GetComponent<HighlightableObject>());

    }
  }

  ///移动至指定目标(默认设置距离限制，因为每个目标都会努力靠近目标地点)
  void MoveTo(Vector3 pos)
  {
    agent.SetDestination(pos);
    agent.Resume();
    animator.SetBool("run", true);
    isMove = true;
  }
  ///点击右键让单位自动寻路
  public void RightClick(Vector3? clickPostion)
  {
    if (selected)
    {
      var pos = clickPostion;
      if (pos.HasValue)
      {
        movePostion = pos.Value;
        MoveTo(movePostion);
      }
    }
  }
  void Update()
  {
    if (isMove && Vector3.Distance(movePostion, transform.position) < Const.MOVE_DISTANCE)
    {
      agent.Stop();
      animator.SetBool("run", false);
      isMove = false;
    }
  }
}