using System;
namespace TaLib
{
    public partial class Core
    {
        public static RetCode MaxIndex(int startIdx, int endIdx, double[] inReal, int optInTimePeriod, ref int outBegIdx, ref int outNBElement, int[] outInteger)
        {
            if (startIdx < 0) {
                return RetCode.OutOfRangeStartIndex;
            }
            if ((endIdx < 0) || (endIdx < startIdx)) {
                return RetCode.OutOfRangeEndIndex;
            }
            if (inReal == null) {
                return RetCode.BadParam;
            }
            if (optInTimePeriod == -2147483648) {
                optInTimePeriod = 30;
            }
            else if ((optInTimePeriod < 2) || (optInTimePeriod > 0x186a0)) {
                return RetCode.BadParam;
            }
            if (outInteger == null) {
                return RetCode.BadParam;
            }
            int nbInitialElementNeeded = optInTimePeriod - 1;
            if (startIdx < nbInitialElementNeeded) {
                startIdx = nbInitialElementNeeded;
            }
            if (startIdx > endIdx) {
                outBegIdx = 0;
                outNBElement = 0;
                return RetCode.Success;
            }
            int outIdx = 0;
            int today = startIdx;
            int trailingIdx = startIdx - nbInitialElementNeeded;
            int highestIdx = -1;
            double highest = 0.0;
        Label_008B:
            if (today > endIdx) {
                outBegIdx = startIdx;
                outNBElement = outIdx;
                return RetCode.Success;
            }
            double tmp = inReal[today];
            if (highestIdx < trailingIdx) {
                highestIdx = trailingIdx;
                highest = inReal[highestIdx];
                int i = highestIdx;
                while (true) {
                    i++;
                    if (i > today) {
                        goto Label_00CC;
                    }
                    tmp = inReal[i];
                    if (tmp > highest) {
                        highestIdx = i;
                        highest = tmp;
                    }
                }
            }
            if (tmp >= highest) {
                highestIdx = today;
                highest = tmp;
            }
        Label_00CC:
            outInteger[outIdx] = highestIdx;
            outIdx++;
            trailingIdx++;
            today++;
            goto Label_008B;
        }
        public static RetCode MaxIndex(int startIdx, int endIdx, float[] inReal, int optInTimePeriod, ref int outBegIdx, ref int outNBElement, int[] outInteger)
        {
            if (startIdx < 0) {
                return RetCode.OutOfRangeStartIndex;
            }
            if ((endIdx < 0) || (endIdx < startIdx)) {
                return RetCode.OutOfRangeEndIndex;
            }
            if (inReal == null) {
                return RetCode.BadParam;
            }
            if (optInTimePeriod == -2147483648) {
                optInTimePeriod = 30;
            }
            else if ((optInTimePeriod < 2) || (optInTimePeriod > 0x186a0)) {
                return RetCode.BadParam;
            }
            if (outInteger == null) {
                return RetCode.BadParam;
            }
            int nbInitialElementNeeded = optInTimePeriod - 1;
            if (startIdx < nbInitialElementNeeded) {
                startIdx = nbInitialElementNeeded;
            }
            if (startIdx > endIdx) {
                outBegIdx = 0;
                outNBElement = 0;
                return RetCode.Success;
            }
            int outIdx = 0;
            int today = startIdx;
            int trailingIdx = startIdx - nbInitialElementNeeded;
            int highestIdx = -1;
            double highest = 0.0;
        Label_008B:
            if (today > endIdx) {
                outBegIdx = startIdx;
                outNBElement = outIdx;
                return RetCode.Success;
            }
            double tmp = inReal[today];
            if (highestIdx < trailingIdx) {
                highestIdx = trailingIdx;
                highest = inReal[highestIdx];
                int i = highestIdx;
                while (true) {
                    i++;
                    if (i > today) {
                        goto Label_00CF;
                    }
                    tmp = inReal[i];
                    if (tmp > highest) {
                        highestIdx = i;
                        highest = tmp;
                    }
                }
            }
            if (tmp >= highest) {
                highestIdx = today;
                highest = tmp;
            }
        Label_00CF:
            outInteger[outIdx] = highestIdx;
            outIdx++;
            trailingIdx++;
            today++;
            goto Label_008B;
        }
        public static int MaxIndexLookback(int optInTimePeriod)
        {
            if (optInTimePeriod == -2147483648) {
                optInTimePeriod = 30;
            }
            else if ((optInTimePeriod < 2) || (optInTimePeriod > 0x186a0)) {
                return -1;
            }
            return (optInTimePeriod - 1);
        }
    }
}
