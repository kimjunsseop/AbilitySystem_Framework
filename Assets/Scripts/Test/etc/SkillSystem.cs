using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillSystem : MonoBehaviour
{
    [SerializeField]
    private GraphicRaycaster graphicRaycaster;
    [SerializeField]
    private Skill[] skills;

    private List<RaycastResult> raycastResults;
    private PointerEventData pointerEventData;

    private void Awake()
    {
        raycastResults = new List<RaycastResult>();
        pointerEventData = new PointerEventData(null);
    }

    private void Update()
    {
        if (!Input.anyKeyDown) return;

        // 1 ~ skills.Length 숫자키를 눌러 스킬 시전
        if (int.TryParse(Input.inputString, out int key) && (key >= 1 && key <= skills.Length))
        {
            skills[key - 1].UseSkill();
        }

        // 스킬 아이콘을 마우스로 클릭해서 스킬 시전
        if (Input.GetMouseButtonDown(0))
        {
            raycastResults.Clear();

            pointerEventData.position = Input.mousePosition;
            graphicRaycaster.Raycast(pointerEventData, raycastResults);

            if (raycastResults.Count > 0)
            {
                // 마우스로 클릭한 오브젝트에 "Skill" 컴포넌트가 있는지 확인
                // Skill 컴포넌트가 없으면 실행 X. Skill 컴포넌트가 있으면 skill 변수에 저장 후 조건문 내부에서 메소드 실행
                if (raycastResults[0].gameObject.TryGetComponent<Skill>(out var skill))
                {
                    skill.UseSkill();
                }
            }
        }
    }
}
