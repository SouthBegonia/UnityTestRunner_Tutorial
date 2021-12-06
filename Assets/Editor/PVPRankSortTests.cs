using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

/*
 * PVPRankSort 测试代码
 */

namespace Game.Tests
{
    public class PVPRankSortTests
    {
        PVPRankSort PvpRankSort;

        [SetUp]
        public void SetUp()
        {
            //最先执行的方法，作为多测试方法的功能部分
            PvpRankSort = new PVPRankSort();
        }

        [TearDown]
        public void TearDowm()
        {
            //最后执行的方法，用于清除或回收公共资源
            PvpRankSort = null;
        }

        // 单一比较参数排序算法的测试
        [Test]
        public void PVPRankSort_SingleComparedParam()
        {
            // Arrange：安排对象，根据需要对其进行创建和设置
            //        如构造测试用数据
            List<PVPRankCell> testRankList = PvpRankSort.GenTestRankList();

            // Act：作用于对象
            //        如具体算法实现
            testRankList.Sort(PVPRankSort.PVPRankCellComparer_BySingleComparedParam);

            // Assert：断言某些项按预期进行
            //        如结果校验：PlatformID升序
            for (int index = 0; index + 1 < testRankList.Count; ++index)
            {
                if (testRankList[index].PlatformID != testRankList[index + 1].PlatformID)
                    Assert.Less(testRankList[index].PlatformID, testRankList[index + 1].PlatformID); //PlatformID升序
                else
                    Debug.LogWarning($"Warning>>>>>  {testRankList[index].Name} 的排序参数和 {testRankList[index + 1].Name} 一致"); //隐患情况
            }
        }

        // 多比较参数排序算法的测试
        [Test]
        public void PVPRankSort_MultiComparedParam()
        {
            // Arrange：安排对象，根据需要对其进行创建和设置
            //        如构造测试用数据
            List<PVPRankCell> testRankList = PvpRankSort.GenTestRankList();

            // Act：作用于对象
            //        如具体算法实现
            testRankList.Sort(PvpRankSort.PVPRankCellComparer_ByMultiComparedParam);

            // Assert：断言某些项按预期进行
            //        如结果校验：分数降序->名次升序->PlatformID升序
            for (int index = 0; index + 1 < testRankList.Count; ++index)
            {
                if (testRankList[index].Score != testRankList[index + 1].Score)
                    Assert.Greater(testRankList[index].Score, testRankList[index + 1].Score); //分数降序
                else if (testRankList[index].RankInGlobal != testRankList[index + 1].RankInGlobal)
                    Assert.Less(testRankList[index].RankInGlobal, testRankList[index + 1].RankInGlobal); //排名升序
                else if (testRankList[index].PlatformID != testRankList[index + 1].PlatformID)
                    Assert.Less(testRankList[index].PlatformID, testRankList[index + 1].PlatformID); //PlatformID升序
                else
                    Debug.LogWarning($"Warning>>>>>  {testRankList[index].Name} 的排序参数和 {testRankList[index + 1].Name} 一致"); //隐患情况
            }
        }
    }
}
