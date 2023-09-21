//Problem: https://leetcode.com/problems/time-based-key-value-store/

import java.util.ArrayList;
import java.util.Comparator;
import java.util.Hashtable;

class TimeMap {
    class TimeStamp {
        int time;
        String value;

        public TimeStamp(int time, String value) {
            this.time = time;
            this.value = value;
        }

        public int getTime() {
            return time;
        }
    }

    private final Hashtable<String, ArrayList<TimeStamp>> TIME_MAP;

    public TimeMap() {
        TIME_MAP = new Hashtable<>();
    }

    public void set(String key, String value, int timestamp) {
        TimeStamp newTimeStamp = new TimeStamp(timestamp, value);

        if (TIME_MAP.containsKey(key)) {
            ArrayList<TimeStamp> list = TIME_MAP.get(key);
            list.add(newTimeStamp);
        } else {
            ArrayList<TimeStamp> list = new ArrayList<>();
            list.add(newTimeStamp);
            list.sort(Comparator.comparing(TimeStamp::getTime));
            TIME_MAP.put(key, list);
        }
    }

    public String get(String key, int timestamp) {
        if (TIME_MAP.containsKey(key)) {
            ArrayList<TimeStamp> list = TIME_MAP.get(key);
            int index = search(list, 0, list.size() - 1, timestamp);

            if (index != -1) {
                return list.get(index).value;
            }
        }

        return "";
    }

    private int search(ArrayList<TimeStamp> list, int start, int end, int timestamp) {
        if (start >= end) {
            if (list.get(start).time > timestamp) {
                return start - 1;
            }

            return start;
        }

        int mid = start + (end - start) / 2;
        TimeStamp midValue = list.get(mid);

        if (midValue.time == timestamp) {
            return mid;
        }

        if (midValue.time > timestamp) {
            return search(list, start, mid - 1, timestamp);
        }

        return search(list, mid + 1, end, timestamp);
    }
}