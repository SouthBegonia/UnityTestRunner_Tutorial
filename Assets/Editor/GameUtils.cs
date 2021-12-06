using System.Text;

/*
 * GameUtils 业务代码
 */

namespace Game.Tests
{
    public class GameUtils
    {
        /// <summary>
        /// 获取字符串长度
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetTextLength(string str)
        {
            // 错误：缺判空
            // if (string.IsNullOrEmpty(str))
            // {
            //     return 0;
            // }

            int len = 0;
            for (int i = 0; i < str.Length; i++)
            {
                byte[] byte_len = Encoding.UTF8.GetBytes(str.Substring(i, 1));
                if (byte_len.Length > 1)
                    len += 2;
                else
                    len += 1;
            }

            return len;
        }
    }
}
