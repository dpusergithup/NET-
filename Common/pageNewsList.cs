using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class pageNewsList
    {
        ///  <summary>
        ///  页的大小
        ///  </summary>
        ///  <param  name="pagesize">页大小</param>
        ///  <param  name="currentpage">当前页码</param>
        ///  <param  name="totalcount">一共有多少条</param>
        ///  <returns></returns>
        public static string showpagenavigate(int pagesize, int currentpage, int totalcount)
        {
            string redirectto = "";
            pagesize = pagesize == 0 ? 3 : pagesize;
            var totalpages = Math.Max((totalcount + pagesize - 1) / pagesize, 1);  //总页数
            var output = new StringBuilder();
            if (totalpages > 1)
            {
                if (currentpage != 1)
                {//处理首页连接
                    output.AppendFormat("<a  class='pagelink'  href='{0}?pageindex=1&pagesize={1}'>首页</a>  ", redirectto, pagesize);
                }
                if (currentpage > 1)
                {//处理上一页的连接
                    output.AppendFormat("<a  class='pagelink'  href='{0}?pageindex={1}&pagesize={2}'>上一页</a>  ", redirectto, currentpage - 1, pagesize);
                }
                else
                {
                    //  output.append("<span  class=''pagelink''>上一页</span>");
                }

                output.Append("  ");
                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {//一共最多显示10个页码，前面5个，后面5个
                    if ((currentpage + i - currint) >= 1 && (currentpage + i - currint) <= totalpages)
                    {
                        if (currint == i)
                        {//当前页处理
                         //output.append(string.format("[{0}]",  currentpage));
                            output.AppendFormat("<a  class='cpb'  href='{0}?pageindex={1}&pagesize={2}'>{3}</a>  ", redirectto, currentpage, pagesize, currentpage);
                        }
                        else
                        {//一般页处理
                            output.AppendFormat("<a  class='pagelink'  href='{0}?pageindex={1}&pagesize={2}'>{3}</a>  ", redirectto, currentpage + i - currint, pagesize, currentpage + i - currint);
                        }
                    }
                    output.Append("  ");
                }
                if (currentpage < totalpages)
                {//处理下一页的链接
                    output.AppendFormat("<a  class='pagelink'  href='{0}?pageindex={1}&pagesize={2}'>下一页</a>  ", redirectto, currentpage + 1, pagesize);
                }
                else
                {
                    //output.append("<span  class=''pagelink''>下一页</span>");
                }
                output.Append("  ");
                if (currentpage != totalpages)
                {
                    output.AppendFormat("<a  class='pagelink'  href='{0}?pageindex={1}&pagesize={2}'>末页</a>  ", redirectto, totalpages, pagesize);
                }
                output.Append("  ");
            }
            output.AppendFormat("第{0}页  /  共{1}页", currentpage, totalpages);//这个统计加不加都行
            return output.ToString();
        }
    }
}
