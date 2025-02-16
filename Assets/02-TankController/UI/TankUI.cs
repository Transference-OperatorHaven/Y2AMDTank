using UnityEngine;
using UnityEngine.UIElements;

public class TankUI : MonoBehaviour
{
    TankController m_Controller;
    TankSO m_Data;
    Barrel m_barrel;

    private VisualElement m_Root;
    private VisualElement m_BottomContainer;
    private VisualElement m_BottomLeftContainer;
    private VisualElement m_BottomRightContainer;
    private VisualElement m_TopContainer;
    private VisualElement m_TopRightContainer;
    private UIDocument m_Document;
    Label m_AmmoText;
    Label m_MoveText;
    Label m_HealthText;

    public void Init(TankController controller)
    {
        m_Controller = controller; 
        m_barrel = controller.GetComponent<Barrel>();
        m_Data = m_Controller.getData();
    }

    private void Start()
    {
        m_Document = GetComponent<UIDocument>();
        m_Root = m_Document.rootVisualElement;
        m_TopContainer = m_Root.Q<VisualElement>(name: "top");
        m_BottomContainer = m_Root.Q<VisualElement>(name: "bottom");
        m_BottomLeftContainer = m_BottomContainer.Q<VisualElement>(name: "left");
        m_BottomRightContainer = m_BottomContainer.Q<VisualElement>(name: "right");
        m_TopRightContainer = m_TopContainer.Q<VisualElement>(name: "right");


        m_AmmoText = m_BottomLeftContainer.Q<Label>(name: "ammo");
        m_MoveText = m_BottomRightContainer.Q<Label>(name: "move");
        m_HealthText = m_TopRightContainer.Q<Label>(name: "health");
    }

    private void Update()
    {
        m_AmmoText.text = $"Ammo: {m_barrel.m_AmmoCounts[m_barrel.m_SelectedShell]} / {m_barrel.m_AmmoTypes[m_barrel.m_SelectedShell].maxAmmo}";
        m_HealthText.text = $"{m_Controller.m_CurrentHealth} / {m_Data.Health}";
        if (m_Controller.m_DriveWheels[0].m_Acceleration == 1)
        {
            if (m_Controller.m_DriveWheels[1].m_Acceleration == 1)
            {
                m_MoveText.text = "Forward";
            }
        }
        else
        {
            if (m_Controller.m_DriveWheels[1].m_Acceleration == 1.5f)
            {
                m_MoveText.text = "Left turn";
            }
            else if (m_Controller.m_DriveWheels[0].m_Acceleration == 1.5f)
            {
                m_MoveText.text = "Right Turn";
            }
            else if (m_Controller.m_DriveWheels[1].m_Acceleration == -1)
            {
                m_MoveText.text = "Reverse";
            }
            else
            {
                m_MoveText.text = "Idle";
            }
        }

    }
}
