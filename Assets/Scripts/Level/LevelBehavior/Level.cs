using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Level
{
    public class LevelBehavior
    {
        private LevelBehavior parent;
        private List<LevelBehavior> children = new List<LevelBehavior>();
        private LevelBehaviorType type = LevelBehaviorType.Action;
        private Action action;
        private bool condition = true;
        private bool isFinish = false;
        private float Delay;

        public LevelBehavior OnFixedUpdate()
        {
            if (isFinish)
            {
                return ReturnChild();
            }


            switch (type)
            {
                case LevelBehaviorType.Action:
                    return OnAction();
                case LevelBehaviorType.Delay:
                    return OnDelay();
                case LevelBehaviorType.Condition:
                    return OnCondition();
                default: return OnAction();
            }
        }

        private LevelBehavior OnCondition()
        {
            if (!condition)
            {
                return null;
            }

            return ReturnChild();
        }

        private LevelBehavior OnAction()
        {
            action?.Invoke();
            isFinish = true;
            return this;
        }


        private LevelBehavior OnDelay()
        {
            if (Delay > 0)
            {
                Delay -= Time.deltaTime;
            }

            if (Delay <= 0)
            {
                isFinish = true; // 延迟结束后标记为完成
                Delay = 0;
            }

            return this;
        }

        private LevelBehavior ReturnChild()
        {
            foreach (var child in children)
            {
                LevelBehavior l = child.OnFixedUpdate();
                if (l != null)
                {
                    // 如果子行为返回了非空的LevelBehavior，则继续执行
                    return l;
                }
            }

            return null;
        }

        public LevelBehavior SetLevelBehavior(LevelBehaviorType type)
        {
            this.type = type;
            return this;
        }

        public LevelBehavior SetDelay(float delay)
        {
            this.type = LevelBehaviorType.Delay;
            this.Delay = delay;
            return this;
        }

        public LevelBehavior AddChild(LevelBehavior child)
        {
            child.parent = this;
            children.Add(child);
            return this;
        }

        public LevelBehavior AddChild()
        {
            LevelBehavior child = new LevelBehavior();
            child.parent = this;
            children.Add(child);
            return child;
        }

        public LevelBehavior SetCondition(bool condition)
        {
            this.type = LevelBehaviorType.Condition;
            this.condition = condition;
            return this;
        }

        public LevelBehavior SetAction(Action action)
        {
            this.type = LevelBehaviorType.Action;
            this.action = action;
            return this;
        }
    }


    public enum LevelBehaviorType
    {
        Action,
        Delay,
        Condition
    }
}