using System;

namespace Greenfield.Web.Core
{
    public class CyclomaticComplexity
    {
        public int One(int left, int right)
        {
            int value = left + right;

            return value;
        }

        public int Two(int left, int right)
        {
            int value;

            if (left > right)
            {
                value = left + right;
            }
            else
            {
                value = right - left;
            }

            return value;
        }

        public int Three(int left, int right)
        {
            int value;

            if (left < right)
            {
                if (left < 0)
                {
                    value = 0;
                }
                else
                {
                    value = left + right;
                }
            }
            else
            {
                value = right - left;
            }

            return value;
        }

        public int Four(int left, int right)
        {
            int value;

            if (left > right)
            {
                value = left + right;
            }
            else
            {
                value = right - left;
            }

            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
            {
                value = -value;
            }

            return value;
        }
    }
}
