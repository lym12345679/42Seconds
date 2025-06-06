using System;
using UnityEngine;
using MizukiTool.RecyclePool;

namespace Game.Recycle
{
    public static class RecyclePool
    {
        private static bool isRigister = false;
        private static string path = "Prefabs/Recycle/";

        /// <summary>
        /// 在对象池中请求物体
        /// </summary>
        /// <param name="id">对象池枚举(可以是任何一个)</param>
        /// <param name="hander">对象处理方式</param>
        /// <param name="parent">设置父物体</param>
        /// <typeparam name="T">枚举</typeparam>
        public static void Request<T>(T id, Action<RecycleCollection> hander = null, Transform parent = null)
            where T : Enum
        {
            if (!isRigister)
            {
                isRigister = true;
                SetRigisterAction();
            }

            MizukiTool.RecyclePool.RecyclePoolUtil.Request(id, hander, parent);
        }


        /// <summary>
        /// 将从对象池请求的物体返回对象池
        /// </summary>
        /// <param name="go">需要回收的物体</param>
        public static void ReturnToPool(GameObject go)
            => MizukiTool.RecyclePool.RecyclePoolUtil.ReturnToPool(go);

        /// <summary>
        /// 在这里注册所有对象
        /// 参考格式:recyclePool.RigisterOnePrefab(TargetEnum, TargetPrefab);
        /// etc:recyclePool.RigisterOnePrefab(MyTestEnum.MyTestEnum1, Resources.Load<GameObject>("Prefab/Recycle/RecycleGO"));
        /// </summary>
        public static void SetRigisterAction()
        {
            Action<MizukiTool.RecyclePool.RecyclePool> action = (recyclePool) =>
            {
                recyclePool.RigisterOnePrefab(RecycleItemEnum.TextItem,
                    Resources.Load<GameObject>(path + "TextItem"));
                recyclePool.RigisterOnePrefab(RecycleItemEnum.Warn,
                    Resources.Load<GameObject>(path + "Warn"));
                recyclePool.RigisterOnePrefab(RecycleItemEnum.Spike1,
                    Resources.Load<GameObject>(path + "Spike1"));
                recyclePool.RigisterOnePrefab(RecycleItemEnum.Spike2,
                    Resources.Load<GameObject>(path + "Spike2"));
                recyclePool.RigisterOnePrefab(RecycleItemEnum.EmptyObj,
                    Resources.Load<GameObject>(path + "EmptyObj"));
                recyclePool.RigisterOnePrefab(RecycleItemEnum.Spike0,
                    Resources.Load<GameObject>(path + "Spike0"));
                recyclePool.RigisterOnePrefab(RecycleItemEnum.WeakWall,
                    Resources.Load<GameObject>(path + "WeakWall"));
                recyclePool.RigisterOnePrefab(RecycleItemEnum.GeneratingLaser,
                    Resources.Load<GameObject>(path + "GeneratingLaser"));
                recyclePool.RigisterOnePrefab(RecycleItemEnum.Laser1,
                    Resources.Load<GameObject>(path + "Laser1"));
                recyclePool.RigisterOnePrefab(RecycleItemEnum.GeneratingLaser1,
                    Resources.Load<GameObject>(path + "GeneratingLaser1"));
                recyclePool.RigisterOnePrefab(RecycleItemEnum.Laser2,
                    Resources.Load<GameObject>(path + "Laser2"));
                recyclePool.RigisterOnePrefab(RecycleItemEnum.Bread,
                    Resources.Load<GameObject>(path + "Bread"));
                recyclePool.RigisterOnePrefab(RecycleItemEnum.GuidedMissile,
                    Resources.Load<GameObject>(path + "GuidedMissile"));
                recyclePool.RigisterOnePrefab(RecycleItemEnum.Boom,
                    Resources.Load<GameObject>(path + "Boom"));
            };
            RecyclePoolUtil.SetRigisterAction(action);
        }
    }

    public enum RecycleItemEnum
    {
        TextItem,
        Warn,
        Spike1,
        Spike2,
        EmptyObj,
        Spike0,
        WeakWall,
        GeneratingLaser,
        GeneratingLaser1,
        Laser1,
        Laser2,
        Bread,
        GuidedMissile,
        Boom
    }
}