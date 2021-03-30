using System ;
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int maxLength = s.Length ;
        if(maxLength == 0) return 0;
        else if (maxLength == 1) return 1;
        char[] streak = new char[maxLength] ;
        for ( int i = 0 ; i < maxLength; i++)
        {   
            streak[i] = s[i];
            char[] cmp = new char[maxLength-streak.Length] ;
            for(int j = 0 ; j<maxLength -streak.Length ; j++)
            {
                
                cmp[j] = s[i+j+1];
                if(streak[streak.Length-1] == cmp[0])
            {
                streak = cmp ;
            }
            else if (streak.SequenceEqual(cmp))
            {
                streak = cmp ;
            }
            else
            {
                char[] z = new char[streak.Length + cmp.Length] ;
                streak.CopyTo(z, 0);
                cmp.CopyTo(z, streak.Length);
                streak = z ;
            }
            }
            
            
        } 
        
        return streak.Length ;
    }
}