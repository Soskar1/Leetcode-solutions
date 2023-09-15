//Problem: https://leetcode.com/problems/koko-eating-bananas/

import java.util.Arrays;

class Solution {
    public int minEatingSpeed(int[] piles, int h) {
        int min = 1;
        int max;
        int minSpeed = Integer.MAX_VALUE;

        Arrays.sort(piles);
        max = piles[piles.length - 1];

        while (min <= max) {
            int mid = min + ((max - min) / 2);

            int result = calculateHours(piles, mid);

            if (result > h) {
                min = mid + 1;
            } else {
                minSpeed = Integer.min(mid, minSpeed);

                max = mid - 1;
            }
        }

        return minSpeed;
    }

    private int calculateHours(int[] piles, int k) {
        int h = 0;

        for (int pile : piles) {
            h += Math.ceil(pile / (double) k);
        }

        return h;
    }
}