using Code.UI.Shop;

namespace Code.StateMachine.States
{
    public class ShopState : IState
    {
        private readonly ShopOverlay _shopOverlay;

        public ShopState(ShopOverlay shopOverlay)
        {
            _shopOverlay = shopOverlay;
        }
        public void Enter()
        {
            _shopOverlay.Load();
            _shopOverlay.Show();
        }

        public void Exit()
        {
            _shopOverlay.Hide();
        }
    }
}