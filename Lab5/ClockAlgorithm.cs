using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    static class ClockAlgorithm
    {
        static List<Page> pages;
        static int currPage  = -1;

        static public void LoadPages(List<Page> pages)
        {
            pages.Sort((x, y) => x.inMemTime - y.inMemTime);
            var ps = pages.FindAll((x) => x.physical != -1);

            ClockAlgorithm.pages = ps;
            ClockAlgorithm.currPage = 0;
        }

        static public void AddPage(Page p) => pages.Insert(currPage, p);

        static public Page GetPageForDelete()
        {
            Page page = null;

            while (MoveNext())
            {
                page = pages[currPage];

                if (page.physical != -1)
                {
                    if (page.R == 0)
                        break;

                    if (page.R == 1)
                        page.R = 0;
                }
            }

            pages.Remove(page);

            return page;
        }

        static private bool MoveNext()
        {
            if (currPage >= pages.Count)
                Reset();

            currPage++;

            return true;
        }

        static private void Reset() => currPage = -1;
    }
}
