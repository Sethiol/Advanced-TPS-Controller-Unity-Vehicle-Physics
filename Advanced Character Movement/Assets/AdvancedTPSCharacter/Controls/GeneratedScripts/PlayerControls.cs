// GENERATED AUTOMATICALLY FROM 'Assets/AdvancedTPSCharacter/Controls/InputActions/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Keyboard"",
            ""id"": ""35e76f1a-73ad-4aad-a220-4c799e82245c"",
            ""actions"": [
                {
                    ""name"": ""Movement KeyBinds"",
                    ""type"": ""Value"",
                    ""id"": ""a3ad73c1-8963-40ae-937c-3545e5127613"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""1def6cb3-9b56-489a-8644-33a50075dfc8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""75fb3ac6-f944-4408-8218-2b006fb273c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e8fcee7e-c72f-4503-a5be-3dfbd0ce02d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Equip"",
                    ""type"": ""Button"",
                    ""id"": ""8307b32e-d0f7-4382-924b-442f14dc0235"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""6daefb05-3b51-4445-8dcf-f071fdf6803d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""52724c4c-dc14-4d02-aba0-b611fbe2aa9a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Holster&Equip"",
                    ""type"": ""Button"",
                    ""id"": ""a1c44331-0c2f-4d1b-9ba5-3d4890c92169"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""MoveThrough"",
                    ""type"": ""Button"",
                    ""id"": ""bc72296c-b3c8-4de8-925e-cc020b098ced"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""MoveBack"",
                    ""type"": ""Button"",
                    ""id"": ""a85a9ed4-aedc-45a0-a245-5d3310c40709"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""RemoveWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""6a5628fd-3b28-41b9-bf1d-e9b035548ffe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""88202cc3-062a-40c3-9842-650709659155"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""e6796a7a-6356-4c6a-8ae7-6bc6a06dc8f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""MoveVector"",
                    ""id"": ""744da326-a690-4391-aba5-7f84e60277ca"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement KeyBinds"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""74811f1e-16c3-4348-b16c-70a16140ca1a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement KeyBinds"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d40c1eee-ea38-4c76-b2e5-b3e908702244"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement KeyBinds"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cc8a47a4-30d2-42ce-ae38-40b0dd4b66c4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement KeyBinds"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a653345d-522c-4c27-83a3-e1ef4a6e42b2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement KeyBinds"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""PS4MoveVector"",
                    ""id"": ""8358d974-6ec9-416f-95c7-30af01e7b701"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement KeyBinds"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d74deb6a-f9d5-4660-a954-f955bd82af4d"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement KeyBinds"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""29985244-fea1-4963-899d-9e9536642a77"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement KeyBinds"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0389cb2e-a705-4616-927d-ce3deac85ec7"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement KeyBinds"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""feed838d-7bf7-45ab-b792-fba26a7b152d"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement KeyBinds"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""XboxVector"",
                    ""id"": ""80d86f42-d9e3-4d1e-a441-55d4ceb8507f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement KeyBinds"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0249e5d3-e737-4b47-bd8e-f02a2fea88f5"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement KeyBinds"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""28c704ca-654e-4136-b3b8-43c6f7e4866a"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement KeyBinds"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cd8816d8-7649-4394-ae77-06bb47b8b79d"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement KeyBinds"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1a9c49ca-16ef-4f33-97f2-cb3b0a323e13"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement KeyBinds"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""80ef3816-8fb8-4eca-9fe6-5e3cfe25cc13"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0aaceb7-f7cd-4ee4-800f-0340fe88cc6d"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45127ec9-eec6-43c4-8456-3fee40804f82"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89ad697f-fcee-4630-8c10-a41d71f40b11"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a73b5232-e126-4cc6-a720-b7b41107dbb7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10a982cc-a5fb-4209-81e2-0f250b52cc5c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecf5bf74-e27c-45ad-8262-3f3df362642e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Equip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3705160c-5fa2-410c-a7c9-c1773f1b0dee"",
                    ""path"": ""<DualShockGamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Equip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17d4c27c-05cd-4392-a189-1b23a0ef4aba"",
                    ""path"": ""<XInputController>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Equip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0da26913-b3e8-49fb-96e2-f2ef1658439e"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee2509bf-e2c9-415a-b877-4c9926d325dd"",
                    ""path"": ""<DualShockGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b838ebac-466a-4fcb-8e30-cc41ec72dd2c"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1d561d7-af7e-44a1-8046-805367da74b3"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3801f39b-e524-457a-a552-8868bfc9afaa"",
                    ""path"": ""<DualShockGamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cc90c98-af0d-4f10-a63d-2ccc3bf5ccc6"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b0edd9e-14be-4fbf-9e72-fbbdabe542d6"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Holster&Equip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04fb0f62-d88d-4f81-a9b9-36b930edc080"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Holster&Equip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e207c56-8f52-42ef-a2a5-047b3e6a7899"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Holster&Equip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0116d04f-034c-468f-815c-e7346756719b"",
                    ""path"": ""<DualShockGamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveThrough"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6f8daca-7f2e-4796-b41f-0884d47eb0f7"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveThrough"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""923783fc-ec94-45f5-8245-ded8df194e2d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveThrough"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbbcb670-1e71-47c5-98cd-8503d351f885"",
                    ""path"": ""<DualShockGamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66511872-2f7d-41b9-80b3-63e597ae84a3"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f82166a-874f-4dcb-b045-72928b5989ad"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RemoveWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c34ea25-a5da-4c2f-9e4c-657b1d03f03e"",
                    ""path"": ""<DualShockGamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RemoveWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a9b83dc-2309-4577-9f10-e659941bd9ab"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RemoveWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ce85c1c-7632-4f7e-8c97-a8a838fc5a84"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df3a978d-b5dd-470a-b8bd-e221deeae09d"",
                    ""path"": ""<DualShockGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10db0b12-269b-49df-9b95-2b83dcdae016"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7c59727-a96d-4fcc-ab4b-65aa19086ecd"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5889bba7-c6fd-4486-bb26-f8e2f91a967d"",
                    ""path"": ""<DualShockGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85dc2e55-57c9-4f3c-9d82-6977f79e8402"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""af9c3db3-1e2d-4a34-9ce3-cceae23234a5"",
            ""actions"": [],
            ""bindings"": []
        },
        {
            ""name"": ""Car"",
            ""id"": ""956dcfef-56c1-4b04-9e4f-7724ce48aaee"",
            ""actions"": [
                {
                    ""name"": ""Braking"",
                    ""type"": ""Value"",
                    ""id"": ""28fa84a7-c864-408f-b87d-6f3aeac559c4"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""Value"",
                    ""id"": ""b5c478dd-c7f8-4590-8599-6d2a1c310b5b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Value"",
                    ""id"": ""994c0cf3-668d-4462-9ecc-23a3a3abf8df"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ExitVehicle"",
                    ""type"": ""Button"",
                    ""id"": ""bc98ba12-54ae-4b1f-b286-10aa49c81d7d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleView"",
                    ""type"": ""Button"",
                    ""id"": ""9d184c71-a35b-40e3-890d-b1f326c9dfc3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bee7703a-5609-4354-be6c-c1ae1718c89f"",
                    ""path"": ""<DualShockGamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Braking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be7fb6ab-d5fe-43f1-913f-046d5edaac6c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Braking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""PS4 Move Horizontal Vector"",
                    ""id"": ""13f8eb15-93b8-46b9-9bf7-060cb610c4b9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""98b20eb5-71a7-4ea0-9130-77dff03fb3e2"",
                    ""path"": ""<DualShockGamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""863c4662-9f5f-4e51-9837-e89c654b4887"",
                    ""path"": ""<DualShockGamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard Move Horizontal Vector"",
                    ""id"": ""34aa8421-127b-4128-80b4-31cdd8f39759"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b8307a5f-1a19-4615-bbe2-d087b0562ed4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b79a9d9f-d8b4-43c2-a5f2-c1ee49f2f24b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard Vertical Vector"",
                    ""id"": ""08a83a25-0a5e-48e5-a9a3-0f099329fda1"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ecf0029f-4fc5-4c74-8ed6-e2ab33b8ef9e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2c07d0ef-0f8f-40bb-9313-4301497086ec"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""PS4 Vertical Vector"",
                    ""id"": ""a22cd67c-dec6-4985-8a42-f478592900c3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7ed61acb-905e-4dfc-87bd-33e3ba5cf529"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5d4087cd-8b63-4673-b9dc-bc09416e071d"",
                    ""path"": ""<DualShockGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""89b4419b-4bb0-460a-9bb3-98dd026c9b24"",
                    ""path"": ""<DualShockGamepad>/buttonNorth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExitVehicle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2938958-15cc-4fbe-9dac-689b1e5231be"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExitVehicle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a4fb262-ee33-4afa-906d-bbf35f675045"",
                    ""path"": ""<DualShockGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleView"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bee22f02-1e1b-4e46-baf8-b0b3b25e40b3"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleView"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_MovementKeyBinds = m_Keyboard.FindAction("Movement KeyBinds", throwIfNotFound: true);
        m_Keyboard_Sprint = m_Keyboard.FindAction("Sprint", throwIfNotFound: true);
        m_Keyboard_Crouch = m_Keyboard.FindAction("Crouch", throwIfNotFound: true);
        m_Keyboard_Jump = m_Keyboard.FindAction("Jump", throwIfNotFound: true);
        m_Keyboard_Equip = m_Keyboard.FindAction("Equip", throwIfNotFound: true);
        m_Keyboard_Escape = m_Keyboard.FindAction("Escape", throwIfNotFound: true);
        m_Keyboard_Aim = m_Keyboard.FindAction("Aim", throwIfNotFound: true);
        m_Keyboard_HolsterEquip = m_Keyboard.FindAction("Holster&Equip", throwIfNotFound: true);
        m_Keyboard_MoveThrough = m_Keyboard.FindAction("MoveThrough", throwIfNotFound: true);
        m_Keyboard_MoveBack = m_Keyboard.FindAction("MoveBack", throwIfNotFound: true);
        m_Keyboard_RemoveWeapon = m_Keyboard.FindAction("RemoveWeapon", throwIfNotFound: true);
        m_Keyboard_Shoot = m_Keyboard.FindAction("Shoot", throwIfNotFound: true);
        m_Keyboard_Reload = m_Keyboard.FindAction("Reload", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        // Car
        m_Car = asset.FindActionMap("Car", throwIfNotFound: true);
        m_Car_Braking = m_Car.FindAction("Braking", throwIfNotFound: true);
        m_Car_Vertical = m_Car.FindAction("Vertical", throwIfNotFound: true);
        m_Car_Horizontal = m_Car.FindAction("Horizontal", throwIfNotFound: true);
        m_Car_ExitVehicle = m_Car.FindAction("ExitVehicle", throwIfNotFound: true);
        m_Car_ToggleView = m_Car.FindAction("ToggleView", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_MovementKeyBinds;
    private readonly InputAction m_Keyboard_Sprint;
    private readonly InputAction m_Keyboard_Crouch;
    private readonly InputAction m_Keyboard_Jump;
    private readonly InputAction m_Keyboard_Equip;
    private readonly InputAction m_Keyboard_Escape;
    private readonly InputAction m_Keyboard_Aim;
    private readonly InputAction m_Keyboard_HolsterEquip;
    private readonly InputAction m_Keyboard_MoveThrough;
    private readonly InputAction m_Keyboard_MoveBack;
    private readonly InputAction m_Keyboard_RemoveWeapon;
    private readonly InputAction m_Keyboard_Shoot;
    private readonly InputAction m_Keyboard_Reload;
    public struct KeyboardActions
    {
        private @PlayerControls m_Wrapper;
        public KeyboardActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementKeyBinds => m_Wrapper.m_Keyboard_MovementKeyBinds;
        public InputAction @Sprint => m_Wrapper.m_Keyboard_Sprint;
        public InputAction @Crouch => m_Wrapper.m_Keyboard_Crouch;
        public InputAction @Jump => m_Wrapper.m_Keyboard_Jump;
        public InputAction @Equip => m_Wrapper.m_Keyboard_Equip;
        public InputAction @Escape => m_Wrapper.m_Keyboard_Escape;
        public InputAction @Aim => m_Wrapper.m_Keyboard_Aim;
        public InputAction @HolsterEquip => m_Wrapper.m_Keyboard_HolsterEquip;
        public InputAction @MoveThrough => m_Wrapper.m_Keyboard_MoveThrough;
        public InputAction @MoveBack => m_Wrapper.m_Keyboard_MoveBack;
        public InputAction @RemoveWeapon => m_Wrapper.m_Keyboard_RemoveWeapon;
        public InputAction @Shoot => m_Wrapper.m_Keyboard_Shoot;
        public InputAction @Reload => m_Wrapper.m_Keyboard_Reload;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @MovementKeyBinds.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMovementKeyBinds;
                @MovementKeyBinds.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMovementKeyBinds;
                @MovementKeyBinds.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMovementKeyBinds;
                @Sprint.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSprint;
                @Crouch.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnCrouch;
                @Jump.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnJump;
                @Equip.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnEquip;
                @Equip.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnEquip;
                @Equip.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnEquip;
                @Escape.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnEscape;
                @Aim.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnAim;
                @HolsterEquip.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnHolsterEquip;
                @HolsterEquip.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnHolsterEquip;
                @HolsterEquip.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnHolsterEquip;
                @MoveThrough.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMoveThrough;
                @MoveThrough.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMoveThrough;
                @MoveThrough.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMoveThrough;
                @MoveBack.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMoveBack;
                @MoveBack.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMoveBack;
                @MoveBack.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMoveBack;
                @RemoveWeapon.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRemoveWeapon;
                @RemoveWeapon.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRemoveWeapon;
                @RemoveWeapon.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRemoveWeapon;
                @Shoot.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnShoot;
                @Reload.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnReload;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovementKeyBinds.started += instance.OnMovementKeyBinds;
                @MovementKeyBinds.performed += instance.OnMovementKeyBinds;
                @MovementKeyBinds.canceled += instance.OnMovementKeyBinds;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Equip.started += instance.OnEquip;
                @Equip.performed += instance.OnEquip;
                @Equip.canceled += instance.OnEquip;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @HolsterEquip.started += instance.OnHolsterEquip;
                @HolsterEquip.performed += instance.OnHolsterEquip;
                @HolsterEquip.canceled += instance.OnHolsterEquip;
                @MoveThrough.started += instance.OnMoveThrough;
                @MoveThrough.performed += instance.OnMoveThrough;
                @MoveThrough.canceled += instance.OnMoveThrough;
                @MoveBack.started += instance.OnMoveBack;
                @MoveBack.performed += instance.OnMoveBack;
                @MoveBack.canceled += instance.OnMoveBack;
                @RemoveWeapon.started += instance.OnRemoveWeapon;
                @RemoveWeapon.performed += instance.OnRemoveWeapon;
                @RemoveWeapon.canceled += instance.OnRemoveWeapon;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    public struct MenuActions
    {
        private @PlayerControls m_Wrapper;
        public MenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);

    // Car
    private readonly InputActionMap m_Car;
    private ICarActions m_CarActionsCallbackInterface;
    private readonly InputAction m_Car_Braking;
    private readonly InputAction m_Car_Vertical;
    private readonly InputAction m_Car_Horizontal;
    private readonly InputAction m_Car_ExitVehicle;
    private readonly InputAction m_Car_ToggleView;
    public struct CarActions
    {
        private @PlayerControls m_Wrapper;
        public CarActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Braking => m_Wrapper.m_Car_Braking;
        public InputAction @Vertical => m_Wrapper.m_Car_Vertical;
        public InputAction @Horizontal => m_Wrapper.m_Car_Horizontal;
        public InputAction @ExitVehicle => m_Wrapper.m_Car_ExitVehicle;
        public InputAction @ToggleView => m_Wrapper.m_Car_ToggleView;
        public InputActionMap Get() { return m_Wrapper.m_Car; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarActions set) { return set.Get(); }
        public void SetCallbacks(ICarActions instance)
        {
            if (m_Wrapper.m_CarActionsCallbackInterface != null)
            {
                @Braking.started -= m_Wrapper.m_CarActionsCallbackInterface.OnBraking;
                @Braking.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnBraking;
                @Braking.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnBraking;
                @Vertical.started -= m_Wrapper.m_CarActionsCallbackInterface.OnVertical;
                @Vertical.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnVertical;
                @Vertical.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnVertical;
                @Horizontal.started -= m_Wrapper.m_CarActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnHorizontal;
                @ExitVehicle.started -= m_Wrapper.m_CarActionsCallbackInterface.OnExitVehicle;
                @ExitVehicle.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnExitVehicle;
                @ExitVehicle.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnExitVehicle;
                @ToggleView.started -= m_Wrapper.m_CarActionsCallbackInterface.OnToggleView;
                @ToggleView.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnToggleView;
                @ToggleView.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnToggleView;
            }
            m_Wrapper.m_CarActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Braking.started += instance.OnBraking;
                @Braking.performed += instance.OnBraking;
                @Braking.canceled += instance.OnBraking;
                @Vertical.started += instance.OnVertical;
                @Vertical.performed += instance.OnVertical;
                @Vertical.canceled += instance.OnVertical;
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @ExitVehicle.started += instance.OnExitVehicle;
                @ExitVehicle.performed += instance.OnExitVehicle;
                @ExitVehicle.canceled += instance.OnExitVehicle;
                @ToggleView.started += instance.OnToggleView;
                @ToggleView.performed += instance.OnToggleView;
                @ToggleView.canceled += instance.OnToggleView;
            }
        }
    }
    public CarActions @Car => new CarActions(this);
    public interface IKeyboardActions
    {
        void OnMovementKeyBinds(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnEquip(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnHolsterEquip(InputAction.CallbackContext context);
        void OnMoveThrough(InputAction.CallbackContext context);
        void OnMoveBack(InputAction.CallbackContext context);
        void OnRemoveWeapon(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
    }
    public interface ICarActions
    {
        void OnBraking(InputAction.CallbackContext context);
        void OnVertical(InputAction.CallbackContext context);
        void OnHorizontal(InputAction.CallbackContext context);
        void OnExitVehicle(InputAction.CallbackContext context);
        void OnToggleView(InputAction.CallbackContext context);
    }
}
