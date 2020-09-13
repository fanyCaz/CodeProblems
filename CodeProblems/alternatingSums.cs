using System;
using System.Linq;
using System.Collections.Generic;

public class Alternating{
    public static void Main(string[] args){
        var res = alternatingSums( new int[] {50,60,60,45,70} );
        foreach(int i in res){
            Console.WriteLine(i);
        }
    }

    static int[] alternatingSums(int[] a){
        int team1 = 0,team2=0;
        for(int i = 0; i< a.Length; i++){
            if(i%2 == 0){
                team1 += a[i];
            }
            else{
                team2 += a[i];
            }
        }
        return new int[] {team1,team2};
        
    }
}