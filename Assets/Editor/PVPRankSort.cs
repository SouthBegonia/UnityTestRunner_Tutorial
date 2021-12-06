using System.Collections.Generic;

/*
 * PVPRankSort 业务代码
 */

namespace Game.Tests
{
    public class PVPRankCell
    {
        public string Name;
        public int Score;
        public int RankInGlobal;
        public long PlatformID;
    }

    public class PVPRankSort
    {
        /// <summary>
        /// 目标测试方法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int PVPRankCellComparer_BySingleComparedParam(PVPRankCell a, PVPRankCell b)
        {
            //return -a.PlatformID.CompareTo(b.PlatformID); //错误
            return a.PlatformID.CompareTo(b.PlatformID);     //正确
        }


        /// <summary>
        /// 目标测试方法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int PVPRankCellComparer_ByMultiComparedParam(PVPRankCell a, PVPRankCell b)
        {
            if (a.Score != b.Score)
                return -a.Score.CompareTo(b.Score);

            if (a.RankInGlobal != b.RankInGlobal)
                return a.RankInGlobal.CompareTo(b.RankInGlobal);

            return -a.PlatformID.CompareTo(b.PlatformID); //错误
            //return a.PlatformID.CompareTo(b.PlatformID);     //正确
        }

        /// <summary>
        /// 生成测试用数据
        /// </summary>
        /// <returns></returns>
        public List<PVPRankCell> GenTestRankList()
        {
            List<PVPRankCell> testRankList = new List<PVPRankCell>
            {
                new PVPRankCell() {Name = "A", Score = 10, RankInGlobal = 3, PlatformID = 1001},
                new PVPRankCell() {Name = "B", Score = 10, RankInGlobal = 3, PlatformID = 1002},
                new PVPRankCell() {Name = "C", Score = 10, RankInGlobal = 3, PlatformID = 1002},    //隐患数据
                new PVPRankCell() {Name = "D", Score = 20, RankInGlobal = 1, PlatformID = 1003},
                new PVPRankCell() {Name = "E", Score = 30, RankInGlobal = 2, PlatformID = 1004},
            };
            return testRankList;
        }
    }
}
