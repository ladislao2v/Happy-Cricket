using System;

namespace Code.Views.Players
{
    public interface IMovementService
    {
        void Run(int count, Action onRun);
    }
}