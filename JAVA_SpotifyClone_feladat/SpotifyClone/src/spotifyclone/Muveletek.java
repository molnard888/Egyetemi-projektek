/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package spotifyclone;

import java.util.Scanner; 



  
class Muveletek 
{ 
    public static void main(String args[]) 
    { 
        // Using Scanner for Getting Input from User 
        Scanner in = new Scanner(System.in); 
  
        
        System.out.println("Lejátszó"); 
        System.out.println("Lejátszás tárolási sorrendben: 1");
        System.out.println("Lejátszás véletlenszerű sorrendben: 2");
        System.out.println("Előadók listázása névsor szerint: 3");
        System.out.println("Számok stílusainak listázása: 4");
        System.out.println("Előadó számainak lejátszása egymás után: 5");
         System.out.print("Adjon meg egy számot 1-tő 5-ig: ");
        System.out.println();
        
        int a = in.nextInt(); 
        switch (a) {
        case 1:
            System.out.println("Lejátszás tárolási sorrendben");
            for(int i=0;i<35;i++){
            System.out.println(spotifyclone.SpotifyClone.Ttomb[i].cim + ", " + spotifyclone.SpotifyClone.Ttomb[i].eloado + ", " + 
                    spotifyclone.SpotifyClone.Ttomb[i].stilus + ", " + spotifyclone.SpotifyClone.Ttomb[i].hossz);
            System.out.println("-----Lejátszva-----");
            }
            break;
        case 2:
            System.out.println("Lejátszás véletlenszerű sorrendben");
            break;
        case 3:
            System.out.println("Előadók listázása névsor szerint");
            break;
        case 4:
            System.out.println("Számok stílusainak listázása");
            break;
        case 5:
            System.out.println("Előadó számainak lejátszása egymás után");
            break;    
        default:
            System.out.println("Lejátszó /Válasszon műveletet!/"); 
                System.out.println("Lejátszás tárolási sorrendben: 1");
                System.out.println("Lejátszás véletlenszerű sorrendben: 2");
                System.out.println("Előadók listázása névsor szerint: 3");
                System.out.println("Számok stílusainak listázása: 4");
                System.out.println("Előadó számainak lejátszása egymás után: 5");
        }
    } 
} 