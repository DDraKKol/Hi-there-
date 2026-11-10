namespace ModuleWork1
{
    public abstract class Transport
    {
        private string _name;
        private bool _isBusy;

        public string Name => _name;

        public bool IsBusy => _isBusy;

        public Transport(string name)
        {
            _name = name;
            _isBusy = false;
        }

        public abstract decimal CalculateCost(Order order);

        // За замовчуванням обмежень немає (їх не вказано в умові).
        public virtual bool CanTake(Order order)
        {
            return true;
        }

        public void Occupy()
        {
            _isBusy = true;
        }

        public void Release()
        {
            _isBusy = false;
        }
    }
}