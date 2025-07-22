using System;

namespace AccountOpening
{
    public class NavigationService
    {
        public event Action<int>? OnNavigateToStep;
        
        public void NavigateToStep(int step)
        {
            OnNavigateToStep?.Invoke(step);
        }
    }
}
