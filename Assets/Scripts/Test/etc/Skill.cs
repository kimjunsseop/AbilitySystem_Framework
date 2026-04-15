using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField]
    private string skillName;
    [SerializeField]
    private float maxCooldownTime;
    [SerializeField]
    private TextMeshProUGUI textSkillData;
    [SerializeField]
    private TextMeshProUGUI textCooldownTime;
    [SerializeField]
    private Image imageCooldownTime;

    private float currentCooldownTime;
    private bool isCooldown;


    private void Awake()
    {
        SetCooldownIs(false);
    }

    //외부에서 스킬을 사용할 때 호출하는 메소드
    public void UseSkill()
    {
        //이미 스킬을 사용해서 재사용 대기 시간이 남아있으면 종료
        if(isCooldown  == true)
        {
            textSkillData.text = $"[{skillName}] Cooldown Time : {currentCooldownTime:F1}";
            return;
        }

        textSkillData.text = $"Use Skill : {skillName}";
        StartCoroutine(nameof(OnCooldownTime), maxCooldownTime);
    }
    //실제 스킬의 재사용 대기 시간을 제어하는 코루틴 메소드
    private IEnumerator OnCooldownTime(float maxCooldownTime)
    {
        //스킬 재사용 대기 시간 저장
        currentCooldownTime = maxCooldownTime;
        SetCooldownIs(true);

        while(currentCooldownTime > 0)
        {
            currentCooldownTime -= Time.deltaTime;
            //Image UI의 fillAmount를 조절해 채워지는 이미지 모양 설정
            imageCooldownTime.fillAmount = currentCooldownTime / maxCooldownTime;
            //Text UI에 쿨다운 시간 표시
            textCooldownTime.text = currentCooldownTime.ToString("F1");
            yield return null;
        }

        SetCooldownIs(false);

    }


    private void SetCooldownIs(bool boolean)
    {
        isCooldown = boolean;
        textCooldownTime.enabled = boolean;
        imageCooldownTime.enabled = boolean;
    }
}