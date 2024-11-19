using Boootstrapp.GameFSM.GunsConfigs;
using Boootstrapp.GameFSM.Screens;
using Boootstrapp.GameFSM.Screens.ShopScreen;
using Boootstrapp.GameFSM.States;
using GameFSM.Screens;
using GameFSM.Screens.ShopScreen;
using GameFSM.States;
using UnityEngine;

public class ShopScreen : BaseScreen
{
    [SerializeField] private GunsData _gunsConfigs;
    [SerializeField] private UpdateContent _updateContent;
    [SerializeField] private ShopContent _shopContent;
    [SerializeField] private Transform _transform;


    private BaseContent _instanceContent;

    public override void Init()
    {
        base.Init();
        InstanceContent(_shopContent);
    }

    public void BackMenu()
    {
        SoundManager.PlayButtonClick();
        GameStateMashine.Enter<MenuState>();
    }

    private void OpenShopScreen()
    {
        SoundManager.PlayButtonClick();
        InstanceContent(_shopContent);
    }

    private void OpenUpdateScreen()
    {
        SoundManager.PlayButtonClick();
        InstanceContent(_updateContent);
    }


    private void InstanceContent(BaseContent content)
    {
        DestroyContent();

        _instanceContent = Instantiate(content, _transform);
        _instanceContent.ButtonShop.onClick.AddListener(OpenShopScreen);
        _instanceContent.ButtonUpdate.onClick.AddListener(OpenUpdateScreen);
        _instanceContent.Init();
    }

    private void DestroyContent()
    {
        if (_instanceContent != null)
        {
            _instanceContent.ButtonShop.onClick.RemoveListener(OpenShopScreen);
            _instanceContent.ButtonUpdate.onClick.RemoveListener(OpenUpdateScreen);
            Destroy(_instanceContent.gameObject);
        }
    }
}