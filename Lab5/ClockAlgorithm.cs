using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class ClockAlgorithm
    {
        List<Page> pages;
        int currPage;
        public int CurrPage 
        {
            get => currPage;
            private set
            {
                if (value >= pages.Count)
                    currPage = 0;
                else
                    currPage = value;
            }
        }

        public ClockAlgorithm(List<Page> pages)
        {
            var q = from item in pages
                    where item.physical != -1
                    orderby item.inMemTime descending
                    select item;

            this.pages = q.ToList();
            currPage = 0;
        }

        public Page GetPageForDelete()
        {
            Page page;

            while (true)
            {
                page = MoveNext();

                if (page.physical != -1)
                {
                    if (page.R == 0)
                    {
                        break;
                    }
                    if (page.R == 1)
                    {
                        page.R = 0;
                    }
                }
            }

            return page;
        }

        private Page MoveNext() => pages[CurrPage++];
    }
}
