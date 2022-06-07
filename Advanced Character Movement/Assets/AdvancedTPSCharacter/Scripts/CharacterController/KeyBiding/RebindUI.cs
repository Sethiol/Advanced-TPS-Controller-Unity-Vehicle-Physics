using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class RebindUI : MonoBehaviour
{
    [SerializeField]
    private InputActionReference inputActionReference; //this is on the SO

    [SerializeField]
    private bool excludeMouse = true;
    [Range(0, 10)]
    [SerializeField]
    private int selectedBinding;
    [SerializeField]
    private InputBinding.DisplayStringOptions displayStringOptions;
    [Header("Binding Info - DO NOT EDIT")]
    [SerializeField]
    private InputBinding inputBinding;
    private int bindingIndex;

    private string actionName;

    [Header("UI Fields")]
    [SerializeField]
    private TextMeshProUGUI actionText;
    [SerializeField]
    private Button rebindButton;
    [SerializeField]
    private TextMeshProUGUI rebindText;
    [SerializeField]
    private Button resetButton;

    private void OnEnable()
    {
        rebindButton.onClick.AddListener(() => DoRebind());
        resetButton.onClick.AddListener(() => ResetBinding());

        if (inputActionReference != null)
        {
            InputManager.LoadBindingOverride(actionName);
            GetBindingInfo();
            UpdateUI();
        }
        InputManager.rebindComplete += UpdateUI;

    }
    private void OnDestroy()
    {
        InputManager.rebindComplete -= UpdateUI;
    }
    private void OnValidate()
    {
        if (inputActionReference == null)
            return;

        GetBindingInfo();
        UpdateUI();
    }

    private void GetBindingInfo()
    {
        if (inputActionReference.action != null)
            actionName = inputActionReference.action.name;

        if (inputActionReference.action.bindings.Count > selectedBinding)
        {
            inputBinding = inputActionReference.action.bindings[selectedBinding];
            bindingIndex = selectedBinding;
        }
    }

    private void UpdateUI()
    {
        if (actionText != null)
            actionText.text = actionName;

        if (rebindText != null)
        {
            if (Application.isPlaying)
            {
                rebindText.text = InputManager.GetBindingName(actionName, bindingIndex);
                rebindText.text.ToUpper();
            }
            else
            {
                rebindText.text = inputActionReference.action.GetBindingDisplayString(bindingIndex);
                rebindText.text.ToUpper();
            }
        }
    }

    private void DoRebind()
    {
        InputManager.StartRebind(actionName, bindingIndex, rebindText, true);
    }

    private void ResetBinding()
    {
        InputManager.ResetBinding(actionName, bindingIndex);
        UpdateUI();
    }
}

