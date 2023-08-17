namespace Game.GamePlay.Upgrades
{
    public sealed class UpgradePurchaser
    {
        private IMoneyStorage _moneyStorage;

        public UpgradePurchaser(IMoneyStorage moneyStorage)
        {
            _moneyStorage = moneyStorage;
        }

        private bool CanPurchase(Upgrade upgrade)
        {
            if (upgrade.IsMaxLevel)
            {
                return false;
            }

            return _moneyStorage.CanSpendMoney(upgrade.NextPrice);
        }

        public bool TryPurchase(Upgrade upgrade)
        {
            if (CanPurchase(upgrade) == false)
            {
                return false;
            }
            
            _moneyStorage.SpendMoney(upgrade.NextPrice);
            upgrade.LevelUp();
            return true;
        }
    }
}