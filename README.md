#  Simple Game Ability System Framework

## 1. 소개
개요 : 
Unity에서 재사용 가능한 Ability 시스템을 구축하기 위해 설계된 데이터 기반(SO) Ability System 프레임워크 입니다.


목표 : 
- 다양한 게임에서 재사용 가능한 스킬 시스템 제공
- 코드 수정 없이 Ability를 조합으로 생성
- 로직과 연출의 완전한 분리
<br/>
구조 :
```text
Ability (ScriptableObject)
 ├── TargetSelector : 스킬의 대상(적, 아군, 범위 등)을 선정
 ├── Condition      : 스킬 발동을 위한 사전 조건 검사 (MP, 쿨타임 등)
 ├── Effect         : 실제 게임 로직 처리 (데미지, 버프, 상태 이상 등)
 └── Presentation   : 시각 및 청각적 연출 (이펙트, 사운드, 애니메이션)
```

---

## 2. 설치 방법
Realase v1.0을 다운받아 .unitypackage 파일을 import 하여 사용하면됩니다.

---

## 3. 파일 별 설명

| 파일명 | 역할 |
| :--- | :--- |
| **`Ability.cs`** | Ability의 모든 데이터를 정의하는 핵심 Scriptable Object(쿨타임, 타겟팅, 조건, 효과, 연출, 캐스팅 포함) |
| **`AbilityContext.cs`** | Ability 실행 시 필요한 실행 정보(caster, targets)를 전달하는 데이터 객체 |
| **`AbilityController.cs`** | Ability 사용의 진입점으로, 쿨타임 체크, 타겟 선정, 조건 검증 후 Ability 실행을 요청 |
| **`AbilityRunner.cs`** | Ability 실행 흐름을 담당(Cast Time -> Effect -> Presentation 순으로 처리) |
| **`Condition.cs`** | Ability 사용 가능 여부를 판단하는 조건 로직의 추상 클래스 (해당 클래스를 상속받아 여러 상황의 조건으로 생성 후 Ability에 적용) |
| **`Effect.cs`** | 특정 Ability가 실행될때 실제 게임 로직을 수행하는 추상 클래스 (해당 클래스를 상속받아 여러 Effect를 만들어 SO로 생성 후 Ability에 적용) |
| **`PresentationEffect.cs`** | 주로, 상호작용이 아닌 연출을 담당하는 Effect 추상 클래스 |
| **`TargetSelector.cs`** | Ability의 타겟을 선택하는 로직을 정의하는 추상클래스 (해당 클래스를 상속받아, singleTarget, muiltiTarget, areaTarget 등 여러 TargetSelector를 만들어 Ability에 적용) |
| **`CooldownHnadler.cs`** | Ability 별 쿨타임을 관리하는 내부 시스템 |
| **`AbilityEvent.cs`** | 외부에서 구독할 수 있는 이벤트로, Ability 사용 시 Invoke |

---

## 4. 사용 방법

### **1. AbilityController 컴포넌트 추가**
Ability를 사용할 GameObject에 AbilityController 컴포넌트를 추가합니다. (해당 컴포넌트의 Abilities에 2번에서 생성한 Ability를 추가)  
<img width="300" height="400" alt="Ability" src="https://github.com/user-attachments/assets/483d845b-93f9-4002-87b8-d4725568cdbd" />


### **2. Ability 생성 및 컨트롤러에 추가**
Ability를 생성하고, 생성된 Ability를 1번 내용의 Controller의 Abilities에 추가합니다.
<img width="400" height="400" alt="createability" src="https://github.com/user-attachments/assets/c178523d-b9e2-4108-85a5-a94387feede0" /> <img width="200" height="400" alt="AbilitySO" src="https://github.com/user-attachments/assets/88b6c8df-5e49-4bf0-abac-dee718e873e5" />
 <img width="300" height="100" alt="addability" src="https://github.com/user-attachments/assets/2cf5fc3e-7d6c-4148-87cd-19a1252d9910" />



