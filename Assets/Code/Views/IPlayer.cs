using System;

namespace Code.Views
{
    public interface IPlayer
    {
        event Action Swung;
        void Swing();
    }
}