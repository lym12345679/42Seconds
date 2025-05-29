using System.Collections.Generic;
using UnityEngine;
using System;
using Game.Traps;
using MizukiTool.UIEffect;

namespace Game.Level
{

    public class LevelBehaviorTree : MonoBehaviour
    {
        protected float currentTime
        {
            get
            {
                if (LevelManager.Instance != null)
                    return LevelManager.Instance.CurrentTime;
                else
                    return 0f;
            }
        } // 当前时间
        public List<Spike> spikeList = new List<Spike>(); // 关卡中的对象列表
        // 关卡行为树的实现
        // 这里可以添加关卡行为树的逻辑和方法


        protected void Start()
        {
            // 初始化关卡行为树
            InitializeBehaviorTree();
        }
        protected void Update()
        {
            Action action = GetAction(); // 获取当前动作
            if (action != null)
            {
                action.Invoke(); // 执行当前动作
            }
        }
        protected virtual void InitializeBehaviorTree()
        {
            // 在这里设置关卡行为树的初始状态和节点
            Debug.Log("Level Behavior Tree Initialized");
        }

        protected virtual Action GetAction()
        {
            return null; // 获取当前动作
        }
        protected Action Condition(bool b, Func<Action> action)
        {
            // 条件逻辑
            if (b)
            {
                return action.Invoke(); // 如果条件为true，执行动作
            }
            return null; // 如果条件不满足，返回null
        }
        protected Action Selector(params Func<Action>[] conditions)
        {
            // 选择器逻辑
            foreach (var condition in conditions)
            {
                Action action = condition.Invoke(); // 执行每个条件
                if (action != null)
                {
                    return action; // 如果有满足条件的动作，返回该动作
                }

            }
            return null; // 如果没有满足条件的动作，返回null
        }
        protected Action SelectorInverse(params Func<Action>[] conditions)
        {
            // 反向选择器逻辑
            for (int i = conditions.Length - 1; i >= 0; i--)
            {
                Action action = conditions[i].Invoke(); // 执行每个条件
                if (action != null)
                {
                    return action; // 如果有满足条件的动作，返回该动作
                }
            }
            return null; // 如果没有满足条件的动作，返回null
        }

        // 可以添加更多的方法来处理关卡逻辑
    }
}