### **3. TargetSelector 만들기**
TargetSelector.cs 를 상속하여 커스텀 TargetSelector 를 만든 후 Ability에 등록합니다. 
<img width="400" height="300" alt="exampleTargetSelector" src="https://github.com/user-attachments/assets/b87e57ae-fdf8-404a-9c3f-a5cadf9d76fb" /> <img width="400" height="300" alt="CreateTarget" src="https://github.com/user-attachments/assets/6f4d4680-3da7-41b3-8bb7-b619821c209d" />
<img width="200" height="100" alt="TargetSO" src="https://github.com/user-attachments/assets/94f31c12-56ff-4938-97e8-f09972b423c5" /> <img width="200" height="400" alt="Target_in_ability" src="https://github.com/user-attachments/assets/7f218971-80de-49f1-9715-268993b591df" />




### **4. Condition 만들기**
Condition.cs 를 상속하여 커스텀 Condition 를 만든 후 Ability에 등록합니다.  
<img width="400" height="100" alt="exampleCondition" src="https://github.com/user-attachments/assets/78a34e35-8cbe-4d48-bc9d-0c728d6074d4" /> <img width="400" height="300" alt="CreateCondition" src="https://github.com/user-attachments/assets/354b2b99-e13c-4cf2-a521-f07ef289abc4" /> <img width="200" height="150" alt="ConditionSO" src="https://github.com/user-attachments/assets/e93ff504-c692-42a5-9f2f-e3e4b35c4f23" /> <img width="200" height="340" alt="Condition_in_ABILITY" src="https://github.com/user-attachments/assets/aada426b-7872-42ff-aa68-8dd35ff82d3e" />
 
 



### **5. Effect 만들기**
Effect.cs 를 상속하여 커스텀 Effect 를 만든 후 Ability에 등록합니다.  
<img width="300" height="400" alt="EffectExample" src="https://github.com/user-attachments/assets/f20daac5-96c0-4abe-85c0-b3e93bc8307d" /> <img width="400" height="300" alt="CreateEffect" src="https://github.com/user-attachments/assets/96714d0b-5f45-48fe-b9d3-c2bc39de3523" /> 
<img width="200" height="100" alt="EffectSO" src="https://github.com/user-attachments/assets/088c5caa-f0eb-4f91-b687-d55e1a38b2fd" /> <img width="200" height="300" alt="effect_in_ability" src="https://github.com/user-attachments/assets/4e671c12-217f-41bd-8faa-3a210d972968" />




### **6. PresentationEffect 만들기**
PresentationEffect.cs 를 상속하여 커스텀 PresentationEffect 를 만든 후 Ability에 등록합니다.  
PresentationEffect 또한 5번의 Effect와 같은 과정으로 만들어 Ability에 등록하면 됩니다.


---

## 5. 사용 방법

- **AbilityController는 Ability 시스템의 실행 진입점이며, 플레이어, AI 오브젝트 등 모든 Ability 사용 주체에 공통적으로 사용됩니다.**
- **Ability 사용 시 AbilityController 객체의 TryUseAbility() 함수를 사용하면 됩니다.**
- **실 사용 예시 코드**
<details>
<summary>여기를 클릭해서 코드 보기(사용예시 1)</summary>

```csharp
public class PlayerAbilityInput : MonoBehaviour
{
    public AbilityController controller;
    public Ability ability;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Player의 Input을 통해 ability 사용
            controller.TryUseAbility(ability);
        }
    }
}
```
</details>

<details>
<summary>여기를 클릭해서 코드 보기(사용예시 2)</summary>

```csharp
public class MonsterAI : MonoBehaviour
{
    public AbilityController controller;
    public Ability attackAbility;

    void Update()
    {
        if (CanAttack())
        {
            // AI의 공격 가능 상황에서 ability 사용
            controller.TryUseAbility(attackAbility);
        }
    }

    bool CanAttack()
    {
        // 거리, 쿨타임, 상태 등 판단
        return true;
    }
}
```
</details>

<details>
<summary>여기를 클릭해서 코드 보기(사용예시 3)</summary>

```csharp
public class Turret : MonoBehaviour
{
    public AbilityController controller;
    public Ability fireAbility;

    public float interval = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            controller.TryUseAbility(fireAbility);
            timer = 0f;
        }
    }
}
```
</details>
---

## 6. 주의 사항 :
    
