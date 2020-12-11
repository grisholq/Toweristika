using System;

namespace Toweristika.Ecs
{
    public class AddWayObjectEvent
    {
        public IMovable Moveable { get; set; }
        public Action Callback { get; set; }
    }
}