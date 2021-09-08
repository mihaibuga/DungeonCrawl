﻿namespace DungeonCrawl.Actors.Items
{
    public abstract class Item : Actor
    {
        public bool SomethingAbove { get; private set; } = false;

        public abstract ItemType Type { get; }

        public abstract int Value { get; }

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        public void Hide()
        {
            SetSprite(1);
            SomethingAbove = true;
        }

        public void MakeVisible()
        {
            SetSprite(DefaultSpriteId);
            SomethingAbove = false;
        }

        /// <summary>
        ///     All items are drawn "above" floor etc
        /// </summary>
        public override int Z => -1;

        public Item Clone()
        {
            Item clone = Instantiate(this);
            clone.transform.localScale = new UnityEngine.Vector3(0, 0, 0);
            clone.name = this.name;
            return clone;
        }
    }
}
